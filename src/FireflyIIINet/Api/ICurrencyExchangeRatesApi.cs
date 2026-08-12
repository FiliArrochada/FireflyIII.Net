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

        [Delete("/v1/exchange-rates/{from}/{to}")]
        Task DeleteSpecificCurrencyExchangeRates(string from, string to, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Delete("/v1/exchange-rates/{from}/{to}/{date}")]
        Task DeleteSpecificCurrencyExchangeRateOnDate(string from, string to, string date, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Get("/v1/exchange-rates")]
        Task<CurrencyExchangeRateArray> ListCurrencyExchangeRates([Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/exchange-rates/{id}")]
        Task<CurrencyExchangeRateSingle> ListSpecificCurrencyExchangeRate(string id, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/exchange-rates/{from}/{to}")]
        Task<CurrencyExchangeRateArray> ListSpecificCurrencyExchangeRates(string from, string to, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Get("/v1/exchange-rates/{from}/{to}/{date}")]
        Task<CurrencyExchangeRateArray> ListSpecificCurrencyExchangeRateOnDate(string from, string to, string date, [Header("X-Trace-Id")] Guid? xTraceId = null, int? limit = null, int? page = null);

        [Post("/v1/exchange-rates")]
        [Headers("Content-Type: application/json")]
        Task<CurrencyExchangeRateSingle> StoreCurrencyExchangeRate([Body] CurrencyExchangeRateStore currencyExchangeRateStore, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Post("/v1/exchange-rates/by-date/{date}")]
        [Headers("Content-Type: application/json")]
        Task<CurrencyExchangeRateArray> StoreCurrencyExchangeRatesByDate(string date, [Body] CurrencyExchangeRateStoreByDate currencyExchangeRateStoreByDate, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Post("/v1/exchange-rates/by-currencies/{from}/{to}")]
        [Headers("Content-Type: application/json")]
        Task<CurrencyExchangeRateArray> StoreCurrencyExchangeRatesByPair(string from, string to, [Body] Dictionary<string, string> rates, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/exchange-rates/{id}")]
        [Headers("Content-Type: application/json")]
        Task<CurrencyExchangeRateSingle> UpdateCurrencyExchangeRate(string id, [Body] CurrencyExchangeRateUpdate currencyExchangeRateUpdate, [Header("X-Trace-Id")] Guid? xTraceId = null);

        [Put("/v1/exchange-rates/{from}/{to}/{date}")]
        [Headers("Content-Type: application/json")]
        Task<CurrencyExchangeRateSingle> UpdateCurrencyExchangeRateByDate(string from, string to, string date, [Body] CurrencyExchangeRateUpdateNoDate currencyExchangeRateUpdateNoDate, [Header("X-Trace-Id")] Guid? xTraceId = null);
    }
}
