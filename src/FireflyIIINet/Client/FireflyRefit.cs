/*
 * Firefly III API v2.0.12
 *
 * Refit glue: URL parameter formatting quirks of the Firefly III API and the
 * RefitSettings factory wiring them together with the shared STJ options.
 */

using System;
using System.Globalization;
using System.Reflection;
using Refit;

namespace FireflyIIINet.Client
{
    /// <summary>
    /// URL parameter formatter for the Firefly III API: booleans are emitted lowercase
    /// (<c>true</c>/<c>false</c>) as expected by Laravel's validator; everything else
    /// (including enums via their <c>[EnumMember]</c> values and <c>[Query(Format = ...)]</c>
    /// dates) uses Refit's default behaviour.
    /// </summary>
    public class FireflyUrlParameterFormatter : DefaultUrlParameterFormatter
    {
        /// <inheritdoc />
        public override string Format(object parameterValue, ICustomAttributeProvider attributeProvider, Type type)
        {
            if (parameterValue is bool b)
            {
                return b ? "true" : "false";
            }
            return base.Format(parameterValue, attributeProvider, type);
        }
    }

    /// <summary>
    /// Builds the <see cref="RefitSettings"/> needed to create Firefly III Refit clients:
    /// System.Text.Json serialization via <see cref="SerializerOptions.Default"/> and
    /// <see cref="FireflyUrlParameterFormatter"/> for query strings.
    /// </summary>
    public static class FireflyRefitSettings
    {
        /// <summary>
        /// Creates a new <see cref="RefitSettings"/> instance configured for the Firefly III API.
        /// </summary>
        public static RefitSettings Create()
        {
            return new RefitSettings(new SystemTextJsonContentSerializer(SerializerOptions.Default))
            {
                UrlParameterFormatter = new FireflyUrlParameterFormatter()
            };
        }
    }
}
