# FireflyIIINet.Api.DataApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**BulkAccountMoveTransactions**](DataApi.md#bulkaccountmovetransactions) | **POST** /api/v1/data/bulk/accounts/transactions | Bulk move transactions from one account to another. |
| [**DestroyData**](DataApi.md#destroydata) | **DELETE** /api/v1/data/destroy | Endpoint to destroy user data |
| [**ExportAccounts**](DataApi.md#exportaccounts) | **GET** /api/v1/data/export/accounts | Export account data from Firefly III |
| [**ExportBills**](DataApi.md#exportbills) | **GET** /api/v1/data/export/bills | Export bills from Firefly III |
| [**ExportBudgets**](DataApi.md#exportbudgets) | **GET** /api/v1/data/export/budgets | Export budgets and budget amount data from Firefly III |
| [**ExportCategories**](DataApi.md#exportcategories) | **GET** /api/v1/data/export/categories | Export category data from Firefly III |
| [**ExportPiggies**](DataApi.md#exportpiggies) | **GET** /api/v1/data/export/piggy-banks | Export piggy banks from Firefly III |
| [**ExportRecurring**](DataApi.md#exportrecurring) | **GET** /api/v1/data/export/recurring | Export recurring transaction data from Firefly III |
| [**ExportRules**](DataApi.md#exportrules) | **GET** /api/v1/data/export/rules | Export rule groups and rule data from Firefly III |
| [**ExportTags**](DataApi.md#exporttags) | **GET** /api/v1/data/export/tags | Export tag data from Firefly III |
| [**ExportTransactions**](DataApi.md#exporttransactions) | **GET** /api/v1/data/export/transactions | Export transaction data from Firefly III |

<a id="bulkaccountmovetransactions"></a>
# **BulkAccountMoveTransactions**
> void BulkAccountMoveTransactions (BulkAccountTransactionObject bulkAccountTransactionObject)

Bulk move transactions from one account to another.

Allows you to move all from one account to another. Requires two of the exact same accounts to work. Will not migrate deleted transactions. Both accounts must be of the exact same type (asset accounts for example). 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class BulkAccountMoveTransactionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var bulkAccountTransactionObject = new BulkAccountTransactionObject(); // BulkAccountTransactionObject | JSON array with the necessary information to facilitate the move.

            try
            {
                // Bulk move transactions from one account to another.
                apiInstance.BulkAccountMoveTransactions(bulkAccountTransactionObject);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DataApi.BulkAccountMoveTransactions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the BulkAccountMoveTransactionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Bulk move transactions from one account to another.
    apiInstance.BulkAccountMoveTransactionsWithHttpInfo(bulkAccountTransactionObject);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DataApi.BulkAccountMoveTransactionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **bulkAccountTransactionObject** | [**BulkAccountTransactionObject**](BulkAccountTransactionObject.md) | JSON array with the necessary information to facilitate the move. |  |

### Return type

void (empty response body)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Empty response when the move was successful. |  -  |
| **500** | Internal error. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="destroydata"></a>
# **DestroyData**
> void DestroyData (DataDestroyObject objects)

Endpoint to destroy user data

A call to this endpoint permanently destroys the requested data type. Use it with care and always with user permission. The demo user is incapable of using this endpoint. 

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var objects = new DataDestroyObject(); // DataDestroyObject | The type of data that you wish to destroy.

            try
            {
                // Endpoint to destroy user data
                apiInstance.DestroyData(objects);
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
    apiInstance.DestroyDataWithHttpInfo(objects);
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
| **objects** | [**DataDestroyObject**](DataDestroyObject.md) | The type of data that you wish to destroy. |  |

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
| **204** | Empty response when data has been destroyed. |  -  |
| **500** | Internal error, or user is unauthorized to destroy data. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportaccounts"></a>
# **ExportAccounts**
> System.IO.Stream ExportAccounts (ExportFileFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var type = new ExportFileFilter(); // ExportFileFilter | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export account data from Firefly III
                System.IO.Stream result = apiInstance.ExportAccounts(type);
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
    ApiResponse<System.IO.Stream> response = apiInstance.ExportAccountsWithHttpInfo(type);
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
| **type** | [**ExportFileFilter**](ExportFileFilter.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportbills"></a>
# **ExportBills**
> System.IO.Stream ExportBills (ExportFileFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var type = new ExportFileFilter(); // ExportFileFilter | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export bills from Firefly III
                System.IO.Stream result = apiInstance.ExportBills(type);
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
    ApiResponse<System.IO.Stream> response = apiInstance.ExportBillsWithHttpInfo(type);
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
| **type** | [**ExportFileFilter**](ExportFileFilter.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportbudgets"></a>
# **ExportBudgets**
> System.IO.Stream ExportBudgets (ExportFileFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var type = new ExportFileFilter(); // ExportFileFilter | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export budgets and budget amount data from Firefly III
                System.IO.Stream result = apiInstance.ExportBudgets(type);
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
    ApiResponse<System.IO.Stream> response = apiInstance.ExportBudgetsWithHttpInfo(type);
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
| **type** | [**ExportFileFilter**](ExportFileFilter.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportcategories"></a>
# **ExportCategories**
> System.IO.Stream ExportCategories (ExportFileFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var type = new ExportFileFilter(); // ExportFileFilter | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export category data from Firefly III
                System.IO.Stream result = apiInstance.ExportCategories(type);
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
    ApiResponse<System.IO.Stream> response = apiInstance.ExportCategoriesWithHttpInfo(type);
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
| **type** | [**ExportFileFilter**](ExportFileFilter.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportpiggies"></a>
# **ExportPiggies**
> System.IO.Stream ExportPiggies (ExportFileFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var type = new ExportFileFilter(); // ExportFileFilter | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export piggy banks from Firefly III
                System.IO.Stream result = apiInstance.ExportPiggies(type);
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
    ApiResponse<System.IO.Stream> response = apiInstance.ExportPiggiesWithHttpInfo(type);
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
| **type** | [**ExportFileFilter**](ExportFileFilter.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportrecurring"></a>
# **ExportRecurring**
> System.IO.Stream ExportRecurring (ExportFileFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var type = new ExportFileFilter(); // ExportFileFilter | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export recurring transaction data from Firefly III
                System.IO.Stream result = apiInstance.ExportRecurring(type);
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
    ApiResponse<System.IO.Stream> response = apiInstance.ExportRecurringWithHttpInfo(type);
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
| **type** | [**ExportFileFilter**](ExportFileFilter.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exportrules"></a>
# **ExportRules**
> System.IO.Stream ExportRules (ExportFileFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var type = new ExportFileFilter(); // ExportFileFilter | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export rule groups and rule data from Firefly III
                System.IO.Stream result = apiInstance.ExportRules(type);
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
    ApiResponse<System.IO.Stream> response = apiInstance.ExportRulesWithHttpInfo(type);
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
| **type** | [**ExportFileFilter**](ExportFileFilter.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exporttags"></a>
# **ExportTags**
> System.IO.Stream ExportTags (ExportFileFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var type = new ExportFileFilter(); // ExportFileFilter | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export tag data from Firefly III
                System.IO.Stream result = apiInstance.ExportTags(type);
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
    ApiResponse<System.IO.Stream> response = apiInstance.ExportTagsWithHttpInfo(type);
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
| **type** | [**ExportFileFilter**](ExportFileFilter.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="exporttransactions"></a>
# **ExportTransactions**
> System.IO.Stream ExportTransactions (DateTime start, DateTime end, string accounts = null, ExportFileFilter type = null)

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
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DataApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var accounts = 1,2,3;  // string | Limit the export of transactions to these accounts only. Only asset accounts will be accepted. Other types will be silently dropped.  (optional) 
            var type = new ExportFileFilter(); // ExportFileFilter | The file type the export file (CSV is currently the only option). (optional) 

            try
            {
                // Export transaction data from Firefly III
                System.IO.Stream result = apiInstance.ExportTransactions(start, end, accounts, type);
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
    ApiResponse<System.IO.Stream> response = apiInstance.ExportTransactionsWithHttpInfo(start, end, accounts, type);
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
| **accounts** | **string** | Limit the export of transactions to these accounts only. Only asset accounts will be accepted. Other types will be silently dropped.  | [optional]  |
| **type** | [**ExportFileFilter**](ExportFileFilter.md) | The file type the export file (CSV is currently the only option). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The exported transaction in a file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

