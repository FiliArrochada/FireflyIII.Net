# FireflyIIINet.Model.RuleTriggerStore

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** | The type of thing this trigger responds to. A limited set is possible | 
**Value** | **string** | The accompanying value the trigger responds to. This value is often mandatory, but this depends on the trigger. | 
**Order** | **int** | Order of the trigger | [optional] 
**Active** | **bool** | If the trigger is active. Defaults to true. | [optional] 
**StopProcessing** | **bool** | When true, other triggers will not be checked if this trigger was triggered. Defaults to false. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

