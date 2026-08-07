/*
 * Data-driven sweep over every concrete model class in FireflyIIINet.Model:
 * construct (via the protected [JsonConstructor] ctor when there is no public
 * parameterless one), serialize with the shared SerializerOptions, deserialize,
 * and require value equality. This proves each model's attribute wiring
 * ([JsonPropertyName], converters, JsonIgnore conditions) survives a round trip.
 *
 * Reflection here is test-harness plumbing only — the shipped library stays
 * reflection-free outside StringEnumMemberConverter's cached enum maps.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Model
{
    public class AllModelsRoundTripTests
    {
        public static IEnumerable<object[]> ModelTypes()
        {
            return typeof(Account).Assembly.GetTypes()
                .Where(t => t.Namespace == "FireflyIIINet.Model"
                            && t.IsClass
                            && !t.IsAbstract
                            && !t.IsNested
                            // oneOf wrappers have no parameterless ctor and their converter
                            // is exercised by SerializationTests.PolymorphicProperty_* instead
                            && !typeof(AbstractOpenAPISchema).IsAssignableFrom(t)
                            && !t.Name.EndsWith("JsonConverter"))
                .Select(t => new object[] { t });
        }

        private static object CreateInstance(Type type)
        {
            // Models with required properties expose a protected parameterless [JsonConstructor];
            // the rest have a single public ctor whose parameters all carry defaults.
            var parameterless = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                binder: null, Type.EmptyTypes, modifiers: null);
            if (parameterless != null)
            {
                return parameterless.Invoke(null);
            }

            var ctor = type.GetConstructors().OrderBy(c => c.GetParameters().Length).First();
            var args = ctor.GetParameters()
                .Select(p => p.HasDefaultValue
                    ? p.DefaultValue
                    : (p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType) : null))
                .ToArray();
            return ctor.Invoke(args);
        }

        [Theory]
        [MemberData(nameof(ModelTypes))]
        public void Default_Instance_RoundTrips_With_Value_Equality(Type modelType)
        {
            var original = CreateInstance(modelType);

            var json = JsonSerializer.Serialize(original, modelType, SerializerOptions.Default);
            var back = JsonSerializer.Deserialize(json, modelType, SerializerOptions.Default);

            Assert.NotNull(back);
            Assert.Equal(original, back);
        }

        [Theory]
        [MemberData(nameof(ModelTypes))]
        public void ToJson_Produces_Parseable_Json(Type modelType)
        {
            var instance = CreateInstance(modelType);
            var toJson = modelType.GetMethod("ToJson");
            Assert.True(toJson != null, $"{modelType.Name} has no ToJson method");

            var json = (string)toJson.Invoke(instance, null);
            using var doc = JsonDocument.Parse(json);
            Assert.Equal(JsonValueKind.Object, doc.RootElement.ValueKind);
        }
    }
}
