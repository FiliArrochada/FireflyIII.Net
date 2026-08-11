using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IAccountsApi
    {
        [Delete("/v1/accounts/{id}")]
        Task DeleteAccount(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/accounts/{id}")]
        Task<AccountSingle> GetAccount(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? date = null);

        [Get("/v2/accounts/{id}")]
        Task<AccountV2Single> GetAccountV2(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? date = null);

        [Get("/v1/accounts")]
        Task<AccountArray> ListAccount([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? date = null, AccountTypeFilter? type = null);

        [Get("/v1/accounts/{id}/attachments")]
        Task<AttachmentArray> ListAttachmentByAccount(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/accounts/{id}/piggy-banks")]
        Task<PiggyBankArray> ListPiggyBankByAccount(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/accounts/{id}/transactions")]
        Task<TransactionArray> ListTransactionByAccount(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null, int? limit = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, TransactionTypeFilter? type = null);

        [Get("/v2/accounts/{id}/transactions")]
        Task<TransactionV2Array> ListTransactionByAccountV2(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null, int? limit = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, TransactionTypeFilter? type = null);

        [Post("/v1/accounts")]
        [Headers("Content-Type: application/json")]
        Task<AccountSingle> StoreAccount([Body] AccountStore accountStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/accounts/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AccountSingle> UpdateAccount(string id, [Body] AccountUpdate accountUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
