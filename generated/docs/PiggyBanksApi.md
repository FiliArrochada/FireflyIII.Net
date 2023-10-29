# FireflyIIINet.Api.PiggyBanksApi

All URIs are relative to *https://demo.firefly-iii.org/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeletePiggyBank**](PiggyBanksApi.md#deletepiggybank) | **DELETE** /v1/piggy-banks/{id} | Delete a piggy bank. |
| [**GetPiggyBank**](PiggyBanksApi.md#getpiggybank) | **GET** /v1/piggy-banks/{id} | Get a single piggy bank. |
| [**ListAttachmentByPiggyBank**](PiggyBanksApi.md#listattachmentbypiggybank) | **GET** /v1/piggy-banks/{id}/attachments | Lists all attachments. |
| [**ListEventByPiggyBank**](PiggyBanksApi.md#listeventbypiggybank) | **GET** /v1/piggy-banks/{id}/events | List all events linked to a piggy bank. |
| [**ListPiggyBank**](PiggyBanksApi.md#listpiggybank) | **GET** /v1/piggy-banks | List all piggy banks. |
| [**StorePiggyBank**](PiggyBanksApi.md#storepiggybank) | **POST** /v1/piggy-banks | Store a new piggy bank |
| [**UpdatePiggyBank**](PiggyBanksApi.md#updatepiggybank) | **PUT** /v1/piggy-banks/{id} | Update existing piggy bank. |

<a id="deletepiggybank"></a>
# **DeletePiggyBank**
> void DeletePiggyBank (string id, Guid? xTraceId = null)

Delete a piggy bank.

Delete a piggy bank.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DeletePiggyBankExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PiggyBanksApi(config);
            var id = 123;  // string | The ID of the piggy bank.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Delete a piggy bank.
                apiInstance.DeletePiggyBank(id, xTraceId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PiggyBanksApi.DeletePiggyBank: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeletePiggyBankWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a piggy bank.
    apiInstance.DeletePiggyBankWithHttpInfo(id, xTraceId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PiggyBanksApi.DeletePiggyBankWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the piggy bank. |  |
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
| **204** | Piggy bank deleted. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getpiggybank"></a>
# **GetPiggyBank**
> PiggyBankSingle GetPiggyBank (string id, Guid? xTraceId = null)

Get a single piggy bank.

Get a single piggy bank.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetPiggyBankExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PiggyBanksApi(config);
            var id = 123;  // string | The ID of the piggy bank.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Get a single piggy bank.
                PiggyBankSingle result = apiInstance.GetPiggyBank(id, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PiggyBanksApi.GetPiggyBank: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetPiggyBankWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single piggy bank.
    ApiResponse<PiggyBankSingle> response = apiInstance.GetPiggyBankWithHttpInfo(id, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PiggyBanksApi.GetPiggyBankWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the piggy bank. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**PiggyBankSingle**](PiggyBankSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested piggy bank |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listattachmentbypiggybank"></a>
# **ListAttachmentByPiggyBank**
> AttachmentArray ListAttachmentByPiggyBank (string id, Guid? xTraceId = null, int? page = null)

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
    public class ListAttachmentByPiggyBankExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PiggyBanksApi(config);
            var id = 123;  // string | The ID of the piggy bank.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // Lists all attachments.
                AttachmentArray result = apiInstance.ListAttachmentByPiggyBank(id, xTraceId, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PiggyBanksApi.ListAttachmentByPiggyBank: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListAttachmentByPiggyBankWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Lists all attachments.
    ApiResponse<AttachmentArray> response = apiInstance.ListAttachmentByPiggyBankWithHttpInfo(id, xTraceId, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PiggyBanksApi.ListAttachmentByPiggyBankWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the piggy bank. |  |
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

<a id="listeventbypiggybank"></a>
# **ListEventByPiggyBank**
> PiggyBankEventArray ListEventByPiggyBank (string id, Guid? xTraceId = null, int? page = null)

List all events linked to a piggy bank.

List all events linked to a piggy bank (adding and removing money).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListEventByPiggyBankExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PiggyBanksApi(config);
            var id = 123;  // string | The ID of the piggy bank
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List all events linked to a piggy bank.
                PiggyBankEventArray result = apiInstance.ListEventByPiggyBank(id, xTraceId, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PiggyBanksApi.ListEventByPiggyBank: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListEventByPiggyBankWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all events linked to a piggy bank.
    ApiResponse<PiggyBankEventArray> response = apiInstance.ListEventByPiggyBankWithHttpInfo(id, xTraceId, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PiggyBanksApi.ListEventByPiggyBankWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the piggy bank |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**PiggyBankEventArray**](PiggyBankEventArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of piggy bank related events |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listpiggybank"></a>
# **ListPiggyBank**
> PiggyBankArray ListPiggyBank (Guid? xTraceId = null, int? page = null)

List all piggy banks.

List all piggy banks.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListPiggyBankExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PiggyBanksApi(config);
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List all piggy banks.
                PiggyBankArray result = apiInstance.ListPiggyBank(xTraceId, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PiggyBanksApi.ListPiggyBank: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListPiggyBankWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all piggy banks.
    ApiResponse<PiggyBankArray> response = apiInstance.ListPiggyBankWithHttpInfo(xTraceId, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PiggyBanksApi.ListPiggyBankWithHttpInfo: " + e.Message);
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

[**PiggyBankArray**](PiggyBankArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of piggy banks |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storepiggybank"></a>
# **StorePiggyBank**
> PiggyBankSingle StorePiggyBank (PiggyBankStore piggyBankStore, Guid? xTraceId = null)

Store a new piggy bank

Creates a new piggy bank. The data required can be submitted as a JSON body or as a list of parameters.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class StorePiggyBankExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PiggyBanksApi(config);
            var piggyBankStore = new PiggyBankStore(); // PiggyBankStore | JSON array or key=value pairs with the necessary piggy bank information. See the model for the exact specifications.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Store a new piggy bank
                PiggyBankSingle result = apiInstance.StorePiggyBank(piggyBankStore, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PiggyBanksApi.StorePiggyBank: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StorePiggyBankWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Store a new piggy bank
    ApiResponse<PiggyBankSingle> response = apiInstance.StorePiggyBankWithHttpInfo(piggyBankStore, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PiggyBanksApi.StorePiggyBankWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **piggyBankStore** | [**PiggyBankStore**](PiggyBankStore.md) | JSON array or key&#x3D;value pairs with the necessary piggy bank information. See the model for the exact specifications. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**PiggyBankSingle**](PiggyBankSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New piggy bank stored, result in response. |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatepiggybank"></a>
# **UpdatePiggyBank**
> PiggyBankSingle UpdatePiggyBank (string id, PiggyBankUpdate piggyBankUpdate, Guid? xTraceId = null)

Update existing piggy bank.

Update existing piggy bank.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class UpdatePiggyBankExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PiggyBanksApi(config);
            var id = 123;  // string | The ID of the piggy bank
            var piggyBankUpdate = new PiggyBankUpdate(); // PiggyBankUpdate | JSON array with updated piggy bank information. See the model for the exact specifications.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Update existing piggy bank.
                PiggyBankSingle result = apiInstance.UpdatePiggyBank(id, piggyBankUpdate, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PiggyBanksApi.UpdatePiggyBank: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdatePiggyBankWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing piggy bank.
    ApiResponse<PiggyBankSingle> response = apiInstance.UpdatePiggyBankWithHttpInfo(id, piggyBankUpdate, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PiggyBanksApi.UpdatePiggyBankWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the piggy bank |  |
| **piggyBankUpdate** | [**PiggyBankUpdate**](PiggyBankUpdate.md) | JSON array with updated piggy bank information. See the model for the exact specifications. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**PiggyBankSingle**](PiggyBankSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated piggy bank stored, result in response |  -  |
| **422** | Validation error. The body will have the exact details. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

