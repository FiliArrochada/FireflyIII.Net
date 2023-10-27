# FireflyIIINet.Model.RuleUpdate

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Title** | **string** |  | [optional] 
**Description** | **string** |  | [optional] 
**RuleGroupId** | **string** | ID of the rule group under which the rule must be stored. Either this field or rule_group_title is mandatory. | [optional] 
**Order** | **int** |  | [optional] 
**Trigger** | **string** | Which action is necessary for the rule to fire? Use either store-journal or update-journal. | [optional] 
**Active** | **bool** | Whether or not the rule is even active. Default is true. | [optional] 
**Strict** | **bool** | If the rule is set to be strict, ALL triggers must hit in order for the rule to fire. Otherwise, just one is enough. Default value is true. | [optional] 
**StopProcessing** | **bool** | If this value is true and the rule is triggered, other rules  after this one in the group will be skipped. Default value is false. | [optional] 
**Triggers** | [**List&lt;RuleTriggerUpdate&gt;**](RuleTriggerUpdate.md) |  | [optional] 
**Actions** | [**List&lt;RuleActionUpdate&gt;**](RuleActionUpdate.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

