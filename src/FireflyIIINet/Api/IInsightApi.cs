using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IInsightApi
    {
        [Get("/v1/insight/expense/asset")]
        Task<List<InsightGroupEntry>> InsightExpenseAsset([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/expense/bill")]
        Task<List<InsightGroupEntry>> InsightExpenseBill([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("bills[]")] List<long> bills = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/expense/budget")]
        Task<List<InsightGroupEntry>> InsightExpenseBudget([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("budgets[]")] List<long> budgets = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/expense/category")]
        Task<List<InsightGroupEntry>> InsightExpenseCategory([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("categories[]")] List<long> categories = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/expense/expense")]
        Task<List<InsightGroupEntry>> InsightExpenseExpense([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/expense/no-bill")]
        Task<List<InsightTotalEntry>> InsightExpenseNoBill([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/expense/no-budget")]
        Task<List<InsightTotalEntry>> InsightExpenseNoBudget([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/expense/no-category")]
        Task<List<InsightTotalEntry>> InsightExpenseNoCategory([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/expense/no-tag")]
        Task<List<InsightTotalEntry>> InsightExpenseNoTag([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/expense/tag")]
        Task<List<InsightGroupEntry>> InsightExpenseTag([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("tags[]")] List<long> tags = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/expense/total")]
        Task<List<InsightTotalEntry>> InsightExpenseTotal([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/income/asset")]
        Task<List<InsightGroupEntry>> InsightIncomeAsset([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/income/category")]
        Task<List<InsightGroupEntry>> InsightIncomeCategory([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("categories[]")] List<long> categories = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/income/no-category")]
        Task<List<InsightTotalEntry>> InsightIncomeNoCategory([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/income/no-tag")]
        Task<List<InsightTotalEntry>> InsightIncomeNoTag([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/income/revenue")]
        Task<List<InsightGroupEntry>> InsightIncomeRevenue([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/income/tag")]
        Task<List<InsightGroupEntry>> InsightIncomeTag([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("tags[]")] List<long> tags = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/income/total")]
        Task<List<InsightTotalEntry>> InsightIncomeTotal([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/transfer/category")]
        Task<List<InsightGroupEntry>> InsightTransferCategory([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("categories[]")] List<long> categories = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/transfer/no-category")]
        Task<List<InsightTotalEntry>> InsightTransferNoCategory([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/transfer/no-tag")]
        Task<List<InsightTotalEntry>> InsightTransferNoTag([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/transfer/tag")]
        Task<List<InsightGroupEntry>> InsightTransferTag([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("tags[]")] List<long> tags = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/transfer/total")]
        Task<List<InsightTotalEntry>> InsightTransferTotal([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);

        [Get("/v1/insight/transfer/asset")]
        Task<List<InsightTransferEntry>> InsightTransfers([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(CollectionFormat.Multi), AliasAs("accounts[]")] List<long> accounts = null);
    }
}
