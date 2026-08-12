/*
 * Fixture tests for the Preferences area, fed by the example payloads from the
 * Firefly III OpenAPI spec (api/firefly-iii-6.2.7-v1.yaml, Preference schema).
 *
 * The "data" attribute is the PolymorphicProperty oneOf (bool | string | object |
 * string[]); these fixtures exercise the string and string-array branches through
 * the full Single envelope, plus the bool branch on the bare model.
 *
 * Note: created_at/updated_at map onto private-setter properties and are present in
 * the payloads only to prove they deserialize without error.
 */

using System.Collections.Generic;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class PreferencesFixtureTests
    {
        [Fact]
        public void PreferenceSingle_With_String_Data_Deserializes_Spec_Example()
        {
            const string json = """
            {
              "data": {
                "type": "preferences",
                "id": "1",
                "attributes": {
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "name": "currencyPreference",
                  "data": "EUR"
                }
              }
            }
            """;

            var single = JsonSerializer.Deserialize<PreferenceSingle>(json, SerializerOptions.Default);

            Assert.Equal("preferences", single.Data.Type);
            Assert.Equal("1", single.Data.Id);

            var preference = single.Data.Attributes;
            Assert.Equal("currencyPreference", preference.Name);
            Assert.IsType<string>(preference.Data.ActualInstance);
            Assert.Equal("EUR", preference.Data.GetString());
        }

        [Fact]
        public void PreferenceSingle_With_StringArray_Data_Deserializes()
        {
            const string json = """
            {
              "data": {
                "type": "preferences",
                "id": "2",
                "attributes": {
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "name": "frontpageAccounts",
                  "data": ["1", "2", "3"]
                }
              }
            }
            """;

            var single = JsonSerializer.Deserialize<PreferenceSingle>(json, SerializerOptions.Default);

            Assert.Equal("2", single.Data.Id);
            Assert.Equal("frontpageAccounts", single.Data.Attributes.Name);
            Assert.Equal(new List<string> { "1", "2", "3" }, single.Data.Attributes.Data.GetListString());
        }

        [Fact]
        public void Preference_With_Bool_Data_Deserializes()
        {
            const string json = """
            {
              "name": "darkMode",
              "data": true
            }
            """;

            var preference = JsonSerializer.Deserialize<Preference>(json, SerializerOptions.Default);

            Assert.Equal("darkMode", preference.Name);
            Assert.True(preference.Data.GetBool());
        }
    }
}
