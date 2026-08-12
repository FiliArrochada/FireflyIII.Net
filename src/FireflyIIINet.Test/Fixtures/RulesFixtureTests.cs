/*
 * Fixture tests for the Rules area, fed by the example payloads from the
 * Firefly III OpenAPI spec (api/firefly-iii-6.2.8-v1.yaml, Rule / RuleTrigger /
 * RuleAction / RuleGroup schemas).
 *
 * Note: read-only spec fields (created_at, updated_at, trigger/action id, order on
 * Rule/RuleTrigger/RuleGroup) map onto private-setter properties and are present in
 * the payloads only to prove they deserialize without error; assertions target the
 * publicly settable properties.
 */

using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class RulesFixtureTests
    {
        private const string RuleSingleJson = """
        {
          "data": {
            "type": "rules",
            "id": "1",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "title": "First rule title.",
              "description": "First rule description",
              "rule_group_id": "81",
              "rule_group_title": "New rule group",
              "order": 5,
              "trigger": "store-journal",
              "active": true,
              "strict": true,
              "stop_processing": false,
              "triggers": [
                {
                  "id": "2",
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "type": "description_is",
                  "value": "tag1",
                  "order": 5,
                  "active": true,
                  "stop_processing": false
                },
                {
                  "id": "3",
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "type": "amount_less",
                  "value": "100",
                  "order": 6,
                  "active": true,
                  "stop_processing": false
                }
              ],
              "actions": [
                {
                  "id": "2",
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "type": "set_category",
                  "value": "Daily groceries",
                  "order": 5,
                  "active": true,
                  "stop_processing": false
                },
                {
                  "id": "3",
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "type": "remove_all_tags",
                  "value": null,
                  "order": 6,
                  "active": true,
                  "stop_processing": true
                }
              ]
            },
            "links": {
              "self": "https://demo.firefly-iii.org/api/v1/rules/1"
            }
          }
        }
        """;

        [Fact]
        public void RuleSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<RuleSingle>(RuleSingleJson, SerializerOptions.Default);

            Assert.Equal("rules", single.Data.Type);
            Assert.Equal("1", single.Data.Id);

            var rule = single.Data.Attributes;
            Assert.Equal("First rule title.", rule.Title);
            Assert.Equal("First rule description", rule.Description);
            Assert.Equal("81", rule.RuleGroupId);
            Assert.Equal("New rule group", rule.RuleGroupTitle);
            Assert.Equal(RuleTriggerType.StoreJournal, rule.Trigger);
            Assert.True(rule.Active);
            Assert.True(rule.Strict);
            Assert.False(rule.StopProcessing);
        }

        [Fact]
        public void RuleSingle_Maps_Triggers_And_Actions_Arrays()
        {
            var single = JsonSerializer.Deserialize<RuleSingle>(RuleSingleJson, SerializerOptions.Default);
            var rule = single.Data.Attributes;

            Assert.Equal(2, rule.Triggers.Count);
            Assert.Equal(RuleTriggerKeyword.DescriptionIs, rule.Triggers[0].Type);
            Assert.Equal("tag1", rule.Triggers[0].Value);
            Assert.True(rule.Triggers[0].Active);
            Assert.Equal(RuleTriggerKeyword.AmountLess, rule.Triggers[1].Type);
            Assert.Equal("100", rule.Triggers[1].Value);

            Assert.Equal(2, rule.Actions.Count);
            Assert.Equal(RuleActionKeyword.SetCategory, rule.Actions[0].Type);
            Assert.Equal("Daily groceries", rule.Actions[0].Value);
            Assert.Equal(5, rule.Actions[0].Order);
            Assert.Equal(RuleActionKeyword.RemoveAllTags, rule.Actions[1].Type);
            Assert.Null(rule.Actions[1].Value); // nullable per spec, explicit null on the wire
            Assert.True(rule.Actions[1].StopProcessing);
        }

        [Theory]
        [InlineData("store-journal", RuleTriggerType.StoreJournal)]
        [InlineData("update-journal", RuleTriggerType.UpdateJournal)]
        public void RuleTriggerType_Maps_All_Wire_Values(string wireValue, RuleTriggerType expected)
        {
            var json = $$"""
            {
              "title": "Rule",
              "rule_group_id": "81",
              "trigger": "{{wireValue}}",
              "triggers": [],
              "actions": []
            }
            """;
            var rule = JsonSerializer.Deserialize<Rule>(json, SerializerOptions.Default);
            Assert.Equal(expected, rule.Trigger);
        }

        [Fact]
        public void RuleGroupSingle_Deserializes_Spec_Example()
        {
            const string json = """
            {
              "data": {
                "type": "rule_groups",
                "id": "81",
                "attributes": {
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "title": "Default rule group",
                  "description": null,
                  "order": 4,
                  "active": true
                },
                "links": {
                  "self": "https://demo.firefly-iii.org/api/v1/rule-groups/81"
                }
              }
            }
            """;

            var single = JsonSerializer.Deserialize<RuleGroupSingle>(json, SerializerOptions.Default);

            Assert.Equal("rule_groups", single.Data.Type);
            Assert.Equal("81", single.Data.Id);
            Assert.Equal("Default rule group", single.Data.Attributes.Title);
            Assert.Null(single.Data.Attributes.Description); // nullable per spec, explicit null
            Assert.True(single.Data.Attributes.Active);
        }
    }
}
