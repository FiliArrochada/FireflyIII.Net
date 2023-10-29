# FireflyIIINet.Api.InsightApi

All URIs are relative to *https://demo.firefly-iii.org/api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**InsightExpenseAsset**](InsightApi.md#insightexpenseasset) | **GET** /v1/insight/expense/asset | Insight into expenses, grouped by asset account. |
| [**InsightExpenseBill**](InsightApi.md#insightexpensebill) | **GET** /v1/insight/expense/bill | Insight into expenses, grouped by bill. |
| [**InsightExpenseBudget**](InsightApi.md#insightexpensebudget) | **GET** /v1/insight/expense/budget | Insight into expenses, grouped by budget. |
| [**InsightExpenseCategory**](InsightApi.md#insightexpensecategory) | **GET** /v1/insight/expense/category | Insight into expenses, grouped by category. |
| [**InsightExpenseExpense**](InsightApi.md#insightexpenseexpense) | **GET** /v1/insight/expense/expense | Insight into expenses, grouped by expense account. |
| [**InsightExpenseNoBill**](InsightApi.md#insightexpensenobill) | **GET** /v1/insight/expense/no-bill | Insight into expenses, without bill. |
| [**InsightExpenseNoBudget**](InsightApi.md#insightexpensenobudget) | **GET** /v1/insight/expense/no-budget | Insight into expenses, without budget. |
| [**InsightExpenseNoCategory**](InsightApi.md#insightexpensenocategory) | **GET** /v1/insight/expense/no-category | Insight into expenses, without category. |
| [**InsightExpenseNoTag**](InsightApi.md#insightexpensenotag) | **GET** /v1/insight/expense/no-tag | Insight into expenses, without tag. |
| [**InsightExpenseTag**](InsightApi.md#insightexpensetag) | **GET** /v1/insight/expense/tag | Insight into expenses, grouped by tag. |
| [**InsightExpenseTotal**](InsightApi.md#insightexpensetotal) | **GET** /v1/insight/expense/total | Insight into total expenses. |
| [**InsightIncomeAsset**](InsightApi.md#insightincomeasset) | **GET** /v1/insight/income/asset | Insight into income, grouped by asset account. |
| [**InsightIncomeCategory**](InsightApi.md#insightincomecategory) | **GET** /v1/insight/income/category | Insight into income, grouped by category. |
| [**InsightIncomeNoCategory**](InsightApi.md#insightincomenocategory) | **GET** /v1/insight/income/no-category | Insight into income, without category. |
| [**InsightIncomeNoTag**](InsightApi.md#insightincomenotag) | **GET** /v1/insight/income/no-tag | Insight into income, without tag. |
| [**InsightIncomeRevenue**](InsightApi.md#insightincomerevenue) | **GET** /v1/insight/income/revenue | Insight into income, grouped by revenue account. |
| [**InsightIncomeTag**](InsightApi.md#insightincometag) | **GET** /v1/insight/income/tag | Insight into income, grouped by tag. |
| [**InsightIncomeTotal**](InsightApi.md#insightincometotal) | **GET** /v1/insight/income/total | Insight into total income. |
| [**InsightTransferCategory**](InsightApi.md#insighttransfercategory) | **GET** /v1/insight/transfer/category | Insight into transfers, grouped by category. |
| [**InsightTransferNoCategory**](InsightApi.md#insighttransfernocategory) | **GET** /v1/insight/transfer/no-category | Insight into transfers, without category. |
| [**InsightTransferNoTag**](InsightApi.md#insighttransfernotag) | **GET** /v1/insight/transfer/no-tag | Insight into expenses, without tag. |
| [**InsightTransferTag**](InsightApi.md#insighttransfertag) | **GET** /v1/insight/transfer/tag | Insight into transfers, grouped by tag. |
| [**InsightTransferTotal**](InsightApi.md#insighttransfertotal) | **GET** /v1/insight/transfer/total | Insight into total transfers. |
| [**InsightTransfers**](InsightApi.md#insighttransfers) | **GET** /v1/insight/transfer/asset | Insight into transfers, grouped by account. |

<a id="insightexpenseasset"></a>
# **InsightExpenseAsset**
> List&lt;InsightGroupEntry&gt; InsightExpenseAsset (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into expenses, grouped by asset account.

This endpoint gives a summary of the expenses made by the user, grouped by asset account. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseAssetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, grouped by asset account.
                List<InsightGroupEntry> result = apiInstance.InsightExpenseAsset(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseAsset: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseAssetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, grouped by asset account.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightExpenseAssetWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseAssetWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of asset accounts and expense details. Each asset account has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightexpensebill"></a>
# **InsightExpenseBill**
> List&lt;InsightGroupEntry&gt; InsightExpenseBill (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? bills = null, List<long>? accounts = null)

Insight into expenses, grouped by bill.

This endpoint gives a summary of the expenses made by the user, grouped by (any) bill. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseBillExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var bills = new List<long>?(); // List<long>? | The bills to be included in the results.  (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, grouped by bill.
                List<InsightGroupEntry> result = apiInstance.InsightExpenseBill(start, end, xTraceId, bills, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseBill: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseBillWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, grouped by bill.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightExpenseBillWithHttpInfo(start, end, xTraceId, bills, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseBillWithHttpInfo: " + e.Message);
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
| **bills** | [**List&lt;long&gt;?**](long.md) | The bills to be included in the results.  | [optional]  |
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of budget and expense details. Each budget has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightexpensebudget"></a>
# **InsightExpenseBudget**
> List&lt;InsightGroupEntry&gt; InsightExpenseBudget (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? budgets = null, List<long>? accounts = null)

Insight into expenses, grouped by budget.

This endpoint gives a summary of the expenses made by the user, grouped by (any) budget. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var budgets = new List<long>?(); // List<long>? | The budgets to be included in the results.  (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, grouped by budget.
                List<InsightGroupEntry> result = apiInstance.InsightExpenseBudget(start, end, xTraceId, budgets, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, grouped by budget.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightExpenseBudgetWithHttpInfo(start, end, xTraceId, budgets, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseBudgetWithHttpInfo: " + e.Message);
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
| **budgets** | [**List&lt;long&gt;?**](long.md) | The budgets to be included in the results.  | [optional]  |
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of budget and expense details. Each budget has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightexpensecategory"></a>
# **InsightExpenseCategory**
> List&lt;InsightGroupEntry&gt; InsightExpenseCategory (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? categories = null, List<long>? accounts = null)

Insight into expenses, grouped by category.

This endpoint gives a summary of the expenses made by the user, grouped by (any) category. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var categories = new List<long>?(); // List<long>? | The categories to be included in the results.  (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, grouped by category.
                List<InsightGroupEntry> result = apiInstance.InsightExpenseCategory(start, end, xTraceId, categories, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, grouped by category.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightExpenseCategoryWithHttpInfo(start, end, xTraceId, categories, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseCategoryWithHttpInfo: " + e.Message);
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
| **categories** | [**List&lt;long&gt;?**](long.md) | The categories to be included in the results.  | [optional]  |
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of category and expense details. Each category has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightexpenseexpense"></a>
# **InsightExpenseExpense**
> List&lt;InsightGroupEntry&gt; InsightExpenseExpense (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into expenses, grouped by expense account.

This endpoint gives a summary of the expenses made by the user, grouped by expense account. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseExpenseExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you add the accounts ID's of expense accounts, only those accounts are included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. You can combine both asset / liability and expense account ID's. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, grouped by expense account.
                List<InsightGroupEntry> result = apiInstance.InsightExpenseExpense(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseExpense: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseExpenseWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, grouped by expense account.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightExpenseExpenseWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseExpenseWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you add the accounts ID&#39;s of expense accounts, only those accounts are included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. You can combine both asset / liability and expense account ID&#39;s. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of expense accounts and expense details. Each expense acccount has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightexpensenobill"></a>
# **InsightExpenseNoBill**
> List&lt;InsightTotalEntry&gt; InsightExpenseNoBill (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into expenses, without bill.

This endpoint gives a summary of the expenses made by the user, including only expenses with no bill. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseNoBillExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, without bill.
                List<InsightTotalEntry> result = apiInstance.InsightExpenseNoBill(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseNoBill: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseNoBillWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, without bill.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightExpenseNoBillWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseNoBillWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of expense details. One row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightexpensenobudget"></a>
# **InsightExpenseNoBudget**
> List&lt;InsightTotalEntry&gt; InsightExpenseNoBudget (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into expenses, without budget.

This endpoint gives a summary of the expenses made by the user, including only expenses with no budget. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseNoBudgetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, without budget.
                List<InsightTotalEntry> result = apiInstance.InsightExpenseNoBudget(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseNoBudget: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseNoBudgetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, without budget.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightExpenseNoBudgetWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseNoBudgetWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of expense details. One row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightexpensenocategory"></a>
# **InsightExpenseNoCategory**
> List&lt;InsightTotalEntry&gt; InsightExpenseNoCategory (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into expenses, without category.

This endpoint gives a summary of the expenses made by the user, including only expenses with no category. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseNoCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, without category.
                List<InsightTotalEntry> result = apiInstance.InsightExpenseNoCategory(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseNoCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseNoCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, without category.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightExpenseNoCategoryWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseNoCategoryWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of expense details. One row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightexpensenotag"></a>
# **InsightExpenseNoTag**
> List&lt;InsightTotalEntry&gt; InsightExpenseNoTag (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into expenses, without tag.

This endpoint gives a summary of the expenses made by the user, including only expenses with no tag. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseNoTagExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, without tag.
                List<InsightTotalEntry> result = apiInstance.InsightExpenseNoTag(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseNoTag: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseNoTagWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, without tag.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightExpenseNoTagWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseNoTagWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of expense details. One row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightexpensetag"></a>
# **InsightExpenseTag**
> List&lt;InsightGroupEntry&gt; InsightExpenseTag (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? tags = null, List<long>? accounts = null)

Insight into expenses, grouped by tag.

This endpoint gives a summary of the expenses made by the user, grouped by (any) tag. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseTagExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var tags = new List<long>?(); // List<long>? | The tags to be included in the results.  (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, grouped by tag.
                List<InsightGroupEntry> result = apiInstance.InsightExpenseTag(start, end, xTraceId, tags, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseTag: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseTagWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, grouped by tag.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightExpenseTagWithHttpInfo(start, end, xTraceId, tags, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseTagWithHttpInfo: " + e.Message);
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
| **tags** | [**List&lt;long&gt;?**](long.md) | The tags to be included in the results.  | [optional]  |
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of tag and expense details. Each tag has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightexpensetotal"></a>
# **InsightExpenseTotal**
> List&lt;InsightTotalEntry&gt; InsightExpenseTotal (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into total expenses.

This endpoint gives a sum of the total expenses made by the user. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightExpenseTotalExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into total expenses.
                List<InsightTotalEntry> result = apiInstance.InsightExpenseTotal(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightExpenseTotal: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightExpenseTotalWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into total expenses.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightExpenseTotalWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightExpenseTotalWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only withdrawals from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of sums in different currencies. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightincomeasset"></a>
# **InsightIncomeAsset**
> List&lt;InsightGroupEntry&gt; InsightIncomeAsset (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into income, grouped by asset account.

This endpoint gives a summary of the income received by the user, grouped by asset account. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightIncomeAssetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into income, grouped by asset account.
                List<InsightGroupEntry> result = apiInstance.InsightIncomeAsset(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightIncomeAsset: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightIncomeAssetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into income, grouped by asset account.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightIncomeAssetWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightIncomeAssetWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of asset accounts and income details. Each asset account has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightincomecategory"></a>
# **InsightIncomeCategory**
> List&lt;InsightGroupEntry&gt; InsightIncomeCategory (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? categories = null, List<long>? accounts = null)

Insight into income, grouped by category.

This endpoint gives a summary of the income received by the user, grouped by (any) category. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightIncomeCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var categories = new List<long>?(); // List<long>? | The categories to be included in the results.  (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into income, grouped by category.
                List<InsightGroupEntry> result = apiInstance.InsightIncomeCategory(start, end, xTraceId, categories, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightIncomeCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightIncomeCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into income, grouped by category.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightIncomeCategoryWithHttpInfo(start, end, xTraceId, categories, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightIncomeCategoryWithHttpInfo: " + e.Message);
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
| **categories** | [**List&lt;long&gt;?**](long.md) | The categories to be included in the results.  | [optional]  |
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of category and income details. Each category has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightincomenocategory"></a>
# **InsightIncomeNoCategory**
> List&lt;InsightTotalEntry&gt; InsightIncomeNoCategory (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into income, without category.

This endpoint gives a summary of the income received by the user, including only income with no category. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightIncomeNoCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into income, without category.
                List<InsightTotalEntry> result = apiInstance.InsightIncomeNoCategory(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightIncomeNoCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightIncomeNoCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into income, without category.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightIncomeNoCategoryWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightIncomeNoCategoryWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of income details. One row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightincomenotag"></a>
# **InsightIncomeNoTag**
> List&lt;InsightTotalEntry&gt; InsightIncomeNoTag (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into income, without tag.

This endpoint gives a summary of the income received by the user, including only income with no tag. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightIncomeNoTagExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into income, without tag.
                List<InsightTotalEntry> result = apiInstance.InsightIncomeNoTag(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightIncomeNoTag: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightIncomeNoTagWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into income, without tag.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightIncomeNoTagWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightIncomeNoTagWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of income details. One row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightincomerevenue"></a>
# **InsightIncomeRevenue**
> List&lt;InsightGroupEntry&gt; InsightIncomeRevenue (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into income, grouped by revenue account.

This endpoint gives a summary of the income received by the user, grouped by revenue account. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightIncomeRevenueExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you add the accounts ID's of revenue accounts, only those accounts are included in the results. If you include ID's of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. You can combine both asset / liability and deposit account ID's. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into income, grouped by revenue account.
                List<InsightGroupEntry> result = apiInstance.InsightIncomeRevenue(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightIncomeRevenue: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightIncomeRevenueWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into income, grouped by revenue account.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightIncomeRevenueWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightIncomeRevenueWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you add the accounts ID&#39;s of revenue accounts, only those accounts are included in the results. If you include ID&#39;s of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. You can combine both asset / liability and deposit account ID&#39;s. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of revenue accounts and income details. Each revenue acccount has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightincometag"></a>
# **InsightIncomeTag**
> List&lt;InsightGroupEntry&gt; InsightIncomeTag (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? tags = null, List<long>? accounts = null)

Insight into income, grouped by tag.

This endpoint gives a summary of the income received by the user, grouped by (any) tag. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightIncomeTagExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var tags = new List<long>?(); // List<long>? | The tags to be included in the results.  (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into income, grouped by tag.
                List<InsightGroupEntry> result = apiInstance.InsightIncomeTag(start, end, xTraceId, tags, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightIncomeTag: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightIncomeTagWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into income, grouped by tag.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightIncomeTagWithHttpInfo(start, end, xTraceId, tags, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightIncomeTagWithHttpInfo: " + e.Message);
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
| **tags** | [**List&lt;long&gt;?**](long.md) | The tags to be included in the results.  | [optional]  |
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of tag and income details. Each tag has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insightincometotal"></a>
# **InsightIncomeTotal**
> List&lt;InsightTotalEntry&gt; InsightIncomeTotal (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into total income.

This endpoint gives a sum of the total income received by the user. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightIncomeTotalExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into total income.
                List<InsightTotalEntry> result = apiInstance.InsightIncomeTotal(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightIncomeTotal: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightIncomeTotalWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into total income.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightIncomeTotalWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightIncomeTotalWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only deposits to those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of sums in different currencies. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insighttransfercategory"></a>
# **InsightTransferCategory**
> List&lt;InsightGroupEntry&gt; InsightTransferCategory (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? categories = null, List<long>? accounts = null)

Insight into transfers, grouped by category.

This endpoint gives a summary of the transfers made by the user, grouped by (any) category. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightTransferCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var categories = new List<long>?(); // List<long>? | The categories to be included in the results.  (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only transfers between those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into transfers, grouped by category.
                List<InsightGroupEntry> result = apiInstance.InsightTransferCategory(start, end, xTraceId, categories, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightTransferCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightTransferCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into transfers, grouped by category.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightTransferCategoryWithHttpInfo(start, end, xTraceId, categories, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightTransferCategoryWithHttpInfo: " + e.Message);
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
| **categories** | [**List&lt;long&gt;?**](long.md) | The categories to be included in the results.  | [optional]  |
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only transfers between those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of category and transfer details. Each category has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insighttransfernocategory"></a>
# **InsightTransferNoCategory**
> List&lt;InsightTotalEntry&gt; InsightTransferNoCategory (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into transfers, without category.

This endpoint gives a summary of the transfers made by the user, including only transfers with no category. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightTransferNoCategoryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only transfers between those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into transfers, without category.
                List<InsightTotalEntry> result = apiInstance.InsightTransferNoCategory(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightTransferNoCategory: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightTransferNoCategoryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into transfers, without category.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightTransferNoCategoryWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightTransferNoCategoryWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only transfers between those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of transfer details. One row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insighttransfernotag"></a>
# **InsightTransferNoTag**
> List&lt;InsightTotalEntry&gt; InsightTransferNoTag (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into expenses, without tag.

This endpoint gives a summary of the transfers made by the user, including only transfers with no tag. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightTransferNoTagExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only transfers from those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into expenses, without tag.
                List<InsightTotalEntry> result = apiInstance.InsightTransferNoTag(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightTransferNoTag: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightTransferNoTagWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into expenses, without tag.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightTransferNoTagWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightTransferNoTagWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only transfers from those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of transfer details. One row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insighttransfertag"></a>
# **InsightTransferTag**
> List&lt;InsightGroupEntry&gt; InsightTransferTag (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? tags = null, List<long>? accounts = null)

Insight into transfers, grouped by tag.

This endpoint gives a summary of the transfers created by the user, grouped by (any) tag. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightTransferTagExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var tags = new List<long>?(); // List<long>? | The tags to be included in the results.  (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only transfers between those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into transfers, grouped by tag.
                List<InsightGroupEntry> result = apiInstance.InsightTransferTag(start, end, xTraceId, tags, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightTransferTag: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightTransferTagWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into transfers, grouped by tag.
    ApiResponse<List<InsightGroupEntry>> response = apiInstance.InsightTransferTagWithHttpInfo(start, end, xTraceId, tags, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightTransferTagWithHttpInfo: " + e.Message);
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
| **tags** | [**List&lt;long&gt;?**](long.md) | The tags to be included in the results.  | [optional]  |
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only transfers between those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightGroupEntry&gt;**](InsightGroupEntry.md)

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
| **200** | A list of tag and transfer details. Each tag has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insighttransfertotal"></a>
# **InsightTransferTotal**
> List&lt;InsightTotalEntry&gt; InsightTransferTotal (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into total transfers.

This endpoint gives a sum of the total amount transfers made by the user. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightTransferTotalExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only transfers between those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into total transfers.
                List<InsightTotalEntry> result = apiInstance.InsightTransferTotal(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightTransferTotal: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightTransferTotalWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into total transfers.
    ApiResponse<List<InsightTotalEntry>> response = apiInstance.InsightTransferTotalWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightTransferTotalWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only transfers between those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTotalEntry&gt;**](InsightTotalEntry.md)

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
| **200** | A list of sums in different currencies. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="insighttransfers"></a>
# **InsightTransfers**
> List&lt;InsightTransferEntry&gt; InsightTransfers (DateTime start, DateTime end, Guid? xTraceId = null, List<long>? accounts = null)

Insight into transfers, grouped by account.

This endpoint gives a summary of the transfers made by the user, grouped by asset account or lability. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class InsightTransfersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org/api";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new InsightApi(config);
            var start = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var end = DateTime.Parse("2013-10-20");  // DateTime | A date formatted YYYY-MM-DD. 
            var xTraceId = "xTraceId_example";  // Guid? | Unique identifier associated with this request. (optional) 
            var accounts = new List<long>?(); // List<long>? | The accounts to be included in the results. If you include ID's of asset accounts or liabilities, only transfers between those asset accounts / liabilities will be included. Other account ID's will be ignored.  (optional) 

            try
            {
                // Insight into transfers, grouped by account.
                List<InsightTransferEntry> result = apiInstance.InsightTransfers(start, end, xTraceId, accounts);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InsightApi.InsightTransfers: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the InsightTransfersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Insight into transfers, grouped by account.
    ApiResponse<List<InsightTransferEntry>> response = apiInstance.InsightTransfersWithHttpInfo(start, end, xTraceId, accounts);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InsightApi.InsightTransfersWithHttpInfo: " + e.Message);
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
| **accounts** | [**List&lt;long&gt;?**](long.md) | The accounts to be included in the results. If you include ID&#39;s of asset accounts or liabilities, only transfers between those asset accounts / liabilities will be included. Other account ID&#39;s will be ignored.  | [optional]  |

### Return type

[**List&lt;InsightTransferEntry&gt;**](InsightTransferEntry.md)

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
| **200** | A list of asset accounts and transfer details. Each asset account has one row per currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

