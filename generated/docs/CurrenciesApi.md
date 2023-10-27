# FireflyIII.Api.CurrenciesApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DefaultCurrency**](CurrenciesApi.md#defaultcurrency) | **POST** /api/v1/currencies/{code}/default | Make currency default currency. |
| [**DeleteCurrency**](CurrenciesApi.md#deletecurrency) | **DELETE** /api/v1/currencies/{code} | Delete a currency. |
| [**DisableCurrency**](CurrenciesApi.md#disablecurrency) | **POST** /api/v1/currencies/{code}/disable | Disable a currency. |
| [**EnableCurrency**](CurrenciesApi.md#enablecurrency) | **POST** /api/v1/currencies/{code}/enable | Enable a single currency. |
| [**GetCurrency**](CurrenciesApi.md#getcurrency) | **GET** /api/v1/currencies/{code} | Get a single currency. |
| [**ListAccountByCurrency**](CurrenciesApi.md#listaccountbycurrency) | **GET** /api/v1/currencies/{code}/accounts | List all accounts with this currency. |
| [**ListAvailableBudgetByCurrency**](CurrenciesApi.md#listavailablebudgetbycurrency) | **GET** /api/v1/currencies/{code}/available_budgets | List all available budgets with this currency. |
| [**ListBillByCurrency**](CurrenciesApi.md#listbillbycurrency) | **GET** /api/v1/currencies/{code}/bills | List all bills with this currency. |
| [**ListBudgetLimitByCurrency**](CurrenciesApi.md#listbudgetlimitbycurrency) | **GET** /api/v1/currencies/{code}/budget_limits | List all budget limits with this currency |
| [**ListCurrency**](CurrenciesApi.md#listcurrency) | **GET** /api/v1/currencies | List all currencies. |
| [**ListExchangeRateByCurrency**](CurrenciesApi.md#listexchangeratebycurrency) | **GET** /api/v1/currencies/{code}/cer | List all known exchange rates with (from or to) this currency. |
| [**ListRecurrenceByCurrency**](CurrenciesApi.md#listrecurrencebycurrency) | **GET** /api/v1/currencies/{code}/recurrences | List all recurring transactions with this currency. |
| [**ListRuleByCurrency**](CurrenciesApi.md#listrulebycurrency) | **GET** /api/v1/currencies/{code}/rules | List all rules with this currency. |
| [**ListTransactionByCurrency**](CurrenciesApi.md#listtransactionbycurrency) | **GET** /api/v1/currencies/{code}/transactions | List all transactions with this currency. |
| [**StoreCurrency**](CurrenciesApi.md#storecurrency) | **POST** /api/v1/currencies | Store a new currency |
| [**UpdateCurrency**](CurrenciesApi.md#updatecurrency) | **PUT** /api/v1/currencies/{code} | Update existing currency. |

<a id="defaultcurrency"></a>
# **DefaultCurrency**
> CurrencySingle DefaultCurrency (string code)

Make currency default currency.

Make this currency the default currency. If the currency is not enabled, it will be enabled as well.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class DefaultCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = USD;  // string | The currency code.

            try
            {
                // Make currency default currency.
                CurrencySingle result = apiInstance.DefaultCurrency(code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.DefaultCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DefaultCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Make currency default currency.
    ApiResponse<CurrencySingle> response = apiInstance.DefaultCurrencyWithHttpInfo(code);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.DefaultCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |

### Return type

[**CurrencySingle**](CurrencySingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Currency has been made the default currency. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="deletecurrency"></a>
# **DeleteCurrency**
> void DeleteCurrency (string code)

Delete a currency.

Delete a currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class DeleteCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = GBP;  // string | The currency code.

            try
            {
                // Delete a currency.
                apiInstance.DeleteCurrency(code);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.DeleteCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a currency.
    apiInstance.DeleteCurrencyWithHttpInfo(code);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.DeleteCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |

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
| **204** | Currency deleted. |  -  |
| **404** | No such currency |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="disablecurrency"></a>
# **DisableCurrency**
> CurrencySingle DisableCurrency (int code)

Disable a currency.

Disable a currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class DisableCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = 56;  // int | The currency code.

            try
            {
                // Disable a currency.
                CurrencySingle result = apiInstance.DisableCurrency(code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.DisableCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DisableCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Disable a currency.
    ApiResponse<CurrencySingle> response = apiInstance.DisableCurrencyWithHttpInfo(code);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.DisableCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **int** | The currency code. |  |

### Return type

[**CurrencySingle**](CurrencySingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Currency was disabled. |  -  |
| **409** | Currency cannot be disabled, because it is still in use. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="enablecurrency"></a>
# **EnableCurrency**
> CurrencySingle EnableCurrency (string code)

Enable a single currency.

Enable a single currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class EnableCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = USD;  // string | The currency code.

            try
            {
                // Enable a single currency.
                CurrencySingle result = apiInstance.EnableCurrency(code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.EnableCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the EnableCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Enable a single currency.
    ApiResponse<CurrencySingle> response = apiInstance.EnableCurrencyWithHttpInfo(code);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.EnableCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |

### Return type

[**CurrencySingle**](CurrencySingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** | Currency was enabled. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getcurrency"></a>
# **GetCurrency**
> CurrencySingle GetCurrency (string code)

Get a single currency.

Get a single currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class GetCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = USD;  // string | The currency code.

            try
            {
                // Get a single currency.
                CurrencySingle result = apiInstance.GetCurrency(code);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.GetCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single currency.
    ApiResponse<CurrencySingle> response = apiInstance.GetCurrencyWithHttpInfo(code);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.GetCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |

### Return type

[**CurrencySingle**](CurrencySingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested currency |  -  |
| **404** | Currency not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listaccountbycurrency"></a>
# **ListAccountByCurrency**
> AccountArray ListAccountByCurrency (string code, int? page = null, string date = null, AccountTypeFilter type = null)

List all accounts with this currency.

List all accounts with this currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListAccountByCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = USD;  // string | The currency code.
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 
            var date = "date_example";  // string | A date formatted YYYY-MM-DD. When added to the request, Firefly III will show the account's balance on that day.  (optional) 
            var type = new AccountTypeFilter(); // AccountTypeFilter | Optional filter on the account type(s) returned (optional) 

            try
            {
                // List all accounts with this currency.
                AccountArray result = apiInstance.ListAccountByCurrency(code, page, date, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.ListAccountByCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListAccountByCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all accounts with this currency.
    ApiResponse<AccountArray> response = apiInstance.ListAccountByCurrencyWithHttpInfo(code, page, date, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.ListAccountByCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |
| **date** | **string** | A date formatted YYYY-MM-DD. When added to the request, Firefly III will show the account&#39;s balance on that day.  | [optional]  |
| **type** | [**AccountTypeFilter**](AccountTypeFilter.md) | Optional filter on the account type(s) returned | [optional]  |

### Return type

[**AccountArray**](AccountArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of accounts |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listavailablebudgetbycurrency"></a>
# **ListAvailableBudgetByCurrency**
> AvailableBudgetArray ListAvailableBudgetByCurrency (string code, int? page = null)

List all available budgets with this currency.

List all available budgets with this currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListAvailableBudgetByCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = EUR;  // string | The currency code.
            var page = 1;  // int? | Page number. The default pagination is 50 (optional) 

            try
            {
                // List all available budgets with this currency.
                AvailableBudgetArray result = apiInstance.ListAvailableBudgetByCurrency(code, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.ListAvailableBudgetByCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListAvailableBudgetByCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all available budgets with this currency.
    ApiResponse<AvailableBudgetArray> response = apiInstance.ListAvailableBudgetByCurrencyWithHttpInfo(code, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.ListAvailableBudgetByCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |
| **page** | **int?** | Page number. The default pagination is 50 | [optional]  |

### Return type

[**AvailableBudgetArray**](AvailableBudgetArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of available budgets |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbillbycurrency"></a>
# **ListBillByCurrency**
> BillArray ListBillByCurrency (string code, int? page = null)

List all bills with this currency.

List all bills with this currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListBillByCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = USD;  // string | The currency code.
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List all bills with this currency.
                BillArray result = apiInstance.ListBillByCurrency(code, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.ListBillByCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListBillByCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all bills with this currency.
    ApiResponse<BillArray> response = apiInstance.ListBillByCurrencyWithHttpInfo(code, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.ListBillByCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**BillArray**](BillArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of bills. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbudgetlimitbycurrency"></a>
# **ListBudgetLimitByCurrency**
> BudgetLimitArray ListBudgetLimitByCurrency (string code, int? page = null, DateTime? start = null, DateTime? end = null)

List all budget limits with this currency

List all budget limits with this currency

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListBudgetLimitByCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = USD;  // string | The currency code.
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 
            var start = Mon Jan 01 00:00:00 WET 2018;  // DateTime? | Start date for the budget limit list. (optional) 
            var end = Wed Jan 31 00:00:00 WET 2018;  // DateTime? | End date for the budget limit list. (optional) 

            try
            {
                // List all budget limits with this currency
                BudgetLimitArray result = apiInstance.ListBudgetLimitByCurrency(code, page, start, end);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.ListBudgetLimitByCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListBudgetLimitByCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all budget limits with this currency
    ApiResponse<BudgetLimitArray> response = apiInstance.ListBudgetLimitByCurrencyWithHttpInfo(code, page, start, end);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.ListBudgetLimitByCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |
| **start** | **DateTime?** | Start date for the budget limit list. | [optional]  |
| **end** | **DateTime?** | End date for the budget limit list. | [optional]  |

### Return type

[**BudgetLimitArray**](BudgetLimitArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of budget limits. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listcurrency"></a>
# **ListCurrency**
> CurrencyArray ListCurrency (int? page = null)

List all currencies.

List all currencies.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List all currencies.
                CurrencyArray result = apiInstance.ListCurrency(page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.ListCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all currencies.
    ApiResponse<CurrencyArray> response = apiInstance.ListCurrencyWithHttpInfo(page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.ListCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**CurrencyArray**](CurrencyArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of currencies. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listexchangeratebycurrency"></a>
# **ListExchangeRateByCurrency**
> ExchangeRateArray ListExchangeRateByCurrency (string code, int? page = null, DateTime? date = null, DateTime? start = null, DateTime? end = null)

List all known exchange rates with (from or to) this currency.

List all known exchange rates.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListExchangeRateByCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = GBP;  // string | The currency code.
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 
            var date = DateTime.Parse("2013-10-20");  // DateTime? | The date of which you want to know the exchange rate  (optional) 
            var start = DateTime.Parse("2013-10-20");  // DateTime? | Use this instead of the date parameter to search for a range of currency exchange values.  (optional) 
            var end = DateTime.Parse("2013-10-20");  // DateTime? | Use this instead of the date parameter to search for a range of currency exchange values.  (optional) 

            try
            {
                // List all known exchange rates with (from or to) this currency.
                ExchangeRateArray result = apiInstance.ListExchangeRateByCurrency(code, page, date, start, end);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.ListExchangeRateByCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListExchangeRateByCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all known exchange rates with (from or to) this currency.
    ApiResponse<ExchangeRateArray> response = apiInstance.ListExchangeRateByCurrencyWithHttpInfo(code, page, date, start, end);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.ListExchangeRateByCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |
| **date** | **DateTime?** | The date of which you want to know the exchange rate  | [optional]  |
| **start** | **DateTime?** | Use this instead of the date parameter to search for a range of currency exchange values.  | [optional]  |
| **end** | **DateTime?** | Use this instead of the date parameter to search for a range of currency exchange values.  | [optional]  |

### Return type

[**ExchangeRateArray**](ExchangeRateArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of exchange rates |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listrecurrencebycurrency"></a>
# **ListRecurrenceByCurrency**
> RecurrenceArray ListRecurrenceByCurrency (string code, int? page = null)

List all recurring transactions with this currency.

List all recurring transactions with this currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListRecurrenceByCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = EUR;  // string | The currency code.
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List all recurring transactions with this currency.
                RecurrenceArray result = apiInstance.ListRecurrenceByCurrency(code, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.ListRecurrenceByCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListRecurrenceByCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all recurring transactions with this currency.
    ApiResponse<RecurrenceArray> response = apiInstance.ListRecurrenceByCurrencyWithHttpInfo(code, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.ListRecurrenceByCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**RecurrenceArray**](RecurrenceArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of recurring transactions |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listrulebycurrency"></a>
# **ListRuleByCurrency**
> RuleArray ListRuleByCurrency (string code, int? page = null)

List all rules with this currency.

List all rules with this currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListRuleByCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = USD;  // string | The currency code.
            var page = 1;  // int? | Page number. The default pagination per 50. (optional) 

            try
            {
                // List all rules with this currency.
                RuleArray result = apiInstance.ListRuleByCurrency(code, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.ListRuleByCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListRuleByCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all rules with this currency.
    ApiResponse<RuleArray> response = apiInstance.ListRuleByCurrencyWithHttpInfo(code, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.ListRuleByCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |
| **page** | **int?** | Page number. The default pagination per 50. | [optional]  |

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

<a id="listtransactionbycurrency"></a>
# **ListTransactionByCurrency**
> TransactionArray ListTransactionByCurrency (string code, int? page = null, DateTime? startDate = null, DateTime? endDate = null, TransactionTypeFilter type = null)

List all transactions with this currency.

List all transactions with this currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class ListTransactionByCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = USD;  // string | The currency code.
            var page = 1;  // int? | Page number. The default pagination is per 50. (optional) 
            var startDate = Mon Sep 17 01:00:00 WEST 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the list of transactions.  (optional) 
            var endDate = Mon Dec 31 00:00:00 WET 2018;  // DateTime? | A date formatted YYYY-MM-DD, to limit the list of transactions.  (optional) 
            var type = new TransactionTypeFilter(); // TransactionTypeFilter | Optional filter on the transaction type(s) returned (optional) 

            try
            {
                // List all transactions with this currency.
                TransactionArray result = apiInstance.ListTransactionByCurrency(code, page, startDate, endDate, type);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.ListTransactionByCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListTransactionByCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all transactions with this currency.
    ApiResponse<TransactionArray> response = apiInstance.ListTransactionByCurrencyWithHttpInfo(code, page, startDate, endDate, type);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.ListTransactionByCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |
| **page** | **int?** | Page number. The default pagination is per 50. | [optional]  |
| **startDate** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the list of transactions.  | [optional]  |
| **endDate** | **DateTime?** | A date formatted YYYY-MM-DD, to limit the list of transactions.  | [optional]  |
| **type** | [**TransactionTypeFilter**](TransactionTypeFilter.md) | Optional filter on the transaction type(s) returned | [optional]  |

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
| **200** | A list of transactions. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="storecurrency"></a>
# **StoreCurrency**
> CurrencySingle StoreCurrency (Currency currency)

Store a new currency

Creates a new currency. The data required can be submitted as a JSON body or as a list of parameters.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class StoreCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var currency = new Currency(); // Currency | JSON array or key=value pairs with the necessary currency information. See the model for the exact specifications.

            try
            {
                // Store a new currency
                CurrencySingle result = apiInstance.StoreCurrency(currency);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.StoreCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StoreCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Store a new currency
    ApiResponse<CurrencySingle> response = apiInstance.StoreCurrencyWithHttpInfo(currency);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.StoreCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **currency** | [**Currency**](Currency.md) | JSON array or key&#x3D;value pairs with the necessary currency information. See the model for the exact specifications. |  |

### Return type

[**CurrencySingle**](CurrencySingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New currency stored, result in response. |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updatecurrency"></a>
# **UpdateCurrency**
> CurrencySingle UpdateCurrency (string code, Currency currency)

Update existing currency.

Update existing currency.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

namespace Example
{
    public class UpdateCurrencyExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CurrenciesApi(config);
            var code = EUR;  // string | The currency code.
            var currency = new Currency(); // Currency | JSON array with updated currency information. See the model for the exact specifications.

            try
            {
                // Update existing currency.
                CurrencySingle result = apiInstance.UpdateCurrency(code, currency);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CurrenciesApi.UpdateCurrency: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateCurrencyWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing currency.
    ApiResponse<CurrencySingle> response = apiInstance.UpdateCurrencyWithHttpInfo(code, currency);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CurrenciesApi.UpdateCurrencyWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** | The currency code. |  |
| **currency** | [**Currency**](Currency.md) | JSON array with updated currency information. See the model for the exact specifications. |  |

### Return type

[**CurrencySingle**](CurrencySingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated currency stored, result in response |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

