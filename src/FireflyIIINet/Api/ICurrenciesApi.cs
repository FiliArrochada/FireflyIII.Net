using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface ICurrenciesApi
    {
        [Post("/v1/currencies/{code}/default")]
        Task<CurrencySingle> DefaultCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Delete("/v1/currencies/{code}")]
        Task DeleteCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Post("/v1/currencies/{code}/disable")]
        Task<CurrencySingle> DisableCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Post("/v1/currencies/{code}/enable")]
        Task<CurrencySingle> EnableCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/currencies/{code}")]
        Task<CurrencySingle> GetCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/currencies/default")]
        Task<CurrencySingle> GetDefaultCurrency([Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/currencies/{code}/accounts")]
        Task<AccountArray> ListAccountByCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? date = null, AccountTypeFilter? type = null);

        [Get("/v1/currencies/{code}/available-budgets")]
        Task<AvailableBudgetArray> ListAvailableBudgetByCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null);

        [Get("/v1/currencies/{code}/bills")]
        Task<BillArray> ListBillByCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null);

        [Get("/v1/currencies/{code}/budget_limits")]
        Task<BudgetLimitArray> ListBudgetLimitByCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null);

        [Get("/v1/currencies")]
        Task<CurrencyArray> ListCurrency([Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null);

        [Get("/v1/currencies/{code}/recurrences")]
        Task<RecurrenceArray> ListRecurrenceByCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null);

        [Get("/v1/currencies/{code}/rules")]
        Task<RuleArray> ListRuleByCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null);

        [Get("/v1/currencies/{code}/transactions")]
        Task<TransactionArray> ListTransactionByCurrency(string code, [Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, TransactionTypeFilter? type = null);

        [Post("/v1/currencies")]
        [Headers("Content-Type: application/json")]
        Task<CurrencySingle> StoreCurrency([Body] CurrencyStore currencyStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/currencies/{code}")]
        [Headers("Content-Type: application/json")]
        Task<CurrencySingle> UpdateCurrency(string code, [Body] CurrencyUpdate currencyUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
