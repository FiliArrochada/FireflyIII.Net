using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IUserGroupsApi
    {
        [Get("/v1/user-groups/{id}")]
        Task<UserGroupSingle> GetUserGroup(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/user-groups")]
        Task<UserGroupArray> ListUserGroups([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Put("/v1/user-groups/{id}")]
        [Headers("Content-Type: application/json")]
        Task<UserGroupSingle> UpdateUserGroup(string id, [Body] UserGroupUpdate userGroupUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
