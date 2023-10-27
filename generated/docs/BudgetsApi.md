# FireflyIIINet.Api.BudgetsApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteBudget**](BudgetsApi.md#deletebudget) | **DELETE** /api/v1/budgets/{id} | Delete a budget. |
| [**DeleteBudgetLimit**](BudgetsApi.md#deletebudgetlimit) | **DELETE** /api/v1/budgets/{id}/limits/{limitId} | Delete a budget limit. |
| [**GetBudget**](BudgetsApi.md#getbudget) | **GET** /api/v1/budgets/{id} | Get a single budget. |
| [**GetBudgetLimit**](BudgetsApi.md#getbudgetlimit) | **GET** /api/v1/budgets/{id}/limits/{limitId} | Get single budget limit. |
| [**ListAttachmentByBudget**](BudgetsApi.md#listattachmentbybudget) | **GET** /api/v1/budgets/{id}/attachments | Lists all attachments of a budget. |
| [**ListBudget**](BudgetsApi.md#listbudget) | **GET** /api/v1/budgets | List all budgets. |
| [**ListBudgetLimit**](BudgetsApi.md#listbudgetlimit) | **GET** /api/v1/budget-limits | Get list of budget limits by date |
| [**ListBudgetLimitByBudget**](BudgetsApi.md#listbudgetlimitbybudget) | **GET** /api/v1/budgets/{id}/limits | Get all limits for a budget. |
| [**ListTransactionByBudget**](BudgetsApi.md#listtransactionbybudget) | **GET** /api/v1/budgets/{id}/transactions | All transactions to a budget. |
| [**ListTransactionByBudgetLimit**](BudgetsApi.md#listtransactionbybudgetlimit) | **GET** /api/v1/budgets/{id}/limits/{limitId}/transactions | List all transactions by a budget limit ID. |
| [**StoreBudget**](BudgetsApi.md#storebudget) | **POST** /api/v1/budgets | Store a new budget |
| [**StoreBudgetLimit**](BudgetsApi.md#storebudgetlimit) | **POST** /api/v1/budgets/{id}/limits | Store new budget limit. |
| [**UpdateBudget**](BudgetsApi.md#updatebudget) | **PUT** /api/v1/budgets/{id} | Update existing budget. |
| [**UpdateBudgetLimit**](BudgetsApi.md#updatebudgetlimit) | **PUT** /api/v1/budgets/{id}/limits/{limitId} | Update existing budget limit. |

<a id="deletebudget"></a>
# **DeleteBudget**
> void DeleteBudget (int id)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the budget.

            try
            {
                // Delete a budget.
                apiInstance.DeleteBudget(id);
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
    apiInstance.DeleteBudgetWithHttpInfo(id);
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
| **id** | **int** | The ID of the budget. |  |

### Return type

void (empty response body)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Budget deleted. |  -  |
| **404** | No such budget |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletebudgetlimit"></a>
# **DeleteBudgetLimit**
> void DeleteBudgetLimit (int id, int limitId)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the budget. The budget limit MUST be associated to the budget ID.
            var limitId = 1;  // int | The ID of the budget limit. The budget limit MUST be associated to the budget ID.

            try
            {
                // Delete a budget limit.
                apiInstance.DeleteBudgetLimit(id, limitId);
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
    apiInstance.DeleteBudgetLimitWithHttpInfo(id, limitId);
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
| **id** | **int** | The ID of the budget. The budget limit MUST be associated to the budget ID. |  |
| **limitId** | **int** | The ID of the budget limit. The budget limit MUST be associated to the budget ID. |  |

### Return type

void (empty response body)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Budget limit deleted. |  -  |
| **404** | No such budget limit |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getbudget"></a>
# **GetBudget**
> BudgetSingle GetBudget (int id, DateTime? start = null, DateTime? end = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the requested budget.
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to get info on how much the user has spent.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD, to get info on how much the user has spent.  (optional) 

            try
            {
                // Get a single budget.
                BudgetSingle result = apiInstance.GetBudget(id, start, end);
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
    ApiResponse<BudgetSingle> response = apiInstance.GetBudgetWithHttpInfo(id, start, end);
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
| **id** | **int** | The ID of the requested budget. |  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD, to get info on how much the user has spent.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD, to get info on how much the user has spent.  | [optional]  |

### Return type

[**BudgetSingle**](BudgetSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested budget |  -  |
| **404** | Budget not found. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getbudgetlimit"></a>
# **GetBudgetLimit**
> BudgetLimitSingle GetBudgetLimit (int id, int limitId)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the budget. The budget limit MUST be associated to the budget ID.
            var limitId = 1;  // int | The ID of the budget limit. The budget limit MUST be associated to the budget ID.

            try
            {
                // Get single budget limit.
                BudgetLimitSingle result = apiInstance.GetBudgetLimit(id, limitId);
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
    ApiResponse<BudgetLimitSingle> response = apiInstance.GetBudgetLimitWithHttpInfo(id, limitId);
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
| **id** | **int** | The ID of the budget. The budget limit MUST be associated to the budget ID. |  |
| **limitId** | **int** | The ID of the budget limit. The budget limit MUST be associated to the budget ID. |  |

### Return type

[**BudgetLimitSingle**](BudgetLimitSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested budget limit |  -  |
| **404** | Budget limit not found. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listattachmentbybudget"></a>
# **ListAttachmentByBudget**
> AttachmentArray ListAttachmentByBudget (int id, int? page = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the budget.
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // Lists all attachments of a budget.
                AttachmentArray result = apiInstance.ListAttachmentByBudget(id, page);
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
    ApiResponse<AttachmentArray> response = apiInstance.ListAttachmentByBudgetWithHttpInfo(id, page);
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
| **id** | **int** | The ID of the budget. |  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**AttachmentArray**](AttachmentArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of attachments |  -  |
| **404** | No such budget. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbudget"></a>
# **ListBudget**
> BudgetArray ListBudget (int? page = null, DateTime? start = null, DateTime? end = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to get info on how much the user has spent. You must submit both start and end.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD, to get info on how much the user has spent. You must submit both start and end.  (optional) 

            try
            {
                // List all budgets.
                BudgetArray result = apiInstance.ListBudget(page, start, end);
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
    ApiResponse<BudgetArray> response = apiInstance.ListBudgetWithHttpInfo(page, start, end);
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
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD, to get info on how much the user has spent. You must submit both start and end.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD, to get info on how much the user has spent. You must submit both start and end.  | [optional]  |

### Return type

[**BudgetArray**](BudgetArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of budgets. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbudgetlimit"></a>
# **ListBudgetLimit**
> BudgetLimitArray ListBudgetLimit (DateTime start, DateTime end)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime | A date formatted YYYY-MM-DD. 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime | A date formatted YYYY-MM-DD. 

            try
            {
                // Get list of budget limits by date
                BudgetLimitArray result = apiInstance.ListBudgetLimit(start, end);
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
    ApiResponse<BudgetLimitArray> response = apiInstance.ListBudgetLimitWithHttpInfo(start, end);
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

### Return type

[**BudgetLimitArray**](BudgetLimitArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of budget limits. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbudgetlimitbybudget"></a>
# **ListBudgetLimitByBudget**
> BudgetLimitArray ListBudgetLimitByBudget (int id, DateTime? start = null, DateTime? end = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the requested budget.
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 

            try
            {
                // Get all limits for a budget.
                BudgetLimitArray result = apiInstance.ListBudgetLimitByBudget(id, start, end);
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
    ApiResponse<BudgetLimitArray> response = apiInstance.ListBudgetLimitByBudgetWithHttpInfo(id, start, end);
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
| **id** | **int** | The ID of the requested budget. |  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |

### Return type

[**BudgetLimitArray**](BudgetLimitArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of budget limits applicable to this budget. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listtransactionbybudget"></a>
# **ListTransactionByBudget**
> TransactionArray ListTransactionByBudget (int id, int? limit = null, int? page = null, DateTime? start = null, DateTime? end = null, TransactionTypeFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the budget.
            var limit = 5;  // int? | Limits the number of results on one page. (optional) 
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 
            var type = new TransactionTypeFilter(); // TransactionTypeFilter | Optional filter on the transaction type(s) returned (optional) 

            try
            {
                // All transactions to a budget.
                TransactionArray result = apiInstance.ListTransactionByBudget(id, limit, page, start, end, type);
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
    ApiResponse<TransactionArray> response = apiInstance.ListTransactionByBudgetWithHttpInfo(id, limit, page, start, end, type);
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
| **id** | **int** | The ID of the budget. |  |
| **limit** | **int?** | Limits the number of results on one page. | [optional]  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |
| **type** | [**TransactionTypeFilter**](TransactionTypeFilter.md) | Optional filter on the transaction type(s) returned | [optional]  |

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

<a id="listtransactionbybudgetlimit"></a>
# **ListTransactionByBudgetLimit**
> TransactionArray ListTransactionByBudgetLimit (int id, int limitId, int? page = null, TransactionTypeFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the budget. The budget limit MUST be associated to the budget ID.
            var limitId = 1;  // int | The ID of the budget limit. The budget limit MUST be associated to the budget ID.
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 
            var type = new TransactionTypeFilter(); // TransactionTypeFilter | Optional filter on the transaction type(s) returned (optional) 

            try
            {
                // List all transactions by a budget limit ID.
                TransactionArray result = apiInstance.ListTransactionByBudgetLimit(id, limitId, page, type);
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
    ApiResponse<TransactionArray> response = apiInstance.ListTransactionByBudgetLimitWithHttpInfo(id, limitId, page, type);
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
| **id** | **int** | The ID of the budget. The budget limit MUST be associated to the budget ID. |  |
| **limitId** | **int** | The ID of the budget limit. The budget limit MUST be associated to the budget ID. |  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |
| **type** | [**TransactionTypeFilter**](TransactionTypeFilter.md) | Optional filter on the transaction type(s) returned | [optional]  |

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

<a id="storebudget"></a>
# **StoreBudget**
> BudgetSingle StoreBudget (BudgetStore budgetStore)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var budgetStore = new BudgetStore(); // BudgetStore | JSON array or key=value pairs with the necessary budget information. See the model for the exact specifications.

            try
            {
                // Store a new budget
                BudgetSingle result = apiInstance.StoreBudget(budgetStore);
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
    ApiResponse<BudgetSingle> response = apiInstance.StoreBudgetWithHttpInfo(budgetStore);
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
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storebudgetlimit"></a>
# **StoreBudgetLimit**
> BudgetLimitSingle StoreBudgetLimit (int id, BudgetLimitStore budgetLimitStore)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the budget.
            var budgetLimitStore = new BudgetLimitStore(); // BudgetLimitStore | JSON array or key=value pairs with the necessary budget information. See the model for the exact specifications.

            try
            {
                // Store new budget limit.
                BudgetLimitSingle result = apiInstance.StoreBudgetLimit(id, budgetLimitStore);
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
    ApiResponse<BudgetLimitSingle> response = apiInstance.StoreBudgetLimitWithHttpInfo(id, budgetLimitStore);
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
| **id** | **int** | The ID of the budget. |  |
| **budgetLimitStore** | [**BudgetLimitStore**](BudgetLimitStore.md) | JSON array or key&#x3D;value pairs with the necessary budget information. See the model for the exact specifications. |  |

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
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatebudget"></a>
# **UpdateBudget**
> BudgetSingle UpdateBudget (int id, BudgetUpdate budgetUpdate)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the budget.
            var budgetUpdate = new BudgetUpdate(); // BudgetUpdate | JSON array with updated budget information. See the model for the exact specifications.

            try
            {
                // Update existing budget.
                BudgetSingle result = apiInstance.UpdateBudget(id, budgetUpdate);
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
    ApiResponse<BudgetSingle> response = apiInstance.UpdateBudgetWithHttpInfo(id, budgetUpdate);
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
| **id** | **int** | The ID of the budget. |  |
| **budgetUpdate** | [**BudgetUpdate**](BudgetUpdate.md) | JSON array with updated budget information. See the model for the exact specifications. |  |

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
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatebudgetlimit"></a>
# **UpdateBudgetLimit**
> BudgetLimitSingle UpdateBudgetLimit (int id, int limitId, BudgetLimit budgetLimit)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new BudgetsApi(config);
            var id = 1;  // int | The ID of the budget. The budget limit MUST be associated to the budget ID.
            var limitId = 1;  // int | The ID of the budget limit. The budget limit MUST be associated to the budget ID.
            var budgetLimit = new BudgetLimit(); // BudgetLimit | JSON array with updated budget limit information. See the model for the exact specifications.

            try
            {
                // Update existing budget limit.
                BudgetLimitSingle result = apiInstance.UpdateBudgetLimit(id, limitId, budgetLimit);
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
    ApiResponse<BudgetLimitSingle> response = apiInstance.UpdateBudgetLimitWithHttpInfo(id, limitId, budgetLimit);
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
| **id** | **int** | The ID of the budget. The budget limit MUST be associated to the budget ID. |  |
| **limitId** | **int** | The ID of the budget limit. The budget limit MUST be associated to the budget ID. |  |
| **budgetLimit** | [**BudgetLimit**](BudgetLimit.md) | JSON array with updated budget limit information. See the model for the exact specifications. |  |

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
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

