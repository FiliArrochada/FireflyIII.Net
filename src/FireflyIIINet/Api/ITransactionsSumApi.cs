using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface ITransactionsSumApi
    {
        [Get("/v2/bills/sum/paid")]
        Task<List<TransactionSum>> GetBillsPaidTrSum([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v2/bills/sum/unpaid")]
        Task<List<TransactionSum>> GetBillsUnpaidTrSum([Query(Format = "yyyy-MM-dd")] DateTime start, [Query(Format = "yyyy-MM-dd")] DateTime end, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
