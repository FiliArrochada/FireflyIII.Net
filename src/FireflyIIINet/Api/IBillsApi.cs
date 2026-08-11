using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IBillsApi
    {
        [Delete("/v1/bills/{id}")]
        Task DeleteBill(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/bills/{id}")]
        Task<BillSingle> GetBill(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null);

        [Get("/v1/bills/{id}/attachments")]
        Task<AttachmentArray> ListAttachmentByBill(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/bills")]
        Task<BillArray> ListBill([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null);

        [Get("/v1/bills/{id}/rules")]
        Task<RuleArray> ListRuleByBill(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/bills/{id}/transactions")]
        Task<TransactionArray> ListTransactionByBill(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, TransactionTypeFilter? type = null);

        [Post("/v1/bills")]
        [Headers("Content-Type: application/json")]
        Task<BillSingle> StoreBill([Body] BillStore billStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/bills/{id}")]
        [Headers("Content-Type: application/json")]
        Task<BillSingle> UpdateBill(string id, [Body] BillUpdate billUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v2/subscriptions/{id}")]
        Task<SubscriptionSingle> GetSubscription(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null);

        [Get("/v2/subscriptions")]
        Task<SubscriptionArray> ListSubscriptions([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);
    }
}
