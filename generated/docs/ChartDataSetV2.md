# FireflyIIINet.Model.ChartDataSetV2

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Label** | **string** | This is the label of the current data-set. It can refer to an object by name, or a collected set of data. | [optional] 
**CurrencyId** | **string** | The currency ID of the currency associated to the data in the entries. | [optional] 
**CurrencyCode** | **string** |  | [optional] 
**CurrencySymbol** | **string** |  | [optional] 
**CurrencyDecimalPlaces** | **int** | Number of decimals for the currency associated to the data in the entries. | [optional] 
**NativeId** | **string** | The currency ID of the user&#39;s native (default) currency. | [optional] 
**NativeCode** | **string** | The currency code of the user&#39;s native (default) currency. | [optional] 
**NativeSymbol** | **string** | The currency symbol of the user&#39;s native (default) currency. | [optional] 
**NativeDecimalPlaces** | **int** | Number of decimals for the native (default) currency of the user. | [optional] 
**Start** | **DateTime** | Holds the date and time of start of the range of data collected. It could be there was no data for this point in time, but this is the start of the requested range. | [optional] 
**End** | **DateTime** | Holds the date and time of END of the range of data collected. It could be there was no data for this point in time, but this is the end of the requested range. | [optional] 
**Period** | **ChartV2PeriodProperty** |  | [optional] 
**Entries** | [**List&lt;ChartDataPointV2&gt;**](ChartDataPointV2.md) | The actual entries for this data set. They &#39;key&#39; value is the label for the data point. The value is the actual (numerical) value. | [optional] 
**NativeEntries** | [**List&lt;ChartDataPointV2&gt;**](ChartDataPointV2.md) | The entries for this data set converted to the user&#39;s native (default) currency. They &#39;key&#39; value is the label for the data point. The value is the actual (numerical) value. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

