# FireflyIII.Api.RulesApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteRule**](RulesApi.md#deleterule) | **DELETE** /api/v1/rules/{id} | Delete an rule. |
| [**FireRule**](RulesApi.md#firerule) | **POST** /api/v1/rules/{id}/trigger | Fire the rule on your transactions. |
| [**GetRule**](RulesApi.md#getrule) | **GET** /api/v1/rules/{id} | Get a single rule. |
| [**ListRule**](RulesApi.md#listrule) | **GET** /api/v1/rules | List all rules. |
| [**StoreRule**](RulesApi.md#storerule) | **POST** /api/v1/rules | Store a new rule |
| [**TestRule**](RulesApi.md#testrule) | **GET** /api/v1/rules/{id}/test | Test which transactions would be hit by the rule. No changes will be made. |
| [**UpdateRule**](RulesApi.md#updaterule) | **PUT** /api/v1/rules/{id} | Update existing rule. |

<a id="deleterule"></a>
# **DeleteRule**
> void DeleteRule (int id)

Delete an rule.

Delete an rule.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class DeleteRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RulesApi(config);
            var id = 1;  // int | The ID of the rule.

            try
            {
                // Delete an rule.
                apiInstance.DeleteRule(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RulesApi.DeleteRule: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteRuleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete an rule.
    apiInstance.DeleteRuleWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RulesApi.DeleteRuleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the rule. |  |

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
| **204** | Rule deleted. |  -  |
| **404** | No such rule |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="firerule"></a>
# **FireRule**
> void FireRule (int id, DateTime? start = null, DateTime? end = null, string accounts = null)

Fire the rule on your transactions.

Fire the rule group on your transactions. Changes will be made by the rules in the group! Limit the result if you want to.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class FireRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RulesApi(config);
            var id = 1;  // int | The ID of the rule.
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the transactions the actions will be applied to. Both the start date and the end date must be present.  (optional) 
            var end = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the transactions the actions will be applied to. Both the start date and the end date must be present.  (optional) 
            var accounts = 1,2,3;  // string | Limit the testing of the rule to these asset accounts. Only asset accounts will be accepted. Other types will be silently dropped.  (optional) 

            try
            {
                // Fire the rule on your transactions.
                apiInstance.FireRule(id, start, end, accounts);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RulesApi.FireRule: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FireRuleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Fire the rule on your transactions.
    apiInstance.FireRuleWithHttpInfo(id, start, end, accounts);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RulesApi.FireRuleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the rule. |  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the transactions the actions will be applied to. Both the start date and the end date must be present.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the transactions the actions will be applied to. Both the start date and the end date must be present.  | [optional]  |
| **accounts** | **string** | Limit the testing of the rule to these asset accounts. Only asset accounts will be accepted. Other types will be silently dropped.  | [optional]  |

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
| **204** | The rules in the group are executed. Due to the setup of this function (asynchronous job execution) the result cannot be displayed. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getrule"></a>
# **GetRule**
> RuleSingle GetRule (int id)

Get a single rule.

Get a single rule.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class GetRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RulesApi(config);
            var id = 1;  // int | The ID of the object.X

            try
            {
                // Get a single rule.
                RuleSingle result = apiInstance.GetRule(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RulesApi.GetRule: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetRuleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single rule.
    ApiResponse<RuleSingle> response = apiInstance.GetRuleWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RulesApi.GetRuleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the object.X |  |

### Return type

[**RuleSingle**](RuleSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested rule |  -  |
| **404** | Rule not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listrule"></a>
# **ListRule**
> RuleArray ListRule (int? page = null)

List all rules.

List all rules.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RulesApi(config);
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List all rules.
                RuleArray result = apiInstance.ListRule(page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RulesApi.ListRule: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListRuleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all rules.
    ApiResponse<RuleArray> response = apiInstance.ListRuleWithHttpInfo(page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RulesApi.ListRuleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**RuleArray**](RuleArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of rules |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storerule"></a>
# **StoreRule**
> RuleSingle StoreRule (Rule rule)

Store a new rule

Creates a new rule. The data required can be submitted as a JSON body or as a list of parameters.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class StoreRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RulesApi(config);
            var rule = new Rule(); // Rule | JSON array or key=value pairs with the necessary rule information. See the model for the exact specifications.

            try
            {
                // Store a new rule
                RuleSingle result = apiInstance.StoreRule(rule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RulesApi.StoreRule: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StoreRuleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Store a new rule
    ApiResponse<RuleSingle> response = apiInstance.StoreRuleWithHttpInfo(rule);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RulesApi.StoreRuleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **rule** | [**Rule**](Rule.md) | JSON array or key&#x3D;value pairs with the necessary rule information. See the model for the exact specifications. |  |

### Return type

[**RuleSingle**](RuleSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New rule stored, result in response. |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="testrule"></a>
# **TestRule**
> TransactionArray TestRule (int id, int? page = null, DateTime? start = null, DateTime? end = null, int? searchLimit = null, int? triggeredLimit = null, string accounts = null)

Test which transactions would be hit by the rule. No changes will be made.

Test which transactions would be hit by the rule. No changes will be made. Limit the result if you want to.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class TestRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RulesApi(config);
            var id = 1;  // int | The ID of the rule.
            var page = 1;  // int? | Page number. The default pagination is 50 items. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the transactions the test will be applied to. Both the start date and the end date must be present.  (optional) 
            var end = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the transactions the test will be applied to. Both the start date and the end date must be present.  (optional) 
            var searchLimit = 56;  // int? | Maximum number of transactions Firefly III will try. Don't set this too high, or it will take Firefly III very long to run the test. I suggest a max of 200.  (optional) 
            var triggeredLimit = 56;  // int? | Maximum number of transactions the rule can actually trigger on, before Firefly III stops. I would suggest setting this to 10 or 15. Don't go above the user's page size, because browsing to page 2 or 3 of a test result would fire the test again, making any navigation efforts very slow.  (optional) 
            var accounts = 1,2,3;  // string | Limit the testing of the rule to these asset accounts. Only asset accounts will be accepted. Other types will be silently dropped.  (optional) 

            try
            {
                // Test which transactions would be hit by the rule. No changes will be made.
                TransactionArray result = apiInstance.TestRule(id, page, start, end, searchLimit, triggeredLimit, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RulesApi.TestRule: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the TestRuleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Test which transactions would be hit by the rule. No changes will be made.
    ApiResponse<TransactionArray> response = apiInstance.TestRuleWithHttpInfo(id, page, start, end, searchLimit, triggeredLimit, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RulesApi.TestRuleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the rule. |  |
| **page** | **int?** | Page number. The default pagination is 50 items. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the transactions the test will be applied to. Both the start date and the end date must be present.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the transactions the test will be applied to. Both the start date and the end date must be present.  | [optional]  |
| **searchLimit** | **int?** | Maximum number of transactions Firefly III will try. Don&#39;t set this too high, or it will take Firefly III very long to run the test. I suggest a max of 200.  | [optional]  |
| **triggeredLimit** | **int?** | Maximum number of transactions the rule can actually trigger on, before Firefly III stops. I would suggest setting this to 10 or 15. Don&#39;t go above the user&#39;s page size, because browsing to page 2 or 3 of a test result would fire the test again, making any navigation efforts very slow.  | [optional]  |
| **accounts** | **string** | Limit the testing of the rule to these asset accounts. Only asset accounts will be accepted. Other types will be silently dropped.  | [optional]  |

### Return type

[**TransactionArray**](TransactionArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of transactions that would be changed by the rule. No changes will be made. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updaterule"></a>
# **UpdateRule**
> RuleSingle UpdateRule (int id, Rule rule)

Update existing rule.

Update existing rule.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class UpdateRuleExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RulesApi(config);
            var id = 1;  // int | The ID of the object.X
            var rule = new Rule(); // Rule | JSON array with updated rule information. See the model for the exact specifications.

            try
            {
                // Update existing rule.
                RuleSingle result = apiInstance.UpdateRule(id, rule);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RulesApi.UpdateRule: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateRuleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing rule.
    ApiResponse<RuleSingle> response = apiInstance.UpdateRuleWithHttpInfo(id, rule);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RulesApi.UpdateRuleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the object.X |  |
| **rule** | [**Rule**](Rule.md) | JSON array with updated rule information. See the model for the exact specifications. |  |

### Return type

[**RuleSingle**](RuleSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated rule stored, result in response |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

