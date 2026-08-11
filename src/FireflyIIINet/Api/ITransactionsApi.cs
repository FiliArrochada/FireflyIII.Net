using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface ITransactionsApi
    {
        [Delete("/v1/transactions/{id}")]
        Task DeleteTransaction(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Delete("/v1/transaction-journals/{id}")]
        Task DeleteTransactionJournal(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/transactions/{id}")]
        Task<TransactionSingle> GetTransaction(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/transaction-journals/{id}")]
        Task<TransactionSingle> GetTransactionByJournal(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/transactions/{id}/attachments")]
        Task<AttachmentArray> ListAttachmentByTransaction(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/transactions/{id}/piggy-bank-events")]
        Task<PiggyBankEventArray> ListEventByTransaction(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/transaction-journals/{id}/links")]
        Task<TransactionLinkArray> ListLinksByJournal(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/transactions")]
        Task<TransactionArray> ListTransaction([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, TransactionTypeFilter? type = null);

        [Post("/v1/transactions")]
        [Headers("Content-Type: application/json")]
        Task<TransactionSingle> StoreTransaction([Body] TransactionStore transactionStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/transactions/{id}")]
        [Headers("Content-Type: application/json")]
        Task<TransactionSingle> UpdateTransaction(string id, [Body] TransactionUpdate transactionUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
