/*
 * Data-driven sweep over every enum in FireflyIIINet.Model (top-level and nested in models):
 * each member must serialize to its [EnumMember] wire value and deserialize back to the
 * same member through the shared SerializerOptions. This locks the wire contract for the
 * whole enum surface without a hand-written test per enum.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using FireflyIIINet.Client;
using Xunit;

namespace FireflyIIINet.Test.Model
{
    public class AllEnumsRoundTripTests
    {
        public static IEnumerable<object[]> EnumTypes()
        {
            var assembly = typeof(FireflyIIINet.Model.Account).Assembly;
            var top = assembly.GetTypes()
                .Where(t => t.IsEnum && t.Namespace == "FireflyIIINet.Model");
            var nested = assembly.GetTypes()
                .Where(t => t.Namespace == "FireflyIIINet.Model" && t.IsClass)
                .SelectMany(t => t.GetNestedTypes())
                .Where(t => t.IsEnum);
            return top.Concat(nested).Distinct().Select(t => new object[] { t });
        }

        [Theory]
        [MemberData(nameof(EnumTypes))]
        public void Every_Member_RoundTrips_Via_EnumMember_Value(Type enumType)
        {
            Assert.NotEmpty(Enum.GetNames(enumType));

            foreach (var name in Enum.GetNames(enumType))
            {
                var member = Enum.Parse(enumType, name);
                var expectedWire = enumType.GetField(name)
                    .GetCustomAttribute<EnumMemberAttribute>()?.Value ?? name;

                var json = JsonSerializer.Serialize(member, enumType, SerializerOptions.Default);
                Assert.Equal("\"" + expectedWire + "\"", json);

                var back = JsonSerializer.Deserialize(json, enumType, SerializerOptions.Default);
                Assert.Equal(member, back);
            }
        }
    }
}
