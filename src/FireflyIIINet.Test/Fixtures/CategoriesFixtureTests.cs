/*
 * Fixture tests: deserialization of realistic CategoryProperties payloads built from the
 * example values in api/firefly-iii-6.4.2-v1.yaml (CategoryProperties / CategorySpent /
 * CategoryEarned schemas).
 *
 * Notes:
 *  - CategoryProperties has no enum and no publicly-settable date-time property; created_at
 *    and updated_at are generated read-only (private setters).
 *  - The spent/earned lists are generated read-only (`private set`) and carry
 *    [JsonInclude] so System.Text.Json populates them on deserialization, matching
 *    the previous Newtonsoft behaviour. A dedicated test asserts the values.
 */

using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class CategoriesFixtureTests
    {
        private const string CategorySingleJson = """
        {
          "data": {
            "type": "categories",
            "id": "2",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "name": "Lunch",
              "notes": "Some example notes",
              "spent": [
                {
                  "currency_id": "5",
                  "currency_code": "USD",
                  "currency_symbol": "$",
                  "currency_decimal_places": 2,
                  "sum": "-12423.45"
                }
              ],
              "earned": [
                {
                  "currency_id": "5",
                  "currency_code": "USD",
                  "currency_symbol": "$",
                  "currency_decimal_places": 2,
                  "sum": "123.45"
                }
              ]
            }
          }
        }
        """;

        private const string CategoryArrayJson = """
        {
          "data": [
            {
              "type": "categories",
              "id": "2",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "name": "Lunch",
                "notes": "Some example notes",
                "spent": [],
                "earned": []
              }
            },
            {
              "type": "categories",
              "id": "7",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "name": "Groceries",
                "notes": null,
                "spent": [],
                "earned": []
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
          }
        }
        """;

        [Fact]
        public void CategorySingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<CategorySingle>(CategorySingleJson, SerializerOptions.Default);

            Assert.NotNull(single);
            Assert.Equal("categories", single.Data.Type);
            Assert.Equal("2", single.Data.Id);
            Assert.Equal("Lunch", single.Data.Attributes.Name);
            Assert.Equal("Some example notes", single.Data.Attributes.Notes);
        }

        [Fact]
        public void Category_Spent_And_Earned_ReadOnly_Lists_Are_Populated()
        {
            // Spent/Earned have private setters + [JsonInclude]: server-computed
            // read-only fields must survive deserialization (Newtonsoft parity).
            var single = JsonSerializer.Deserialize<CategorySingle>(CategorySingleJson, SerializerOptions.Default);

            var spent = Assert.Single(single.Data.Attributes.Spent);
            Assert.Equal("USD", spent.CurrencyCode);
            Assert.Equal("-12423.45", spent.Sum);

            var earned = Assert.Single(single.Data.Attributes.Earned);
            Assert.Equal("123.45", earned.Sum);
        }

        [Fact]
        public void CategoryArray_Deserializes_Spec_Example()
        {
            var array = JsonSerializer.Deserialize<CategoryArray>(CategoryArrayJson, SerializerOptions.Default);

            Assert.NotNull(array);
            Assert.Equal(2, array.Data.Count);
            Assert.Equal("2", array.Data[0].Id);
            Assert.Equal("Lunch", array.Data[0].Attributes.Name);
            Assert.Equal("Groceries", array.Data[1].Attributes.Name);
            Assert.Null(array.Data[1].Attributes.Notes); // explicit null deserializes without error

            Assert.Equal(2, array.Meta.Pagination.Total);
            Assert.Equal(50, array.Meta.Pagination.PerPage);
        }
    }
}
