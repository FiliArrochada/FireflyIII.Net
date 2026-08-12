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

        [Get("/v1/autocomplete/currencies-with-code")]
        Task<List<AutocompleteCurrencyCode>> GetCurrenciesCodeAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/object-groups")]
        Task<List<AutocompleteObjectGroup>> GetObjectGroupsAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v1/autocomplete/piggy-banks")]
        Task<List<AutocompletePiggy>> GetPiggiesAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

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

        [Get("/v1/autocomplete/transactions-with-id")]
        Task<List<AutocompleteTransactionID>> GetTransactionsIDAC([Header("X-Trace-Id")] Guid? xTraceId = null, string query = null, int? limit = null);

        [Get("/v2/autocomplete/accounts")]
        Task<List<AutocompleteObject>> GetAccountsACV2([Header("X-Trace-Id")] Guid? xTraceId = null, [AliasAs("user_group_id")] int? userGroupId = null, string query = null, [Query(Format = "yyyy-MM-dd")] DateTime? date = null, int? size = null, int? page = null);
    }
}
