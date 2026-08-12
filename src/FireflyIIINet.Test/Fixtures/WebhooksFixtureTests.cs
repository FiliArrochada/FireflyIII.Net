/*
 * Fixture tests for the Webhooks area, fed by the example payloads from the
 * Firefly III OpenAPI spec (api/firefly-iii-6.2.7-v1.yaml, Webhook / WebhookMessage /
 * WebhookAttempt schemas).
 *
 * Note: read-only spec fields (created_at, updated_at, secret) map onto private-setter
 * properties and are present in the payloads only to prove they deserialize without
 * error; assertions target the publicly settable properties.
 */

using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class WebhooksFixtureTests
    {
        [Fact]
        public void WebhookSingle_Deserializes_Spec_Example_With_All_Three_Enums()
        {
            const string json = """
            {
              "data": {
                "type": "webhooks",
                "id": "1",
                "attributes": {
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "active": false,
                  "title": "Update magic mirror on new transaction",
                  "secret": "iMLZLtLx2JHWhK9Dtyuoqyir",
                  "trigger": "STORE_TRANSACTION",
                  "response": "TRANSACTIONS",
                  "delivery": "JSON",
                  "url": "https://example.com"
                },
                "links": {
                  "self": "https://demo.firefly-iii.org/api/v1/webhooks/1"
                }
              }
            }
            """;

            var single = JsonSerializer.Deserialize<WebhookSingle>(json, SerializerOptions.Default);

            Assert.Equal("webhooks", single.Data.Type);
            Assert.Equal("1", single.Data.Id);

            var webhook = single.Data.Attributes;
            Assert.Equal("Update magic mirror on new transaction", webhook.Title);
            Assert.Equal("https://example.com", webhook.Url);
            Assert.False(webhook.Active);
            Assert.Equal(WebhookTrigger.STORETRANSACTION, webhook.Trigger);
            Assert.Equal(WebhookResponse.TRANSACTIONS, webhook.Response);
            Assert.Equal(WebhookDelivery.JSON, webhook.Delivery);
        }

        [Theory]
        [InlineData("STORE_TRANSACTION", WebhookTrigger.STORETRANSACTION, "ACCOUNTS", WebhookResponse.ACCOUNTS)]
        [InlineData("UPDATE_TRANSACTION", WebhookTrigger.UPDATETRANSACTION, "TRANSACTIONS", WebhookResponse.TRANSACTIONS)]
        [InlineData("DESTROY_TRANSACTION", WebhookTrigger.DESTROYTRANSACTION, "NONE", WebhookResponse.NONE)]
        public void Webhook_Trigger_And_Response_Map_All_Wire_Values(
            string triggerWire, WebhookTrigger expectedTrigger, string responseWire, WebhookResponse expectedResponse)
        {
            var json = $$"""
            {
              "active": true,
              "title": "A webhook",
              "trigger": "{{triggerWire}}",
              "response": "{{responseWire}}",
              "delivery": "JSON",
              "url": "https://example.com"
            }
            """;

            var webhook = JsonSerializer.Deserialize<Webhook>(json, SerializerOptions.Default);
            Assert.Equal(expectedTrigger, webhook.Trigger);
            Assert.Equal(expectedResponse, webhook.Response);
        }

        [Fact]
        public void WebhookMessageSingle_Deserializes_Spec_Example()
        {
            const string json = """
            {
              "data": {
                "type": "webhook_messages",
                "id": "2",
                "attributes": {
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "sent": false,
                  "errored": false,
                  "webhook_id": "5",
                  "uuid": "7a344c02-5b52-46b1-90e6-a437431dcf07",
                  "message": "{some:message}"
                }
              }
            }
            """;

            var single = JsonSerializer.Deserialize<WebhookMessageSingle>(json, SerializerOptions.Default);

            Assert.Equal("webhook_messages", single.Data.Type);
            Assert.Equal("2", single.Data.Id);

            var message = single.Data.Attributes;
            Assert.False(message.Sent);
            Assert.False(message.Errored);
            Assert.Equal("5", message.WebhookId);
            Assert.Equal("7a344c02-5b52-46b1-90e6-a437431dcf07", message.Uuid);
            // wire name "message" (renamed from "string" in 2.0.12) maps onto the Message property
            Assert.Equal("{some:message}", message.Message);
        }

        [Fact]
        public void WebhookAttemptSingle_Deserializes_Spec_Example_With_Nullable_Fields()
        {
            const string json = """
            {
              "data": {
                "type": "webhook_attempts",
                "id": "3",
                "attributes": {
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "webhook_message_id": "5",
                  "status_code": 404,
                  "logs": null,
                  "response": "Page not found"
                }
              }
            }
            """;

            var single = JsonSerializer.Deserialize<WebhookAttemptSingle>(json, SerializerOptions.Default);

            Assert.Equal("webhook_attempts", single.Data.Type);
            Assert.Equal("3", single.Data.Id);

            var attempt = single.Data.Attributes;
            Assert.Equal("5", attempt.WebhookMessageId);
            Assert.Equal(404, attempt.StatusCode);
            Assert.Null(attempt.Logs); // nullable per spec, explicit null on the wire
            Assert.Equal("Page not found", attempt.Response);
        }
    }
}
