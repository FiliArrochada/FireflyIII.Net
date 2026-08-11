using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IWebhooksApi
    {
        [Delete("/v1/webhooks/{id}")]
        Task DeleteWebhook(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Delete("/v1/webhooks/{id}/messages/{messageId}")]
        Task DeleteWebhookMessage(string id, int messageId, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Delete("/v1/webhooks/{id}/messages/{messageId}/attempts/{attemptId}")]
        Task DeleteWebhookMessageAttempt(string id, int messageId, int attemptId, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/webhooks/{id}/messages/{messageId}")]
        Task<WebhookMessageSingle> GetSingleWebhookMessage(string id, int messageId, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/webhooks/{id}/messages/{messageId}/attempts/{attemptId}")]
        Task<WebhookAttemptSingle> GetSingleWebhookMessageAttempt(string id, int messageId, int attemptId, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/webhooks/{id}")]
        Task<WebhookSingle> GetWebhook(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/webhooks/{id}/messages/{messageId}/attempts")]
        Task<WebhookAttemptArray> GetWebhookMessageAttempts(string id, int messageId, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/webhooks/{id}/messages")]
        Task<WebhookMessageArray> GetWebhookMessages(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/webhooks")]
        Task<WebhookArray> ListWebhook([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Post("/v1/webhooks")]
        [Headers("Content-Type: application/json")]
        Task<WebhookSingle> StoreWebhook([Body] WebhookStore webhookStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Post("/v1/webhooks/{id}/trigger-transaction/{transactionId}")]
        Task TriggerTransactionWebhook(string id, string transactionId, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Post("/v1/webhooks/{id}/submit")]
        Task SubmitWebook(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/webhooks/{id}")]
        [Headers("Content-Type: application/json")]
        Task<WebhookSingle> UpdateWebhook(string id, [Body] WebhookUpdate webhookUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
