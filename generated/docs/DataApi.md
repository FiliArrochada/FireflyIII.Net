# FireflyIIINet.Api.DataApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DestroyData**](DataApi.md#destroydata) | **DELETE** /api/v1/data/destroy | Endpoint to destroy user data |

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

