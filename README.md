# FireflyIIINet - the C# library for the Firefly III API

[![CI](https://github.com/filipe-silva/FireflyIII.Net/actions/workflows/ci.yml/badge.svg)](https://github.com/filipe-silva/FireflyIII.Net/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/FireflyIIINet.svg)](https://www.nuget.org/packages/FireflyIIINet/)

This is a .NET client for the [Firefly III](https://firefly-iii.org) personal finance manager API.

This C# SDK is a hand-maintained client for the Firefly III API, built on Refit and System.Text.Json. It is kept in sync with the Firefly III OpenAPI specification manually — updates are applied directly to the source.

- API version: 6.4.17 (v1 endpoints, plus the two v2 endpoints last documented in 6.2.21)
- SDK version: 6.4.17 (tracks the API version; the 4th revision component denotes client-only changes)
- Source specification: [api/firefly-iii-6.4.17-v1.yaml](api/firefly-iii-6.4.17-v1.yaml) (upstream stopped publishing v2 specs after 6.2.21)
- All released specifications (0.10.4 – 6.6.6): [api/](api/)

## Frameworks supported
- .NET 10.0
- .NET Framework 4.8

## Dependencies

- [Refit](https://www.nuget.org/packages/Refit/) - 15.0.0 or later
- [Refit.Reflection](https://www.nuget.org/packages/Refit.Reflection/) - version-locked to Refit (keeps `RestService.For<T>` working on all targets)
- [System.Text.Json](https://www.nuget.org/packages/System.Text.Json/) - 10.0.10 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

## Installation

Build with `dotnet build FireflyIIINet.sln`, then reference the library and use the namespaces:

```csharp
using FireflyIIINet.Api;     // the Refit interfaces (IAccountsApi, ITransactionsApi, ...)
using FireflyIIINet.Client;  // FireflyRefitSettings, SerializerOptions
using FireflyIIINet.Model;
using Refit;
```

This client is a set of [Refit](https://github.com/reactiveui/refit) interfaces — one per API area
(`IAboutApi`, `IAccountsApi`, `IAttachmentsApi`, `IAutocompleteApi`, `IAvailableBudgetsApi`,
`IBillsApi`, `IBudgetsApi`, `ICategoriesApi`, `IChartsApi`, `IConfigurationApi`, `ICurrenciesApi`,
`IDataApi`, `IInsightApi`, `ILinksApi`, `INetWorthApi`, `IObjectGroupsApi`, `IPiggyBanksApi`,
`IPreferencesApi`, `IRecurrencesApi`, `IRuleGroupsApi`, `IRulesApi`, `ISearchApi`, `ISummaryApi`,
`ITagsApi`, `ITransactionsApi`, `ITransactionsSumApi`, `IUsersApi`, `IWebhooksApi`).

You build a client with an `HttpClient` plus the settings from `FireflyRefitSettings.Create()`,
which wire up the library's System.Text.Json options and the URL parameter formatting the
Firefly III API expects (lowercase booleans, `[EnumMember]` enum values, `yyyy-MM-dd` dates).
Auth is a personal access token supplied as a bearer token on the `HttpClient`.

## Getting Started

```csharp
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Refit;

var http = new HttpClient { BaseAddress = new Uri("https://demo.firefly-iii.org/api") };
http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "<personal access token>");

var accounts = RestService.For<IAccountsApi>(http, FireflyRefitSettings.Create());

var list = await accounts.ListAccount(type: AccountTypeFilter.Asset);
foreach (var account in list.Data)
    Console.WriteLine($"{account.Id}: {account.Attributes.Name}");
```

A runnable end-to-end example (create + delete a transaction) lives in [src/Example/](src/Example/).

## Errors

Refit throws `Refit.ApiException` for non-success status codes; the JSON error payload is
available via `ex.Content` and can be deserialized to the spec's error models
(`ValidationError`, `NotFound`, `Unauthenticated`, ...) with `SerializerOptions.Default`.

## Notes

- `Transaction`/`TransactionSplitStore` piggy bank properties intentionally serialize explicit
  `null` values (`piggy_bank_id`, `piggy_bank_name`) — the API distinguishes absent from null.
- Date-only fields use the `yyyy-MM-dd` wire format via `OpenAPIDateConverter`; date-time fields
  use RFC 3339.
- The test suite never hits the network — Refit slice tests use a capturing handler that records
  the outgoing request and returns canned JSON.

## Development

There is no code generator in this repo. When the spec changes, edit the Refit interfaces under
`src/FireflyIIINet/Api` and the models under `src/FireflyIIINet/Model` directly, and keep
the spec copy under `api/` in sync.

```bash
dotnet build FireflyIIINet.sln
dotnet test  FireflyIIINet.sln

# Check whether upstream has published API specs not yet vendored in api/,
# and (--diff) how far the pinned SDK spec is behind the newest upstream v1.
# This is a .NET 10 file-based app (needs the .NET 10 SDK; the library targets net8.0).
dotnet run scripts/check-spec-version.cs -- --diff
```

A scheduled workflow (`spec-check.yml`) runs the same check weekly; when new upstream
specs appear it fails the run and opens a `spec-check`-labeled issue (one at a time —
no duplicates while an issue is open).
