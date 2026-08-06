using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IUsersApi
    {
        [Delete("/v1/users/{id}")]
        Task DeleteUser(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/users/{id}")]
        Task<UserSingle> GetUser(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/users")]
        Task<UserArray> ListUser([Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null);

        [Post("/v1/users")]
        [Headers("Content-Type: application/json")]
        Task<UserSingle> StoreUser([Body] User user, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/users/{id}")]
        [Headers("Content-Type: application/json")]
        Task<UserSingle> UpdateUser(string id, [Body] User user, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
