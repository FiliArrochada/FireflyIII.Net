using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface ITagsApi
    {
        [Delete("/v1/tags/{tag}")]
        Task DeleteTag(string tag, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/tags/{tag}")]
        Task<TagSingle> GetTag(string tag, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/tags/{tag}/attachments")]
        Task<AttachmentArray> ListAttachmentByTag(string tag, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/tags")]
        Task<TagArray> ListTag([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/tags/{tag}/transactions")]
        Task<TransactionArray> ListTransactionByTag(string tag, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null, [Query(Format = "yyyy-MM-dd")] DateTime? start = null, [Query(Format = "yyyy-MM-dd")] DateTime? end = null, TransactionTypeFilter? type = null);

        [Post("/v1/tags")]
        [Headers("Content-Type: application/json")]
        Task<TagSingle> StoreTag([Body] TagModelStore tagModelStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/tags/{tag}")]
        [Headers("Content-Type: application/json")]
        Task<TagSingle> UpdateTag(string tag, [Body] TagModelUpdate tagModelUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
