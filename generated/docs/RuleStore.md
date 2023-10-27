# FireflyIIINet.Model.RuleStore

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Title** | **string** |  | 
**Description** | **string** |  | [optional] 
**RuleGroupId** | **string** | ID of the rule group under which the rule must be stored. Either this field or rule_group_title is mandatory. | 
**RuleGroupTitle** | **string** | Title of the rule group under which the rule must be stored. Either this field or rule_group_id is mandatory. | [optional] 
**Order** | **int** |  | [optional] 
**Trigger** | **string** | Which action is necessary for the rule to fire? Use either store-journal or update-journal. | 
**Active** | **bool** | Whether or not the rule is even active. Default is true. | [optional] 
**Strict** | **bool** | If the rule is set to be strict, ALL triggers must hit in order for the rule to fire. Otherwise, just one is enough. Default value is true. | [optional] 
**StopProcessing** | **bool** | If this value is true and the rule is triggered, other rules  after this one in the group will be skipped. Default value is false. | [optional] 
**Triggers** | [**List&lt;RuleTriggerStore&gt;**](RuleTriggerStore.md) |  | 
**Actions** | [**List&lt;RuleActionStore&gt;**](RuleActionStore.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

