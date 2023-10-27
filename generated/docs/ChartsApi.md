# FireflyIIINet.Api.ChartsApi

All URIs are relative to *https://demo.firefly-iii.org/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetBalanceChart**](ChartsApi.md#getbalancechart) | **GET** /v2/chart/balance/balance | A chart that contains spent/earned amounts |
| [**GetChartAccountOverview**](ChartsApi.md#getchartaccountoverview) | **GET** /v2/chart/account/dashboard | Dashboard chart with asset account balance information. |

<a id="getbalancechart"></a>
# **GetBalanceChart**
> List&lt;ChartDataSetV2&gt; GetBalanceChart (DateTime start, DateTime end, List<int> accounts, PeriodProperty period, Guid? xTraceId = null)

A chart that contains spent/earned amounts

The chart contains spent/earned amounts for the given date range, grouped by the given period, and collected for the given accounts. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetBalanceChartExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new ChartsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var accounts = new List<int>(); // List<int> | An array of accounts that should be included. Example: accounts[]=1&accounts[]=2 
            var period = new PeriodProperty(); // PeriodProperty | The period by which the results must be grouped.
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // A chart that contains spent/earned amounts
                List<ChartDataSetV2> result = apiInstance.GetBalanceChart(start, end, accounts, period, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartsApi.GetBalanceChart: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetBalanceChartWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // A chart that contains spent/earned amounts
    ApiResponse<List<ChartDataSetV2>> response = apiInstance.GetBalanceChartWithHttpInfo(start, end, accounts, period, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChartsApi.GetBalanceChartWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **start** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **end** | **DateTime** | A date formatted YYYY-MM-DD.  |  |
| **accounts** | [**List&lt;int&gt;**](int.md) | An array of accounts that should be included. Example: accounts[]&#x3D;1&amp;accounts[]&#x3D;2  |  |
| **period** | [**PeriodProperty**](PeriodProperty.md) | The period by which the results must be grouped. |  |
| **xTraceId** | **Guid?** | Unique identifier associated with this request. | [optional]  |

### Return type

[**List&lt;ChartDataSetV2&gt;**](ChartDataSetV2.md)

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
| **200** | Chart information. Check out the model for more details. Each main entry is a set of data. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getchartaccountoverview"></a>
# **GetChartAccountOverview**
> List&lt;ChartDataSetV2&gt; GetChartAccountOverview (DateTime start, DateTime end, Guid? xTraceId = null)

Dashboard chart with asset account balance information.

This endpoint returns the data required to generate a chart with basic asset account balance information. By default it contains the users frontpage accounts OR all the user's asset accounts if this preference is empty. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetChartAccountOverviewExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";
            // Configure Bearer token for authorization: local_bearer_auth
            config.AccessToken = "YOUR_BEARER_TOKEN";

            var apiInstance = new ChartsApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Dashboard chart with asset account balance information.
                List<ChartDataSetV2> result = apiInstance.GetChartAccountOverview(start, end, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChartsApi.GetChartAccountOverview: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetChartAccountOverviewWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Dashboard chart with asset account balance information.
    ApiResponse<List<ChartDataSetV2>> response = apiInstance.GetChartAccountOverviewWithHttpInfo(start, end, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChartsApi.GetChartAccountOverviewWithHttpInfo: " + e.Message);
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

### Return type

[**List&lt;ChartDataSetV2&gt;**](ChartDataSetV2.md)

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
| **200** | Chart information. Check out the model for more details. Each main entry is a set of data. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

