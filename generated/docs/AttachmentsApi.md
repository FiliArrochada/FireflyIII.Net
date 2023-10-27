# FireflyIIINet.Api.AttachmentsApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteAttachment**](AttachmentsApi.md#deleteattachment) | **DELETE** /api/v1/attachments/{id} | Delete an attachment. |
| [**DownloadAttachment**](AttachmentsApi.md#downloadattachment) | **GET** /api/v1/attachments/{id}/download | Download a single attachment. |
| [**GetAttachment**](AttachmentsApi.md#getattachment) | **GET** /api/v1/attachments/{id} | Get a single attachment. |
| [**ListAttachment**](AttachmentsApi.md#listattachment) | **GET** /api/v1/attachments | List all attachments. |
| [**StoreAttachment**](AttachmentsApi.md#storeattachment) | **POST** /api/v1/attachments | Store a new attachment. |
| [**UpdateAttachment**](AttachmentsApi.md#updateattachment) | **PUT** /api/v1/attachments/{id} | Update existing attachment. |
| [**UploadAttachment**](AttachmentsApi.md#uploadattachment) | **POST** /api/v1/attachments/{id}/upload | Upload an attachment. |

<a id="deleteattachment"></a>
# **DeleteAttachment**
> void DeleteAttachment (int id)

Delete an attachment.

With this endpoint you delete an attachment, including any stored file data. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DeleteAttachmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttachmentsApi(config);
            var id = 1;  // int | The ID of the single.

            try
            {
                // Delete an attachment.
                apiInstance.DeleteAttachment(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttachmentsApi.DeleteAttachment: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteAttachmentWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete an attachment.
    apiInstance.DeleteAttachmentWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttachmentsApi.DeleteAttachmentWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the single. |  |

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
| **204** | Attachment deleted. |  -  |
| **404** | No such attachment |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="downloadattachment"></a>
# **DownloadAttachment**
> System.IO.Stream DownloadAttachment (int id)

Download a single attachment.

This endpoint allows you to download the binary content of a transaction. It will be sent to you as a download, using the content type \"application/octet-stream\" and content disposition \"attachment; filename=example.pdf\". 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DownloadAttachmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttachmentsApi(config);
            var id = 1;  // int | The ID of the attachment.

            try
            {
                // Download a single attachment.
                System.IO.Stream result = apiInstance.DownloadAttachment(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttachmentsApi.DownloadAttachment: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DownloadAttachmentWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Download a single attachment.
    ApiResponse<System.IO.Stream> response = apiInstance.DownloadAttachmentWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttachmentsApi.DownloadAttachmentWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the attachment. |  |

### Return type

**System.IO.Stream**

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested attachment |  -  |
| **404** | File not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getattachment"></a>
# **GetAttachment**
> AttachmentSingle GetAttachment (int id)

Get a single attachment.

Get a single attachment. This endpoint only returns the available metadata for the attachment. Actual file data is handled in two other endpoints (see below). 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetAttachmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttachmentsApi(config);
            var id = 1;  // int | The ID of the attachment.

            try
            {
                // Get a single attachment.
                AttachmentSingle result = apiInstance.GetAttachment(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttachmentsApi.GetAttachment: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAttachmentWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single attachment.
    ApiResponse<AttachmentSingle> response = apiInstance.GetAttachmentWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttachmentsApi.GetAttachmentWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the attachment. |  |

### Return type

[**AttachmentSingle**](AttachmentSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested attachment |  -  |
| **404** | Attachment not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listattachment"></a>
# **ListAttachment**
> AttachmentArray ListAttachment (int? page = null)

List all attachments.

This endpoint lists all attachments. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListAttachmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttachmentsApi(config);
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List all attachments.
                AttachmentArray result = apiInstance.ListAttachment(page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttachmentsApi.ListAttachment: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListAttachmentWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all attachments.
    ApiResponse<AttachmentArray> response = apiInstance.ListAttachmentWithHttpInfo(page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttachmentsApi.ListAttachmentWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
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
| **200** | A list of attachments. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storeattachment"></a>
# **StoreAttachment**
> AttachmentSingle StoreAttachment (AttachmentStore attachmentStore)

Store a new attachment.

Creates a new attachment. The data required can be submitted as a JSON body or as a list of parameters. You cannot use this endpoint to upload the actual file data (see below). This endpoint only creates the attachment object. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class StoreAttachmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttachmentsApi(config);
            var attachmentStore = new AttachmentStore(); // AttachmentStore | JSON array or key=value pairs with the necessary attachment information. See the model for the exact specifications.

            try
            {
                // Store a new attachment.
                AttachmentSingle result = apiInstance.StoreAttachment(attachmentStore);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttachmentsApi.StoreAttachment: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StoreAttachmentWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Store a new attachment.
    ApiResponse<AttachmentSingle> response = apiInstance.StoreAttachmentWithHttpInfo(attachmentStore);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttachmentsApi.StoreAttachmentWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **attachmentStore** | [**AttachmentStore**](AttachmentStore.md) | JSON array or key&#x3D;value pairs with the necessary attachment information. See the model for the exact specifications. |  |

### Return type

[**AttachmentSingle**](AttachmentSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New attachment stored, result in response. |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateattachment"></a>
# **UpdateAttachment**
> AttachmentSingle UpdateAttachment (int id, AttachmentUpdate attachmentUpdate)

Update existing attachment.

Update the meta data for an existing attachment. This endpoint does not allow you to upload or download data. For that, see below. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class UpdateAttachmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttachmentsApi(config);
            var id = 1;  // int | The ID of the attachment.
            var attachmentUpdate = new AttachmentUpdate(); // AttachmentUpdate | JSON array with updated attachment information. See the model for the exact specifications.

            try
            {
                // Update existing attachment.
                AttachmentSingle result = apiInstance.UpdateAttachment(id, attachmentUpdate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttachmentsApi.UpdateAttachment: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateAttachmentWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing attachment.
    ApiResponse<AttachmentSingle> response = apiInstance.UpdateAttachmentWithHttpInfo(id, attachmentUpdate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttachmentsApi.UpdateAttachmentWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the attachment. |  |
| **attachmentUpdate** | [**AttachmentUpdate**](AttachmentUpdate.md) | JSON array with updated attachment information. See the model for the exact specifications. |  |

### Return type

[**AttachmentSingle**](AttachmentSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated attachment stored, result in response |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="uploadattachment"></a>
# **UploadAttachment**
> void UploadAttachment (int id, System.IO.Stream body = null)

Upload an attachment.

Use this endpoint to upload (and possible overwrite) the file contents of an attachment. Simply put the entire file in the body as binary data. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class UploadAttachmentExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AttachmentsApi(config);
            var id = 1;  // int | The ID of the attachment.
            var body = new System.IO.MemoryStream(System.IO.File.ReadAllBytes("/path/to/file.txt"));  // System.IO.Stream |  (optional) 

            try
            {
                // Upload an attachment.
                apiInstance.UploadAttachment(id, body);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AttachmentsApi.UploadAttachment: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UploadAttachmentWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Upload an attachment.
    apiInstance.UploadAttachmentWithHttpInfo(id, body);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AttachmentsApi.UploadAttachmentWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the attachment. |  |
| **body** | **System.IO.Stream****System.IO.Stream** |  | [optional]  |

### Return type

void (empty response body)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: application/octet-stream
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Upload was a success |  -  |
| **404** | File not found |  -  |
| **422** | Upload invalid or empty file. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

