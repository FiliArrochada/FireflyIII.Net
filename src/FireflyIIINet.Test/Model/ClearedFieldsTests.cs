/*
 * Clearing a stored value: an update leaves out a field that is null, so the server keeps what
 * it has; Clear sends the field as null, so the server removes it (a piggy bank's target date, a
 * recurrence's end date, a tag's location). Without it, emptying such a field could not reach
 * the server at all.
 */

using System;
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
    public class ClearedFieldsTests
    {
        private static JsonElement Json(object model) =>
            JsonDocument.Parse(JsonSerializer.Serialize(model, model.GetType(), SerializerOptions.Default)).RootElement;

        [Fact]
        public void An_unset_field_is_left_out_and_a_cleared_one_is_sent_as_null()
        {
            var json = Json(new PiggyBankUpdate(name: "Holiday").Clear(u => u.TargetDate));

            Assert.Equal(JsonValueKind.Null, json.GetProperty("target_date").ValueKind);
            Assert.False(json.TryGetProperty("target_amount", out _));
            Assert.False(json.TryGetProperty("notes", out _));
        }

        [Fact]
        public void Clear_sets_the_property_to_null_whatever_it_held()
        {
            var update = new PiggyBankUpdate(name: "Holiday", targetAmount: "400", targetDate: new DateTime(2026, 12, 1)).Clear(u => u.TargetAmount).Clear(u => u.TargetDate);

            Assert.Null(update.TargetAmount);
            var json = Json(update);
            Assert.Equal(JsonValueKind.Null, json.GetProperty("target_amount").ValueKind);
            Assert.Equal(JsonValueKind.Null, json.GetProperty("target_date").ValueKind);
        }

        [Fact]
        public void A_value_assigned_after_Clear_is_sent()
        {
            var update = new PiggyBankUpdate(name: "Holiday").Clear(u => u.TargetAmount);
            update.TargetAmount = "250";

            Assert.Equal("250", Json(update).GetProperty("target_amount").GetString());
        }

        [Fact]
        public void Clear_marks_only_the_instance_it_was_called_on()
        {
            new PiggyBankUpdate(name: "One").Clear(u => u.TargetDate);

            Assert.False(Json(new PiggyBankUpdate(name: "Two")).TryGetProperty("target_date", out _));
        }

        [Fact]
        public void Dates_numbers_and_ids_can_be_cleared()
        {
            var bill = Json(new BillUpdate(name: "Gym").Clear(u => u.EndDate).Clear(u => u.ExtensionDate));
            Assert.Equal(JsonValueKind.Null, bill.GetProperty("end_date").ValueKind);
            Assert.Equal(JsonValueKind.Null, bill.GetProperty("extension_date").ValueKind);

            var tag = Json(new TagModelUpdate(tag: "Holiday").Clear(u => u.Latitude).Clear(u => u.Longitude).Clear(u => u.ZoomLevel));
            Assert.Equal(JsonValueKind.Null, tag.GetProperty("latitude").ValueKind);
            Assert.Equal(JsonValueKind.Null, tag.GetProperty("zoom_level").ValueKind);

            var recurrence = Json(new RecurrenceUpdate(title: "Rent").Clear(u => u.RepeatUntil));
            Assert.Equal(JsonValueKind.Null, recurrence.GetProperty("repeat_until").ValueKind);
        }

        [Fact]
        public void A_bill_with_no_end_date_set_sends_none()
        {
            // BillUpdate's end and extension dates were plain DateTime, so they could not be null.
            var json = Json(new BillUpdate(name: "Gym"));

            Assert.False(json.TryGetProperty("end_date", out _));
            Assert.False(json.TryGetProperty("extension_date", out _));
        }

        [Fact]
        public void Clearing_a_category_note_goes_through_its_own_three_states()
        {
            Assert.Equal(JsonValueKind.Null, Json(new CategoryUpdate(name: "Food").Clear(u => u.Notes)).GetProperty("notes").ValueKind);
        }

        [Fact]
        public void A_field_that_cannot_be_null_cannot_be_cleared()
        {
            var error = Assert.Throws<ArgumentException>(() => new PiggyBankUpdate(name: "Holiday").Clear(u => u.StartDate));
            Assert.Contains("StartDate", error.Message);
        }

        [Fact]
        public void Only_a_property_of_the_model_itself_can_be_cleared()
        {
            Assert.Throws<ArgumentException>(() => new PiggyBankUpdate(name: "Holiday").Clear(u => u.Name.Length.ToString()));
        }

        [Fact]
        public async Task A_cleared_field_reaches_the_request_body()
        {
            var cap = new CapturingHandler("{\"data\":{\"type\":\"piggy_banks\",\"id\":\"3\",\"attributes\":{\"name\":\"Holiday\"}}}");
            var api = FireflyRefit.Create<IPiggyBanksApi>(new HttpClient(cap) { BaseAddress = new Uri("https://demo.firefly-iii.org/api") });

            await api.UpdatePiggyBank("3", new PiggyBankUpdate(name: "Holiday").Clear(u => u.TargetDate));

            var body = JsonDocument.Parse(cap.LastRequestBody).RootElement;
            Assert.Equal(JsonValueKind.Null, body.GetProperty("target_date").ValueKind);
            Assert.False(body.TryGetProperty("target_amount", out _));
        }
    }
}
