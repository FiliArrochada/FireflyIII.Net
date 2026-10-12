# FireflyIIINet - the C# library for the Firefly III API

[![CI](https://github.com/filipe-silva/FireflyIII.Net/actions/workflows/ci.yml/badge.svg)](https://github.com/filipe-silva/FireflyIII.Net/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/FireflyIIINet.svg)](https://www.nuget.org/packages/FireflyIIINet/)

This is a .NET client for the [Firefly III](https://firefly-iii.org) personal finance manager API.

This C# SDK is a hand-maintained client for the Firefly III API, built on Refit and System.Text.Json. It is kept in sync with the Firefly III OpenAPI specification manually — updates are applied directly to the source.

- API version: 6.7.8 (v1 endpoints, plus the two v2 endpoints last documented in 6.2.21)
- SDK version: 6.7.8.1 (tracks the API version; a 4th revision component denotes client-only changes)
- Source specification: [api/firefly-iii-v6.7.8-v1.yaml](api/firefly-iii-v6.7.8-v1.yaml) (upstream stopped publishing v2 specs after 6.2.21)
- All released specifications (0.10.4 – 6.7.8): [api/](api/)

> **Rule triggers and actions go beyond the specification.** The spec's `RuleTriggerKeyword`
> enum lists 36 values, but Firefly III accepts every search operator as a rule trigger
> (`config/search.php`, 144 of them) and returns them verbatim from `GET /rules`; the same
> applies to `RuleActionKeyword` (`config/firefly.php`). Both enums therefore carry the
> server's full set, and an unrecognised value deserializes to `Unknown` instead of failing
> the response. Don't write `Unknown` back to the API — a rule read with an unknown keyword
> cannot be round-tripped.

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

> **Servers behind Cloudflare need a `User-Agent`.** `HttpClient` sends none by default, and
> Cloudflare's bot protection answers such requests with 403 before they reach Firefly III. The
> public demo (https://demo.firefly-iii.org) is one of them. Add one to the client:
> `http.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp/1.0");`.
>
> **No native AOT.** The SDK uses reflection-based System.Text.Json and Refit's reflection
> request builder, so it does not work in an app published with native AOT, or with
> `JsonSerializerIsReflectionEnabledByDefault` off: every response fails to deserialize.
> A .NET 10 file-based app turns AOT on by default; add `#:property PublishAot=false`.

## Errors

Refit throws `Refit.ApiException` for non-success status codes; the JSON error payload is
available via `ex.Content` and can be deserialized to the spec's error models
(`ValidationError`, `NotFound`, `Unauthenticated`, ...) with `SerializerOptions.Default`.

## Notes

- `Transaction`/`TransactionSplitStore` piggy bank properties intentionally serialize explicit
  `null` values (`piggy_bank_id`, `piggy_bank_name`) — the API distinguishes absent from null.
- Chart data sets (`ChartDataSet`, `ChartDataSetV2`) carry `entries` as the server sends them, an
  object of label to value, which the spec mis-declares as an object with `items`.
  `ChartEntriesConverter` reads it (and PHP's `[]` for an empty set) into a list of points in
  the server's order, each with `Key` and `Value`.
- Optional inputs are nullable: Refit parameters that default to `null`, model constructor
  parameters that are not required, and `[AllowNull]` on optional model properties, so a
  nullable-enabled consumer can pass and assign `null` ("leave unset") without warnings. The
  library itself compiles with `<Nullable>annotations</Nullable>`; getters keep their declared
  types, so reading an optional field still needs the caller's own null check.
- Fields the spec marks both required and `nullable: true` (a piggy bank's `target_amount`, a
  recurrence's `repeat_until`, a rule action's `value`, ...) take `null` in their constructors
  and always send the key, `null` included.
- `IDataApi.DestroyData`'s `unused` is a `bool?`: the spec types it as an int64 array, but the
  server validates it as `true`/`false`.
- `GET /v1/release-notes/{version}` has two methods: `GetReleaseNotes(version)`, and
  `GetCurrentReleaseNotes()` for the server's own version (the route makes `{version}` optional).
  The model's `release_notes` field is `ReleaseNotesHtml`, since a member cannot share the
  `ReleaseNotes` type's name.
- `CategoryUpdate.Notes` and `CategoryUpdate.Color` are three-state, as the server treats them:
  never assigned (or null in the constructor) leaves the key out and the stored value unchanged;
  assigning `null` sends `null` and clears it; assigning a value sets it. The update still needs
  `Name`: the server fails with 500 without it, although the spec marks it optional.
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
# Upstream publishes one branch per release, so the check scans every branch (~22 GitHub API
# requests); set GITHUB_TOKEN or GH_TOKEN to stay clear of the 60/h anonymous limit.
dotnet run scripts/check-spec-version.cs -- --diff

# Read-only live smoke test against a real server (GETs only). Works against the public demo,
# https://demo.firefly-iii.org (demo@firefly-iii.org / demo): create a personal access token
# under Options > Profile > OAuth.
FIREFLY_TOKEN=<token> dotnet run scripts/smoke-test.cs -- https://demo.firefly-iii.org
```

A scheduled workflow (`spec-check.yml`) runs the same check weekly (without `--diff`); when
new upstream specs appear it opens a `spec-check`-labeled issue, comments on that issue on
later runs while they stay unvendored, and closes it once `api/` is complete again.
