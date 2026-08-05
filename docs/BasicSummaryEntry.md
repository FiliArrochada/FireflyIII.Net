# FireflyIIINet.Model.BasicSummaryEntry

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Key** | **string** | This is a reference to the type of info shared, not influenced by translations or user preferences. The EUR value is a reference to the currency code. Possibilities are: balance-in-ABC, spent-in-ABC, earned-in-ABC, bills-paid-in-ABC, bills-unpaid-in-ABC, left-to-spend-in-ABC and net-worth-in-ABC. | [optional] 
**Title** | **string** | A translated title for the information shared. | [optional] 
**MonetaryValue** | **double** | The amount as a float. | [optional] 
**CurrencyId** | **string** | The currency ID of the associated currency. | [optional] 
**CurrencyCode** | **string** |  | [optional] 
**CurrencySymbol** | **string** |  | [optional] 
**CurrencyDecimalPlaces** | **int** | Number of decimals for the associated currency. | [optional] 
**ValueParsed** | **string** | The amount formatted according to the users locale | [optional] 
**LocalIcon** | **string** | Reference to a font-awesome icon without the fa- part. | [optional] 
**SubTitle** | **string** | A short explanation of the amounts origin. Already formatted according to the locale of the user or translated, if relevant. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

