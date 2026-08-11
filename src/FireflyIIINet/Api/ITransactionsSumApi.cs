using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface ITransactionsSumApi
    {
        [Get("/v2/subscriptions/sum/paid")]
        Task<List<TransactionSum>> GetSubscriptionsPaidTrSum([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v2/subscriptions/sum/unpaid")]
        Task<List<TransactionSum>> GetSubscriptionsUnpaidTrSum([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
