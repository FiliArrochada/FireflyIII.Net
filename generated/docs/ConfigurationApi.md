# FireflyIIINet.Api.ConfigurationApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetConfiguration**](ConfigurationApi.md#getconfiguration) | **GET** /api/v1/configuration | Get Firefly III system configuration values. |
| [**GetSingleConfiguration**](ConfigurationApi.md#getsingleconfiguration) | **GET** /api/v1/configuration/{name} | Get a single Firefly III system configuration value |
| [**SetConfiguration**](ConfigurationApi.md#setconfiguration) | **PUT** /api/v1/configuration/{name} | Update configuration value |

<a id="getconfiguration"></a>
# **GetConfiguration**
> List&lt;ModelConfiguration&gt; GetConfiguration ()

Get Firefly III system configuration values.

Returns all editable and not-editable configuration values for this Firefly III installation

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetConfigurationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConfigurationApi(config);

            try
            {
                // Get Firefly III system configuration values.
                List<ModelConfiguration> result = apiInstance.GetConfiguration();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigurationApi.GetConfiguration: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetConfigurationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Firefly III system configuration values.
    ApiResponse<List<ModelConfiguration>> response = apiInstance.GetConfigurationWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigurationApi.GetConfigurationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;ModelConfiguration&gt;**](ModelConfiguration.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | System configuration values |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getsingleconfiguration"></a>
# **GetSingleConfiguration**
> ConfigurationSingle GetSingleConfiguration (ConfigValueFilter name)

Get a single Firefly III system configuration value

Returns one configuration variable for this Firefly III installation

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetSingleConfigurationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConfigurationApi(config);
            var name = new ConfigValueFilter(); // ConfigValueFilter | The name of the configuration value you want to know.

            try
            {
                // Get a single Firefly III system configuration value
                ConfigurationSingle result = apiInstance.GetSingleConfiguration(name);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigurationApi.GetSingleConfiguration: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSingleConfigurationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single Firefly III system configuration value
    ApiResponse<ConfigurationSingle> response = apiInstance.GetSingleConfigurationWithHttpInfo(name);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigurationApi.GetSingleConfigurationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | [**ConfigValueFilter**](ConfigValueFilter.md) | The name of the configuration value you want to know. |  |

### Return type

[**ConfigurationSingle**](ConfigurationSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | One system configuration value |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="setconfiguration"></a>
# **SetConfiguration**
> ConfigurationSingle SetConfiguration (ConfigValueUpdateFilter name, PolymorphicProperty value)

Update configuration value

Set a single configuration value. Not all configuration values can be updated so the list of accepted configuration variables is small.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class SetConfigurationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ConfigurationApi(config);
            var name = new ConfigValueUpdateFilter(); // ConfigValueUpdateFilter | The name of the configuration value you want to update.
            var value = new PolymorphicProperty(); // PolymorphicProperty | 

            try
            {
                // Update configuration value
                ConfigurationSingle result = apiInstance.SetConfiguration(name, value);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ConfigurationApi.SetConfiguration: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SetConfigurationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update configuration value
    ApiResponse<ConfigurationSingle> response = apiInstance.SetConfigurationWithHttpInfo(name, value);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ConfigurationApi.SetConfigurationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | [**ConfigValueUpdateFilter**](ConfigValueUpdateFilter.md) | The name of the configuration value you want to update. |  |
| **value** | [**PolymorphicProperty**](PolymorphicProperty.md) |  |  |

### Return type

[**ConfigurationSingle**](ConfigurationSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded, application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New configuration value stored, result in response. |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

