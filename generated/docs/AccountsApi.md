# FireflyIIINet.Api.AccountsApi

All URIs are relative to *https://demo.firefly-iii.org/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ListTransactionByAccount**](AccountsApi.md#listtransactionbyaccount) | **GET** /v2/accounts/{id}/transactions | List all transactions related to the account. |

<a id="listtransactionbyaccount"></a>
# **ListTransactionByAccount**
> TransactionArray ListTransactionByAccount (string id, Guid? xTraceId = null, int? page = null, int? limit = null, DateTime? start = null, DateTime? end = null, TransactionTypeFilter? type = null)

List all transactions related to the account.

This endpoint returns a list of all the transactions connected to the account. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListTransactionByAccountExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new AccountsApi(config);
            var id = 123;  // string | The ID of the account.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is per 50 items. (optional) 
            var limit = 5;  // int? | Limits the number of results on one page. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 
            var end = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 
            var type = new TransactionTypeFilter?(); // TransactionTypeFilter? | Optional filter on the transaction type(s) returned. (optional) 

            try
            {
                // List all transactions related to the account.
                TransactionArray result = apiInstance.ListTransactionByAccount(id, xTraceId, page, limit, start, end, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AccountsApi.ListTransactionByAccount: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListTransactionByAccountWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all transactions related to the account.
    ApiResponse<TransactionArray> response = apiInstance.ListTransactionByAccountWithHttpInfo(id, xTraceId, page, limit, start, end, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AccountsApi.ListTransactionByAccountWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the account. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **page** | **int?** | Page number. The default pagination is per 50 items. | [optional]  |
| **limit** | **int?** | Limits the number of results on one page. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |
| **type** | [**TransactionTypeFilter?**](TransactionTypeFilter?.md) | Optional filter on the transaction type(s) returned. | [optional]  |

### Return type

[**TransactionArray**](TransactionArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **200** | A list of transactions |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

