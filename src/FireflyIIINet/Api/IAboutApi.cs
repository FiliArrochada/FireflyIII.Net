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
        // Body-less POST: Content-Type is mandatory anyway, see IRulesApi.FireRule.
        [Post("/v1/batch/finish")]
        [Headers("Content-Type: application/json")]
        Task FinishBatch([Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/about")]
        Task<SystemInfo> GetAbout([Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/cron/{cliToken}")]
        Task<CronResult> GetCron(string cliToken, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? date = null, bool? force = null);

        [Get("/v1/about/user")]
        Task<UserSingle> GetCurrentUser([Header("X-Trace-Id")] Guid? xTraceId = null);

        // version takes "6.7.8", "v6.7.8" or "develop-2026-10-12". The server route makes it
        // optional ({version?}); GetCurrentReleaseNotes is that form, for the server's own version.
        [Get("/v1/release-notes/{version}")]
        Task<ReleaseNotes> GetReleaseNotes(string version, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/release-notes")]
        Task<ReleaseNotes> GetCurrentReleaseNotes([Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
