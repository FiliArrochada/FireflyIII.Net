using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface IPreferencesApi
    {
        [Get("/v1/preferences/{name}")]
        Task<PreferenceSingle> GetPreference(string name, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v2/preferences/{name}")]
        Task<PreferenceSingle> GetPreferenceV2(string name, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/preferences")]
        Task<PreferenceArray> ListPreference([Header("X-Trace-Id")] Guid? xTraceId = null, int? page = null);

        [Post("/v1/preferences")]
        [Headers("Content-Type: application/json")]
        Task<PreferenceSingle> StorePreference([Body] Preference preference, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/preferences/{name}")]
        [Headers("Content-Type: application/json")]
        Task<PreferenceSingle> UpdatePreference(string name, [Body] PreferenceUpdate preferenceUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
