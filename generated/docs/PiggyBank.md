# FireflyIIINet.Model.PiggyBank

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedAt** | **DateTime** |  | [optional] [readonly] 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 
**AccountId** | **string** | The ID of the asset account this piggy bank is connected to. | 
**AccountName** | **string** | The name of the asset account this piggy bank is connected to. | [optional] [readonly] 
**Name** | **string** |  | 
**CurrencyId** | **string** |  | [optional] [readonly] 
**CurrencyCode** | **string** |  | [optional] [readonly] 
**CurrencySymbol** | **string** |  | [optional] [readonly] 
**CurrencyDecimalPlaces** | **int** | Number of decimals supported by the currency | [optional] [readonly] 
**TargetAmount** | **string** |  | 
**Percentage** | **float** |  | [optional] [readonly] 
**CurrentAmount** | **string** |  | [optional] 
**LeftToSave** | **string** |  | [optional] [readonly] 
**SavePerMonth** | **string** |  | [optional] [readonly] 
**StartDate** | **DateTime** | The date you started with this piggy bank. | [optional] 
**TargetDate** | **DateTime?** | The date you intend to finish saving money. | [optional] 
**Order** | **int** |  | [optional] 
**Active** | **bool** |  | [optional] [readonly] 
**Notes** | **string** |  | [optional] 
**ObjectGroupId** | **string** | The group ID of the group this object is part of. NULL if no group. | [optional] 
**ObjectGroupOrder** | **int?** | The order of the group. At least 1, for the highest sorting. | [optional] [readonly] 
**ObjectGroupTitle** | **string** | The name of the group. NULL if no group. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

