# FireflyIIINet.Model.TransactionSplit

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**User** | **string** | User ID | [optional] [readonly] 
**TransactionJournalId** | **string** | ID of the underlying transaction journal. Each transaction consists of a transaction group (see the top ID) and one or more journals making up the splits of the transaction.  | [optional] [readonly] 
**Type** | **TransactionTypeProperty** |  | 
**Date** | **DateTime** | Date of the transaction | 
**Order** | **int?** | Order of this entry in the list of transactions. | [optional] 
**CurrencyId** | **string** | Currency ID. Default is the source account&#39;s currency, or the user&#39;s default currency. Can be used instead of currency_code. | [optional] 
**CurrencyCode** | **string** | Currency code. Default is the source account&#39;s currency, or the user&#39;s default currency. Can be used instead of currency_id. | [optional] 
**CurrencySymbol** | **string** |  | [optional] [readonly] 
**CurrencyName** | **string** |  | [optional] [readonly] 
**CurrencyDecimalPlaces** | **int** | Number of decimals used in this currency. | [optional] [readonly] 
**ForeignCurrencyId** | **string** | Currency ID of the foreign currency. Default is null. Is required when you submit a foreign amount. | [optional] 
**ForeignCurrencyCode** | **string** | Currency code of the foreign currency. Default is NULL. Can be used instead of the foreign_currency_id, but this or the ID is required when submitting a foreign amount. | [optional] 
**ForeignCurrencySymbol** | **string** |  | [optional] [readonly] 
**ForeignCurrencyDecimalPlaces** | **int?** | Number of decimals in the currency | [optional] [readonly] 
**Amount** | **string** | Amount of the transaction. | 
**ForeignAmount** | **string** | The amount in a foreign currency. | [optional] 
**Description** | **string** | Description of the transaction. | 
**SourceId** | **string** | ID of the source account. For a withdrawal or a transfer, this must always be an asset account. For deposits, this must be a revenue account. | 
**SourceName** | **string** | Name of the source account. For a withdrawal or a transfer, this must always be an asset account. For deposits, this must be a revenue account. Can be used instead of the source_id. If the transaction is a deposit, the source_name can be filled in freely: the account will be created based on the name. | [optional] 
**SourceIban** | **string** |  | [optional] [readonly] 
**SourceType** | **AccountTypeProperty** |  | [optional] 
**DestinationId** | **string** | ID of the destination account. For a deposit or a transfer, this must always be an asset account. For withdrawals this must be an expense account. | 
**DestinationName** | **string** | Name of the destination account. You can submit the name instead of the ID. For everything except transfers, the account will be auto-generated if unknown, so submitting a name is enough. | [optional] 
**DestinationIban** | **string** |  | [optional] [readonly] 
**DestinationType** | **AccountTypeProperty** |  | [optional] 
**BudgetId** | **string** | The budget ID for this transaction. | [optional] 
**BudgetName** | **string** | The name of the budget to be used. If the budget name is unknown, the ID will be used or the value will be ignored. | [optional] [readonly] 
**CategoryId** | **string** | The category ID for this transaction. | [optional] 
**CategoryName** | **string** | The name of the category to be used. If the category is unknown, it will be created. If the ID and the name point to different categories, the ID overrules the name. | [optional] 
**BillId** | **string** | Optional. Use either this or the bill_name | [optional] 
**BillName** | **string** | Optional. Use either this or the bill_id | [optional] 
**Reconciled** | **bool** | If the transaction has been reconciled already. When you set this, the amount can no longer be edited by the user. | [optional] 
**Notes** | **string** |  | [optional] 
**Tags** | **List&lt;string&gt;** | Array of tags. | [optional] 
**InternalReference** | **string** | Reference to internal reference of other systems. | [optional] 
**ExternalId** | **string** | Reference to external ID in other systems. | [optional] 
**ExternalUrl** | **string** | External, custom URL for this transaction. | [optional] 
**OriginalSource** | **string** | System generated identifier for original creator of transaction. | [optional] [readonly] 
**RecurrenceId** | **int?** | Reference to recurrence that made the transaction. | [optional] [readonly] 
**RecurrenceTotal** | **int?** | Total number of transactions expected to be created by this recurrence repetition. Will be 0 if infinite. | [optional] [readonly] 
**RecurrenceCount** | **int?** | The # of the current transaction created under this recurrence. | [optional] [readonly] 
**BunqPaymentId** | **string** | Internal ID of bunq transaction. DEPRECATED | [optional] 
**ImportHashV2** | **string** | Hash value of original import transaction (for duplicate detection). | [optional] [readonly] 
**SepaCc** | **string** | SEPA Clearing Code | [optional] 
**SepaCtOp** | **string** | SEPA Opposing Account Identifier | [optional] 
**SepaCtId** | **string** | SEPA end-to-end Identifier | [optional] 
**SepaDb** | **string** | SEPA mandate identifier | [optional] 
**SepaCountry** | **string** | SEPA Country | [optional] 
**SepaEp** | **string** | SEPA External Purpose indicator | [optional] 
**SepaCi** | **string** | SEPA Creditor Identifier | [optional] 
**SepaBatchId** | **string** | SEPA Batch ID | [optional] 
**InterestDate** | **DateTime?** |  | [optional] 
**BookDate** | **DateTime?** |  | [optional] 
**ProcessDate** | **DateTime?** |  | [optional] 
**DueDate** | **DateTime?** |  | [optional] 
**PaymentDate** | **DateTime?** |  | [optional] 
**InvoiceDate** | **DateTime?** |  | [optional] 
**Latitude** | **double?** | Latitude of the transaction&#39;s location, if applicable. Can be used to draw a map. | [optional] 
**Longitude** | **double?** | Latitude of the transaction&#39;s location, if applicable. Can be used to draw a map. | [optional] 
**ZoomLevel** | **int?** | Zoom level for the map, if drawn. This to set the box right. Unfortunately this is a proprietary value because each map provider has different zoom levels. | [optional] 
**HasAttachments** | **bool** | If the transaction has attachments. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

