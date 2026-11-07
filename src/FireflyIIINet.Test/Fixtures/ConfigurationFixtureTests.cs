/*
 * Fixture tests for GET /v1/configuration, fed by what a Firefly III 6.7.9 server returns: a list
 * whose titles go beyond the spec's ConfigValueFilter (the editable configuration.* settings) and
 * whose values are booleans, integers, strings and objects.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FireflyIIINet.Api;
using FireflyIIINet.Model;
using FireflyIIINet.Test.RefitSlice;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class ConfigurationFixtureTests
    {
        private const string ConfigurationJson = """
        [
          {"title":"configuration.is_demo_site","value":false,"editable":true},
          {"title":"configuration.permission_update_check","value":-1,"editable":true},
          {"title":"configuration.enable_exchange_rates","value":false,"editable":true},
          {"title":"configuration.use_running_balance","value":true,"editable":true},
          {"title":"configuration.enable_external_map","value":false,"editable":true},
          {"title":"configuration.enable_external_rates","value":false,"editable":true},
          {"title":"configuration.allow_webhooks","value":false,"editable":true},
          {"title":"configuration.enable_batch_processing","value":true,"editable":true},
          {"title":"configuration.valid_url_protocols","value":"http,https","editable":true},
          {"title":"firefly.version","value":"6.7.9","editable":false},
          {"title":"firefly.default_location","value":{"longitude":"5.916667","latitude":"51.983333","zoom_level":"6"},"editable":false},
          {"title":"firefly.setting_from_a_future_release","value":true,"editable":false}
        ]
        """;

        private static Task<List<ModelConfiguration>> Read()
        {
            var http = new HttpClient(new CapturingHandler(ConfigurationJson)) { BaseAddress = new Uri("https://demo.firefly-iii.org/api") };
            return FireflyRefit.Create<IConfigurationApi>(http).GetConfiguration();
        }

        [Fact]
        public async Task GetConfiguration_Reads_The_Settings_The_Spec_Lists_Only_As_Editable()
        {
            var all = await Read();

            Assert.Equal(12, all.Count);
            var titles = all.Select(c => c.Title).ToList();
            Assert.Contains(ConfigValueFilter.ConfigurationEnableExchangeRates, titles);
            Assert.Contains(ConfigValueFilter.ConfigurationUseRunningBalance, titles);
            Assert.Contains(ConfigValueFilter.ConfigurationEnableExternalMap, titles);
            Assert.Contains(ConfigValueFilter.ConfigurationEnableExternalRates, titles);
            Assert.Contains(ConfigValueFilter.ConfigurationAllowWebhooks, titles);
            Assert.Contains(ConfigValueFilter.ConfigurationEnableBatchProcessing, titles);
            Assert.Contains(ConfigValueFilter.ConfigurationValidUrlProtocols, titles);
            Assert.Equal("http,https", all.Single(c => c.Title == ConfigValueFilter.ConfigurationValidUrlProtocols).Value.ActualInstance);
        }

        [Fact]
        public async Task GetConfiguration_Reads_An_Unknown_Setting_As_Unknown_Instead_Of_Failing()
        {
            var all = await Read();

            Assert.Equal(ConfigValueFilter.Unknown, all.Last().Title);
            Assert.Equal(true, all.Last().Value.ActualInstance);
        }
    }
}
