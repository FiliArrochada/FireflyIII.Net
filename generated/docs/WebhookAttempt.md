# FireflyIIINet.Model.WebhookAttempt

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedAt** | **DateTime** |  | [optional] [readonly] 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 
**WebhookMessageId** | **string** | The ID of the webhook message this attempt belongs to. | [optional] 
**StatusCode** | **int?** | The HTTP status code of the error, if any. | [optional] 
**Logs** | **string** | Internal log for this attempt. May contain sensitive user data. | [optional] 
**Response** | **string** | Webhook receiver response for this attempt, if any. May contain sensitive user data. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

