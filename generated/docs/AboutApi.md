# FireflyIIINet.Api.AboutApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetAbout**](AboutApi.md#getabout) | **GET** /api/v1/about | System information end point. |
| [**GetCron**](AboutApi.md#getcron) | **GET** /api/v1/cron/{cliToken} | Cron job endpoint |
| [**GetCurrentUser**](AboutApi.md#getcurrentuser) | **GET** /api/v1/about/user | Currently authenticated user endpoint. |

<a id="getabout"></a>
# **GetAbout**
> SystemInfo GetAbout ()

System information end point.

Returns general system information and versions of the (supporting) software. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetAboutExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AboutApi(config);

            try
            {
                // System information end point.
                SystemInfo result = apiInstance.GetAbout();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AboutApi.GetAbout: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAboutWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // System information end point.
    ApiResponse<SystemInfo> response = apiInstance.GetAboutWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AboutApi.GetAboutWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**SystemInfo**](SystemInfo.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The available system information |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getcron"></a>
# **GetCron**
> CronResult GetCron (string cliToken, DateTime? date = null, bool? force = null)

Cron job endpoint

Firefly III has one endpoint for its various cron related tasks. Send a GET to this endpoint to run the cron. The cron requires the CLI token to be present. The cron job will fire for all users. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetCronExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AboutApi(config);
            var cliToken = d5ea6b5fb774618dd6ad6ba6e0a7f55c;  // string | The CLI token of any user in Firefly III, required to run the cron job.
            var date = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD. This can be used to make the cron job pretend it's running on another day.  (optional) 
            var force = false;  // bool? | Forces the cron job to fire, regardless of whether it has fired before. This may result in double transactions or weird budgets, so be careful.  (optional) 

            try
            {
                // Cron job endpoint
                CronResult result = apiInstance.GetCron(cliToken, date, force);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AboutApi.GetCron: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCronWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Cron job endpoint
    ApiResponse<CronResult> response = apiInstance.GetCronWithHttpInfo(cliToken, date, force);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AboutApi.GetCronWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **cliToken** | **string** | The CLI token of any user in Firefly III, required to run the cron job. |  |
| **date** | **DateTime?** | A date formatted YYYY-MM-DD. This can be used to make the cron job pretend it&#39;s running on another day.  | [optional]  |
| **force** | **bool?** | Forces the cron job to fire, regardless of whether it has fired before. This may result in double transactions or weird budgets, so be careful.  | [optional]  |

### Return type

[**CronResult**](CronResult.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The result of the cron job(s) firing. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getcurrentuser"></a>
# **GetCurrentUser**
> UserSingle GetCurrentUser ()

Currently authenticated user endpoint.

Returns the currently authenticated user. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetCurrentUserExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new AboutApi(config);

            try
            {
                // Currently authenticated user endpoint.
                UserSingle result = apiInstance.GetCurrentUser();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling AboutApi.GetCurrentUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCurrentUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Currently authenticated user endpoint.
    ApiResponse<UserSingle> response = apiInstance.GetCurrentUserWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling AboutApi.GetCurrentUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**UserSingle**](UserSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth), [local_bearer_auth](../README.md#local_bearer_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The user |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

