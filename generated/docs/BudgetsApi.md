# FireflyIIINet.Api.BudgetsApi

All URIs are relative to *https://demo.firefly-iii.org/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteBudget**](BudgetsApi.md#deletebudget) | **DELETE** /v1/budgets/{id} | Delete a budget. |
| [**DeleteBudgetLimit**](BudgetsApi.md#deletebudgetlimit) | **DELETE** /v1/budgets/{id}/limits/{limitId} | Delete a budget limit. |
| [**GetBudget**](BudgetsApi.md#getbudget) | **GET** /v1/budgets/{id} | Get a single budget. |
| [**GetBudgetLimit**](BudgetsApi.md#getbudgetlimit) | **GET** /v1/budgets/{id}/limits/{limitId} | Get single budget limit. |
| [**GetBudgetedForBudget**](BudgetsApi.md#getbudgetedforbudget) | **GET** /v2/budgets/{id}/budgeted | Returns the budgeted amount for the given budget in the given period. |
| [**GetBudgetedForBudgets**](BudgetsApi.md#getbudgetedforbudgets) | **GET** /v2/budgets/sum/budgeted | Returns the budgeted amount for all budgets in the given period. |
| [**GetSpentForBudget**](BudgetsApi.md#getspentforbudget) | **GET** /v2/budgets/{id}/spent | Returns the spent amount for the given budget in the given period. |
| [**GetSpentForBudgets**](BudgetsApi.md#getspentforbudgets) | **GET** /v2/budgets/sum/spent | Returns the spent amount for all budgets in the given period. |
| [**ListAttachmentByBudget**](BudgetsApi.md#listattachmentbybudget) | **GET** /v1/budgets/{id}/attachments | Lists all attachments of a budget. |
| [**ListBudget**](BudgetsApi.md#listbudget) | **GET** /v1/budgets | List all budgets. |
| [**ListBudgetLimit**](BudgetsApi.md#listbudgetlimit) | **GET** /v1/budget-limits | Get list of budget limits by date |
| [**ListBudgetLimitByBudget**](BudgetsApi.md#listbudgetlimitbybudget) | **GET** /v1/budgets/{id}/limits | Get all limits for a budget. |
| [**ListBudgetLimitByBudgetV2**](BudgetsApi.md#listbudgetlimitbybudgetv2) | **GET** /v2/budgets/{id}/limits | Get all limits for a budget. |
| [**ListBudgets**](BudgetsApi.md#listbudgets) | **GET** /v2/budgets | List all budgets. |
| [**ListTransactionByBudget**](BudgetsApi.md#listtransactionbybudget) | **GET** /v1/budgets/{id}/transactions | All transactions to a budget. |
| [**ListTransactionByBudgetLimit**](BudgetsApi.md#listtransactionbybudgetlimit) | **GET** /v1/budgets/{id}/limits/{limitId}/transactions | List all transactions by a budget limit ID. |
| [**StoreBudget**](BudgetsApi.md#storebudget) | **POST** /v1/budgets | Store a new budget |
| [**StoreBudgetLimit**](BudgetsApi.md#storebudgetlimit) | **POST** /v1/budgets/{id}/limits | Store new budget limit. |
| [**UpdateBudget**](BudgetsApi.md#updatebudget) | **PUT** /v1/budgets/{id} | Update existing budget. |
| [**UpdateBudgetLimit**](BudgetsApi.md#updatebudgetlimit) | **PUT** /v1/budgets/{id}/limits/{limitId} | Update existing budget limit. |

<a id="deletebudget"></a>
# **DeleteBudget**
> void DeleteBudget (string id, Guid? xTraceId = null)

Delete a budget.

Delete a budget. Transactions will not be deleted.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DeleteBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Delete a budget.
                apiInstance.DeleteBudget(id, xTraceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.DeleteBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a budget.
    apiInstance.DeleteBudgetWithHttpInfo(id, xTraceId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.DeleteBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

void (empty response body)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Budget deleted. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletebudgetlimit"></a>
# **DeleteBudgetLimit**
> void DeleteBudgetLimit (string id, string limitId, Guid? xTraceId = null)

Delete a budget limit.

Delete a budget limit.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DeleteBudgetLimitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the budget. The budget limit MUST be associated to the budget ID.
            var limitId = 123;  // string | The ID of the budget limit. The budget limit MUST be associated to the budget ID.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Delete a budget limit.
                apiInstance.DeleteBudgetLimit(id, limitId, xTraceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.DeleteBudgetLimit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteBudgetLimitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a budget limit.
    apiInstance.DeleteBudgetLimitWithHttpInfo(id, limitId, xTraceId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.DeleteBudgetLimitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the budget. The budget limit MUST be associated to the budget ID. |  |
| **limitId** | **string** | The ID of the budget limit. The budget limit MUST be associated to the budget ID. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

void (empty response body)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Budget limit deleted. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getbudget"></a>
# **GetBudget**
> BudgetSingle GetBudget (string id, Guid? xTraceId = null, DateTime? start = null, DateTime? end = null)

Get a single budget.

Get a single budget. If the start date and end date are submitted as well, the \"spent\" array will be updated accordingly.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the requested budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to get info on how much the user has spent.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD, to get info on how much the user has spent.  (optional) 

            try
            {
                // Get a single budget.
                BudgetSingle result = apiInstance.GetBudget(id, xTraceId, start, end);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.GetBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single budget.
    ApiResponse<BudgetSingle> response = apiInstance.GetBudgetWithHttpInfo(id, xTraceId, start, end);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.GetBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the requested budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD, to get info on how much the user has spent.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD, to get info on how much the user has spent.  | [optional]  |

### Return type

[**BudgetSingle**](BudgetSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested budget |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getbudgetlimit"></a>
# **GetBudgetLimit**
> BudgetLimitSingle GetBudgetLimit (string id, int limitId, Guid? xTraceId = null)

Get single budget limit.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetBudgetLimitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the budget. The budget limit MUST be associated to the budget ID.
            var limitId = 1;  // int | The ID of the budget limit. The budget limit MUST be associated to the budget ID.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Get single budget limit.
                BudgetLimitSingle result = apiInstance.GetBudgetLimit(id, limitId, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.GetBudgetLimit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetBudgetLimitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get single budget limit.
    ApiResponse<BudgetLimitSingle> response = apiInstance.GetBudgetLimitWithHttpInfo(id, limitId, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.GetBudgetLimitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the budget. The budget limit MUST be associated to the budget ID. |  |
| **limitId** | **int** | The ID of the budget limit. The budget limit MUST be associated to the budget ID. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**BudgetLimitSingle**](BudgetLimitSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested budget limit |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getbudgetedforbudget"></a>
# **GetBudgetedForBudget**
> List&lt;TransactionSum&gt; GetBudgetedForBudget (DateTime start, DateTime end, string id, Guid? xTraceId = null, int? page = null)

Returns the budgeted amount for the given budget in the given period.

Returns the budgeted amount for the given budget in the given period. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetBudgetedForBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is per 50 items. (optional) 

            try
            {
                // Returns the budgeted amount for the given budget in the given period.
                List<TransactionSum> result = apiInstance.GetBudgetedForBudget(start, end, id, xTraceId, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.GetBudgetedForBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetBudgetedForBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns the budgeted amount for the given budget in the given period.
    ApiResponse<List<TransactionSum>> response = apiInstance.GetBudgetedForBudgetWithHttpInfo(start, end, id, xTraceId, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.GetBudgetedForBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **end** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **id** | **string** | The ID of the budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **page** | **int?** | Page number. The default pagination is per 50 items. | [optional]  |

### Return type

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **200** | An array of sums. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getbudgetedforbudgets"></a>
# **GetBudgetedForBudgets**
> List&lt;TransactionSum&gt; GetBudgetedForBudgets (DateTime start, DateTime end, string id, Guid? xTraceId = null, int? page = null)

Returns the budgeted amount for all budgets in the given period.

Returns the budgeted amount for all budgets in the given period. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetBudgetedForBudgetsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is per 50 items. (optional) 

            try
            {
                // Returns the budgeted amount for all budgets in the given period.
                List<TransactionSum> result = apiInstance.GetBudgetedForBudgets(start, end, id, xTraceId, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.GetBudgetedForBudgets: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetBudgetedForBudgetsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns the budgeted amount for all budgets in the given period.
    ApiResponse<List<TransactionSum>> response = apiInstance.GetBudgetedForBudgetsWithHttpInfo(start, end, id, xTraceId, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.GetBudgetedForBudgetsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **end** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **id** | **string** | The ID of the budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **page** | **int?** | Page number. The default pagination is per 50 items. | [optional]  |

### Return type

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **200** | An array of sums. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getspentforbudget"></a>
# **GetSpentForBudget**
> List&lt;TransactionSum&gt; GetSpentForBudget (DateTime start, DateTime end, string id, Guid? xTraceId = null, int? page = null)

Returns the spent amount for the given budget in the given period.

Returns the spent amount for the given budget in the given period. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetSpentForBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is per 50 items. (optional) 

            try
            {
                // Returns the spent amount for the given budget in the given period.
                List<TransactionSum> result = apiInstance.GetSpentForBudget(start, end, id, xTraceId, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.GetSpentForBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSpentForBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns the spent amount for the given budget in the given period.
    ApiResponse<List<TransactionSum>> response = apiInstance.GetSpentForBudgetWithHttpInfo(start, end, id, xTraceId, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.GetSpentForBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **end** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **id** | **string** | The ID of the budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **page** | **int?** | Page number. The default pagination is per 50 items. | [optional]  |

### Return type

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **200** | An array of sums. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getspentforbudgets"></a>
# **GetSpentForBudgets**
> List&lt;TransactionSum&gt; GetSpentForBudgets (DateTime start, DateTime end, string id, Guid? xTraceId = null, int? page = null)

Returns the spent amount for all budgets in the given period.

Returns the spent amount for all budgets in the given period. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetSpentForBudgetsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is per 50 items. (optional) 

            try
            {
                // Returns the spent amount for all budgets in the given period.
                List<TransactionSum> result = apiInstance.GetSpentForBudgets(start, end, id, xTraceId, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.GetSpentForBudgets: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSpentForBudgetsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns the spent amount for all budgets in the given period.
    ApiResponse<List<TransactionSum>> response = apiInstance.GetSpentForBudgetsWithHttpInfo(start, end, id, xTraceId, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.GetSpentForBudgetsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **end** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **id** | **string** | The ID of the budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **page** | **int?** | Page number. The default pagination is per 50 items. | [optional]  |

### Return type

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **200** | An array of sums. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listattachmentbybudget"></a>
# **ListAttachmentByBudget**
> AttachmentArray ListAttachmentByBudget (string id, Guid? xTraceId = null, int? page = null)

Lists all attachments of a budget.

Lists all attachments.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListAttachmentByBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // Lists all attachments of a budget.
                AttachmentArray result = apiInstance.ListAttachmentByBudget(id, xTraceId, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.ListAttachmentByBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListAttachmentByBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Lists all attachments of a budget.
    ApiResponse<AttachmentArray> response = apiInstance.ListAttachmentByBudgetWithHttpInfo(id, xTraceId, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.ListAttachmentByBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**AttachmentArray**](AttachmentArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of attachments |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbudget"></a>
# **ListBudget**
> BudgetArray ListBudget (Guid? xTraceId = null, int? page = null, DateTime? start = null, DateTime? end = null)

List all budgets.

List all the budgets the user has made. If the start date and end date are submitted as well, the \"spent\" array will be updated accordingly.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to get info on how much the user has spent. You must submit both start and end.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD, to get info on how much the user has spent. You must submit both start and end.  (optional) 

            try
            {
                // List all budgets.
                BudgetArray result = apiInstance.ListBudget(xTraceId, page, start, end);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.ListBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all budgets.
    ApiResponse<BudgetArray> response = apiInstance.ListBudgetWithHttpInfo(xTraceId, page, start, end);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.ListBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD, to get info on how much the user has spent. You must submit both start and end.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD, to get info on how much the user has spent. You must submit both start and end.  | [optional]  |

### Return type

[**BudgetArray**](BudgetArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of budgets. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbudgetlimit"></a>
# **ListBudgetLimit**
> BudgetLimitArray ListBudgetLimit (DateTime start, DateTime end, Guid? xTraceId = null)

Get list of budget limits by date

Get all budget limits for for this date range. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListBudgetLimitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime | A date formatted YYYY-MM-DD. 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Get list of budget limits by date
                BudgetLimitArray result = apiInstance.ListBudgetLimit(start, end, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.ListBudgetLimit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListBudgetLimitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get list of budget limits by date
    ApiResponse<BudgetLimitArray> response = apiInstance.ListBudgetLimitWithHttpInfo(start, end, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.ListBudgetLimitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **end** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**BudgetLimitArray**](BudgetLimitArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of budget limits. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbudgetlimitbybudget"></a>
# **ListBudgetLimitByBudget**
> BudgetLimitArray ListBudgetLimitByBudget (string id, Guid? xTraceId = null, DateTime? start = null, DateTime? end = null)

Get all limits for a budget.

Get all budget limits for this budget and the money spent, and money left. You can limit the list by submitting a date range as well. The \"spent\" array for each budget limit is NOT influenced by the start and end date of your query, but by the start and end date of the budget limit itself. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListBudgetLimitByBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the requested budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 

            try
            {
                // Get all limits for a budget.
                BudgetLimitArray result = apiInstance.ListBudgetLimitByBudget(id, xTraceId, start, end);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.ListBudgetLimitByBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListBudgetLimitByBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get all limits for a budget.
    ApiResponse<BudgetLimitArray> response = apiInstance.ListBudgetLimitByBudgetWithHttpInfo(id, xTraceId, start, end);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.ListBudgetLimitByBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the requested budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |

### Return type

[**BudgetLimitArray**](BudgetLimitArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of budget limits applicable to this budget. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbudgetlimitbybudgetv2"></a>
# **ListBudgetLimitByBudgetV2**
> BudgetLimitV2Array ListBudgetLimitByBudgetV2 (DateTime start, DateTime end, string id, Guid? xTraceId = null)

Get all limits for a budget.

Get all budget limits for this budget. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListBudgetLimitByBudgetV2Example
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var id = 123;  // string | The ID of the requested budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Get all limits for a budget.
                BudgetLimitV2Array result = apiInstance.ListBudgetLimitByBudgetV2(start, end, id, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.ListBudgetLimitByBudgetV2: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListBudgetLimitByBudgetV2WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get all limits for a budget.
    ApiResponse<BudgetLimitV2Array> response = apiInstance.ListBudgetLimitByBudgetV2WithHttpInfo(start, end, id, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.ListBudgetLimitByBudgetV2WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **end** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **id** | **string** | The ID of the requested budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**BudgetLimitV2Array**](BudgetLimitV2Array.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of budget limits applicable to this budget. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbudgets"></a>
# **ListBudgets**
> BudgetV2Array ListBudgets (Guid? xTraceId = null, int? page = null)

List all budgets.

List all the budgets the user has made.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListBudgetsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List all budgets.
                BudgetV2Array result = apiInstance.ListBudgets(xTraceId, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.ListBudgets: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListBudgetsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all budgets.
    ApiResponse<BudgetV2Array> response = apiInstance.ListBudgetsWithHttpInfo(xTraceId, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.ListBudgetsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**BudgetV2Array**](BudgetV2Array.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of budgets. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listtransactionbybudget"></a>
# **ListTransactionByBudget**
> TransactionArray ListTransactionByBudget (string id, Guid? xTraceId = null, int? limit = null, int? page = null, DateTime? start = null, DateTime? end = null, TransactionTypeFilter? type = null)

All transactions to a budget.

Get all transactions linked to a budget, possibly limited by start and end

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListTransactionByBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var limit = 5;  // int? | Limits the number of results on one page. (optional) 
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 
            var type = new TransactionTypeFilter?(); // TransactionTypeFilter? | Optional filter on the transaction type(s) returned (optional) 

            try
            {
                // All transactions to a budget.
                TransactionArray result = apiInstance.ListTransactionByBudget(id, xTraceId, limit, page, start, end, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.ListTransactionByBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListTransactionByBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // All transactions to a budget.
    ApiResponse<TransactionArray> response = apiInstance.ListTransactionByBudgetWithHttpInfo(id, xTraceId, limit, page, start, end, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.ListTransactionByBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **limit** | **int?** | Limits the number of results on one page. | [optional]  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |
| **type** | [**TransactionTypeFilter?**](TransactionTypeFilter?.md) | Optional filter on the transaction type(s) returned | [optional]  |

### Return type

[**TransactionArray**](TransactionArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of transactions. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listtransactionbybudgetlimit"></a>
# **ListTransactionByBudgetLimit**
> TransactionArray ListTransactionByBudgetLimit (string id, string limitId, Guid? xTraceId = null, int? page = null, TransactionTypeFilter? type = null)

List all transactions by a budget limit ID.

List all the transactions within one budget limit. The start and end date are dictated by the budget limit.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListTransactionByBudgetLimitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the budget. The budget limit MUST be associated to the budget ID.
            var limitId = 123;  // string | The ID of the budget limit. The budget limit MUST be associated to the budget ID.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 
            var type = new TransactionTypeFilter?(); // TransactionTypeFilter? | Optional filter on the transaction type(s) returned (optional) 

            try
            {
                // List all transactions by a budget limit ID.
                TransactionArray result = apiInstance.ListTransactionByBudgetLimit(id, limitId, xTraceId, page, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.ListTransactionByBudgetLimit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListTransactionByBudgetLimitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all transactions by a budget limit ID.
    ApiResponse<TransactionArray> response = apiInstance.ListTransactionByBudgetLimitWithHttpInfo(id, limitId, xTraceId, page, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.ListTransactionByBudgetLimitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the budget. The budget limit MUST be associated to the budget ID. |  |
| **limitId** | **string** | The ID of the budget limit. The budget limit MUST be associated to the budget ID. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |
| **type** | [**TransactionTypeFilter?**](TransactionTypeFilter?.md) | Optional filter on the transaction type(s) returned | [optional]  |

### Return type

[**TransactionArray**](TransactionArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of transactions. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storebudget"></a>
# **StoreBudget**
> BudgetSingle StoreBudget (BudgetStore budgetStore, Guid? xTraceId = null)

Store a new budget

Creates a new budget. The data required can be submitted as a JSON body or as a list of parameters.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class StoreBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var budgetStore = new BudgetStore(); // BudgetStore | JSON array or key=value pairs with the necessary budget information. See the model for the exact specifications.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Store a new budget
                BudgetSingle result = apiInstance.StoreBudget(budgetStore, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.StoreBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StoreBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Store a new budget
    ApiResponse<BudgetSingle> response = apiInstance.StoreBudgetWithHttpInfo(budgetStore, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.StoreBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **budgetStore** | [**BudgetStore**](BudgetStore.md) | JSON array or key&#x3D;value pairs with the necessary budget information. See the model for the exact specifications. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**BudgetSingle**](BudgetSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New budget stored, result in response. |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storebudgetlimit"></a>
# **StoreBudgetLimit**
> BudgetLimitSingle StoreBudgetLimit (string id, BudgetLimitStore budgetLimitStore, Guid? xTraceId = null)

Store new budget limit.

Store a new budget limit under this budget.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class StoreBudgetLimitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the budget.
            var budgetLimitStore = new BudgetLimitStore(); // BudgetLimitStore | JSON array or key=value pairs with the necessary budget information. See the model for the exact specifications.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Store new budget limit.
                BudgetLimitSingle result = apiInstance.StoreBudgetLimit(id, budgetLimitStore, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.StoreBudgetLimit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StoreBudgetLimitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Store new budget limit.
    ApiResponse<BudgetLimitSingle> response = apiInstance.StoreBudgetLimitWithHttpInfo(id, budgetLimitStore, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.StoreBudgetLimitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the budget. |  |
| **budgetLimitStore** | [**BudgetLimitStore**](BudgetLimitStore.md) | JSON array or key&#x3D;value pairs with the necessary budget information. See the model for the exact specifications. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**BudgetLimitSingle**](BudgetLimitSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New budget limit stored, result in response. |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatebudget"></a>
# **UpdateBudget**
> BudgetSingle UpdateBudget (string id, BudgetUpdate budgetUpdate, Guid? xTraceId = null)

Update existing budget.

Update existing budget. This endpoint cannot be used to set budget amount limits.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class UpdateBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the budget.
            var budgetUpdate = new BudgetUpdate(); // BudgetUpdate | JSON array with updated budget information. See the model for the exact specifications.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Update existing budget.
                BudgetSingle result = apiInstance.UpdateBudget(id, budgetUpdate, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.UpdateBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing budget.
    ApiResponse<BudgetSingle> response = apiInstance.UpdateBudgetWithHttpInfo(id, budgetUpdate, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.UpdateBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the budget. |  |
| **budgetUpdate** | [**BudgetUpdate**](BudgetUpdate.md) | JSON array with updated budget information. See the model for the exact specifications. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**BudgetSingle**](BudgetSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated budget stored, result in response |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatebudgetlimit"></a>
# **UpdateBudgetLimit**
> BudgetLimitSingle UpdateBudgetLimit (string id, string limitId, BudgetLimit budgetLimit, Guid? xTraceId = null)

Update existing budget limit.

Update existing budget limit.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class UpdateBudgetLimitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 123;  // string | The ID of the budget. The budget limit MUST be associated to the budget ID.
            var limitId = 123;  // string | The ID of the budget limit. The budget limit MUST be associated to the budget ID.
            var budgetLimit = new BudgetLimit(); // BudgetLimit | JSON array with updated budget limit information. See the model for the exact specifications.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Update existing budget limit.
                BudgetLimitSingle result = apiInstance.UpdateBudgetLimit(id, limitId, budgetLimit, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BudgetsApi.UpdateBudgetLimit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateBudgetLimitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing budget limit.
    ApiResponse<BudgetLimitSingle> response = apiInstance.UpdateBudgetLimitWithHttpInfo(id, limitId, budgetLimit, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BudgetsApi.UpdateBudgetLimitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the budget. The budget limit MUST be associated to the budget ID. |  |
| **limitId** | **string** | The ID of the budget limit. The budget limit MUST be associated to the budget ID. |  |
| **budgetLimit** | [**BudgetLimit**](BudgetLimit.md) | JSON array with updated budget limit information. See the model for the exact specifications. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**BudgetLimitSingle**](BudgetLimitSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated budget limit stored, result in response |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

