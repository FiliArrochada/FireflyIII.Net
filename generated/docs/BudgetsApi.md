# FireflyIIINet.Api.BudgetsApi

All URIs are relative to *https://demo.firefly-iii.org/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetBudgetedForBudget**](BudgetsApi.md#getbudgetedforbudget) | **GET** /v2/budgets/{id}/budgeted | Returns the budgeted amount for the given budget in the given period. |
| [**GetBudgetedForBudgets**](BudgetsApi.md#getbudgetedforbudgets) | **GET** /v2/budgets/sum/budgeted | Returns the budgeted amount for all budgets in the given period. |
| [**GetSpentForBudget**](BudgetsApi.md#getspentforbudget) | **GET** /v2/budgets/{id}/spent | Returns the spent amount for the given budget in the given period. |
| [**GetSpentForBudgets**](BudgetsApi.md#getspentforbudgets) | **GET** /v2/budgets/sum/spent | Returns the spent amount for all budgets in the given period. |
| [**ListBudgetLimitByBudget**](BudgetsApi.md#listbudgetlimitbybudget) | **GET** /v2/budgets/{id}/limits | Get all limits for a budget. |
| [**ListBudgets**](BudgetsApi.md#listbudgets) | **GET** /v2/budgets | List all budgets. |

<a id="getbudgetedforbudget"></a>
# **GetBudgetedForBudget**
> List&lt;TransactionSum&gt; GetBudgetedForBudget (DateTime start, DateTime end, string id, Guid? xTraceId = null)

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
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Returns the budgeted amount for the given budget in the given period.
                List<TransactionSum> result = apiInstance.GetBudgetedForBudget(start, end, id, xTraceId);
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
    ApiResponse<List<TransactionSum>> response = apiInstance.GetBudgetedForBudgetWithHttpInfo(start, end, id, xTraceId);
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

### Return type

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

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
> List&lt;TransactionSum&gt; GetBudgetedForBudgets (DateTime start, DateTime end, string id, Guid? xTraceId = null)

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
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Returns the budgeted amount for all budgets in the given period.
                List<TransactionSum> result = apiInstance.GetBudgetedForBudgets(start, end, id, xTraceId);
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
    ApiResponse<List<TransactionSum>> response = apiInstance.GetBudgetedForBudgetsWithHttpInfo(start, end, id, xTraceId);
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

### Return type

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

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
> List&lt;TransactionSum&gt; GetSpentForBudget (DateTime start, DateTime end, string id, Guid? xTraceId = null)

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
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Returns the spent amount for the given budget in the given period.
                List<TransactionSum> result = apiInstance.GetSpentForBudget(start, end, id, xTraceId);
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
    ApiResponse<List<TransactionSum>> response = apiInstance.GetSpentForBudgetWithHttpInfo(start, end, id, xTraceId);
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

### Return type

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

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
> List&lt;TransactionSum&gt; GetSpentForBudgets (DateTime start, DateTime end, string id, Guid? xTraceId = null)

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
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var id = 123;  // string | The ID of the budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Returns the spent amount for all budgets in the given period.
                List<TransactionSum> result = apiInstance.GetSpentForBudgets(start, end, id, xTraceId);
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
    ApiResponse<List<TransactionSum>> response = apiInstance.GetSpentForBudgetsWithHttpInfo(start, end, id, xTraceId);
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

### Return type

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

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

<a id="listbudgetlimitbybudget"></a>
# **ListBudgetLimitByBudget**
> BudgetLimitV2Array ListBudgetLimitByBudget (DateTime start, DateTime end, string id, Guid? xTraceId = null)

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
    public class ListBudgetLimitByBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var id = 123;  // string | The ID of the requested budget.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Get all limits for a budget.
                BudgetLimitV2Array result = apiInstance.ListBudgetLimitByBudget(start, end, id, xTraceId);
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
    ApiResponse<BudgetLimitV2Array> response = apiInstance.ListBudgetLimitByBudgetWithHttpInfo(start, end, id, xTraceId);
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
| **start** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **end** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **id** | **string** | The ID of the requested budget. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**BudgetLimitV2Array**](BudgetLimitV2Array.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

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
> BudgetV2Array ListBudgets (Guid? xTraceId = null, int? limit = null, int? page = null)

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
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var limit = 10;  // int? | Number of items per page. The default pagination is per 50 items. (optional) 
            var page = 1;  // int? | Page number. The default pagination is per 50 items. (optional) 

            try
            {
                // List all budgets.
                BudgetV2Array result = apiInstance.ListBudgets(xTraceId, limit, page);
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
    ApiResponse<BudgetV2Array> response = apiInstance.ListBudgetsWithHttpInfo(xTraceId, limit, page);
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
| **limit** | **int?** | Number of items per page. The default pagination is per 50 items. | [optional]  |
| **page** | **int?** | Page number. The default pagination is per 50 items. | [optional]  |

### Return type

[**BudgetV2Array**](BudgetV2Array.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

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

