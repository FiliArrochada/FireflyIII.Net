/*
 * Fixture tests built from the Firefly III OpenAPI spec examples (firefly-iii-2.0.10-v1.yaml),
 * asserting the wire format maps onto the generated models.
 *
 * Note: properties the spec marks readOnly (created_at, currency_symbol, next_expected_match,
 * pay_dates, paid_dates, ...) are generated with private setters and are therefore NOT populated
 * by System.Text.Json deserialization. They are kept in the payloads to prove the shapes parse
 * without error, but their values are not asserted.
 */

using System;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class BillsFixtureTests
    {
        private const string BillSingleJson = """
        {
          "data": {
            "type": "bills",
            "id": "2",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "currency_id": "5",
              "currency_code": "EUR",
              "currency_symbol": "$",
              "currency_decimal_places": 2,
              "name": "Rent",
              "amount_min": "123.45",
              "amount_max": "123.45",
              "date": "2018-09-17T12:46:47+01:00",
              "end_date": "2019-09-17T12:46:47+01:00",
              "extension_date": "2019-08-17T12:46:47+01:00",
              "repeat_freq": "monthly",
              "skip": 0,
              "active": true,
              "order": 1,
              "notes": "Some example notes",
              "next_expected_match": "2018-10-17T12:46:47+01:00",
              "next_expected_match_diff": "today",
              "object_group_id": "5",
              "object_group_order": 5,
              "object_group_title": "Example Group",
              "pay_dates": [
                "2018-10-17T12:46:47+01:00",
                "2018-11-17T12:46:47+01:00"
              ],
              "paid_dates": [
                {
                  "transaction_group_id": "123",
                  "transaction_journal_id": "123",
                  "date": "2018-09-17T12:46:47+01:00"
                }
              ]
            }
          }
        }
        """;

        private const string BillSingleHalfYearJson = """
        {
          "data": {
            "type": "bills",
            "id": "7",
            "attributes": {
              "currency_id": "5",
              "currency_code": "EUR",
              "name": "Gym membership",
              "amount_min": "25.00",
              "amount_max": "25.00",
              "date": "2023-01-01T00:00:00Z",
              "repeat_freq": "half-year",
              "skip": 0,
              "active": true,
              "order": 2,
              "notes": null,
              "next_expected_match": null,
              "next_expected_match_diff": null,
              "object_group_id": null,
              "object_group_order": null,
              "object_group_title": null
            }
          }
        }
        """;

        private const string BillArrayJson = """
        {
          "data": [
            {
              "type": "bills",
              "id": "1",
              "attributes": {
                "currency_id": "5",
                "currency_code": "EUR",
                "name": "Rent",
                "amount_min": "123.45",
                "amount_max": "123.45",
                "date": "2018-09-17T12:46:47+01:00",
                "repeat_freq": "monthly",
                "skip": 0,
                "active": true,
                "order": 1
              }
            },
            {
              "type": "bills",
              "id": "2",
              "attributes": {
                "currency_id": "5",
                "currency_code": "EUR",
                "name": "Health insurance",
                "amount_min": "98.10",
                "amount_max": "105.30",
                "date": "2018-09-01T00:00:00+01:00",
                "repeat_freq": "yearly",
                "skip": 0,
                "active": false,
                "order": 2
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
        public void BillSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<BillSingle>(BillSingleJson, SerializerOptions.Default);

            Assert.NotNull(single);
            Assert.Equal("bills", single.Data.Type);
            Assert.Equal("2", single.Data.Id);

            var bill = single.Data.Attributes;
            Assert.Equal("Rent", bill.Name);
            Assert.Equal("123.45", bill.AmountMin);
            Assert.Equal("123.45", bill.AmountMax);
            Assert.Equal(BillRepeatFrequency.Monthly, bill.RepeatFreq);
            // RFC3339 values with an offset are adjusted; compare in UTC to stay timezone-agnostic.
            Assert.Equal(new DateTime(2018, 9, 17, 11, 46, 47, DateTimeKind.Utc), bill.Date.ToUniversalTime());
            Assert.Equal(new DateTime(2019, 9, 17, 11, 46, 47, DateTimeKind.Utc), bill.EndDate.ToUniversalTime());
            Assert.Equal(0, bill.Skip);
            Assert.True(bill.Active);
            Assert.Equal(1, bill.Order);
            Assert.Equal("Some example notes", bill.Notes);
            Assert.Equal("5", bill.ObjectGroupId);
            Assert.Equal("Example Group", bill.ObjectGroupTitle);
            // pay_dates / paid_dates are readOnly (private setters): the payload above proves the
            // shape parses, but System.Text.Json leaves the properties unset.
        }

        [Fact]
        public void BillSingle_With_HalfYear_Frequency_And_Explicit_Nulls_Deserializes()
        {
            var single = JsonSerializer.Deserialize<BillSingle>(BillSingleHalfYearJson, SerializerOptions.Default);

            var bill = single.Data.Attributes;
            Assert.Equal("Gym membership", bill.Name);
            Assert.Equal(BillRepeatFrequency.HalfYear, bill.RepeatFreq); // wire value "half-year"
            Assert.Equal(new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), bill.Date.ToUniversalTime());
            Assert.Null(bill.Notes);
            Assert.Null(bill.ObjectGroupId);
            Assert.Null(bill.ObjectGroupTitle);
        }

        [Fact]
        public void BillArray_Deserializes_Spec_Example()
        {
            var array = JsonSerializer.Deserialize<BillArray>(BillArrayJson, SerializerOptions.Default);

            Assert.Equal(2, array.Data.Count);
            Assert.Equal("1", array.Data[0].Id);
            Assert.Equal("Rent", array.Data[0].Attributes.Name);
            Assert.Equal(BillRepeatFrequency.Monthly, array.Data[0].Attributes.RepeatFreq);
            Assert.Equal("Health insurance", array.Data[1].Attributes.Name);
            Assert.Equal(BillRepeatFrequency.Yearly, array.Data[1].Attributes.RepeatFreq);
            Assert.False(array.Data[1].Attributes.Active);

            Assert.Equal(2, array.Meta.Pagination.Total);
            Assert.Equal(50, array.Meta.Pagination.PerPage);
            Assert.Equal(1, array.Meta.Pagination.CurrentPage);
        }
    }
}
