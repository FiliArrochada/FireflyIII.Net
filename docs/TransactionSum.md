# FireflyIIINet.Model.TransactionSum

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | ID of the currency of this sum. | [optional] 
**Name** | **string** | Currency name associated with this sum. | [optional] 
**Symbol** | **string** | Currency symbol associated with this sum. | [optional] 
**Code** | **string** | Currency code associated with this sum. | [optional] 
**DecimalPlaces** | **int** | Number of decimal places for the currency associated with this sum. | [optional] 
**Sum** | **string** | Sum as a string. Can also be negative | [optional] 
**Converted** | **bool** | Indicates if this sum was converted to the user&#39;s native (default) currency. When false, the native_* fields will still be present and filled. | [optional] 
**NativeSum** | **string** | Sum as a string, expressed in the user&#39;s native (default) currency. Can also be negative | [optional] 
**NativeId** | **string** | The ID of the user&#39;s native (default) currency. | [optional] 
**NativeName** | **string** | The name of the user&#39;s native (default) currency | [optional] 
**NativeSymbol** | **string** | Currency symbol associated with this amount. | [optional] 
**NativeCode** | **string** | The currency code of the user&#39;s native (default) currency. | [optional] 
**NativeDecimalPlaces** | **int** | Number of decimal places for this currency. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

