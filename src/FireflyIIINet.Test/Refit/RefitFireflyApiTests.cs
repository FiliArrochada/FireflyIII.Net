/*
 * Vertical-slice tests: prove the Refit interfaces + glue actually build requests and parse
 * responses correctly — query formatting (dates, enums, lowercase booleans, multi arrays),
 * path templating, the X-Trace-Id header, JSON bodies and bearer auth. No network
 * (CapturingHandler intercepts).
 */

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FireflyIIINet.Api;
using FireflyIIINet.Model;
using FireflyIIINet.Test.RefitSlice;
using Xunit;

namespace FireflyIIINet.Test
{
    public class RefitFireflyApiTests
    {
        private static (T api, CapturingHandler cap) Build<T>(string cannedJson, Func<string> token = null)
        {
            var cap = new CapturingHandler(cannedJson);
            HttpMessageHandler pipeline = token == null ? cap : new BearerTokenHandler(token) { InnerHandler = cap };
            var http = new HttpClient(pipeline) { BaseAddress = new Uri("https://demo.firefly-iii.org/api") };
            return (FireflyRefit.Create<T>(http), cap);
        }

        [Fact]
        public async Task ListAccount_Builds_Date_Enum_And_Paging_Query()
        {
            var (api, cap) = Build<IAccountsApi>("{\"data\":[]}");

            var result = await api.ListAccount(page: 2, date: new DateTime(2023, 5, 17), type: AccountTypeFilter.Asset);

            var q = Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query);
            Assert.Equal(HttpMethod.Get, cap.LastRequest.Method);
            Assert.Equal("/api/v1/accounts", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Contains("page=2", q);
            Assert.Contains("date=2023-05-17", q);   // [Query(Format = "yyyy-MM-dd")]
            Assert.Contains("type=asset", q);        // enum via [EnumMember] value
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task GetAccount_Templates_Path_And_Sends_TraceId_Header()
        {
            var traceId = Guid.NewGuid();
            var (api, cap) = Build<IAccountsApi>("{\"data\":{\"type\":\"accounts\",\"id\":\"2\",\"attributes\":{\"name\":\"Checking\",\"type\":\"asset\"}}}");

            var result = await api.GetAccount("2", xTraceId: traceId);

            Assert.Equal("/api/v1/accounts/2", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Equal(traceId.ToString(), Assert.Single(cap.LastRequest.Headers.GetValues("X-Trace-Id")));
            Assert.Equal("Checking", result.Data.Attributes.Name);
        }

        [Fact]
        public async Task GetCron_Serializes_Booleans_Lowercase()
        {
            var (api, cap) = Build<IAboutApi>("{}");

            await api.GetCron("clitoken123", force: true, date: new DateTime(2023, 5, 17));

            var q = Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query);
            Assert.Equal("/api/v1/cron/clitoken123", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Contains("force=true", q);        // lowercase via FireflyUrlParameterFormatter
            Assert.DoesNotContain("force=True", q);
            Assert.Contains("date=2023-05-17", q);
        }

        [Fact]
        public async Task TestRuleGroup_Builds_Multi_Array_And_Aliased_Params()
        {
            var (api, cap) = Build<IRuleGroupsApi>("{\"data\":[]}");

            await api.TestRuleGroup("1", searchLimit: 10, accounts: new List<long> { 1, 2 });

            var q = Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query);
            Assert.Contains("accounts[]=1", q);      // CollectionFormat.Multi + AliasAs "accounts[]"
            Assert.Contains("accounts[]=2", q);
            Assert.Contains("search_limit=10", q);   // AliasAs "search_limit"
        }

        /// <summary>
        /// Firefly III's AcceptHeaders middleware answers 415 to any POST/PUT that arrives
        /// without a Content-Type header, body or no body. Body-less POSTs must therefore
        /// still declare one.
        /// </summary>
        [Fact]
        public async Task FireRule_Posts_With_A_Content_Type_Header()
        {
            var (api, cap) = Build<IRulesApi>("");

            await api.FireRule("1", start: new DateTime(2026, 8, 1), end: new DateTime(2026, 8, 15));

            Assert.Equal(HttpMethod.Post, cap.LastRequest.Method);
            Assert.NotNull(cap.LastRequest.Content);
            Assert.Equal("application/json", cap.LastRequest.Content.Headers.ContentType?.MediaType);
        }

        [Fact]
        public async Task StoreAccount_Posts_Snake_Case_Json_Body()
        {
            var (api, cap) = Build<IAccountsApi>("{\"data\":{\"type\":\"accounts\",\"id\":\"9\",\"attributes\":{\"name\":\"Savings\",\"type\":\"asset\"}}}");

            var result = await api.StoreAccount(new AccountStore(name: "Savings", type: ShortAccountTypeProperty.Asset, accountRole: AccountRoleProperty.SavingAsset));

            Assert.Equal(HttpMethod.Post, cap.LastRequest.Method);
            Assert.Equal("application/json", cap.LastRequest.Content.Headers.ContentType.MediaType);
            Assert.Contains("\"name\":\"Savings\"", cap.LastRequestBody);
            Assert.Contains("\"type\":\"asset\"", cap.LastRequestBody);              // enum wire value
            Assert.Contains("\"account_role\":\"savingAsset\"", cap.LastRequestBody); // snake_case + EnumMember
            Assert.Equal("9", result.Data.Id);
        }

        // ---- endpoints added in Firefly III 6.7.0 ----

        [Fact]
        public async Task CountTransactions_Aliases_Snake_Case_Filters_And_Lowercases_Bool()
        {
            var (api, cap) = Build<ISearchApi>("{\"count\":42}");

            var result = await api.CountTransactions(externalIdentifier: "abcd-1234", internalReference: "INV-998", notes: "groceries", description: "Monthly rent", includeDeleted: false);

            var q = Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query);
            Assert.Equal(HttpMethod.Get, cap.LastRequest.Method);
            Assert.Equal("/api/v1/search/transactions/count", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Contains("external_identifier=abcd-1234", q);   // AliasAs
            Assert.Contains("internal_reference=INV-998", q);      // AliasAs
            Assert.Contains("notes=groceries", q);
            Assert.Contains("description=Monthly rent", q);
            Assert.Contains("include_deleted=false", q);           // AliasAs + lowercase bool
            Assert.Equal(42, result.Count);
        }

        [Fact]
        public async Task CountTransactions_Omits_Unset_Filters()
        {
            var (api, cap) = Build<ISearchApi>("{\"count\":0}");

            var result = await api.CountTransactions(externalIdentifier: "x");

            var q = Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query);
            Assert.Equal("?external_identifier=x", q);
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public async Task ValidateActionExpression_Sends_Expression_Query()
        {
            var (api, cap) = Build<IRulesApi>("{\"valid\":true}");

            var result = await api.ValidateActionExpression("{{ description | upper }}");

            var q = Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query);
            Assert.Equal("/api/v1/rules/validate-expression", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Equal("?expression={{ description | upper }}", q);
            Assert.True(result.Valid);
        }

        [Fact]
        public async Task GetTransactionsWithMeta_Parses_Rows()
        {
            var (api, cap) = Build<IAutocompleteApi>("[{\"id\":\"2\",\"transaction_group_id\":\"2\",\"name\":\"#12: Transaction\",\"description\":\"#12: Transaction\",\"date\":\"2026-09-01T00:00:00+00:00\",\"currency_code\":\"EUR\",\"amount\":\"123.45\"}]");

            var rows = await api.GetTransactionsWithMeta(query: "Trans", limit: 5);

            var q = Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query);
            Assert.Equal("/api/v1/autocomplete/transactions-with-meta", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Contains("query=Trans", q);
            Assert.Contains("limit=5", q);
            var row = Assert.Single(rows);
            Assert.Equal("2", row.Id);
            Assert.Equal("EUR", row.CurrencyCode);
            Assert.Equal("123.45", row.Amount);
            Assert.Equal(new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc), row.Date.Value.ToUniversalTime());
        }

        [Fact]
        public async Task ListAccountByPiggyBank_Templates_Path_And_Pages()
        {
            var (api, cap) = Build<IPiggyBanksApi>("{\"data\":[]}");

            await api.ListAccountByPiggyBank("7", limit: 10, page: 2);

            var q = Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query);
            Assert.Equal("/api/v1/piggy-banks/7/accounts", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Contains("limit=10", q);
            Assert.Contains("page=2", q);
        }

        [Fact]
        public async Task ListExchangeRatesByCurrency_Templates_Cer_Route()
        {
            var (api, cap) = Build<ICurrenciesApi>("{\"data\":[]}");

            var result = await api.ListExchangeRatesByCurrency("USD", page: 1);

            Assert.Equal("/api/v1/currencies/USD/cer", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Contains("page=1", cap.LastRequest.RequestUri.Query);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task GetDefaultCurrency_Is_Alias_Of_Primary()
        {
            var (api, cap) = Build<ICurrenciesApi>("{\"data\":{\"type\":\"currencies\",\"id\":\"1\",\"attributes\":{\"code\":\"EUR\",\"name\":\"Euro\",\"symbol\":\"€\"}}}");

            var result = await api.GetDefaultCurrency();

            Assert.Equal("/api/v1/currencies/default", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Equal("EUR", result.Data.Attributes.Code);
        }

        [Fact]
        public async Task ListAccount_Sends_Active_Filter_Lowercase()
        {
            var (api, cap) = Build<IAccountsApi>("{\"data\":[],\"meta\":{}}");

            await api.ListAccount(active: false);

            Assert.Equal("?active=false", Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query));
        }

        [Fact]
        public async Task DestroyData_Sends_Unused_As_Boolean()
        {
            // The spec types unused as an int64 array; the server validates in:true,false.
            var (api, cap) = Build<IDataApi>("");

            await api.DestroyData(DataDestroyObject.Accounts, unused: true);

            var q = Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query);
            Assert.Equal(HttpMethod.Delete, cap.LastRequest.Method);
            Assert.Equal("/api/v1/data/destroy", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Contains("objects=accounts", q);
            Assert.Contains("unused=true", q);
        }

        [Fact]
        public async Task DestroyData_Omits_Unset_Unused()
        {
            var (api, cap) = Build<IDataApi>("");

            await api.DestroyData(DataDestroyObject.Budgets);

            Assert.Equal("?objects=budgets", Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query));
        }

        [Fact]
        public async Task GetChartBudgetOverviewWithLimits_Builds_Date_Range_And_Parses_Sets()
        {
            var (api, cap) = Build<IChartsApi>("[{\"label\":\"Groceries\",\"currency_id\":\"1\",\"currency_code\":\"EUR\",\"entries\":{\"spent\":\"-120.50\",\"left\":\"79.50\"}}]");

            var sets = await api.GetChartBudgetOverviewWithLimits(new DateTime(2026, 10, 1), new DateTime(2026, 10, 31));

            var q = Uri.UnescapeDataString(cap.LastRequest.RequestUri.Query);
            Assert.Equal("/api/v1/chart/budget/overview-with-limits", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Contains("start=2026-10-01", q);
            Assert.Contains("end=2026-10-31", q);
            var set = Assert.Single(sets);
            Assert.Equal("Groceries", set.Label);
            Assert.Equal(2, set.Entries.Count);
            Assert.Equal(-120.50m, set.Entries[0].Value);
        }

        [Fact]
        public async Task GetReleaseNotes_Templates_Version_And_Parses_Body()
        {
            var (api, cap) = Build<IAboutApi>("{\"version\":\"6.7.8\",\"release_notes\":\"<p>Fixed</p>\",\"release_notes_markdown\":\"Fixed\"}");

            var notes = await api.GetReleaseNotes("v6.7.8");

            Assert.Equal("/api/v1/release-notes/v6.7.8", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Equal("6.7.8", notes.Version);
            Assert.Equal("<p>Fixed</p>", notes.ReleaseNotesHtml);
            Assert.Equal("Fixed", notes.ReleaseNotesMarkdown);
        }

        [Fact]
        public async Task GetCurrentReleaseNotes_Omits_Version_And_Accepts_Null_Notes()
        {
            var (api, cap) = Build<IAboutApi>("{\"version\":\"6.7.8\",\"release_notes\":null,\"release_notes_markdown\":null}");

            var notes = await api.GetCurrentReleaseNotes();

            Assert.Equal("/api/v1/release-notes", cap.LastRequest.RequestUri.AbsolutePath);
            Assert.Equal("6.7.8", notes.Version);
            Assert.Null(notes.ReleaseNotesHtml);
            Assert.Null(notes.ReleaseNotesMarkdown);
        }

        [Fact]
        public async Task BearerHandler_Attaches_Authorization()
        {
            var (api, cap) = Build<IAboutApi>("{}", token: () => "pat-123");

            await api.GetAbout();

            Assert.NotNull(cap.LastRequest.Headers.Authorization);
            Assert.Equal("Bearer", cap.LastRequest.Headers.Authorization.Scheme);
            Assert.Equal("pat-123", cap.LastRequest.Headers.Authorization.Parameter);
        }
    }
}
