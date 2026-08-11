using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface ISummaryApi
    {
        [Get("/v1/summary/basic")]
        Task<Dictionary<string, BasicSummaryEntry>> GetBasicSummary([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [AliasAs("currency_code")] string currencyCode = null);
    }
}
