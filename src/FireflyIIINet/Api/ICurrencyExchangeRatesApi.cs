using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireflyIIINet.Model;
using Refit;

namespace FireflyIIINet.Api
{
    public interface ICurrencyExchangeRatesApi
    {
        [Delete("/v1/exchange-rates/{id}")]
        Task DeleteSpecificCurrencyExchangeRate(string id, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Delete("/v1/exchange-rates/rates/{from}/{to}")]
        Task DeleteSpecificCurrencyExchangeRates(string from, string to, [Header("X-Trace-Id")] Guid? xTraceId = null, [Query(Format = "yyyy-MM-dd")] DateTime? date = null);

        [Get("/v1/exchange-rates")]
        Task<CurrencyExchangeRateArray> ListCurrencyExchangeRates([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/exchange-rates/{id}")]
        Task<CurrencyExchangeRateSingle> ListSpecificCurrencyExchangeRate(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/exchange-rates/rates/{from}/{to}")]
        Task<CurrencyExchangeRateArray> ListSpecificCurrencyExchangeRates(string from, string to, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Put("/v1/exchange-rates/{id}")]
        [Headers("Content-Type: application/json")]
        Task<CurrencyExchangeRateSingle> UpdateCurrencyExchangeRate(string id, [Body] CurrencyExchangeRateUpdate currencyExchangeRateUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
