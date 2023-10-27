# FireflyIIINet.Model.Budget

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedAt** | **DateTime** |  | [optional] [readonly] 
**UpdatedAt** | **DateTime** |  | [optional] [readonly] 
**Name** | **string** |  | 
**Active** | **bool** |  | [optional] 
**Order** | **int** |  | [optional] [readonly] 
**AutoBudgetType** | **AutoBudgetType** |  | [optional] 
**AutoBudgetCurrencyId** | **string** | Use either currency_id or currency_code. Defaults to the user&#39;s default currency. | [optional] 
**AutoBudgetCurrencyCode** | **string** | Use either currency_id or currency_code. Defaults to the user&#39;s default currency. | [optional] 
**AutoBudgetAmount** | **string** |  | [optional] 
**AutoBudgetPeriod** | **AutoBudgetPeriod** |  | [optional] 
**Spent** | [**List&lt;BudgetSpent&gt;**](BudgetSpent.md) | Information on how much was spent in this budget. Is only filled in when the start and end date are submitted. | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

