using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IAutocompleteApi
    {
        [Get("/v1/autocomplete/accounts")]
        Task<List<AutocompleteAccount>> GetAccountsAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null, string date = null, [Query(CollectionFormat.Csv)] List<AccountTypeFilter> types = null);

        [Get("/v1/autocomplete/bills")]
        Task<List<AutocompleteBill>> GetBillsAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/budgets")]
        Task<List<AutocompleteBudget>> GetBudgetsAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/categories")]
        Task<List<AutocompleteCategory>> GetCategoriesAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/currencies")]
        Task<List<AutocompleteCurrency>> GetCurrenciesAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        // Removed from the API in Firefly III 6.7.0 (it was deprecated before that). Kept so
        // existing callers still compile; the server answers 404. The model stays in the spec.
        [Obsolete("Removed in Firefly III 6.7.0. Use GetCurrenciesAC; the currency code is in AutocompleteCurrency.Code.")]
        [Get("/v1/autocomplete/currencies-with-code")]
        Task<List<AutocompleteCurrencyCode>> GetCurrenciesCodeAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/object-groups")]
        Task<List<AutocompleteObjectGroup>> GetObjectGroupsAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/piggy-banks")]
        Task<List<AutocompletePiggy>> GetPiggiesAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        // Removed from the API in Firefly III 6.7.0; see GetCurrenciesCodeAC.
        [Obsolete("Removed in Firefly III 6.7.0. Use GetPiggiesAC.")]
        [Get("/v1/autocomplete/piggy-banks-with-balance")]
        Task<List<AutocompletePiggyBalance>> GetPiggiesBalanceAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/recurring")]
        Task<List<AutocompleteRecurrence>> GetRecurringAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/rule-groups")]
        Task<List<AutocompleteRuleGroup>> GetRuleGroupsAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/rules")]
        Task<List<AutocompleteRule>> GetRulesAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/subscriptions")]
        Task<List<AutocompleteBill>> GetSubscriptionsAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/tags")]
        Task<List<AutocompleteTag>> GetTagAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/transaction-types")]
        Task<List<AutocompleteTransactionType>> GetTransactionTypesAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/transactions")]
        Task<List<AutocompleteTransaction>> GetTransactionsAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        // Replaced in Firefly III 6.7.0 by transactions-with-meta (GetTransactionsWithMeta), whose
        // rows carry the same id/name/description plus date, currency_code and amount.
        [Obsolete("Removed in Firefly III 6.7.0. Use GetTransactionsWithMeta.")]
        [Get("/v1/autocomplete/transactions-with-id")]
        Task<List<AutocompleteTransactionID>> GetTransactionsIDAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/transactions-with-meta")]
        Task<List<AutocompleteTransactionWithMeta>> GetTransactionsWithMeta([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v2/autocomplete/accounts")]
        Task<List<AutocompleteObject>> GetAccountsACV2([Header("X-Trace-Id")] Guid? xTraceId = null, [AliasAs("user_group_id")] int? userGroupId = null, string query = null, [Query(Format = "yyyy-MM-dd")] DateTime? date = null, int? size = null, int? page = null);
    }
}
