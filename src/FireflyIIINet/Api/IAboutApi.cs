using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IAboutApi
    {
        // The spec tags this batch endpoint "about".
        [Post("/v1/batch/finish")]
        Task FinishBatch([Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/about")]
        Task<SystemInfo> GetAbout([Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/cron/{cliToken}")]
        Task<CronResult> GetCron(string cliToken, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? date = null, bool? force = null);

        [Get("/v1/about/user")]
        Task<UserSingle> GetCurrentUser([Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
