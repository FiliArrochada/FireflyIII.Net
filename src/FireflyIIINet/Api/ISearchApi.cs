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

        // 6.7.0: exact-match count on meta fields (notes is a "contains" match), meant for
        // duplicate checks before storing. All filters are optional.
        [Get("/v1/search/transactions/count")]
        Task<TransactionCountResult> CountTransactions([Header("X-Trace-Id")] Guid? xTraceId = null, [AliasAs("external_identifier")] string externalIdentifier = null, [AliasAs("internal_reference")] string internalReference = null, string notes = null, string description = null, [AliasAs("include_deleted")] bool? includeDeleted = null);
    }
}
