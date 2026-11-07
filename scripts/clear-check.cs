#!/usr/bin/env dotnet run
#:project ../src/FireflyIIINet/FireflyIIINet.csproj
#:property PublishAot=false
/*
 * clear-check.cs  —  .NET 10 file-based app (run with: dotnet run scripts/clear-check.cs)
 *
 * Live check that the server removes a stored value when an update sends it as null
 * (ClearedFields.Clear): for each request model it creates an object with every clearable field
 * filled in, sends an update that clears them through the SDK, reads the object back and reports
 * each field. Then it deletes what it created.
 *
 * It writes, so it runs against a demo server only, never one holding real books. The URL is the
 * first argument and defaults to the public demo (https://demo.firefly-iii.org, login
 * demo@firefly-iii.org / demo). Before writing anything it asks who the token belongs to and
 * refuses unless that user's email starts with "demo@". Log in, create a personal access token
 * under Options > Profile > OAuth, and pass it in FIREFLY_TOKEN. A demo resets regularly, taking
 * anything left behind with it.
 *
 * Usage:
 *   FIREFLY_TOKEN=... dotnet run scripts/clear-check.cs [-- <demo server url>]
 *
 * Exit codes: 0 = every field cleared, 1 = at least one did not (or a step failed), 2 = could not
 * start (no token, or not a demo user).
 */

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Refit;

string server = (args.Length > 0 ? args[0] : "https://demo.firefly-iii.org").TrimEnd('/');

string? token = Environment.GetEnvironmentVariable("FIREFLY_TOKEN");
if (string.IsNullOrWhiteSpace(token))
{
    Console.Error.WriteLine("FIREFLY_TOKEN is not set (a personal access token for the demo user).");
    return 2;
}

var http = new HttpClient { BaseAddress = new Uri(server + "/api/") };
http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
http.DefaultRequestHeaders.Accept.ParseAdd("application/json");
// The demo sits behind Cloudflare, which answers 403 to requests without a browser-like UA.
http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; FireflyIII.Net-clear-check)");
T Api<T>() => RestService.For<T>(http, FireflyRefitSettings.Create());

string run = DateTime.UtcNow.ToString("HHmmss");
var cleanup = new List<string>();
int failures = 0;

// Raw JSON for creating and reading back, so only the update under test goes through the SDK models.
async Task<JsonElement> Send(HttpMethod method, string path, string? json = null)
{
    using var request = new HttpRequestMessage(method, path);
    if (json != null) request.Content = new StringContent(json, Encoding.UTF8, "application/json");
    using var response = await http.SendAsync(request);
    string body = await response.Content.ReadAsStringAsync();
    if (!response.IsSuccessStatusCode) throw new InvalidOperationException($"{method} {path}: HTTP {(int)response.StatusCode} {Trunc(body)}");
    return body.Length == 0 ? default : JsonDocument.Parse(body).RootElement.Clone();
}

async Task<(string Id, JsonElement Attributes)> Create(string path, string json)
{
    var data = (await Send(HttpMethod.Post, path, json)).GetProperty("data");
    string id = data.GetProperty("id").GetString()!;
    cleanup.Add($"{path}/{id}");
    return (id, data.GetProperty("attributes"));
}

async Task<JsonElement> Read(string path) => (await Send(HttpMethod.Get, path)).GetProperty("data").GetProperty("attributes");

static string Trunc(string? s) => s == null ? "" : s.Length > 300 ? s[..300] + "..." : s;
static string Show(JsonElement e) => e.ValueKind == JsonValueKind.Undefined ? "(absent)" : e.GetRawText();

// A field counts as cleared when the server answers null or leaves it out; the value it had is shown beside it.
void Expect(string area, JsonElement before, JsonElement after, params string[] fields)
{
    foreach (string field in fields)
    {
        var was = before.TryGetProperty(field, out var b) ? b : default;
        var now = after.TryGetProperty(field, out var a) ? a : default;
        bool cleared = now.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined;
        if (!cleared) failures++;
        Console.WriteLine($"{(cleared ? "PASS" : "FAIL")} {area}.{field}: {Show(was)} -> {Show(now)}");
    }
}

async Task Case(string area, Func<Task> body)
{
    try { await body(); }
    catch (ApiException ex) { failures++; Console.WriteLine($"FAIL {area}: update HTTP {(int)ex.StatusCode} {Trunc(ex.InnerException?.Message ?? ex.Content)}"); }
    catch (Exception ex) { failures++; Console.WriteLine($"FAIL {area}: {ex.GetType().Name}: {Trunc(ex.Message)}"); }
}

// The guard that keeps this off real books: only a demo user's token may write.
string email = (await Read("v1/about/user")).GetProperty("email").GetString() ?? "";
if (!email.StartsWith("demo@", StringComparison.OrdinalIgnoreCase))
{
    Console.Error.WriteLine($"{server}: the token's user is not a demo user (email not demo@...), refusing to write there.");
    return 2;
}
Console.WriteLine($"{server} as {email}");

var (assetId, _) = await Create("v1/accounts", $$"""{"name":"clear-check asset {{run}}","type":"asset","account_role":"defaultAsset","currency_code":"EUR"}""");
var (budgetId, _) = await Create("v1/budgets", $$"""{"name":"clear-check budget {{run}}"}""");
var (categoryId, _) = await Create("v1/categories", $$"""{"name":"clear-check category {{run}}"}""");
string today = DateTime.Today.ToString("yyyy-MM-dd"), later = DateTime.Today.AddMonths(6).ToString("yyyy-MM-dd");

await Case("Account", async () =>
{
    var (id, before) = await Create("v1/accounts", $$"""
        {"name":"clear-check card {{run}}","type":"asset","account_role":"ccAsset","credit_card_type":"monthlyFull",
         "monthly_payment_date":"{{later}}","currency_code":"EUR","iban":"NL02ABNA0123456789","bic":"ABNANL2A",
         "account_number":"123456","opening_balance":"100","opening_balance_date":"{{today}}"}
        """);
    // A credit card keeps its payment date: the server drops it only when the account stops being one.
    var update = new AccountUpdate(name: $"clear-check card {run}", accountRole: AccountRoleProperty.DefaultAsset)
        .Clear(u => u.Iban).Clear(u => u.Bic).Clear(u => u.AccountNumber).Clear(u => u.OpeningBalance)
        .Clear(u => u.OpeningBalanceDate).Clear(u => u.MonthlyPaymentDate);
    await Api<IAccountsApi>().UpdateAccount(id, update);
    Expect("Account", before, await Read($"v1/accounts/{id}"), "iban", "bic", "account_number", "opening_balance", "opening_balance_date", "monthly_payment_date");
});

await Case("Category", async () =>
{
    // The server takes a colour as six hex digits, without "#".
    var (id, before) = await Create("v1/categories", $$"""{"name":"clear-check notes {{run}}","notes":"some notes","color":"336699"}""");
    var update = new CategoryUpdate(name: $"clear-check notes {run}") { Notes = null, Color = null };
    await Api<ICategoriesApi>().UpdateCategory(id, update);
    Expect("Category", before, await Read($"v1/categories/{id}"), "notes", "color");
});

await Case("PiggyBank", async () =>
{
    var (id, before) = await Create("v1/piggy-banks", $$"""
        {"name":"clear-check piggy {{run}}","accounts":[{"account_id":"{{assetId}}"}],"transaction_currency_code":"EUR",
         "target_amount":"500","start_date":"{{today}}","target_date":"{{later}}","object_group_title":"clear-check group {{run}}"}
        """);
    // A piggy bank's group cannot be removed through the API (see the README's Notes), so it is not cleared here.
    var update = new PiggyBankUpdate().Clear(u => u.TargetAmount).Clear(u => u.TargetDate);
    await Api<IPiggyBanksApi>().UpdatePiggyBank(id, update);
    Expect("PiggyBank", before, await Read($"v1/piggy-banks/{id}"), "target_amount", "target_date");
});

await Case("Bill", async () =>
{
    var (id, before) = await Create("v1/bills", $$"""
        {"name":"clear-check bill {{run}}","amount_min":"10","amount_max":"20","date":"{{today}}","repeat_freq":"monthly",
         "currency_code":"EUR","end_date":"{{later}}","extension_date":"{{later}}","object_group_title":"clear-check group {{run}}"}
        """);
    // A bill's end and extension dates cannot be cleared (the server rejects null and ""), and its
    // group goes with an empty title rather than null.
    var update = new BillUpdate(name: $"clear-check bill {run}") { ObjectGroupTitle = "" };
    await Api<IBillsApi>().UpdateBill(id, update);
    Expect("Bill", before, await Read($"v1/bills/{id}"), "object_group_title");
});

await Case("Tag", async () =>
{
    var (id, before) = await Create("v1/tags", $$"""{"tag":"clear-check-{{run}}","date":"{{today}}","latitude":52.37,"longitude":4.89,"zoom_level":6}""");
    var update = new TagModelUpdate().Clear(u => u.Date).Clear(u => u.Latitude).Clear(u => u.Longitude).Clear(u => u.ZoomLevel);
    await Api<ITagsApi>().UpdateTag(id, update);
    Expect("Tag", before, await Read($"v1/tags/{id}"), "date", "latitude", "longitude", "zoom_level");
});

await Case("Transaction", async () =>
{
    var (id, created) = await Create("v1/transactions", $$"""
        {"group_title":"clear-check group {{run}}","transactions":[
          {"type":"withdrawal","date":"{{today}}","amount":"12.34","description":"clear-check split 1","source_id":"{{assetId}}","destination_name":"clear-check shop",
           "foreign_amount":"13.00","foreign_currency_code":"USD","internal_reference":"ref-{{run}}","external_url":"https://example.org/{{run}}",
           "interest_date":"{{today}}","book_date":"{{today}}","process_date":"{{today}}","due_date":"{{today}}","payment_date":"{{today}}","invoice_date":"{{today}}"},
          {"type":"withdrawal","date":"{{today}}","amount":"1.00","description":"clear-check split 2","source_id":"{{assetId}}","destination_name":"clear-check shop"}]}
        """);
    // The server does not keep the splits in the order they were sent: find them by description.
    static JsonElement Split(JsonElement group, string description) =>
        group.GetProperty("transactions").EnumerateArray().First(s => s.GetProperty("description").GetString() == description);
    var filled = Split(created, "clear-check split 1");
    string journal = filled.GetProperty("transaction_journal_id").GetString()!;
    string journal2 = Split(created, "clear-check split 2").GetProperty("transaction_journal_id").GetString()!;
    // A foreign amount goes with "0", which takes the foreign currency with it; null leaves both.
    var split = new TransactionSplitUpdate { TransactionJournalId = journal, ForeignAmount = "0" }
        .Clear(u => u.InternalReference).Clear(u => u.ExternalUrl)
        .Clear(u => u.InterestDate).Clear(u => u.BookDate).Clear(u => u.ProcessDate).Clear(u => u.DueDate).Clear(u => u.PaymentDate).Clear(u => u.InvoiceDate);
    // A group of two splits needs its title on every update, so it is sent again and only the
    // split fields are cleared here.
    var update = new TransactionUpdate(transactions: [split, new TransactionSplitUpdate { TransactionJournalId = journal2 }]) { GroupTitle = $"clear-check group {run}" };
    await Api<ITransactionsApi>().UpdateTransaction(id, update);
    var after = await Read($"v1/transactions/{id}");
    Expect("TransactionSplit", filled, Split(after, "clear-check split 1"), "foreign_amount", "foreign_currency_code", "internal_reference", "external_url",
        "interest_date", "book_date", "process_date", "due_date", "payment_date", "invoice_date");
});

await Case("Recurrence", async () =>
{
    var (id, before) = await Create("v1/recurrences", $$"""
        {"type":"withdrawal","title":"clear-check recurrence {{run}}","first_date":"{{DateTime.Today.AddDays(1):yyyy-MM-dd}}","repeat_until":"{{later}}",
         "apply_rules":true,"active":true,"repetitions":[{"type":"monthly","moment":"1","skip":0,"weekend":1}],
         "transactions":[{"description":"clear-check","amount":"5","currency_code":"EUR","source_id":"{{assetId}}","destination_id":"{{assetId}}",
           "budget_id":"{{budgetId}}","category_id":"{{categoryId}}"}]}
        """);
    var transaction = before.GetProperty("transactions")[0];
    string transactionId = transaction.GetProperty("id").GetString()!;
    // The server needs the transaction (and its accounts) on every recurrence update.
    var transactionUpdate = new RecurrenceTransactionUpdate(id: transactionId, description: "clear-check", amount: "5", sourceId: assetId, destinationId: assetId)
        .Clear(t => t.BudgetId).Clear(t => t.CategoryId);
    var update = new RecurrenceUpdate(transactions: [transactionUpdate]).Clear(u => u.RepeatUntil).Clear(u => u.NrOfRepetitions);
    await Api<IRecurrencesApi>().UpdateRecurrence(id, update);
    var after = await Read($"v1/recurrences/{id}");
    Expect("Recurrence", before, after, "repeat_until", "nr_of_repetitions");
    Expect("RecurrenceTransaction", transaction, after.GetProperty("transactions")[0], "budget_id", "category_id");
});

// Newest first, so a piggy bank or transaction goes before the account it uses.
foreach (string path in Enumerable.Reverse(cleanup))
{
    try { await Send(HttpMethod.Delete, path); }
    catch (Exception ex) { Console.WriteLine($"WARN cleanup {path}: {Trunc(ex.Message)}"); }
}

Console.WriteLine(failures == 0 ? "ALL CLEARED" : $"{failures} FAILED");
return failures == 0 ? 0 : 1;
