# FireflyIIINet.Model.ChartDataSetV2

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Label** | **string** | This is the title of the current set. It can refer to an account, a budget or another object (by name). | [optional] 
**CurrencyId** | **string** | The currency ID of the currency associated to the data in the entries. | [optional] 
**CurrencyCode** | **string** |  | [optional] 
**CurrencySymbol** | **string** |  | [optional] 
**CurrencyDecimalPlaces** | **int** | Number of decimals for the currency associated to the data in the entries. | [optional] 
**NativeId** | **string** | The currency ID of the user&#39;s native currency. | [optional] 
**NativeCode** | **string** | The currency code of the user&#39;s native currency. | [optional] 
**NativeSymbol** | **string** | The currency symbol of the user&#39;s native currency. | [optional] 
**NativeDecimalPlaces** | **int** | Number of decimals for the native currency of the user. | [optional] 
**Converted** | **bool** | This variable holds whether or not the values in the &#39;entries&#39;-array are converted to the user&#39;s native currency. | [optional] 
**StartDate** | **DateTime** |  | [optional] 
**EndDate** | **DateTime** |  | [optional] 
**Type** | **string** | Indicated the type of chart that is expected to be rendered. You can safely ignore this if you want. | [optional] 
**YAxisID** | **int** | Used to indicate the Y axis for this data set. Is usually between 0 and 1 (left and right side of the chart). | [optional] 
**Entries** | [**List&lt;ChartDataPointV2&gt;**](ChartDataPointV2.md) | The actual entries for this data set. They &#39;key&#39; value is the label for the data point. The value is the actual (numerical) value. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

