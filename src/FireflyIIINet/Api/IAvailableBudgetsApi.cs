using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IAvailableBudgetsApi
    {
        [Get("/v1/available-budgets/{id}")]
        Task<AvailableBudgetSingle> GetAvailableBudget(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/available-budgets")]
        Task<AvailableBudgetArray> ListAvailableBudgets([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null);
    }
}
