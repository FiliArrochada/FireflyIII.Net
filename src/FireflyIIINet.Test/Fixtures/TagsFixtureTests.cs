/*
 * Fixture tests: deserialization of realistic Tag payloads built from the
 * example values in api/firefly-iii-6.3.0-v1.yaml (TagModel / TagRead schemas).
 *
 * Notes:
 *  - TagModel has no enum property; the date-only "date" field (yyyy-MM-dd via
 *    OpenAPIDateConverter) provides the DateTime coverage instead.
 *  - created_at/updated_at are generated read-only (private setters) and are
 *    included in the payloads but not asserted: System.Text.Json does not
 *    populate non-public setters without [JsonInclude].
 */

using System;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class TagsFixtureTests
    {
        private const string TagSingleJson = """
        {
          "data": {
            "type": "tags",
            "id": "1",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "tag": "expensive",
              "date": "2018-09-17",
              "description": "Tag for expensive stuff",
              "latitude": 51.983333,
              "longitude": 5.916667,
              "zoom_level": 6
            }
          }
        }
        """;

        private const string TagArrayJson = """
        {
          "data": [
            {
              "type": "tags",
              "id": "1",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "tag": "expensive",
                "date": "2018-09-17",
                "description": "Tag for expensive stuff",
                "latitude": 51.983333,
                "longitude": 5.916667,
                "zoom_level": 6
              }
            },
            {
              "type": "tags",
              "id": "2",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "tag": "vacation",
                "date": null,
                "description": null,
                "latitude": null,
                "longitude": null,
                "zoom_level": null
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
        public void TagSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<TagSingle>(TagSingleJson, SerializerOptions.Default);

            Assert.NotNull(single);
            Assert.Equal("tags", single.Data.Type);
            Assert.Equal("1", single.Data.Id);

            var tag = single.Data.Attributes;
            Assert.Equal("expensive", tag.Tag);
            Assert.Equal(new DateTime(2018, 9, 17), tag.Date); // date-only, yyyy-MM-dd
            Assert.Equal("Tag for expensive stuff", tag.Description);
            Assert.Equal(51.983333, tag.Latitude);
            Assert.Equal(5.916667, tag.Longitude);
            Assert.Equal(6, tag.ZoomLevel);
        }

        [Fact]
        public void TagArray_Deserializes_Spec_Example()
        {
            var array = JsonSerializer.Deserialize<TagArray>(TagArrayJson, SerializerOptions.Default);

            Assert.NotNull(array);
            Assert.Equal(2, array.Data.Count);
            Assert.Equal("expensive", array.Data[0].Attributes.Tag);

            // nullable fields present as explicit null deserialize without error
            var second = array.Data[1].Attributes;
            Assert.Equal("vacation", second.Tag);
            Assert.Null(second.Date);
            Assert.Null(second.Description);
            Assert.Null(second.Latitude);
            Assert.Null(second.ZoomLevel);

            Assert.Equal(2, array.Meta.Pagination.Total);
            Assert.Equal(1, array.Meta.Pagination.CurrentPage);
        }
    }
}
