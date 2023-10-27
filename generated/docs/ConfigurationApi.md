# FireflyIII.Api.ConfigurationApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetConfiguration**](ConfigurationApi.md#getconfiguration) | **GET** /api/v1/configuration | Get Firefly III system configuration. |
| [**SetConfiguration**](ConfigurationApi.md#setconfiguration) | **POST** /api/v1/configuration/{name} | Update configuration |

<a id="getconfiguration"></a>
# **GetConfiguration**
> ModelConfiguration GetConfiguration ()

Get Firefly III system configuration.

Get system configuration

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

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
                // Get Firefly III system configuration.
                ModelConfiguration result = apiInstance.GetConfiguration();
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
    // Get Firefly III system configuration.
    ApiResponse<ModelConfiguration> response = apiInstance.GetConfigurationWithHttpInfo();
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

[**ModelConfiguration**](ModelConfiguration.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | System configuration |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="setconfiguration"></a>
# **SetConfiguration**
> ModelConfiguration SetConfiguration (string name, string value)

Update configuration

Set a single config value.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIII.Api;
using FireflyIII.Client;
using FireflyIII.Model;

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
            var name = single_user_mode;  // string | The configuration value name.
            var value = "value_example";  // string | Can be a number or a boolean. This depends on the actual configuration value.

            try
            {
                // Update configuration
                ModelConfiguration result = apiInstance.SetConfiguration(name, value);
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
    // Update configuration
    ApiResponse<ModelConfiguration> response = apiInstance.SetConfigurationWithHttpInfo(name, value);
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
| **name** | **string** | The configuration value name. |  |
| **value** | **string** | Can be a number or a boolean. This depends on the actual configuration value. |  |

### Return type

[**ModelConfiguration**](ModelConfiguration.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded, application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | New config stored, result in response. |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

