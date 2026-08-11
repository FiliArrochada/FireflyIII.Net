/*
 * Fixture tests: deserialization of realistic Attachment payloads built from the
 * example values in api/firefly-iii-6.1.21-v1.yaml (Attachment / AttachmentRead schemas).
 *
 * Note: the only date-time properties of Attachment (created_at/updated_at) are
 * generated read-only (private setters), as are mime and size. They are included in
 * the payloads for realism but not asserted: System.Text.Json does not populate
 * non-public setters without [JsonInclude].
 */

using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class AttachmentsFixtureTests
    {
        private const string AttachmentSingleJson = """
        {
          "data": {
            "type": "attachments",
            "id": "191",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "attachable_type": "TransactionJournal",
              "attachable_id": "134",
              "md5": "0c3f95f34370baa88f9fd9a671fea305",
              "filename": "file.pdf",
              "download_url": "https://demo.firefly-iii.org/api/v1/attachments/191/download",
              "upload_url": "https://demo.firefly-iii.org/api/v1/attachments/191/download",
              "title": "Some PDF file",
              "notes": "Some notes",
              "mime": "application/pdf",
              "size": 48211
            }
          }
        }
        """;

        private const string AttachmentArrayJson = """
        {
          "data": [
            {
              "type": "attachments",
              "id": "191",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "attachable_type": "TransactionJournal",
                "attachable_id": "134",
                "md5": "0c3f95f34370baa88f9fd9a671fea305",
                "filename": "file.pdf",
                "download_url": "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                "upload_url": "https://demo.firefly-iii.org/api/v1/attachments/191/download",
                "title": "Some PDF file",
                "notes": "Some notes",
                "mime": "application/pdf",
                "size": 48211
              }
            },
            {
              "type": "attachments",
              "id": "192",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "attachable_type": "Bill",
                "attachable_id": "111",
                "md5": "0c3f95f34370baa88f9fd9a671fea305",
                "filename": "invoice.pdf",
                "download_url": "https://demo.firefly-iii.org/api/v1/attachments/192/download",
                "upload_url": "https://demo.firefly-iii.org/api/v1/attachments/192/download",
                "title": "Monthly rent invoice",
                "notes": null,
                "mime": "application/pdf",
                "size": 1024
              }
            }
          ],
          "meta": {
            "pagination": {
              "total": 2,
              "count": 2,
              "per_page": 50,
              "current_page": 1,
              "total_pages": 1
            }
          }
        }
        """;

        [Fact]
        public void AttachmentSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<AttachmentSingle>(AttachmentSingleJson, SerializerOptions.Default);

            Assert.NotNull(single);
            Assert.Equal("attachments", single.Data.Type);
            Assert.Equal("191", single.Data.Id);

            var attachment = single.Data.Attributes;
            Assert.Equal(AttachableType.TransactionJournal, attachment.AttachableType);
            Assert.Equal("134", attachment.AttachableId);
            Assert.Equal("0c3f95f34370baa88f9fd9a671fea305", attachment.Md5);
            Assert.Equal("file.pdf", attachment.Filename);
            Assert.Equal("https://demo.firefly-iii.org/api/v1/attachments/191/download", attachment.DownloadUrl);
            Assert.Equal("Some PDF file", attachment.Title);
            Assert.Equal("Some notes", attachment.Notes);
        }

        [Fact]
        public void AttachmentArray_Deserializes_Spec_Example()
        {
            var array = JsonSerializer.Deserialize<AttachmentArray>(AttachmentArrayJson, SerializerOptions.Default);

            Assert.NotNull(array);
            Assert.Equal(2, array.Data.Count);

            Assert.Equal("191", array.Data[0].Id);
            Assert.Equal(AttachableType.TransactionJournal, array.Data[0].Attributes.AttachableType);

            var second = array.Data[1];
            Assert.Equal("192", second.Id);
            Assert.Equal(AttachableType.Bill, second.Attributes.AttachableType);
            Assert.Equal("invoice.pdf", second.Attributes.Filename);
            Assert.Null(second.Attributes.Notes); // explicit null deserializes without error

            Assert.Equal(2, array.Meta.Pagination.Total);
            Assert.Equal(1, array.Meta.Pagination.TotalPages);
        }
    }
}
