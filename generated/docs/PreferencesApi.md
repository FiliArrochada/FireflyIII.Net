# FireflyIIINet.Api.PreferencesApi

All URIs are relative to *https://demo.firefly-iii.org/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetPreference**](PreferencesApi.md#getpreference) | **GET** /v2/preferences/{name} | Return a single preference. |

<a id="getpreference"></a>
# **GetPreference**
> PreferenceSingle GetPreference (string name, Guid? xTraceId = null)

Return a single preference.

Return a single preference and the value.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetPreferenceExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new PreferencesApi(config);
            var name = currencyPreference;  // string | The name of the preference.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Return a single preference.
                PreferenceSingle result = apiInstance.GetPreference(name, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PreferencesApi.GetPreference: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetPreferenceWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Return a single preference.
    ApiResponse<PreferenceSingle> response = apiInstance.GetPreferenceWithHttpInfo(name, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PreferencesApi.GetPreferenceWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** | The name of the preference. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**PreferenceSingle**](PreferenceSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A single preference. |  -  |
| **401** | Unauthenticated |  -  |
| **404** | Page not found |  -  |
| **400** | Bad request |  -  |
| **500** | Internal exception |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

