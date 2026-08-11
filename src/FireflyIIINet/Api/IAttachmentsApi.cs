using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IAttachmentsApi
    {
        [Delete("/v1/attachments/{id}")]
        Task DeleteAttachment(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/attachments/{id}/download")]
        Task<Stream> DownloadAttachment(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/attachments/{id}")]
        Task<AttachmentSingle> GetAttachment(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/attachments")]
        Task<AttachmentArray> ListAttachment([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Post("/v1/attachments")]
        [Headers("Content-Type: application/json")]
        Task<AttachmentSingle> StoreAttachment([Body] AttachmentStore attachmentStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/attachments/{id}")]
        [Headers("Content-Type: application/json")]
        Task<AttachmentSingle> UpdateAttachment(string id, [Body] AttachmentUpdate attachmentUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Post("/v1/attachments/{id}/upload")]
        [Headers("Content-Type: application/octet-stream")]
        Task UploadAttachment(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, [Body] Stream body = null);
    }
}
