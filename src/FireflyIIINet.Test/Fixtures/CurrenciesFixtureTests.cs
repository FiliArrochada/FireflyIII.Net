/*
 * Fixture tests for the Currencies area, fed by the example payloads from the
 * Firefly III OpenAPI spec (api/firefly-iii-6.2.2-v1.yaml, Currency schema:
 * code "AMS", name "Ankh-Morpork dollar", symbol "AM$").
 *
 * Note: created_at/updated_at map onto private-setter properties and are present in
 * the payloads only to prove they deserialize without error; assertions target the
 * publicly settable properties.
 */

using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class CurrenciesFixtureTests
    {
        [Fact]
        public void CurrencySingle_Deserializes_Spec_Example()
        {
            const string json = """
            {
              "data": {
                "type": "currencies",
                "id": "12",
                "attributes": {
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "enabled": true,
                  "default": false,
                  "code": "AMS",
                  "name": "Ankh-Morpork dollar",
                  "symbol": "AM$",
                  "decimal_places": 2
                }
              }
            }
            """;

            var single = JsonSerializer.Deserialize<CurrencySingle>(json, SerializerOptions.Default);

            Assert.Equal("currencies", single.Data.Type);
            Assert.Equal("12", single.Data.Id);

            var currency = single.Data.Attributes;
            Assert.Equal("AMS", currency.Code);
            Assert.Equal("Ankh-Morpork dollar", currency.Name);
            Assert.Equal("AM$", currency.Symbol);
            Assert.Equal(2, currency.DecimalPlaces);
            Assert.True(currency.Enabled);
            // wire name "default" maps onto the VarDefault property
            Assert.False(currency.VarDefault);
        }

        [Fact]
        public void CurrencyArray_Deserializes_With_Meta_Pagination()
        {
            const string json = """
            {
              "data": [
                {
                  "type": "currencies",
                  "id": "1",
                  "attributes": {
                    "created_at": "2018-09-17T12:46:47+01:00",
                    "updated_at": "2018-09-17T12:46:47+01:00",
                    "enabled": true,
                    "default": true,
                    "code": "EUR",
                    "name": "Euro",
                    "symbol": "€",
                    "decimal_places": 2
                  }
                },
                {
                  "type": "currencies",
                  "id": "12",
                  "attributes": {
                    "created_at": "2018-09-17T12:46:47+01:00",
                    "updated_at": "2018-09-17T12:46:47+01:00",
                    "enabled": true,
                    "default": false,
                    "code": "AMS",
                    "name": "Ankh-Morpork dollar",
                    "symbol": "AM$",
                    "decimal_places": 2
                  }
                }
              ],
              "meta": {
                "pagination": {
                  "total": 2,
                  "count": 2,
                  "per_page": 50,
                  "current_page": 1,
                  "total_pages": 1
                }
              },
              "links": {
                "self": "https://demo.firefly-iii.org/api/v1/currencies?page=1",
                "first": "https://demo.firefly-iii.org/api/v1/currencies?page=1",
                "last": "https://demo.firefly-iii.org/api/v1/currencies?page=1"
              }
            }
            """;

            var array = JsonSerializer.Deserialize<CurrencyArray>(json, SerializerOptions.Default);

            Assert.Equal(2, array.Data.Count);
            Assert.Equal("1", array.Data[0].Id);
            Assert.Equal("EUR", array.Data[0].Attributes.Code);
            Assert.True(array.Data[0].Attributes.VarDefault);
            Assert.Equal("Ankh-Morpork dollar", array.Data[1].Attributes.Name);

            Assert.Equal(2, array.Meta.Pagination.Total);
            Assert.Equal(50, array.Meta.Pagination.PerPage);
            Assert.Equal(1, array.Meta.Pagination.CurrentPage);
            Assert.Equal(1, array.Meta.Pagination.TotalPages);
        }
    }
}
