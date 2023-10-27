# FireflyIIINet.Api.WebhooksApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteWebhook**](WebhooksApi.md#deletewebhook) | **DELETE** /api/v1/webhooks/{id} | Delete a webhook. |
| [**DeleteWebhookMessage**](WebhooksApi.md#deletewebhookmessage) | **DELETE** /api/v1/webhooks/{id}/messages/{messageId} | Delete a webhook message. |
| [**DeleteWebhookMessageAttempt**](WebhooksApi.md#deletewebhookmessageattempt) | **DELETE** /api/v1/webhooks/{id}/messages/{messageId}/attempts/{attemptId} | Delete a webhook attempt. |
| [**GetSingleWebhookMessage**](WebhooksApi.md#getsinglewebhookmessage) | **GET** /api/v1/webhooks/{id}/messages/{messageId} | Get a single message from a webhook. |
| [**GetSingleWebhookMessageAttempt**](WebhooksApi.md#getsinglewebhookmessageattempt) | **GET** /api/v1/webhooks/{id}/messages/{messageId}/attempts/{attemptId} | Get a single failed attempt from a single webhook message. |
| [**GetWebhook**](WebhooksApi.md#getwebhook) | **GET** /api/v1/webhooks/{id} | Get a single webhook. |
| [**GetWebhookMessageAttempts**](WebhooksApi.md#getwebhookmessageattempts) | **GET** /api/v1/webhooks/{id}/messages/{messageId}/attempts | Get all the failed attempts of a single webhook message. |
| [**GetWebhookMessages**](WebhooksApi.md#getwebhookmessages) | **GET** /api/v1/webhooks/{id}/messages | Get all the messages of a single webhook. |
| [**ListWebhook**](WebhooksApi.md#listwebhook) | **GET** /api/v1/webhooks | List all webhooks. |
| [**StoreWebhook**](WebhooksApi.md#storewebhook) | **POST** /api/v1/webhooks | Store a new webhook |
| [**SubmitWebook**](WebhooksApi.md#submitwebook) | **POST** /api/v1/webhooks/{id}/submit | Submit messages for a webhook. |
| [**UpdateWebhook**](WebhooksApi.md#updatewebhook) | **PUT** /api/v1/webhooks/{id} | Update existing webhook. |

<a id="deletewebhook"></a>
# **DeleteWebhook**
> void DeleteWebhook (string id)

Delete a webhook.

Delete a webhook.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DeleteWebhookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var id = 123;  // string | The webhook ID.

            try
            {
                // Delete a webhook.
                apiInstance.DeleteWebhook(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.DeleteWebhook: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteWebhookWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a webhook.
    apiInstance.DeleteWebhookWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.DeleteWebhookWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The webhook ID. |  |

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
| **204** | Webhook deleted. |  -  |
| **404** | No such webhook. |  -  |
| **500** | Error when deleting. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletewebhookmessage"></a>
# **DeleteWebhookMessage**
> void DeleteWebhookMessage (string id, int messageId)

Delete a webhook message.

Delete a webhook message. Any time a webhook is triggered the message is stored before it's sent. You can delete them before or after sending.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DeleteWebhookMessageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var id = 123;  // string | The webhook ID.
            var messageId = 1;  // int | The webhook message ID.

            try
            {
                // Delete a webhook message.
                apiInstance.DeleteWebhookMessage(id, messageId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.DeleteWebhookMessage: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteWebhookMessageWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a webhook message.
    apiInstance.DeleteWebhookMessageWithHttpInfo(id, messageId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.DeleteWebhookMessageWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The webhook ID. |  |
| **messageId** | **int** | The webhook message ID. |  |

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
| **204** | Webhook message deleted. |  -  |
| **404** | No such webhook or webhook message. |  -  |
| **500** | Error when deleting. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletewebhookmessageattempt"></a>
# **DeleteWebhookMessageAttempt**
> void DeleteWebhookMessageAttempt (string id, int messageId, int attemptId)

Delete a webhook attempt.

Delete a webhook message attempt. If you delete all attempts for a webhook message, Firefly III will (once again) assume all is well with the webhook message and will try to send it again.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DeleteWebhookMessageAttemptExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var id = 123;  // string | The webhook ID.
            var messageId = 1;  // int | The webhook message ID.
            var attemptId = 1;  // int | The webhook message attempt ID.

            try
            {
                // Delete a webhook attempt.
                apiInstance.DeleteWebhookMessageAttempt(id, messageId, attemptId);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.DeleteWebhookMessageAttempt: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteWebhookMessageAttemptWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a webhook attempt.
    apiInstance.DeleteWebhookMessageAttemptWithHttpInfo(id, messageId, attemptId);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.DeleteWebhookMessageAttemptWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The webhook ID. |  |
| **messageId** | **int** | The webhook message ID. |  |
| **attemptId** | **int** | The webhook message attempt ID. |  |

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
| **204** | Webhook message attempt deleted. |  -  |
| **404** | No such webhook, webhook message or webhook attempt. |  -  |
| **500** | Error when deleting. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getsinglewebhookmessage"></a>
# **GetSingleWebhookMessage**
> WebhookMessageSingle GetSingleWebhookMessage (string id, int messageId)

Get a single message from a webhook.

When a webhook is triggered it will store the actual content of the webhook in a webhook message. You can view and analyse a single one using this endpoint.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetSingleWebhookMessageExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var id = 123;  // string | The webhook ID.
            var messageId = 1;  // int | The webhook message ID.

            try
            {
                // Get a single message from a webhook.
                WebhookMessageSingle result = apiInstance.GetSingleWebhookMessage(id, messageId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.GetSingleWebhookMessage: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSingleWebhookMessageWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single message from a webhook.
    ApiResponse<WebhookMessageSingle> response = apiInstance.GetSingleWebhookMessageWithHttpInfo(id, messageId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.GetSingleWebhookMessageWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The webhook ID. |  |
| **messageId** | **int** | The webhook message ID. |  |

### Return type

[**WebhookMessageSingle**](WebhookMessageSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A single webhook message. |  -  |
| **404** | Webhook message not found. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getsinglewebhookmessageattempt"></a>
# **GetSingleWebhookMessageAttempt**
> WebhookAttemptSingle GetSingleWebhookMessageAttempt (string id, int messageId, int attemptId)

Get a single failed attempt from a single webhook message.

When a webhook message fails to send it will store the failure in an \"attempt\". You can view and analyse these. Webhooks messages that receive too many attempts (failures) will not be fired. You must first clear out old attempts and try again. This endpoint shows you the details of a single attempt. The ID of the attempt must match the corresponding webhook and webhook message.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetSingleWebhookMessageAttemptExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var id = 123;  // string | The webhook ID.
            var messageId = 1;  // int | The webhook message ID.
            var attemptId = 1;  // int | The webhook attempt ID.

            try
            {
                // Get a single failed attempt from a single webhook message.
                WebhookAttemptSingle result = apiInstance.GetSingleWebhookMessageAttempt(id, messageId, attemptId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.GetSingleWebhookMessageAttempt: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSingleWebhookMessageAttemptWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single failed attempt from a single webhook message.
    ApiResponse<WebhookAttemptSingle> response = apiInstance.GetSingleWebhookMessageAttemptWithHttpInfo(id, messageId, attemptId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.GetSingleWebhookMessageAttemptWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The webhook ID. |  |
| **messageId** | **int** | The webhook message ID. |  |
| **attemptId** | **int** | The webhook attempt ID. |  |

### Return type

[**WebhookAttemptSingle**](WebhookAttemptSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A single webhook attempt. |  -  |
| **404** | Webhook message attempt not found. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getwebhook"></a>
# **GetWebhook**
> WebhookSingle GetWebhook (string id)

Get a single webhook.

Gets all info of a single webhook.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetWebhookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var id = 123;  // string | The webhook ID.

            try
            {
                // Get a single webhook.
                WebhookSingle result = apiInstance.GetWebhook(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.GetWebhook: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetWebhookWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single webhook.
    ApiResponse<WebhookSingle> response = apiInstance.GetWebhookWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.GetWebhookWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The webhook ID. |  |

### Return type

[**WebhookSingle**](WebhookSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested webhook. |  -  |
| **404** | Webhook not found. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getwebhookmessageattempts"></a>
# **GetWebhookMessageAttempts**
> WebhookAttemptArray GetWebhookMessageAttempts (string id, int messageId, int? page = null)

Get all the failed attempts of a single webhook message.

When a webhook message fails to send it will store the failure in an \"attempt\". You can view and analyse these. Webhook messages that receive too many attempts (failures) will not be sent again. You must first clear out old attempts before the message can go out again.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetWebhookMessageAttemptsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var id = 123;  // string | The webhook ID.
            var messageId = 1;  // int | The webhook message ID.
            var page = 1;  // int? | Page number. The default pagination is per 50 items. (optional) 

            try
            {
                // Get all the failed attempts of a single webhook message.
                WebhookAttemptArray result = apiInstance.GetWebhookMessageAttempts(id, messageId, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.GetWebhookMessageAttempts: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetWebhookMessageAttemptsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get all the failed attempts of a single webhook message.
    ApiResponse<WebhookAttemptArray> response = apiInstance.GetWebhookMessageAttemptsWithHttpInfo(id, messageId, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.GetWebhookMessageAttemptsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The webhook ID. |  |
| **messageId** | **int** | The webhook message ID. |  |
| **page** | **int?** | Page number. The default pagination is per 50 items. | [optional]  |

### Return type

[**WebhookAttemptArray**](WebhookAttemptArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of webhook attempts. |  -  |
| **404** | Webhook or webhook message not found. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getwebhookmessages"></a>
# **GetWebhookMessages**
> WebhookMessageArray GetWebhookMessages (string id)

Get all the messages of a single webhook.

When a webhook is triggered the actual message that will be send is stored in a \"message\". You can view and analyse these messages.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetWebhookMessagesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var id = 123;  // string | The webhook ID.

            try
            {
                // Get all the messages of a single webhook.
                WebhookMessageArray result = apiInstance.GetWebhookMessages(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.GetWebhookMessages: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetWebhookMessagesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get all the messages of a single webhook.
    ApiResponse<WebhookMessageArray> response = apiInstance.GetWebhookMessagesWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.GetWebhookMessagesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The webhook ID. |  |

### Return type

[**WebhookMessageArray**](WebhookMessageArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of webhook messages. |  -  |
| **404** | Webhook not found. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listwebhook"></a>
# **ListWebhook**
> WebhookArray ListWebhook (int? page = null)

List all webhooks.

List all the user's webhooks.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListWebhookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var page = 1;  // int? | The page number, if necessary. The default pagination is 50, so 50 webhooks per page. (optional) 

            try
            {
                // List all webhooks.
                WebhookArray result = apiInstance.ListWebhook(page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.ListWebhook: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListWebhookWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all webhooks.
    ApiResponse<WebhookArray> response = apiInstance.ListWebhookWithHttpInfo(page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.ListWebhookWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | The page number, if necessary. The default pagination is 50, so 50 webhooks per page. | [optional]  |

### Return type

[**WebhookArray**](WebhookArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of webhooks. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storewebhook"></a>
# **StoreWebhook**
> WebhookSingle StoreWebhook (WebhookStore webhookStore)

Store a new webhook

Creates a new webhook. The data required can be submitted as a JSON body or as a list of parameters. The webhook will be given a random secret. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class StoreWebhookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var webhookStore = new WebhookStore(); // WebhookStore | JSON array or key=value pairs with the necessary webhook information. See the model for the exact specifications.

            try
            {
                // Store a new webhook
                WebhookSingle result = apiInstance.StoreWebhook(webhookStore);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.StoreWebhook: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StoreWebhookWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Store a new webhook
    ApiResponse<WebhookSingle> response = apiInstance.StoreWebhookWithHttpInfo(webhookStore);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.StoreWebhookWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **webhookStore** | [**WebhookStore**](WebhookStore.md) | JSON array or key&#x3D;value pairs with the necessary webhook information. See the model for the exact specifications. |  |

### Return type

[**WebhookSingle**](WebhookSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New webhook stored, result in response. |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="submitwebook"></a>
# **SubmitWebook**
> void SubmitWebook (string id)

Submit messages for a webhook.

This endpoint will submit any open messages for this webhook. This is an asynchronous operation, so you can't see the result. Refresh the webhook message and/or the webhook message attempts to see the results. This may take some time if the webhook receiver is slow.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class SubmitWebookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var id = 123;  // string | The webhook ID.

            try
            {
                // Submit messages for a webhook.
                apiInstance.SubmitWebook(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.SubmitWebook: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SubmitWebookWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Submit messages for a webhook.
    apiInstance.SubmitWebookWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.SubmitWebookWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The webhook ID. |  |

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
| **200** | OK! |  -  |
| **204** | No messages to send, so did nothing. |  -  |
| **404** | Webhook not found. |  -  |
| **500** | Error while sending. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatewebhook"></a>
# **UpdateWebhook**
> WebhookSingle UpdateWebhook (string id, WebhookUpdate webhookUpdate)

Update existing webhook.

Update an existing webhook's information. If you wish to reset the secret, submit any value as the \"secret\". Firefly III will take this as a hint and reset the secret of the webhook.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class UpdateWebhookExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebhooksApi(config);
            var id = 123;  // string | The webhook ID.
            var webhookUpdate = new WebhookUpdate(); // WebhookUpdate | JSON array with updated webhook information. See the model for the exact specifications.

            try
            {
                // Update existing webhook.
                WebhookSingle result = apiInstance.UpdateWebhook(id, webhookUpdate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling WebhooksApi.UpdateWebhook: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateWebhookWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing webhook.
    ApiResponse<WebhookSingle> response = apiInstance.UpdateWebhookWithHttpInfo(id, webhookUpdate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling WebhooksApi.UpdateWebhookWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The webhook ID. |  |
| **webhookUpdate** | [**WebhookUpdate**](WebhookUpdate.md) | JSON array with updated webhook information. See the model for the exact specifications. |  |

### Return type

[**WebhookSingle**](WebhookSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated webhook stored, result in response |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

