/*
 * Firefly III API
 *
 * Explicit nulls on request models: a field left unset is not sent (the server keeps what it
 * has), and a field marked with Clear is sent as null (the server removes what it has).
 */

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace FireflyIIINet.Client
{
    /// <summary>
    /// Sends a request model's field as an explicit <c>null</c>, which is how the server is told to
    /// remove a stored value: a piggy bank's target date, a recurrence's end date, a tag's
    /// location. An update otherwise leaves out every field that is null, and the server then
    /// keeps the value it has.
    /// </summary>
    /// <example>
    /// <code>
    /// var update = new PiggyBankUpdate(name: "Holiday").Clear(u => u.TargetDate).Clear(u => u.TargetAmount);
    /// </code>
    /// </example>
    public static class ClearedFields
    {
        private static readonly ConditionalWeakTable<object, HashSet<string>> Cleared = new ConditionalWeakTable<object, HashSet<string>>();

        /// <summary>
        /// Sets <paramref name="property"/> to null and sends it as <c>null</c>, so the server
        /// removes the stored value. Assigning the property a value afterwards sends that value.
        /// </summary>
        /// <exception cref="ArgumentException">The expression is not a nullable property of the model.</exception>
        public static T Clear<T, TValue>(this T request, Expression<Func<T, TValue>> property) where T : class
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (property == null) throw new ArgumentNullException(nameof(property));
            var body = property.Body is UnaryExpression { NodeType: ExpressionType.Convert } convert ? convert.Operand : property.Body;
            if (!(body is MemberExpression { Member: PropertyInfo info } member) || member.Expression != property.Parameters[0] || info.SetMethod == null)
            {
                throw new ArgumentException("Pass a settable property of the model itself, as in u => u.TargetDate.", nameof(property));
            }

            if (info.PropertyType.IsValueType && Nullable.GetUnderlyingType(info.PropertyType) == null)
            {
                throw new ArgumentException($"{typeof(T).Name}.{info.Name} is a {info.PropertyType.Name}, which cannot be null.", nameof(property));
            }

            info.SetValue(request, null);
            Cleared.GetOrCreateValue(request).Add(info.Name);
            return request;
        }

        /// <summary>Whether <see cref="Clear"/> marked the property of this request.</summary>
        public static bool IsCleared(object request, string propertyName) =>
            request != null && Cleared.TryGetValue(request, out var names) && names.Contains(propertyName);

        /// <summary>
        /// The <see cref="DefaultJsonTypeInfoResolver"/> modifier behind <see cref="SerializerOptions"/>:
        /// a property its <see cref="JsonIgnoreAttribute"/> would leave out is written as <c>null</c>
        /// when <see cref="Clear"/> marked it, and left out as before otherwise.
        /// </summary>
        internal static void Apply(JsonTypeInfo typeInfo)
        {
            if (typeInfo.Kind != JsonTypeInfoKind.Object || typeInfo.Type.Namespace != "FireflyIIINet.Model") return;

            foreach (var property in typeInfo.Properties)
            {
                if (!(property.AttributeProvider is PropertyInfo info) || !info.CanWrite) continue;
                var condition = info.GetCustomAttribute<JsonIgnoreAttribute>()?.Condition;
                if (condition != JsonIgnoreCondition.WhenWritingNull && condition != JsonIgnoreCondition.WhenWritingDefault) continue;

                var name = info.Name;
                var empty = property.PropertyType.IsValueType && Nullable.GetUnderlyingType(property.PropertyType) == null
                    ? Activator.CreateInstance(property.PropertyType)
                    : null;
                var leftOut = condition == JsonIgnoreCondition.WhenWritingNull
                    ? (Func<object, bool>)(value => value == null)
                    : value => value == null || Equals(value, empty);
                property.ShouldSerialize = (owner, value) => !leftOut(value) || IsCleared(owner, name);
            }
        }
    }
}
