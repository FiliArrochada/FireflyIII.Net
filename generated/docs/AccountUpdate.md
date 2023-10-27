# FireflyIIINet.Model.AccountUpdate

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** |  | 
**Iban** | **string** |  | [optional] 
**Bic** | **string** |  | [optional] 
**AccountNumber** | **string** |  | [optional] 
**OpeningBalance** | **string** |  | [optional] 
**OpeningBalanceDate** | **DateTime?** |  | [optional] 
**VirtualBalance** | **string** |  | [optional] 
**CurrencyId** | **string** | Use either currency_id or currency_code. Defaults to the user&#39;s default currency. | [optional] 
**CurrencyCode** | **string** | Use either currency_id or currency_code. Defaults to the user&#39;s default currency. | [optional] 
**Active** | **bool** | If omitted, defaults to true. | [optional] [default to true]
**Order** | **int** | Order of the account | [optional] 
**IncludeNetWorth** | **bool** | If omitted, defaults to true. | [optional] [default to true]
**AccountRole** | **AccountRoleProperty** |  | [optional] 
**CreditCardType** | **CreditCardType** |  | [optional] 
**MonthlyPaymentDate** | **DateTime?** | Mandatory when the account_role is ccAsset. Moment at which CC payment installments are asked for by the bank. | [optional] 
**LiabilityType** | **LiabilityType** |  | [optional] 
**Interest** | **string** | Mandatory when type is liability. Interest percentage. | [optional] 
**InterestPeriod** | **InterestPeriod** |  | [optional] 
**Notes** | **string** |  | [optional] 
**Latitude** | **double?** | Latitude of the account&#39;s location, if applicable. Can be used to draw a map. If omitted, the existing location will be kept. If submitted as NULL, the current location will be removed. | [optional] 
**Longitude** | **double?** | Latitude of the account&#39;s location, if applicable. Can be used to draw a map. If omitted, the existing location will be kept. If submitted as NULL, the current location will be removed. | [optional] 
**ZoomLevel** | **int?** | Zoom level for the map, if drawn. This to set the box right. Unfortunately this is a proprietary value because each map provider has different zoom levels. If omitted, the existing location will be kept. If submitted as NULL, the current location will be removed. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

