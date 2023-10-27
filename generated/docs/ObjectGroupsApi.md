# FireflyIIINet.Api.ObjectGroupsApi

All URIs are relative to *https://demo.firefly-iii.org*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteObjectGroup**](ObjectGroupsApi.md#deleteobjectgroup) | **DELETE** /api/v1/object_groups/{id} | Delete a object group. |
| [**GetObjectGroup**](ObjectGroupsApi.md#getobjectgroup) | **GET** /api/v1/object_groups/{id} | Get a single object group. |
| [**ListBillByObjectGroup**](ObjectGroupsApi.md#listbillbyobjectgroup) | **GET** /api/v1/object_groups/{id}/bills | List all bills with this object group. |
| [**ListObjectGroups**](ObjectGroupsApi.md#listobjectgroups) | **GET** /api/v1/object_groups | List all oject groups. |
| [**ListPiggyBankByObjectGroup**](ObjectGroupsApi.md#listpiggybankbyobjectgroup) | **GET** /api/v1/object_groups/{id}/piggy_banks | List all piggy banks related to the object group. |
| [**UpdateObjectGroup**](ObjectGroupsApi.md#updateobjectgroup) | **PUT** /api/v1/object_groups/{id} | Update existing object group. |

<a id="deleteobjectgroup"></a>
# **DeleteObjectGroup**
> void DeleteObjectGroup (string id)

Delete a object group.

Delete a object group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class DeleteObjectGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectGroupsApi(config);
            var id = 123;  // string | The ID of the object group.

            try
            {
                // Delete a object group.
                apiInstance.DeleteObjectGroup(id);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ObjectGroupsApi.DeleteObjectGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteObjectGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete a object group.
    apiInstance.DeleteObjectGroupWithHttpInfo(id);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ObjectGroupsApi.DeleteObjectGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the object group. |  |

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
| **204** | Object group deleted. |  -  |
| **404** | No such object group |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getobjectgroup"></a>
# **GetObjectGroup**
> ObjectGroupSingle GetObjectGroup (string id)

Get a single object group.

Get a single object group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class GetObjectGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectGroupsApi(config);
            var id = 123;  // string | The ID of the object group.

            try
            {
                // Get a single object group.
                ObjectGroupSingle result = apiInstance.GetObjectGroup(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ObjectGroupsApi.GetObjectGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetObjectGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get a single object group.
    ApiResponse<ObjectGroupSingle> response = apiInstance.GetObjectGroupWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ObjectGroupsApi.GetObjectGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the object group. |  |

### Return type

[**ObjectGroupSingle**](ObjectGroupSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The requested object group |  -  |
| **404** | Object group not found |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listbillbyobjectgroup"></a>
# **ListBillByObjectGroup**
> BillArray ListBillByObjectGroup (string id, int? page = null)

List all bills with this object group.

List all bills with this object group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListBillByObjectGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectGroupsApi(config);
            var id = 123;  // string | The ID of the account.
            var page = 56;  // int? | Page number. The default pagination is per 50 items. (optional) 

            try
            {
                // List all bills with this object group.
                BillArray result = apiInstance.ListBillByObjectGroup(id, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ObjectGroupsApi.ListBillByObjectGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListBillByObjectGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all bills with this object group.
    ApiResponse<BillArray> response = apiInstance.ListBillByObjectGroupWithHttpInfo(id, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ObjectGroupsApi.ListBillByObjectGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the account. |  |
| **page** | **int?** | Page number. The default pagination is per 50 items. | [optional]  |

### Return type

[**BillArray**](BillArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of bills. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listobjectgroups"></a>
# **ListObjectGroups**
> ObjectGroupArray ListObjectGroups (int? page = null)

List all oject groups.

List all oject groups.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListObjectGroupsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectGroupsApi(config);
            var page = 1;  // int? | Page number. The default pagination is 50. (optional) 

            try
            {
                // List all oject groups.
                ObjectGroupArray result = apiInstance.ListObjectGroups(page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ObjectGroupsApi.ListObjectGroups: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListObjectGroupsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all oject groups.
    ApiResponse<ObjectGroupArray> response = apiInstance.ListObjectGroupsWithHttpInfo(page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ObjectGroupsApi.ListObjectGroupsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **page** | **int?** | Page number. The default pagination is 50. | [optional]  |

### Return type

[**ObjectGroupArray**](ObjectGroupArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of object groups |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="listpiggybankbyobjectgroup"></a>
# **ListPiggyBankByObjectGroup**
> PiggyBankArray ListPiggyBankByObjectGroup (string id, int? page = null)

List all piggy banks related to the object group.

This endpoint returns a list of all the piggy banks connected to the object group. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class ListPiggyBankByObjectGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectGroupsApi(config);
            var id = 123;  // string | The ID of the account.
            var page = 56;  // int? | Page number. The default pagination is per 50 items. (optional) 

            try
            {
                // List all piggy banks related to the object group.
                PiggyBankArray result = apiInstance.ListPiggyBankByObjectGroup(id, page);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ObjectGroupsApi.ListPiggyBankByObjectGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListPiggyBankByObjectGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List all piggy banks related to the object group.
    ApiResponse<PiggyBankArray> response = apiInstance.ListPiggyBankByObjectGroupWithHttpInfo(id, page);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ObjectGroupsApi.ListPiggyBankByObjectGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the account. |  |
| **page** | **int?** | Page number. The default pagination is per 50 items. | [optional]  |

### Return type

[**PiggyBankArray**](PiggyBankArray.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.api+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A list of piggy banks |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="updateobjectgroup"></a>
# **UpdateObjectGroup**
> ObjectGroupSingle UpdateObjectGroup (string id, ObjectGroupUpdate objectGroupUpdate)

Update existing object group.

Update existing object group.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;

namespace Example
{
    public class UpdateObjectGroupExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://demo.firefly-iii.org";
            // Configure OAuth2 access token for authorization: firefly_iii_auth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ObjectGroupsApi(config);
            var id = 123;  // string | The ID of the object group
            var objectGroupUpdate = new ObjectGroupUpdate(); // ObjectGroupUpdate | JSON array with updated piggy bank information. See the model for the exact specifications.

            try
            {
                // Update existing object group.
                ObjectGroupSingle result = apiInstance.UpdateObjectGroup(id, objectGroupUpdate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ObjectGroupsApi.UpdateObjectGroup: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateObjectGroupWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update existing object group.
    ApiResponse<ObjectGroupSingle> response = apiInstance.UpdateObjectGroupWithHttpInfo(id, objectGroupUpdate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ObjectGroupsApi.UpdateObjectGroupWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the object group |  |
| **objectGroupUpdate** | [**ObjectGroupUpdate**](ObjectGroupUpdate.md) | JSON array with updated piggy bank information. See the model for the exact specifications. |  |

### Return type

[**ObjectGroupSingle**](ObjectGroupSingle.md)

### Authorization

[firefly_iii_auth](../README.md#firefly_iii_auth)

### HTTP request headers

 - **Content-Type**: application/json, application/x-www-form-urlencoded
 - **Accept**: application/vnd.api+json, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Updated object group stored, result in response |  -  |
| **422** | Validation errors (see body) |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

