/*
 * Fixture tests: deserialization of realistic CategoryProperties payloads built from the
 * example values in the pinned v1 spec in api/ (CategoryProperties / CategorySpent /
 * CategoryEarned schemas).
 *
 * Notes:
 *  - CategoryProperties has no enum and no publicly-settable date-time property; created_at
 *    and updated_at are generated read-only (private setters).
 *  - The spent/earned lists are generated read-only (`private set`) and carry
 *    [JsonInclude] so System.Text.Json populates them on deserialization, matching
 *    the previous Newtonsoft behaviour. A dedicated test asserts the values.
 */

using System;
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
              "color": "FF0000",
              "last_activity": "2026-10-01T00:00:00+00:00",
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
        public void Category_Color_And_LastActivity_Deserialize()
        {
            // 6.7.8: color (free for apps to use) and last_activity; both may be absent.
            var single = JsonSerializer.Deserialize<CategorySingle>(CategorySingleJson, SerializerOptions.Default);
            var array = JsonSerializer.Deserialize<CategoryArray>(CategoryArrayJson, SerializerOptions.Default);

            Assert.Equal("FF0000", single.Data.Attributes.Color);
            Assert.Equal(new DateTimeOffset(2026, 10, 1, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(single.Data.Attributes.LastActivity.Value.ToUniversalTime()));
            Assert.Null(array.Data[0].Attributes.Color);
            Assert.Null(array.Data[0].Attributes.LastActivity);
        }

        [Fact]
        public void CategoryStore_And_Update_Send_Color_Only_When_Set()
        {
            var withColor = JsonSerializer.Serialize(new CategoryStore("Lunch", color: "00FF00"), SerializerOptions.Default);
            var without = JsonSerializer.Serialize(new CategoryUpdate("Lunch"), SerializerOptions.Default);

            Assert.Contains("\"color\":\"00FF00\"", withColor);
            Assert.DoesNotContain("color", without);
        }

        [Fact]
        public void CategoryUpdate_Notes_And_Color_Are_Three_State()
        {
            // Verified on the live server: an omitted key keeps the stored value, an explicit
            // null clears it.
            var untouched = new CategoryUpdate("Lunch", notes: null, color: null);
            var cleared = new CategoryUpdate("Lunch") { Notes = null, Color = null };
            var set = new CategoryUpdate("Lunch", notes: "n", color: "FF0000");

            Assert.Equal("{\"name\":\"Lunch\"}", JsonSerializer.Serialize(untouched, SerializerOptions.Default));
            Assert.Equal("{\"name\":\"Lunch\",\"notes\":null,\"color\":null}", JsonSerializer.Serialize(cleared, SerializerOptions.Default));
            Assert.Equal("{\"name\":\"Lunch\",\"notes\":\"n\",\"color\":\"FF0000\"}", JsonSerializer.Serialize(set, SerializerOptions.Default));
        }

        [Fact]
        public void CategoryUpdate_Round_Trips_Each_State()
        {
            foreach (var json in new[]
            {
                "{\"name\":\"Lunch\"}",
                "{\"name\":\"Lunch\",\"notes\":null,\"color\":null}",
                "{\"name\":\"Lunch\",\"notes\":\"n\",\"color\":\"FF0000\"}",
            })
            {
                var update = JsonSerializer.Deserialize<CategoryUpdate>(json, SerializerOptions.Default);
                Assert.Equal(json, JsonSerializer.Serialize(update, SerializerOptions.Default));
            }
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
