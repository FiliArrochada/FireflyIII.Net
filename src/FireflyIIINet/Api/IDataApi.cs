using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IDataApi
    {
        [Post("/v1/data/bulk/transactions")]
        Task BulkUpdateTransactions(string query);

        [Delete("/v1/data/destroy")]
        Task DestroyData(DataDestroyObject objects, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/data/export/accounts")]
        Task<Stream> ExportAccounts([Header("X-Trace-Id")] Guid? xTraceId = null, ExportFileFilter? type = null);

        [Get("/v1/data/export/bills")]
        Task<Stream> ExportBills([Header("X-Trace-Id")] Guid? xTraceId = null, ExportFileFilter? type = null);

        [Get("/v1/data/export/budgets")]
        Task<Stream> ExportBudgets([Header("X-Trace-Id")] Guid? xTraceId = null, ExportFileFilter? type = null);

        [Get("/v1/data/export/subscriptions")]
        Task<Stream> ExportSubscriptions([Header("X-Trace-Id")] Guid? xTraceId = null, ExportFileFilter? type = null);

        [Get("/v1/data/export/categories")]
        Task<Stream> ExportCategories([Header("X-Trace-Id")] Guid? xTraceId = null, ExportFileFilter? type = null);

        [Get("/v1/data/export/piggy-banks")]
        Task<Stream> ExportPiggies([Header("X-Trace-Id")] Guid? xTraceId = null, ExportFileFilter? type = null);

        [Get("/v1/data/export/recurring")]
        Task<Stream> ExportRecurring([Header("X-Trace-Id")] Guid? xTraceId = null, ExportFileFilter? type = null);

        [Get("/v1/data/export/rules")]
        Task<Stream> ExportRules([Header("X-Trace-Id")] Guid? xTraceId = null, ExportFileFilter? type = null);

        [Get("/v1/data/export/tags")]
        Task<Stream> ExportTags([Header("X-Trace-Id")] Guid? xTraceId = null, ExportFileFilter? type = null);

        [Get("/v1/data/export/transactions")]
        Task<Stream> ExportTransactions([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, string accounts = null, ExportFileFilter? type = null);

        [Delete("/v1/data/purge")]
        Task PurgeData([Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
