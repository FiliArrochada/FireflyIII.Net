# FireflyIIINet.Api.DataApi

All URIs are relative to *https://demo.firefly-iii.org/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**BulkUpdateTransactions**](DataApi.md#bulkupdatetransactions) | **POST** /v1/data/bulk/transactions | Bulk update transaction properties. For more information, see https://docs.firefly-iii.org/firefly-iii/api/specials |
| [**DestroyData**](DataApi.md#destroydata) | **DELETE** /v1/data/destroy | Endpoint to destroy user data |
| [**ExportAccounts**](DataApi.md#exportaccounts) | **GET** /v1/data/export/accounts | Export account data from Firefly III |
| [**ExportBills**](DataApi.md#exportbills) | **GET** /v1/data/export/bills | Export bills from Firefly III |
| [**ExportBudgets**](DataApi.md#exportbudgets) | **GET** /v1/data/export/budgets | Export budgets and budget amount data from Firefly III |
| [**ExportCategories**](DataApi.md#exportcategories) | **GET** /v1/data/export/categories | Export category data from Firefly III |
| [**ExportPiggies**](DataApi.md#exportpiggies) | **GET** /v1/data/export/piggy-banks | Export piggy banks from Firefly III |
| [**ExportRecurring**](DataApi.md#exportrecurring) | **GET** /v1/data/export/recurring | Export recurring transaction data from Firefly III |
| [**ExportRules**](DataApi.md#exportrules) | **GET** /v1/data/export/rules | Export rule groups and rule data from Firefly III |
| [**ExportTags**](DataApi.md#exporttags) | **GET** /v1/data/export/tags | Export tag data from Firefly III |
| [**ExportTransactions**](DataApi.md#exporttransactions) | **GET** /v1/data/export/transactions | Export transaction data from Firefly III |
| [**PurgeData**](DataApi.md#purgedata) | **DELETE** /v1/data/purge | Endpoint to purge user data |

<a id="bulkupdatetransactions"></a>
# **BulkUpdateTransactions**
> void BulkUpdateTransactions (string query)

Bulk update transaction properties. For more information, see https://docs.firefly-iii.org/firefly-iii/api/specials

Allows you to update transactions in bulk. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class BulkUpdateTransactionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var query = "query_example";  // string | The JSON query.

            try
            {
                // Bulk update transaction properties. For more information, see https://docs.firefly-iii.org/firefly-iii/api/specials
                apiInstance.BulkUpdateTransactions(query);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.BulkUpdateTransactions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the BulkUpdateTransactionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Bulk update transaction properties. For more information, see https://docs.firefly-iii.org/firefly-iii/api/specials
    apiInstance.BulkUpdateTransactionsWithHttpInfo(query);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.BulkUpdateTransactionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **query** | **string** | The JSON query. |  |

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
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **204** | Empty response when the update was successful. A future improvement is to include the changed transactions. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="destroydata"></a>
# **DestroyData**
> void DestroyData (DataDestroyObject objects, Guid? xTraceId = null)

Endpoint to destroy user data

A call to this endpoint deletes the requested data type. Use it with care and always with user permission. The demo user is incapable of using this endpoint. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DestroyDataExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var objects = new DataDestroyObject(); // DataDestroyObject | The type of data that you wish to destroy. You can only use one at a time.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Endpoint to destroy user data
                apiInstance.DestroyData(objects, xTraceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.DestroyData: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DestroyDataWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Endpoint to destroy user data
    apiInstance.DestroyDataWithHttpInfo(objects, xTraceId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.DestroyDataWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **objects** | [**DataDestroyObject**](DataDestroyObject.md) | The type of data that you wish to destroy. You can only use one at a time. |  |
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
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **204** | Empty response when data has been destroyed. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportaccounts"></a>
# **ExportAccounts**
> System.IO.Stream ExportAccounts (Guid? xTraceId = null, ExportFileFilter? type = null)

Export account data from Firefly III

This endpoint allows you to export your accounts from Firefly III into a file. Currently supports CSV exports only. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ExportAccountsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var type = new ExportFileFilter?(); // ExportFileFilter? | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export account data from Firefly III
                System.IO.Stream result = apiInstance.ExportAccounts(xTraceId, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.ExportAccounts: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportAccountsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export account data from Firefly III
    ApiResponse<System.IO.Stream> response = apiInstance.ExportAccountsWithHttpInfo(xTraceId, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.ExportAccountsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **type** | [**ExportFileFilter?**](ExportFileFilter?.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportbills"></a>
# **ExportBills**
> System.IO.Stream ExportBills (Guid? xTraceId = null, ExportFileFilter? type = null)

Export bills from Firefly III

This endpoint allows you to export your bills from Firefly III into a file. Currently supports CSV exports only. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ExportBillsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var type = new ExportFileFilter?(); // ExportFileFilter? | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export bills from Firefly III
                System.IO.Stream result = apiInstance.ExportBills(xTraceId, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.ExportBills: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportBillsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export bills from Firefly III
    ApiResponse<System.IO.Stream> response = apiInstance.ExportBillsWithHttpInfo(xTraceId, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.ExportBillsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **type** | [**ExportFileFilter?**](ExportFileFilter?.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportbudgets"></a>
# **ExportBudgets**
> System.IO.Stream ExportBudgets (Guid? xTraceId = null, ExportFileFilter? type = null)

Export budgets and budget amount data from Firefly III

This endpoint allows you to export your budgets and associated budget data from Firefly III into a file. Currently supports CSV exports only. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ExportBudgetsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var type = new ExportFileFilter?(); // ExportFileFilter? | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export budgets and budget amount data from Firefly III
                System.IO.Stream result = apiInstance.ExportBudgets(xTraceId, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.ExportBudgets: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportBudgetsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export budgets and budget amount data from Firefly III
    ApiResponse<System.IO.Stream> response = apiInstance.ExportBudgetsWithHttpInfo(xTraceId, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.ExportBudgetsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **type** | [**ExportFileFilter?**](ExportFileFilter?.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportcategories"></a>
# **ExportCategories**
> System.IO.Stream ExportCategories (Guid? xTraceId = null, ExportFileFilter? type = null)

Export category data from Firefly III

This endpoint allows you to export your categories from Firefly III into a file. Currently supports CSV exports only. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ExportCategoriesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var type = new ExportFileFilter?(); // ExportFileFilter? | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export category data from Firefly III
                System.IO.Stream result = apiInstance.ExportCategories(xTraceId, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.ExportCategories: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportCategoriesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export category data from Firefly III
    ApiResponse<System.IO.Stream> response = apiInstance.ExportCategoriesWithHttpInfo(xTraceId, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.ExportCategoriesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **type** | [**ExportFileFilter?**](ExportFileFilter?.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportpiggies"></a>
# **ExportPiggies**
> System.IO.Stream ExportPiggies (Guid? xTraceId = null, ExportFileFilter? type = null)

Export piggy banks from Firefly III

This endpoint allows you to export your piggy banks from Firefly III into a file. Currently supports CSV exports only. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ExportPiggiesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var type = new ExportFileFilter?(); // ExportFileFilter? | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export piggy banks from Firefly III
                System.IO.Stream result = apiInstance.ExportPiggies(xTraceId, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.ExportPiggies: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportPiggiesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export piggy banks from Firefly III
    ApiResponse<System.IO.Stream> response = apiInstance.ExportPiggiesWithHttpInfo(xTraceId, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.ExportPiggiesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **type** | [**ExportFileFilter?**](ExportFileFilter?.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportrecurring"></a>
# **ExportRecurring**
> System.IO.Stream ExportRecurring (Guid? xTraceId = null, ExportFileFilter? type = null)

Export recurring transaction data from Firefly III

This endpoint allows you to export your recurring transactions from Firefly III into a file. Currently supports CSV exports only. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ExportRecurringExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var type = new ExportFileFilter?(); // ExportFileFilter? | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export recurring transaction data from Firefly III
                System.IO.Stream result = apiInstance.ExportRecurring(xTraceId, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.ExportRecurring: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportRecurringWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export recurring transaction data from Firefly III
    ApiResponse<System.IO.Stream> response = apiInstance.ExportRecurringWithHttpInfo(xTraceId, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.ExportRecurringWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **type** | [**ExportFileFilter?**](ExportFileFilter?.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportrules"></a>
# **ExportRules**
> System.IO.Stream ExportRules (Guid? xTraceId = null, ExportFileFilter? type = null)

Export rule groups and rule data from Firefly III

This endpoint allows you to export your rules and rule groups from Firefly III into a file. Currently supports CSV exports only. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ExportRulesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var type = new ExportFileFilter?(); // ExportFileFilter? | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export rule groups and rule data from Firefly III
                System.IO.Stream result = apiInstance.ExportRules(xTraceId, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.ExportRules: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportRulesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export rule groups and rule data from Firefly III
    ApiResponse<System.IO.Stream> response = apiInstance.ExportRulesWithHttpInfo(xTraceId, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.ExportRulesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **type** | [**ExportFileFilter?**](ExportFileFilter?.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exporttags"></a>
# **ExportTags**
> System.IO.Stream ExportTags (Guid? xTraceId = null, ExportFileFilter? type = null)

Export tag data from Firefly III

This endpoint allows you to export your tags from Firefly III into a file. Currently supports CSV exports only. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ExportTagsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var type = new ExportFileFilter?(); // ExportFileFilter? | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export tag data from Firefly III
                System.IO.Stream result = apiInstance.ExportTags(xTraceId, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.ExportTags: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportTagsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export tag data from Firefly III
    ApiResponse<System.IO.Stream> response = apiInstance.ExportTagsWithHttpInfo(xTraceId, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.ExportTagsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **type** | [**ExportFileFilter?**](ExportFileFilter?.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exporttransactions"></a>
# **ExportTransactions**
> System.IO.Stream ExportTransactions (DateTime start, DateTime end, Guid? xTraceId = null, string? accounts = null, ExportFileFilter? type = null)

Export transaction data from Firefly III

This endpoint allows you to export transactions from Firefly III into a file. Currently supports CSV exports only. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ExportTransactionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = 1,2,3;  // string? | Limit the export of transactions to these accounts only. Only asset accounts will be accepted. Other types will be silently dropped.  (optional) 
            var type = new ExportFileFilter?(); // ExportFileFilter? | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export transaction data from Firefly III
                System.IO.Stream result = apiInstance.ExportTransactions(start, end, xTraceId, accounts, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.ExportTransactions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ExportTransactionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Export transaction data from Firefly III
    ApiResponse<System.IO.Stream> response = apiInstance.ExportTransactionsWithHttpInfo(start, end, xTraceId, accounts, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.ExportTransactionsWithHttpInfo: " + e.Message);
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
| **accounts** | **string?** | Limit the export of transactions to these accounts only. Only asset accounts will be accepted. Other types will be silently dropped.  | [optional]  |
| **type** | [**ExportFileFilter?**](ExportFileFilter?.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="purgedata"></a>
# **PurgeData**
> void PurgeData (Guid? xTraceId = null)

Endpoint to purge user data

A call to this endpoint purges all previously deleted data. Use it with care and always with user permission. The demo user is incapable of using this endpoint. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class PurgeDataExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Endpoint to purge user data
                apiInstance.PurgeData(xTraceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.PurgeData: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PurgeDataWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Endpoint to purge user data
    apiInstance.PurgeDataWithHttpInfo(xTraceId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.PurgeDataWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
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
| **401** | Unauthenticated |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |
| **204** | Empty response when data has been purged. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

