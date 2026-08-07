/*
 * Structural sweep over every Refit interface in FireflyIIINet.Api. For each method:
 *   - exactly one HTTP verb attribute, with a /v1/ or /v2/ route
 *   - every {placeholder} in the route has a matching parameter (name or [AliasAs])
 *   - a [Body] parameter implies a Content-Type [Headers] attribute (and at most one body)
 *   - the return type is Task or Task<T>
 * These invariants are what the hand-maintained conversion could get wrong silently
 * the sweep makes adding a new endpoint self-checking.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Refit;
using Xunit;

namespace FireflyIIINet.Test.RefitConformance
{
    public class RefitInterfaceConformanceTests
    {
        public static IEnumerable<object[]> ApiInterfaces()
        {
            return typeof(FireflyIIINet.Api.IAboutApi).Assembly.GetTypes()
                .Where(t => t.IsInterface && t.Namespace == "FireflyIIINet.Api")
                .Select(t => new object[] { t });
        }

        [Theory]
        [MemberData(nameof(ApiInterfaces))]
        public void Interface_Methods_Are_Wellformed(Type apiInterface)
        {
            var methods = apiInterface.GetMethods();
            Assert.NotEmpty(methods);

            foreach (var method in methods)
            {
                var id = $"{apiInterface.Name}.{method.Name}";

                // exactly one HTTP verb attribute with a versioned route
                var http = method.GetCustomAttributes<HttpMethodAttribute>(inherit: true).ToList();
                Assert.True(http.Count == 1, $"{id}: expected exactly one HTTP verb attribute, found {http.Count}");
                var route = http[0].Path;
                Assert.True(route.StartsWith("/v1/") || route.StartsWith("/v2/"),
                    $"{id}: route '{route}' does not start with /v1/ or /v2/");

                // every {placeholder} must be satisfiable by a parameter (name or AliasAs)
                var parameters = method.GetParameters();
                var parameterNames = parameters
                    .Select(p => p.GetCustomAttribute<AliasAsAttribute>()?.Name ?? p.Name)
                    .ToHashSet(StringComparer.Ordinal);
                foreach (Match m in Regex.Matches(route, @"\{(\w+)\}"))
                {
                    Assert.True(parameterNames.Contains(m.Groups[1].Value),
                        $"{id}: route placeholder '{{{m.Groups[1].Value}}}' has no matching parameter");
                }

                // [Body] implies a Content-Type header; never more than one body
                var bodyParams = parameters.Where(p => p.GetCustomAttribute<BodyAttribute>() != null).ToList();
                Assert.True(bodyParams.Count <= 1, $"{id}: has {bodyParams.Count} [Body] parameters");
                if (bodyParams.Count == 1)
                {
                    var headers = method.GetCustomAttribute<HeadersAttribute>();
                    Assert.True(headers != null && headers.Headers.Any(h => h.StartsWith("Content-Type:")),
                        $"{id}: [Body] parameter without a Content-Type [Headers] attribute");
                }

                // Task or Task<T> only
                Assert.True(method.ReturnType == typeof(Task)
                            || (method.ReturnType.IsGenericType
                                && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>)),
                    $"{id}: return type {method.ReturnType.Name} is not Task/Task<T>");

                // X-Trace-Id, when present, must be a header parameter
                foreach (var p in parameters.Where(p => p.Name == "xTraceId"))
                {
                    Assert.True(p.GetCustomAttribute<HeaderAttribute>()?.Header == "X-Trace-Id",
                        $"{id}: xTraceId parameter is not bound to the X-Trace-Id header");
                }
            }
        }
    }
}
