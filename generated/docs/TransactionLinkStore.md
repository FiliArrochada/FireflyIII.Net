# FireflyIIINet.Model.TransactionLinkStore

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**LinkTypeId** | **string** | The link type ID to use. You can also use the link_type_name field. | 
**LinkTypeName** | **string** | The link type name to use. You can also use the link_type_id field. | [optional] 
**InwardId** | **string** | The inward transaction transaction_journal_id for the link. This becomes the &#39;is paid by&#39; transaction of the set. | 
**OutwardId** | **string** | The outward transaction transaction_journal_id for the link. This becomes the &#39;pays for&#39; transaction of the set. | 
**Notes** | **string** | Optional. Some notes. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

