using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IObjectGroupsApi
    {
        [Delete("/v1/object-groups/{id}")]
        Task DeleteObjectGroup(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/object-groups/{id}")]
        Task<ObjectGroupSingle> GetObjectGroup(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/object-groups/{id}/bills")]
        Task<BillArray> ListBillByObjectGroup(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/object-groups")]
        Task<ObjectGroupArray> ListObjectGroups([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/object-groups/{id}/piggy-banks")]
        Task<PiggyBankArray> ListPiggyBankByObjectGroup(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Put("/v1/object-groups/{id}")]
        [Headers("Content-Type: application/json")]
        Task<ObjectGroupSingle> UpdateObjectGroup(string id, [Body] ObjectGroupUpdate objectGroupUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
