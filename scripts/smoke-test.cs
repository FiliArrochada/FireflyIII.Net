#!/usr/bin/env dotnet run
#:project ../src/FireflyIIINet/FireflyIIINet.csproj
#:property PublishAot=false
/*
 * smoke-test.cs  —  .NET 10 file-based app (run with: dotnet run scripts/smoke-test.cs)
 *
 * Read-only live smoke test of the SDK against a real Firefly III server: the calls whose wire
 * format the unit tests can only assume (charts, release notes, the account active filter,
 * category color/last_activity). Every call is a GET; nothing on the server is changed.
 *
 * The public demo (https://demo.firefly-iii.org, login demo@firefly-iii.org / demo) works:
 * log in, create a personal access token under Options > Profile > OAuth, and pass it in
 * FIREFLY_TOKEN. The demo runs a develop build and resets regularly, taking the token with it.
 *
 * PublishAot=false: a file-based app defaults to native AOT, which disables the reflection-based
 * System.Text.Json the SDK uses, so every call would fail to deserialize.
 *
 * Usage:
 *   FIREFLY_TOKEN=... dotnet run scripts/smoke-test.cs -- https://demo.firefly-iii.org
 *
 * Exit codes: 0 = every call passed, 1 = at least one call failed, 2 = could not start.
 */

using System.Net.Http.Headers;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Refit;

if (args.Length < 1)
{
    Console.Error.WriteLine("usage: FIREFLY_TOKEN=<personal access token> dotnet run scripts/smoke-test.cs -- <server-url>");
    return 2;
}
string? token = Environment.GetEnvironmentVariable("FIREFLY_TOKEN");
if (string.IsNullOrWhiteSpace(token))
{
    Console.Error.WriteLine("FIREFLY_TOKEN is not set.");
    return 2;
}

var http = new HttpClient { BaseAddress = new Uri(args[0].TrimEnd('/') + "/api") };
http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
// The demo sits behind Cloudflare, which answers 403 to requests without a browser-like UA.
http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; FireflyIII.Net-smoke-test)");
T Api<T>() => RestService.For<T>(http, FireflyRefitSettings.Create());

var start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
var end = start.AddMonths(1).AddDays(-1);
int failures = 0;

async Task Check(string name, Func<Task<string>> call)
{
    try
    {
        Console.WriteLine($"PASS {name}: {await call()}");
    }
    catch (ApiException ex)
    {
        // A 200 here means the request worked but the response did not deserialize.
        failures++;
        Console.WriteLine($"FAIL {name}: HTTP {(int)ex.StatusCode} {Trunc(ex.InnerException?.Message ?? ex.Content)}");
    }
    catch (Exception ex)
    {
        failures++;
        Console.WriteLine($"FAIL {name}: {ex.GetType().Name}: {Trunc(ex.Message)}");
    }
}

static string Trunc(string? s) => s == null ? "" : s.Length > 300 ? s[..300] + "..." : s;

static string Sets(List<ChartDataSet> sets)
{
    string summary = $"{sets.Count} sets, {sets.Sum(s => s.Entries?.Count ?? 0)} points";
    var first = sets.FirstOrDefault(s => s.Entries?.Count > 0);
    return first == null ? summary : $"{summary}, e.g. {first.Label}: {first.Entries[0].Key}={first.Entries[0].Value}";
}

var about = Api<IAboutApi>();
await Check("GetAbout", async () => { var a = (await about.GetAbout()).Data; return $"version {a.VarVersion}, api {a.ApiVersion}"; });
await Check("GetCurrentUser", async () => (await about.GetCurrentUser()).Data.Attributes.Email);

// 6.7.8: release notes, by version (with and without the "v") and for the server's own version.
await Check("GetReleaseNotes(6.7.8)", async () => { var n = await about.GetReleaseNotes("6.7.8"); return $"version {n.Version}, html {n.ReleaseNotesHtml?.Length ?? 0} chars, markdown {n.ReleaseNotesMarkdown?.Length ?? 0} chars"; });
await Check("GetReleaseNotes(v6.7.8)", async () => { var n = await about.GetReleaseNotes("v6.7.8"); return $"version {n.Version}, markdown {n.ReleaseNotesMarkdown?.Length ?? 0} chars"; });
await Check("GetCurrentReleaseNotes", async () => { var n = await about.GetCurrentReleaseNotes(); return $"version {n.Version}, markdown {(n.ReleaseNotesMarkdown == null ? "null" : n.ReleaseNotesMarkdown.Length + " chars")}"; });

// 6.7.4: the account active filter.
var accounts = Api<IAccountsApi>();
await Check("ListAccount", async () => $"{(await accounts.ListAccount(limit: 200)).Data.Count} accounts");
await Check("ListAccount(active: true)", async () => { var r = (await accounts.ListAccount(limit: 200, active: true)).Data; return $"{r.Count} accounts, all active: {r.All(a => a.Attributes.Active)}"; });
await Check("ListAccount(active: false)", async () => { var r = (await accounts.ListAccount(limit: 200, active: false)).Data; return $"{r.Count} accounts, none active: {r.All(a => !a.Attributes.Active)}"; });

// 6.7.8: category color and last_activity.
var categories = Api<ICategoriesApi>();
string? categoryId = null;
await Check("ListCategory", async () =>
{
    var r = (await categories.ListCategory(limit: 50)).Data;
    categoryId = r.FirstOrDefault()?.Id;
    return $"{r.Count} categories, {r.Count(c => c.Attributes.Color != null)} with color, {r.Count(c => c.Attributes.LastActivity != null)} with last_activity";
});
if (categoryId != null)
    await Check($"GetCategory({categoryId})", async () => { var c = (await categories.GetCategory(categoryId, start: start, end: end)).Data.Attributes; return $"{c.Name}, color {c.Color ?? "null"}, last_activity {c.LastActivity?.ToString("o") ?? "null"}"; });

// Charts: entries as the server sends them (6.7.2.1), and the 6.7.4 budget limits chart.
var charts = Api<IChartsApi>();
await Check("GetChartBudgetOverview", async () => Sets(await charts.GetChartBudgetOverview(start, end)));
await Check("GetChartBudgetOverviewWithLimits", async () => Sets(await charts.GetChartBudgetOverviewWithLimits(start, end)));
await Check("GetChartCategoryOverview", async () => Sets(await charts.GetChartCategoryOverview(start, end)));
await Check("GetChartBalance(1D)", async () =>
{
    var assets = (await accounts.ListAccount(limit: 5, type: AccountTypeFilter.Asset)).Data.Select(a => long.Parse(a.Id)).ToList();
    return Sets(await charts.GetChartBalance(start, end, period: "1D", accounts: assets));
});

Console.WriteLine(failures == 0 ? "ALL PASSED" : $"{failures} FAILED");
return failures == 0 ? 0 : 1;
