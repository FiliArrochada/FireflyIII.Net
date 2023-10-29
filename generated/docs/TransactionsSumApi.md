# FireflyIIINet.Api.TransactionsSumApi

All URIs are relative to *https://demo.firefly-iii.org/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetBillsPaidTrSum**](TransactionsSumApi.md#getbillspaidtrsum) | **GET** /v2/bills/sum/paid | Returns the sum of the bills already paid in the period indicated. |
| [**GetBillsUnpaidTrSum**](TransactionsSumApi.md#getbillsunpaidtrsum) | **GET** /v2/bills/sum/unpaid | Returns the sum of the bills not yet paid in the period indicated. |

<a id="getbillspaidtrsum"></a>
# **GetBillsPaidTrSum**
> List&lt;TransactionSum&gt; GetBillsPaidTrSum (DateTime start, DateTime end, Guid? xTraceId = null)

Returns the sum of the bills already paid in the period indicated.

This endpoint sums up (by currency) the transactions linked to bills paid in the given period. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetBillsPaidTrSumExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionsSumApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Returns the sum of the bills already paid in the period indicated.
                List<TransactionSum> result = apiInstance.GetBillsPaidTrSum(start, end, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionsSumApi.GetBillsPaidTrSum: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetBillsPaidTrSumWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns the sum of the bills already paid in the period indicated.
    ApiResponse<List<TransactionSum>> response = apiInstance.GetBillsPaidTrSumWithHttpInfo(start, end, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TransactionsSumApi.GetBillsPaidTrSumWithHttpInfo: " + e.Message);
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

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

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
| **200** | An array of sums. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getbillsunpaidtrsum"></a>
# **GetBillsUnpaidTrSum**
> List&lt;TransactionSum&gt; GetBillsUnpaidTrSum (DateTime start, DateTime end, Guid? xTraceId = null)

Returns the sum of the bills not yet paid in the period indicated.

This endpoint sums up (by currency) the transactions linked to bills unpaid in the given period. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetBillsUnpaidTrSumExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TransactionsSumApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 

            try
            {
                // Returns the sum of the bills not yet paid in the period indicated.
                List<TransactionSum> result = apiInstance.GetBillsUnpaidTrSum(start, end, xTraceId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TransactionsSumApi.GetBillsUnpaidTrSum: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetBillsUnpaidTrSumWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns the sum of the bills not yet paid in the period indicated.
    ApiResponse<List<TransactionSum>> response = apiInstance.GetBillsUnpaidTrSumWithHttpInfo(start, end, xTraceId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TransactionsSumApi.GetBillsUnpaidTrSumWithHttpInfo: " + e.Message);
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

[**List&lt;TransactionSum&gt;**](TransactionSum.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

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
| **200** | An array of sums. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

