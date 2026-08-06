using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IChartsApi
    {
        [Get("/v1/chart/account/overview")]
        Task<List<ChartDataSet>> GetChartAccountOverview([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v2/chart/account/dashboard")]
        Task<List<ChartDataSetV2>> GetChartAccountOverviewV2([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
