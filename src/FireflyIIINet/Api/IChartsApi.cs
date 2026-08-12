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
        Task<List<ChartDataSet>> GetChartAccountOverview([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, string period = null, string preselected = null);

        [Get("/v1/chart/balance/balance")]
        Task<List<ChartDataSet>> GetChartBalance([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, string period = null, string preselected = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/chart/budget/overview")]
        Task<List<ChartDataSet>> GetChartBudgetOverview([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/chart/category/overview")]
        Task<List<ChartDataSet>> GetChartCategoryOverview([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v2/chart/balance/balance")]
        Task<List<ChartDataSetV2>> GetBalanceChartV2([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts, PeriodProperty period, [Header("X-Trace-Id")] Guid? xTraceId = null, PreselectedAccountProperty? preselected = null);
    }
}
