using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IRecurrencesApi
    {
        [Delete("/v1/recurrences/{id}")]
        Task DeleteRecurrence(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/recurrences/{id}")]
        Task<RecurrenceSingle> GetRecurrence(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/recurrences")]
        Task<RecurrenceArray> ListRecurrence([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/recurrences/{id}/transactions")]
        Task<TransactionArray> ListTransactionByRecurrence(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, TransactionTypeFilter? type = null);

        [Post("/v1/recurrences")]
        [Headers("Content-Type: application/json")]
        Task<RecurrenceSingle> StoreRecurrence([Body] RecurrenceStore recurrenceStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/recurrences/{id}")]
        [Headers("Content-Type: application/json")]
        Task<RecurrenceSingle> UpdateRecurrence(string id, [Body] RecurrenceUpdate recurrenceUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
