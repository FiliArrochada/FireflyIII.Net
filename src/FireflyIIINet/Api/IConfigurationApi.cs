using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IConfigurationApi
    {
        [Get("/v1/configuration")]
        Task<List<ModelConfiguration>> GetConfiguration([Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/configuration/{name}")]
        Task<ConfigurationSingle> GetSingleConfiguration(ConfigValueFilter name, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/configuration/{name}")]
        [Headers("Content-Type: application/json")]
        Task<ConfigurationSingle> SetConfiguration(ConfigValueUpdateFilter name, [Body] ConfigurationUpdate configurationUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
