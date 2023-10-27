# FireflyIIINet.Api.NetWorthApi

All URIs are relative to *https://demo.firefly-iii.org/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetNetWorth**](NetWorthApi.md#getnetworth) | **GET** /v2/net-worth | Shows the net worth |

<a id="getnetworth"></a>
# **GetNetWorth**
> List&lt;TransactionSum&gt; GetNetWorth (DateTime date, Guid? xTraceId = null)

Shows the net worth

Shows a multi-currency overview of the user's net worth. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetNetWorthExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new NetWorthApi(config);
            var date = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Shows the net worth
                List<TransactionSum> result = apiInstance.GetNetWorth(date, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling NetWorthApi.GetNetWorth: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetNetWorthWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Shows the net worth
    ApiResponse<List<TransactionSum>> response = apiInstance.GetNetWorthWithHttpInfo(date, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling NetWorthApi.GetNetWorthWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **date** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

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
| **422** | Validation error. The body will have the exact details. |  -  |
| **200** | An array of net worths. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

