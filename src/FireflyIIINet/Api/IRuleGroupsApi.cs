using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IRuleGroupsApi
    {
        [Delete("/v1/rule-groups/{id}")]
        Task DeleteRuleGroup(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        // Body-less POST: Content-Type is mandatory anyway, see IRulesApi.FireRule.
        [Post("/v1/rule-groups/{id}/trigger")]
        [Headers("Content-Type: application/json")]
        Task FireRuleGroup(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/rule-groups/{id}")]
        Task<RuleGroupSingle> GetRuleGroup(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/rule-groups/{id}/rules")]
        Task<RuleArray> ListRuleByGroup(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/rule-groups")]
        Task<RuleGroupArray> ListRuleGroup([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Post("/v1/rule-groups")]
        [Headers("Content-Type: application/json")]
        Task<RuleGroupSingle> StoreRuleGroup([Body] RuleGroupStore ruleGroupStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/rule-groups/{id}/test")]
        Task<TransactionArray> TestRuleGroup(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, [AliasAs("search_limit")] int? searchLimit = null, [AliasAs("triggered_limit")] int? triggeredLimit = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Put("/v1/rule-groups/{id}")]
        [Headers("Content-Type: application/json")]
        Task<RuleGroupSingle> UpdateRuleGroup(string id, [Body] RuleGroupUpdate ruleGroupUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
