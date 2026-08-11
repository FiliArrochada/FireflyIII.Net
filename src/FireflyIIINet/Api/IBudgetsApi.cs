using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IBudgetsApi
    {
        [Delete("/v1/budgets/{id}")]
        Task DeleteBudget(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Delete("/v1/budgets/{id}/limits/{limitId}")]
        Task DeleteBudgetLimit(string id, string limitId, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/budgets/{id}")]
        Task<BudgetSingle> GetBudget(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null);

        [Get("/v1/budgets/{id}/limits/{limitId}")]
        Task<BudgetLimitSingle> GetBudgetLimit(string id, int limitId, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/budgets/{id}/attachments")]
        Task<AttachmentArray> ListAttachmentByBudget(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/budgets")]
        Task<BudgetArray> ListBudget([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null);

        [Get("/v1/budget-limits")]
        Task<BudgetLimitArray> ListBudgetLimit([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/budgets/{id}/limits")]
        Task<BudgetLimitArray> ListBudgetLimitByBudget(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null);

        [Get("/v1/budgets/{id}/transactions")]
        Task<TransactionArray> ListTransactionByBudget(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, TransactionTypeFilter? type = null);

        [Get("/v1/budgets/{id}/limits/{limitId}/transactions")]
        Task<TransactionArray> ListTransactionByBudgetLimit(string id, string limitId, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, TransactionTypeFilter? type = null);

        [Post("/v1/budgets")]
        [Headers("Content-Type: application/json")]
        Task<BudgetSingle> StoreBudget([Body] BudgetStore budgetStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Post("/v1/budgets/{id}/limits")]
        [Headers("Content-Type: application/json")]
        Task<BudgetLimitSingle> StoreBudgetLimit(string id, [Body] BudgetLimitStore budgetLimitStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/budgets/{id}")]
        [Headers("Content-Type: application/json")]
        Task<BudgetSingle> UpdateBudget(string id, [Body] BudgetUpdate budgetUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/budgets/{id}/limits/{limitId}")]
        [Headers("Content-Type: application/json")]
        Task<BudgetLimitSingle> UpdateBudgetLimit(string id, string limitId, [Body] BudgetLimit budgetLimit, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
