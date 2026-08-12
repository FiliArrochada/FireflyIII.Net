using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface ICategoriesApi
    {
        [Delete("/v1/categories/{id}")]
        Task DeleteCategory(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/categories/{id}")]
        Task<CategorySingle> GetCategory(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null);

        [Get("/v1/categories/{id}/attachments")]
        Task<AttachmentArray> ListAttachmentByCategory(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/categories")]
        Task<CategoryArray> ListCategory([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/categories/{id}/transactions")]
        Task<TransactionArray> ListTransactionByCategory(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, TransactionTypeFilter? type = null);

        [Post("/v1/categories")]
        [Headers("Content-Type: application/json")]
        Task<CategorySingle> StoreCategory([Body] CategoryStore categoryStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/categories/{id}")]
        [Headers("Content-Type: application/json")]
        Task<CategorySingle> UpdateCategory(string id, [Body] CategoryUpdate categoryUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
