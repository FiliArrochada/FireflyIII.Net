using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface ILinksApi
    {
        [Delete("/v1/link-types/{id}")]
        Task DeleteLinkType(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Delete("/v1/transaction-links/{id}")]
        Task DeleteTransactionLink(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/link-types/{id}")]
        Task<LinkTypeSingle> GetLinkType(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/transaction-links/{id}")]
        Task<TransactionLinkSingle> GetTransactionLink(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/link-types")]
        Task<LinkTypeArray> ListLinkType([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/link-types/{id}/transactions")]
        Task<TransactionArray> ListTransactionByLinkType(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, TransactionTypeFilter? type = null);

        [Get("/v1/transaction-links")]
        Task<TransactionLinkArray> ListTransactionLink([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Post("/v1/link-types")]
        [Headers("Content-Type: application/json")]
        Task<LinkTypeSingle> StoreLinkType([Body] LinkType linkType, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Post("/v1/transaction-links")]
        [Headers("Content-Type: application/json")]
        Task<TransactionLinkSingle> StoreTransactionLink([Body] TransactionLinkStore transactionLinkStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/link-types/{id}")]
        [Headers("Content-Type: application/json")]
        Task<LinkTypeSingle> UpdateLinkType(string id, [Body] LinkTypeUpdate linkTypeUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/transaction-links/{id}")]
        [Headers("Content-Type: application/json")]
        Task<TransactionLinkSingle> UpdateTransactionLink(string id, [Body] TransactionLinkUpdate transactionLinkUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
