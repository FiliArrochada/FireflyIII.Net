/*
 * Chart data sets: the server sends "entries" as an object keyed by the point's label (the spec's
 * "type: object" with "items"), not as an array. ChartEntriesConverter reads that shape, the
 * empty "[]" PHP sends for no points, and an array of {key, value} objects.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using FireflyIIINet.Test.RefitSlice;
using Xunit;

namespace FireflyIIINet.Test.Model
{
    public class ChartEntriesTests
    {
        private const string BalanceChart = @"[
          {
            ""label"": ""Checking account"",
            ""currency_id"": ""1"",
            ""currency_code"": ""EUR"",
            ""currency_symbol"": ""€"",
            ""currency_decimal_places"": 2,
            ""start_date"": ""2026-10-01T00:00:00+01:00"",
            ""end_date"": ""2026-10-03T23:59:59+01:00"",
            ""type"": ""line"",
            ""yAxisID"": 0,
            ""entries"": {
              ""2026-10-01T00:00:00+01:00"": ""1250.50"",
              ""2026-10-02T00:00:00+01:00"": -12.3,
              ""2026-10-03T00:00:00+01:00"": ""1199.000000000000""
            },
            ""pc_entries"": []
          }
        ]";

        [Fact]
        public void Entries_Object_Reads_As_Points_In_Server_Order()
        {
            var sets = JsonSerializer.Deserialize<List<ChartDataSet>>(BalanceChart, SerializerOptions.Default);

            var set = Assert.Single(sets);
            Assert.Equal("Checking account", set.Label);
            Assert.Equal(
                new[] { "2026-10-01T00:00:00+01:00", "2026-10-02T00:00:00+01:00", "2026-10-03T00:00:00+01:00" },
                set.Entries.Select(p => p.Key));
            Assert.Equal(new decimal?[] { 1250.50m, -12.3m, 1199m }, set.Entries.Select(p => p.Value));
        }

        [Fact]
        public void Empty_Php_Array_Reads_As_No_Points()
        {
            var set = JsonSerializer.Deserialize<List<ChartDataSet>>(BalanceChart, SerializerOptions.Default)[0];

            Assert.NotNull(set.PcEntries);
            Assert.Empty(set.PcEntries);
        }

        [Fact]
        public void Array_Of_Key_Value_Objects_Is_Read_Too()
        {
            var set = JsonSerializer.Deserialize<ChartDataSet>(
                @"{""entries"": [{""key"": ""Groceries"", ""value"": ""-123""}, {""key"": ""Rent"", ""value"": null}]}",
                SerializerOptions.Default);

            Assert.Equal(new[] { "Groceries", "Rent" }, set.Entries.Select(p => p.Key));
            Assert.Equal(new decimal?[] { -123m, null }, set.Entries.Select(p => p.Value));
        }

        [Fact]
        public void Entries_Write_Back_As_An_Object()
        {
            var set = new ChartDataSet(label: "Spent", entries: new List<ChartDataPoint>
            {
                new ChartDataPoint("Groceries", -123.45m),
                new ChartDataPoint("Rent", null),
            });

            var json = JsonSerializer.Serialize(set, SerializerOptions.Default);

            Assert.Contains(@"""entries"":{""Groceries"":-123.45,""Rent"":null}", json);
            Assert.Equal(set, JsonSerializer.Deserialize<ChartDataSet>(json, SerializerOptions.Default));
        }

        [Fact]
        public void V2_Entries_Object_Reads_As_Points()
        {
            var set = JsonSerializer.Deserialize<ChartDataSetV2>(
                @"{""label"": ""Savings"", ""entries"": {""2024-01-01T00:00:00+01:00"": ""10.5""}, ""native_entries"": []}",
                SerializerOptions.Default);

            var point = Assert.Single(set.Entries);
            Assert.Equal("2024-01-01T00:00:00+01:00", point.Key);
            Assert.Equal(10.5m, point.Value);
            Assert.Empty(set.NativeEntries);
        }

        [Fact]
        public void Entries_That_Are_Neither_Object_Nor_Array_Fail_Clearly()
        {
            var error = Assert.Throws<JsonException>(() =>
                JsonSerializer.Deserialize<ChartDataSet>(@"{""entries"": 5}", SerializerOptions.Default));

            Assert.Contains("object or an array", error.Message);
        }

        [Fact]
        public async Task GetChartBalance_Parses_The_Server_Response()
        {
            var cap = new CapturingHandler(BalanceChart);
            var http = new HttpClient(cap) { BaseAddress = new Uri("https://demo.firefly-iii.org/api") };
            var charts = FireflyRefit.Create<IChartsApi>(http);

            var sets = await charts.GetChartBalance(new DateTime(2026, 10, 1), new DateTime(2026, 10, 3), period: "1D", accounts: new List<long> { 1 });

            Assert.Equal(3, sets[0].Entries.Count);
            Assert.Equal(1250.50m, sets[0].Entries[0].Value);
            Assert.Contains("accounts%5B%5D=1", cap.LastRequest.RequestUri.Query);
        }
    }
}
