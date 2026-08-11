using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface ISearchApi
    {
        [Get("/v1/search/accounts")]
        Task<AccountArray> SearchAccounts(string query, AccountSearchFieldFilter field, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, AccountTypeFilter? type = null);

        [Get("/v1/search/transactions")]
        Task<TransactionArray> SearchTransactions(string query, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);
    }
}
