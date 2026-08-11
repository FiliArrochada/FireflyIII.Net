using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IPiggyBanksApi
    {
        [Delete("/v1/piggy-banks/{id}")]
        Task DeletePiggyBank(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/piggy-banks/{id}")]
        Task<PiggyBankSingle> GetPiggyBank(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/piggy-banks/{id}/attachments")]
        Task<AttachmentArray> ListAttachmentByPiggyBank(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/piggy-banks/{id}/events")]
        Task<PiggyBankEventArray> ListEventByPiggyBank(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/piggy-banks")]
        Task<PiggyBankArray> ListPiggyBank([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Post("/v1/piggy-banks")]
        [Headers("Content-Type: application/json")]
        Task<PiggyBankSingle> StorePiggyBank([Body] PiggyBankStore piggyBankStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/piggy-banks/{id}")]
        [Headers("Content-Type: application/json")]
        Task<PiggyBankSingle> UpdatePiggyBank(string id, [Body] PiggyBankUpdate piggyBankUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
