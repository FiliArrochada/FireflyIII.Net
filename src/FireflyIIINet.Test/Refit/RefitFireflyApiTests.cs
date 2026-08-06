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
