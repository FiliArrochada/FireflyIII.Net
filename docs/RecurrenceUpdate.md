# FireflyIIINet.Model.RecurrenceUpdate

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Title** | **string** |  | [optional] 
**Description** | **string** | Not to be confused with the description of the actual transaction(s) being created. | [optional] 
**FirstDate** | **DateTime** | First time the recurring transaction will fire. | [optional] 
**RepeatUntil** | **DateTime?** | Date until the recurring transaction can fire. After that date, it&#39;s basically inactive. Use either this field or repetitions. | [optional] 
**NrOfRepetitions** | **int?** | Max number of created transactions. Use either this field or repeat_until. | [optional] 
**ApplyRules** | **bool** | Whether or not to fire the rules after the creation of a transaction. | [optional] 
**Active** | **bool** | If the recurrence is even active. | [optional] 
**Notes** | **string** |  | [optional] 
**Repetitions** | [**List&lt;RecurrenceRepetitionUpdate&gt;**](RecurrenceRepetitionUpdate.md) |  | [optional] 
**Transactions** | [**List&lt;RecurrenceTransactionUpdate&gt;**](RecurrenceTransactionUpdate.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

