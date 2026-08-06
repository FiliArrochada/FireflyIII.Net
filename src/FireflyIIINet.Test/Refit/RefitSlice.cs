/*
 * Runtime glue for the Refit vertical slice (test project only).
 *
 * Shows what productionizing Refit needs, reusing pieces already in the library:
 *   - FireflyRefitSettings.Create(): STJ serialization via SerializerOptions.Default plus
 *     the Firefly URL parameter formatter (lowercase booleans, [EnumMember] enum values)
 *   - a Bearer DelegatingHandler carrying the personal access token (replaces the old
 *     Configuration.AccessToken wiring in the generated ApiClient)
 * Plus a CapturingHandler so tests can assert the exact outgoing request without a live call.
 */

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FireflyIIINet.Client;
using Refit;

namespace FireflyIIINet.Test.RefitSlice
{
    /// <summary>Builds a Refit client for one API using the library's settings factory.</summary>
    public static class FireflyRefit
    {
        public static readonly RefitSettings Settings = FireflyRefitSettings.Create();

        public static T Create<T>(HttpClient http) => RestService.For<T>(http, Settings);
    }

    /// <summary>Injects `Authorization: Bearer &lt;token&gt;` when a token is available.</summary>
    public sealed class BearerTokenHandler : DelegatingHandler
    {
        private readonly Func<string> _token;
        public BearerTokenHandler(Func<string> token) { _token = token; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            var t = _token();
            if (!string.IsNullOrEmpty(t))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", t);
            return base.SendAsync(request, ct);
        }
    }

    /// <summary>Test double: records the outgoing request and returns a canned JSON response.</summary>
    public sealed class CapturingHandler : HttpMessageHandler
    {
        private readonly string _json;
        public HttpRequestMessage LastRequest { get; private set; }
        public string LastRequestBody { get; private set; }
        public CapturingHandler(string json) { _json = json; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            LastRequest = request;
            // read the body eagerly: Refit disposes the content after sending
            LastRequestBody = request.Content == null ? null : await request.Content.ReadAsStringAsync(ct);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_json, Encoding.UTF8, "application/json"),
            };
        }
    }
}
