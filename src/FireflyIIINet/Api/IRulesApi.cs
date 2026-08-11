using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IRulesApi
    {
        [Delete("/v1/rules/{id}")]
        Task DeleteRule(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Post("/v1/rules/{id}/trigger")]
        Task FireRule(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/rules/{id}")]
        Task<RuleSingle> GetRule(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/rules")]
        Task<RuleArray> ListRule([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Post("/v1/rules")]
        [Headers("Content-Type: application/json")]
        Task<RuleSingle> StoreRule([Body] RuleStore ruleStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/rules/{id}/test")]
        Task<TransactionArray> TestRule(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Put("/v1/rules/{id}")]
        [Headers("Content-Type: application/json")]
        Task<RuleSingle> UpdateRule(string id, [Body] RuleUpdate ruleUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
