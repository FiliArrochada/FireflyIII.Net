# FireflyIIINet.Model.Transaction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedAt** | **DateTime** |  | [optional] [readonly] 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 
**User** | **string** | User ID | [optional] [readonly] 
**ErrorIfDuplicateHash** | **bool** | Break if the submitted transaction exists already. | [optional] 
**ApplyRules** | **bool** | Whether or not to apply rules when submitting transaction. | [optional] 
**GroupTitle** | **string** | Title of the transaction if it has been split in more than one piece. Empty otherwise. | [optional] 
**Transactions** | [**List&lt;TransactionSplit&gt;**](TransactionSplit.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

