# FireflyIIINet.Api.CategoriesApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteCategory**](CategoriesApi.md#deletecategory) | **DELETE** /api/v1/categories/{id} | Delete a category. |
| [**GetCategory**](CategoriesApi.md#getcategory) | **GET** /api/v1/categories/{id} | Get a single category. |
| [**ListAttachmentByCategory**](CategoriesApi.md#listattachmentbycategory) | **GET** /api/v1/categories/{id}/attachments | Lists all attachments. |
| [**ListCategory**](CategoriesApi.md#listcategory) | **GET** /api/v1/categories | List all categories. |
| [**ListTransactionByCategory**](CategoriesApi.md#listtransactionbycategory) | **GET** /api/v1/categories/{id}/transactions | List all transactions in a category. |
| [**StoreCategory**](CategoriesApi.md#storecategory) | **POST** /api/v1/categories | Store a new category |
| [**UpdateCategory**](CategoriesApi.md#updatecategory) | **PUT** /api/v1/categories/{id} | Update existing category. |

<a id="deletecategory"></a>
# **DeleteCategory**
> void DeleteCategory (int id)

Delete a category.

Delete a category. Transactions will not be removed.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DeleteCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CategoriesApi(config);
            var id = 1;  // int | The ID of the category.

            try
            {
                // Delete a category.
                apiInstance.DeleteCategory(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CategoriesApi.DeleteCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a category.
    apiInstance.DeleteCategoryWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CategoriesApi.DeleteCategoryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the category. |  |

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
| **204** | Category deleted. |  -  |
| **404** | No such category. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getcategory"></a>
# **GetCategory**
> CategorySingle GetCategory (int id, DateTime? start = null, DateTime? end = null)

Get a single category.

Get a single category.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CategoriesApi(config);
            var id = 1;  // int | The ID of the category.
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to show spent and earned info.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD, to show spent and earned info.  (optional) 

            try
            {
                // Get a single category.
                CategorySingle result = apiInstance.GetCategory(id, start, end);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CategoriesApi.GetCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single category.
    ApiResponse<CategorySingle> response = apiInstance.GetCategoryWithHttpInfo(id, start, end);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CategoriesApi.GetCategoryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the category. |  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD, to show spent and earned info.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD, to show spent and earned info.  | [optional]  |

### Return type

[**CategorySingle**](CategorySingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested category |  -  |
| **404** | Category not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listattachmentbycategory"></a>
# **ListAttachmentByCategory**
> AttachmentArray ListAttachmentByCategory (int id, int? page = null)

Lists all attachments.

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
    public class ListAttachmentByCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CategoriesApi(config);
            var id = 1;  // int | The ID of the category.
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // Lists all attachments.
                AttachmentArray result = apiInstance.ListAttachmentByCategory(id, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CategoriesApi.ListAttachmentByCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListAttachmentByCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Lists all attachments.
    ApiResponse<AttachmentArray> response = apiInstance.ListAttachmentByCategoryWithHttpInfo(id, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CategoriesApi.ListAttachmentByCategoryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the category. |  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**AttachmentArray**](AttachmentArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of attachments |  -  |
| **404** | No such category. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listcategory"></a>
# **ListCategory**
> CategoryArray ListCategory (int? page = null)

List all categories.

List all categories.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CategoriesApi(config);
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List all categories.
                CategoryArray result = apiInstance.ListCategory(page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CategoriesApi.ListCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all categories.
    ApiResponse<CategoryArray> response = apiInstance.ListCategoryWithHttpInfo(page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CategoriesApi.ListCategoryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**CategoryArray**](CategoryArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of categories. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listtransactionbycategory"></a>
# **ListTransactionByCategory**
> TransactionArray ListTransactionByCategory (int id, int? page = null, DateTime? start = null, DateTime? end = null, TransactionTypeFilter type = null)

List all transactions in a category.

List all transactions in a category, optionally limited to the date ranges specified.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListTransactionByCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CategoriesApi(config);
            var id = 1;  // int | The ID of the category.
            var page = 1;  // int? | Page number. The default pagination is per 50. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the result list.  (optional) 
            var end = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the result list.  (optional) 
            var type = new TransactionTypeFilter(); // TransactionTypeFilter | Optional filter on the transaction type(s) returned (optional) 

            try
            {
                // List all transactions in a category.
                TransactionArray result = apiInstance.ListTransactionByCategory(id, page, start, end, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CategoriesApi.ListTransactionByCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListTransactionByCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all transactions in a category.
    ApiResponse<TransactionArray> response = apiInstance.ListTransactionByCategoryWithHttpInfo(id, page, start, end, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CategoriesApi.ListTransactionByCategoryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the category. |  |
| **page** | **int?** | Page number. The default pagination is per 50. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the result list.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the result list.  | [optional]  |
| **type** | [**TransactionTypeFilter**](TransactionTypeFilter.md) | Optional filter on the transaction type(s) returned | [optional]  |

### Return type

[**TransactionArray**](TransactionArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of transactions. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storecategory"></a>
# **StoreCategory**
> CategorySingle StoreCategory (Category category)

Store a new category

Creates a new category. The data required can be submitted as a JSON body or as a list of parameters.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class StoreCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CategoriesApi(config);
            var category = new Category(); // Category | JSON array or key=value pairs with the necessary category information. See the model for the exact specifications.

            try
            {
                // Store a new category
                CategorySingle result = apiInstance.StoreCategory(category);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CategoriesApi.StoreCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StoreCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Store a new category
    ApiResponse<CategorySingle> response = apiInstance.StoreCategoryWithHttpInfo(category);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CategoriesApi.StoreCategoryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **category** | [**Category**](Category.md) | JSON array or key&#x3D;value pairs with the necessary category information. See the model for the exact specifications. |  |

### Return type

[**CategorySingle**](CategorySingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New category stored, result in response. |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatecategory"></a>
# **UpdateCategory**
> CategorySingle UpdateCategory (int id, CategoryUpdate categoryUpdate)

Update existing category.

Update existing category.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class UpdateCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new CategoriesApi(config);
            var id = 1;  // int | The ID of the category.
            var categoryUpdate = new CategoryUpdate(); // CategoryUpdate | JSON array with updated category information. See the model for the exact specifications.

            try
            {
                // Update existing category.
                CategorySingle result = apiInstance.UpdateCategory(id, categoryUpdate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CategoriesApi.UpdateCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing category.
    ApiResponse<CategorySingle> response = apiInstance.UpdateCategoryWithHttpInfo(id, categoryUpdate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CategoriesApi.UpdateCategoryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the category. |  |
| **categoryUpdate** | [**CategoryUpdate**](CategoryUpdate.md) | JSON array with updated category information. See the model for the exact specifications. |  |

### Return type

[**CategorySingle**](CategorySingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated category stored, result in response |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

