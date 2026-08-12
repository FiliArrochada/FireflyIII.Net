/*
 * Fixture tests built from the Firefly III OpenAPI spec examples (firefly-iii-6.2.1-v1.yaml),
 * asserting the wire format maps onto the generated models.
 *
 * Note: created_at/updated_at are readOnly in the spec and generated with private setters, so
 * System.Text.Json does not populate them; they are kept in the payloads to prove they parse
 * without error. The ObjectGroup schema has no enum-typed or nullable property, so those
 * assertions are not applicable in this area.
 */

using System;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class ObjectGroupsFixtureTests
    {
        private const string ObjectGroupSingleJson = """
        {
          "data": {
            "type": "object_groups",
            "id": "2",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "title": "My object group",
              "order": 1
            }
          }
        }
        """;

        private const string ObjectGroupArrayJson = """
        {
          "data": [
            {
              "type": "object_groups",
              "id": "1",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "title": "My object group",
                "order": 1
              }
            },
            {
              "type": "object_groups",
              "id": "2",
              "attributes": {
                "created_at": "2018-10-01T09:00:00+01:00",
                "updated_at": "2018-10-01T09:00:00+01:00",
                "title": "Example Group",
                "order": 2
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
        public void ObjectGroupSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<ObjectGroupSingle>(ObjectGroupSingleJson, SerializerOptions.Default);

            Assert.NotNull(single);
            Assert.Equal("object_groups", single.Data.Type);
            Assert.Equal("2", single.Data.Id);
            Assert.Equal("My object group", single.Data.Attributes.Title);
            Assert.Equal(1, single.Data.Attributes.Order);
        }

        [Fact]
        public void ObjectGroupArray_Deserializes_Spec_Example()
        {
            var array = JsonSerializer.Deserialize<ObjectGroupArray>(ObjectGroupArrayJson, SerializerOptions.Default);

            Assert.Equal(2, array.Data.Count);
            Assert.Equal("1", array.Data[0].Id);
            Assert.Equal("My object group", array.Data[0].Attributes.Title);
            Assert.Equal("Example Group", array.Data[1].Attributes.Title);
            Assert.Equal(2, array.Data[1].Attributes.Order);

            Assert.Equal(2, array.Meta.Pagination.Total);
            Assert.Equal(50, array.Meta.Pagination.PerPage);
            Assert.Equal(1, array.Meta.Pagination.TotalPages);
        }
    }
}
