# FireflyIIINet.Api.SearchApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**SearchAccounts**](SearchApi.md#searchaccounts) | **GET** /api/v1/search/accounts | Search for accounts |
| [**SearchTransactions**](SearchApi.md#searchtransactions) | **GET** /api/v1/search/transactions | Search for transactions |

<a id="searchaccounts"></a>
# **SearchAccounts**
> AccountArray SearchAccounts (string query, AccountSearchFieldFilter field, int? page = null, AccountTypeFilter type = null)

Search for accounts

Search for accounts

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class SearchAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SearchApi(config);
            var query = checking;  // string | The query you wish to search for.
            var field = new AccountSearchFieldFilter(); // AccountSearchFieldFilter | The account field(s) you want to search in.
            var page = 1;  // int? | Page number. The default pagination is 50 (optional) 
            var type = new AccountTypeFilter(); // AccountTypeFilter | The type of accounts you wish to limit the search to. (optional) 

            try
            {
                // Search for accounts
                AccountArray result = apiInstance.SearchAccounts(query, field, page, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchApi.SearchAccounts: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchAccountsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search for accounts
    ApiResponse<AccountArray> response = apiInstance.SearchAccountsWithHttpInfo(query, field, page, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchApi.SearchAccountsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **query** | **string** | The query you wish to search for. |  |
| **field** | [**AccountSearchFieldFilter**](AccountSearchFieldFilter.md) | The account field(s) you want to search in. |  |
| **page** | **int?** | Page number. The default pagination is 50 | [optional]  |
| **type** | [**AccountTypeFilter**](AccountTypeFilter.md) | The type of accounts you wish to limit the search to. | [optional]  |

### Return type

[**AccountArray**](AccountArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of accounts. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="searchtransactions"></a>
# **SearchTransactions**
> TransactionArray SearchTransactions (string query, int? page = null)

Search for transactions

Searches through the users transactions.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class SearchTransactionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SearchApi(config);
            var query = groceries;  // string | The query you wish to search for.
            var page = 1;  // int? | Page number. The default pagination is 50 (optional) 

            try
            {
                // Search for transactions
                TransactionArray result = apiInstance.SearchTransactions(query, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchApi.SearchTransactions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchTransactionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Search for transactions
    ApiResponse<TransactionArray> response = apiInstance.SearchTransactionsWithHttpInfo(query, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchApi.SearchTransactionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **query** | **string** | The query you wish to search for. |  |
| **page** | **int?** | Page number. The default pagination is 50 | [optional]  |

### Return type

[**TransactionArray**](TransactionArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of transactions. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

