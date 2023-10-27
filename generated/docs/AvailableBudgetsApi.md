# FireflyIIINet.Api.AvailableBudgetsApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteAvailableBudget**](AvailableBudgetsApi.md#deleteavailablebudget) | **DELETE** /api/v1/available_budgets/{id} | Delete an available budget. |
| [**GetAvailableBudget**](AvailableBudgetsApi.md#getavailablebudget) | **GET** /api/v1/available_budgets/{id} | Get a single available budget. |
| [**ListAvailableBudget**](AvailableBudgetsApi.md#listavailablebudget) | **GET** /api/v1/available_budgets | List all available budget amounts. |
| [**StoreAvailableBudget**](AvailableBudgetsApi.md#storeavailablebudget) | **POST** /api/v1/available_budgets | Store a new available budget |
| [**UpdateAvailableBudget**](AvailableBudgetsApi.md#updateavailablebudget) | **PUT** /api/v1/available_budgets/{id} | Update existing available budget, to change for example the date range of the amount or the amount itself. |

<a id="deleteavailablebudget"></a>
# **DeleteAvailableBudget**
> void DeleteAvailableBudget (int id)

Delete an available budget.

Delete an available budget. Not much more to say.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DeleteAvailableBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AvailableBudgetsApi(config);
            var id = 1;  // int | The ID of the available budget.

            try
            {
                // Delete an available budget.
                apiInstance.DeleteAvailableBudget(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AvailableBudgetsApi.DeleteAvailableBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteAvailableBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete an available budget.
    apiInstance.DeleteAvailableBudgetWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AvailableBudgetsApi.DeleteAvailableBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the available budget. |  |

### Return type

void (empty response body)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Available budget deleted. |  -  |
| **404** | No such available budget. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getavailablebudget"></a>
# **GetAvailableBudget**
> AvailableBudgetSingle GetAvailableBudget (int id)

Get a single available budget.

Get a single available budget, by ID.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetAvailableBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AvailableBudgetsApi(config);
            var id = 1;  // int | The ID of the available budget.

            try
            {
                // Get a single available budget.
                AvailableBudgetSingle result = apiInstance.GetAvailableBudget(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AvailableBudgetsApi.GetAvailableBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAvailableBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single available budget.
    ApiResponse<AvailableBudgetSingle> response = apiInstance.GetAvailableBudgetWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AvailableBudgetsApi.GetAvailableBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the available budget. |  |

### Return type

[**AvailableBudgetSingle**](AvailableBudgetSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested available budget |  -  |
| **404** | AvailableBudget not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listavailablebudget"></a>
# **ListAvailableBudget**
> AvailableBudgetArray ListAvailableBudget (int? page = null, DateTime? start = null, DateTime? end = null)

List all available budget amounts.

Firefly III allows users to set the amount that is available to be budgeted in so-called \"available budgets\". For example, the user could have 1200,- available to be divided during the coming month. This amount is used on the /budgets page. This endpoint returns all of these amounts and the periods for which they are set. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListAvailableBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AvailableBudgetsApi(config);
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD.  (optional) 

            try
            {
                // List all available budget amounts.
                AvailableBudgetArray result = apiInstance.ListAvailableBudget(page, start, end);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AvailableBudgetsApi.ListAvailableBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListAvailableBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all available budget amounts.
    ApiResponse<AvailableBudgetArray> response = apiInstance.ListAvailableBudgetWithHttpInfo(page, start, end);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AvailableBudgetsApi.ListAvailableBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD.  | [optional]  |

### Return type

[**AvailableBudgetArray**](AvailableBudgetArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of available budget amounts. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storeavailablebudget"></a>
# **StoreAvailableBudget**
> AvailableBudgetSingle StoreAvailableBudget (AvailableBudgetStore availableBudgetStore)

Store a new available budget

Creates a new available budget for a specified period. The data required can be submitted as a JSON body or as a list of parameters. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class StoreAvailableBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AvailableBudgetsApi(config);
            var availableBudgetStore = new AvailableBudgetStore(); // AvailableBudgetStore | JSON array or key=value pairs with the necessary available budget information. See the model for the exact specifications.

            try
            {
                // Store a new available budget
                AvailableBudgetSingle result = apiInstance.StoreAvailableBudget(availableBudgetStore);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AvailableBudgetsApi.StoreAvailableBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StoreAvailableBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Store a new available budget
    ApiResponse<AvailableBudgetSingle> response = apiInstance.StoreAvailableBudgetWithHttpInfo(availableBudgetStore);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AvailableBudgetsApi.StoreAvailableBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **availableBudgetStore** | [**AvailableBudgetStore**](AvailableBudgetStore.md) | JSON array or key&#x3D;value pairs with the necessary available budget information. See the model for the exact specifications. |  |

### Return type

[**AvailableBudgetSingle**](AvailableBudgetSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New available budget stored, result in response. |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateavailablebudget"></a>
# **UpdateAvailableBudget**
> AvailableBudgetSingle UpdateAvailableBudget (int id, AvailableBudgetUpdate availableBudgetUpdate)

Update existing available budget, to change for example the date range of the amount or the amount itself.

Update existing available budget.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class UpdateAvailableBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AvailableBudgetsApi(config);
            var id = 1;  // int | The ID of the object.X
            var availableBudgetUpdate = new AvailableBudgetUpdate(); // AvailableBudgetUpdate | JSON array or form value with updated available budget information. See the model for the exact specifications.

            try
            {
                // Update existing available budget, to change for example the date range of the amount or the amount itself.
                AvailableBudgetSingle result = apiInstance.UpdateAvailableBudget(id, availableBudgetUpdate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AvailableBudgetsApi.UpdateAvailableBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateAvailableBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing available budget, to change for example the date range of the amount or the amount itself.
    ApiResponse<AvailableBudgetSingle> response = apiInstance.UpdateAvailableBudgetWithHttpInfo(id, availableBudgetUpdate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AvailableBudgetsApi.UpdateAvailableBudgetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the object.X |  |
| **availableBudgetUpdate** | [**AvailableBudgetUpdate**](AvailableBudgetUpdate.md) | JSON array or form value with updated available budget information. See the model for the exact specifications. |  |

### Return type

[**AvailableBudgetSingle**](AvailableBudgetSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: application/vnd.api+json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated available budget stored, result in response |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

