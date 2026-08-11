using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface INetWorthApi
    {
        [Get("/v2/net-worth")]
        Task<Dictionary<string, NetWorthItem>> GetNetWorth([Query(Format = "yyyy-MM-dd")] DateTime date, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
