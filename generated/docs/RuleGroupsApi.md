# FireflyIII.Api.RuleGroupsApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteRuleGroup**](RuleGroupsApi.md#deleterulegroup) | **DELETE** /api/v1/rule_groups/{id} | Delete a rule group. |
| [**FireRuleGroup**](RuleGroupsApi.md#firerulegroup) | **POST** /api/v1/rule_groups/{id}/trigger | Fire the rule group on your transactions. |
| [**GetRuleGroup**](RuleGroupsApi.md#getrulegroup) | **GET** /api/v1/rule_groups/{id} | Get a single rule group. |
| [**ListRuleByGroup**](RuleGroupsApi.md#listrulebygroup) | **GET** /api/v1/rule_groups/{id}/rules | List rules in this rule group. |
| [**ListRuleGroup**](RuleGroupsApi.md#listrulegroup) | **GET** /api/v1/rule_groups | List all rule groups. |
| [**StoreRuleGroup**](RuleGroupsApi.md#storerulegroup) | **POST** /api/v1/rule_groups | Store a new rule group. |
| [**TestRuleGroup**](RuleGroupsApi.md#testrulegroup) | **GET** /api/v1/rule_groups/{id}/test | Test which transactions would be hit by the rule group. No changes will be made. |
| [**UpdateRuleGroup**](RuleGroupsApi.md#updaterulegroup) | **PUT** /api/v1/rule_groups/{id} | Update existing rule group. |

<a id="deleterulegroup"></a>
# **DeleteRuleGroup**
> void DeleteRuleGroup (int id)

Delete a rule group.

Delete a rule group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class DeleteRuleGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RuleGroupsApi(config);
            var id = 1;  // int | The ID of the rule group.

            try
            {
                // Delete a rule group.
                apiInstance.DeleteRuleGroup(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RuleGroupsApi.DeleteRuleGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteRuleGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a rule group.
    apiInstance.DeleteRuleGroupWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RuleGroupsApi.DeleteRuleGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the rule group. |  |

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
| **204** | Rule group deleted. |  -  |
| **404** | No such rule group |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="firerulegroup"></a>
# **FireRuleGroup**
> void FireRuleGroup (int id, DateTime? start = null, DateTime? end = null, string accounts = null)

Fire the rule group on your transactions.

Fire the rule group on your transactions. Changes will be made by the rules in the rule group! Limit the result if you want to.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class FireRuleGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RuleGroupsApi(config);
            var id = 1;  // int | The ID of the rule group.
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the transactions the actions will be applied to. Both the start date and the end date must be present.  (optional) 
            var end = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the transactions the actions will be applied to. Both the start date and the end date must be present.  (optional) 
            var accounts = 1,2,3;  // string | Limit the testing of the rule group to these asset accounts. Only asset accounts will be accepted. Other types will be silently dropped.  (optional) 

            try
            {
                // Fire the rule group on your transactions.
                apiInstance.FireRuleGroup(id, start, end, accounts);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RuleGroupsApi.FireRuleGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the FireRuleGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Fire the rule group on your transactions.
    apiInstance.FireRuleGroupWithHttpInfo(id, start, end, accounts);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RuleGroupsApi.FireRuleGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the rule group. |  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the transactions the actions will be applied to. Both the start date and the end date must be present.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the transactions the actions will be applied to. Both the start date and the end date must be present.  | [optional]  |
| **accounts** | **string** | Limit the testing of the rule group to these asset accounts. Only asset accounts will be accepted. Other types will be silently dropped.  | [optional]  |

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

<a id="getrulegroup"></a>
# **GetRuleGroup**
> RuleGroupSingle GetRuleGroup (int id)

Get a single rule group.

Get a single rule group. This does not include the rules. For that, see below.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class GetRuleGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RuleGroupsApi(config);
            var id = 1;  // int | The ID of the rule group.

            try
            {
                // Get a single rule group.
                RuleGroupSingle result = apiInstance.GetRuleGroup(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RuleGroupsApi.GetRuleGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetRuleGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single rule group.
    ApiResponse<RuleGroupSingle> response = apiInstance.GetRuleGroupWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RuleGroupsApi.GetRuleGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the rule group. |  |

### Return type

[**RuleGroupSingle**](RuleGroupSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested rule group |  -  |
| **404** | Rule group not found. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listrulebygroup"></a>
# **ListRuleByGroup**
> RuleArray ListRuleByGroup (int id, int? page = null)

List rules in this rule group.

List rules in this rule group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListRuleByGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RuleGroupsApi(config);
            var id = 1;  // int | The ID of the rule group.
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List rules in this rule group.
                RuleArray result = apiInstance.ListRuleByGroup(id, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RuleGroupsApi.ListRuleByGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListRuleByGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List rules in this rule group.
    ApiResponse<RuleArray> response = apiInstance.ListRuleByGroupWithHttpInfo(id, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RuleGroupsApi.ListRuleByGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the rule group. |  |
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
| **200** | A list of rules. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listrulegroup"></a>
# **ListRuleGroup**
> RuleGroupArray ListRuleGroup (int? page = null)

List all rule groups.

List all rule groups.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListRuleGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RuleGroupsApi(config);
            var page = 1;  // int? | Page number. The default pagination is 50 (optional) 

            try
            {
                // List all rule groups.
                RuleGroupArray result = apiInstance.ListRuleGroup(page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RuleGroupsApi.ListRuleGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListRuleGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all rule groups.
    ApiResponse<RuleGroupArray> response = apiInstance.ListRuleGroupWithHttpInfo(page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RuleGroupsApi.ListRuleGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number. The default pagination is 50 | [optional]  |

### Return type

[**RuleGroupArray**](RuleGroupArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of rule groups. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storerulegroup"></a>
# **StoreRuleGroup**
> RuleGroupSingle StoreRuleGroup (RuleGroup ruleGroup)

Store a new rule group.

Creates a new rule group. The data required can be submitted as a JSON body or as a list of parameters.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class StoreRuleGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RuleGroupsApi(config);
            var ruleGroup = new RuleGroup(); // RuleGroup | JSON array or key=value pairs with the necessary rule group information. See the model for the exact specifications.

            try
            {
                // Store a new rule group.
                RuleGroupSingle result = apiInstance.StoreRuleGroup(ruleGroup);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RuleGroupsApi.StoreRuleGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StoreRuleGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Store a new rule group.
    ApiResponse<RuleGroupSingle> response = apiInstance.StoreRuleGroupWithHttpInfo(ruleGroup);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RuleGroupsApi.StoreRuleGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **ruleGroup** | [**RuleGroup**](RuleGroup.md) | JSON array or key&#x3D;value pairs with the necessary rule group information. See the model for the exact specifications. |  |

### Return type

[**RuleGroupSingle**](RuleGroupSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New rule group stored, result in response. |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="testrulegroup"></a>
# **TestRuleGroup**
> TransactionArray TestRuleGroup (int id, int? page = null, DateTime? start = null, DateTime? end = null, int? searchLimit = null, int? triggeredLimit = null, string accounts = null)

Test which transactions would be hit by the rule group. No changes will be made.

Test which transactions would be hit by the rule group. No changes will be made. Limit the result if you want to.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class TestRuleGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RuleGroupsApi(config);
            var id = 1;  // int | The ID of the rule group.
            var page = 1;  // int? | Page number. The default pagination is 50 items. (optional) 
            var start = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the transactions the test will be applied to. Both the start date and the end date must be present.  (optional) 
            var end = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the transactions the test will be applied to. Both the start date and the end date must be present.  (optional) 
            var searchLimit = 56;  // int? | Maximum number of transactions Firefly III will try. Don't set this too high, or it will take Firefly III very long to run the test. I suggest a max of 200.  (optional) 
            var triggeredLimit = 56;  // int? | Maximum number of transactions the rule group can actually trigger on, before Firefly III stops. I would suggest setting this to 10 or 15. Don't go above the user's page size, because browsing to page 2 or 3 of a test result would fire the test again, making any navigation efforts very slow.  (optional) 
            var accounts = 1,2,3;  // string | Limit the testing of the rule group to these asset accounts. Only asset accounts will be accepted. Other types will be silently dropped.  (optional) 

            try
            {
                // Test which transactions would be hit by the rule group. No changes will be made.
                TransactionArray result = apiInstance.TestRuleGroup(id, page, start, end, searchLimit, triggeredLimit, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RuleGroupsApi.TestRuleGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the TestRuleGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Test which transactions would be hit by the rule group. No changes will be made.
    ApiResponse<TransactionArray> response = apiInstance.TestRuleGroupWithHttpInfo(id, page, start, end, searchLimit, triggeredLimit, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RuleGroupsApi.TestRuleGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the rule group. |  |
| **page** | **int?** | Page number. The default pagination is 50 items. | [optional]  |
| **start** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the transactions the test will be applied to. Both the start date and the end date must be present.  | [optional]  |
| **end** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the transactions the test will be applied to. Both the start date and the end date must be present.  | [optional]  |
| **searchLimit** | **int?** | Maximum number of transactions Firefly III will try. Don&#39;t set this too high, or it will take Firefly III very long to run the test. I suggest a max of 200.  | [optional]  |
| **triggeredLimit** | **int?** | Maximum number of transactions the rule group can actually trigger on, before Firefly III stops. I would suggest setting this to 10 or 15. Don&#39;t go above the user&#39;s page size, because browsing to page 2 or 3 of a test result would fire the test again, making any navigation efforts very slow.  | [optional]  |
| **accounts** | **string** | Limit the testing of the rule group to these asset accounts. Only asset accounts will be accepted. Other types will be silently dropped.  | [optional]  |

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
| **200** | A list of transactions that would be changed by any of the rules of the rule group. No changes will be made. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updaterulegroup"></a>
# **UpdateRuleGroup**
> RuleGroupSingle UpdateRuleGroup (int id, RuleGroup ruleGroup)

Update existing rule group.

Update existing rule group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class UpdateRuleGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new RuleGroupsApi(config);
            var id = 1;  // int | The ID of the rule group.
            var ruleGroup = new RuleGroup(); // RuleGroup | JSON array with updated rule group information. See the model for the exact specifications.

            try
            {
                // Update existing rule group.
                RuleGroupSingle result = apiInstance.UpdateRuleGroup(id, ruleGroup);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RuleGroupsApi.UpdateRuleGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateRuleGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing rule group.
    ApiResponse<RuleGroupSingle> response = apiInstance.UpdateRuleGroupWithHttpInfo(id, ruleGroup);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RuleGroupsApi.UpdateRuleGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** | The ID of the rule group. |  |
| **ruleGroup** | [**RuleGroup**](RuleGroup.md) | JSON array with updated rule group information. See the model for the exact specifications. |  |

### Return type

[**RuleGroupSingle**](RuleGroupSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated rule group stored, result in response |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

