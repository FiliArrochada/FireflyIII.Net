#!/usr/bin/env dotnet run
/*
 * check-spec-version.cs  —  .NET 10 file-based app (run with: dotnet run scripts/check-spec-version.cs)
 *
 * Checks whether upstream has published Firefly III API specs that are not yet vendored in
 * this repo's api/ folder. Unlike MangaDex.NET's checker (which this is modeled on), the SDK
 * here deliberately pins an older API version, so "local == upstream latest" is not the
 * question — the useful signals are:
 *   1. which upstream-published spec files are missing from api/ (new releases to vendor), and
 *   2. how far the pinned SDK spec is behind the newest upstream v1 spec (--diff shows the
 *      path-level gap, to size a future SDK version bump).
 *
 * Upstream source is the firefly-iii/api-docs GitHub repo (the repo behind
 * api-docs.firefly-iii.org). The docs site itself sits behind Cloudflare and 403s
 * non-browser user agents, so the GitHub API is the stable machine endpoint. Note the
 * upstream repo's cleanup workflow deletes old dist files — this tool only sees currently
 * published versions (historical ones were recovered from git history separately).
 *
 * Beta / rc / develop specs are ignored, matching the repo's vendoring policy.
 *
 * Dependencies: only the .NET SDK (BCL only, no NuGet packages).
 *
 * Usage:
 *   dotnet run scripts/check-spec-version.cs
 *   dotnet run scripts/check-spec-version.cs -- --diff
 *   GITHUB_TOKEN=... UPSTREAM_REPO=owner/name PINNED_SPEC=... dotnet run scripts/check-spec-version.cs
 *
 * Exit codes: 0 = nothing new upstream, 1 = new upstream specs found (or path drift with --diff),
 *             2 = could not complete.
 */

using System.Text.Json;
using System.Text.RegularExpressions;

const string UserAgent = "FireflyIII.Net-spec-check/1.0 (+https://github.com/filipe-silva/FireflyIII.Net)";

string upstreamRepo = Environment.GetEnvironmentVariable("UPSTREAM_REPO") ?? "firefly-iii/api-docs";
string? token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
bool showDiff = args.Contains("--diff");

// ---- locate repo root (folder whose api/ contains vendored specs) ----
var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
while (dir != null && !HasSpecs(Path.Combine(dir.FullName, "api")))
    dir = dir.Parent;
if (dir == null) return Fail("could not find the repo root (no api/ folder with firefly-iii-*.yaml found upwards).");
string apiDir = Path.Combine(dir.FullName, "api");

string pinnedSpec = Environment.GetEnvironmentVariable("PINNED_SPEC")
                    ?? Path.Combine(apiDir, "firefly-iii-6.5.5-v1.yaml");

var local = Directory.EnumerateFiles(apiDir, "firefly-iii-*.yaml")
    .Select(Path.GetFileName)
    .Where(n => n != null)
    .Select(n => n!)
    .ToHashSet(StringComparer.OrdinalIgnoreCase);

Console.WriteLine("=== Vendored specs ===");
Console.WriteLine($"folder  : {apiDir}");
Console.WriteLine($"count   : {local.Count}");
Console.WriteLine($"newest  : {Newest(local) ?? "?"}");

// ---- upstream: list dist/*.yaml via the GitHub trees API ----
Console.WriteLine("\n=== Upstream (github.com/" + upstreamRepo + ", dist/) ===");
List<string> upstream;
try
{
    upstream = await FetchUpstreamListAsync(upstreamRepo, token);
}
catch (Exception e)
{
    return Fail($"could not list upstream specs: {e.Message}");
}
var published = upstream
    .Where(n => !Regex.IsMatch(n, "beta|develop|-rc", RegexOptions.IgnoreCase))
    .ToList();
Console.WriteLine($"published (non-beta/develop): {published.Count}");
Console.WriteLine($"newest  : {Newest(published) ?? "?"}");

// ---- result: new upstream specs not vendored ----
Console.WriteLine("\n=== Result ===");
var missing = published.Where(n => !local.Contains(n)).OrderBy(n => n).ToList();
bool drift = missing.Count > 0;
if (missing.Count == 0)
{
    Console.WriteLine("UP TO DATE: every published upstream spec is vendored in api/.");
}
else
{
    Console.WriteLine($"NEW UPSTREAM SPECS ({missing.Count}) — not yet in api/:");
    foreach (var n in missing)
        Console.WriteLine($"  + {n}\n    https://raw.githubusercontent.com/{upstreamRepo}/main/dist/{n}");
}

// ---- pinned SDK spec vs newest upstream v1 ----
string? pinnedVersion = File.Exists(pinnedSpec) ? GetVersion(File.ReadAllText(pinnedSpec)) : null;
string? newestV1 = Newest(published.Where(n => n.EndsWith("-v1.yaml")));
Console.WriteLine($"\nSDK pinned spec : {Path.GetFileName(pinnedSpec)} (info.version {pinnedVersion ?? "?"})");
Console.WriteLine($"newest upstream v1: {newestV1 ?? "?"}");

if (showDiff && newestV1 != null && File.Exists(pinnedSpec))
{
    Console.WriteLine("\n=== Path diff (pinned SDK spec vs newest upstream v1) ===");
    string upstreamYaml;
    try
    {
        upstreamYaml = await FetchRawAsync($"https://raw.githubusercontent.com/{upstreamRepo}/main/dist/{newestV1}");
    }
    catch (Exception e)
    {
        return Fail($"could not fetch {newestV1}: {e.Message}");
    }
    var pinnedPaths = GetPaths(File.ReadAllText(pinnedSpec));
    var newPaths = GetPaths(upstreamYaml);
    var added = newPaths.Where(p => !pinnedPaths.Contains(p)).OrderBy(p => p).ToList();
    var removed = pinnedPaths.Where(p => !newPaths.Contains(p)).OrderBy(p => p).ToList();
    Console.WriteLine($"pinned paths: {pinnedPaths.Count}   upstream paths: {newPaths.Count}");
    if (added.Count == 0 && removed.Count == 0)
    {
        Console.WriteLine("No path-level differences.");
    }
    else
    {
        if (added.Count > 0)
        {
            Console.WriteLine($"\nAdded upstream (missing from pinned spec) [{added.Count}]:");
            foreach (var p in added) Console.WriteLine($"  + {p}");
        }
        if (removed.Count > 0)
        {
            Console.WriteLine($"\nRemoved upstream (still in pinned spec) [{removed.Count}]:");
            foreach (var p in removed) Console.WriteLine($"  - {p}");
        }
        drift = true;
    }
}

return drift ? 1 : 0;

// ---------- helpers ----------

static int Fail(string msg) { Console.Error.WriteLine($"ERROR: {msg}"); return 2; }

static bool HasSpecs(string apiDir)
    => Directory.Exists(apiDir) && Directory.EnumerateFiles(apiDir, "firefly-iii-*.yaml").Any();

// Highest version among spec filenames (handles the upstream 'v6.6.x' prefix quirk and -v1/-v2 suffixes).
static string? Newest(IEnumerable<string> names)
    => names.Select(n => (Name: n, Ver: VersionOf(n)))
            .Where(x => x.Ver != null)
            .OrderByDescending(x => x.Ver)
            .Select(x => x.Name)
            .FirstOrDefault();

static Version? VersionOf(string fileName)
{
    var m = Regex.Match(fileName, @"^firefly-iii-v?(?<ver>\d+(\.\d+)*)(-v\d)?\.yaml$", RegexOptions.IgnoreCase);
    if (!m.Success) return null;
    var s = m.Groups["ver"].Value;
    if (!s.Contains('.')) s += ".0";
    return Version.TryParse(s, out var v) ? v : null;
}

static async Task<List<string>> FetchUpstreamListAsync(string repo, string? token)
{
    using var http = NewClient(token);
    var json = await http.GetStringAsync($"https://api.github.com/repos/{repo}/git/trees/main?recursive=1");
    using var doc = JsonDocument.Parse(json);
    if (doc.RootElement.TryGetProperty("truncated", out var tr) && tr.GetBoolean())
        Console.Error.WriteLine("WARNING: GitHub tree listing was truncated; results may be incomplete.");
    var result = new List<string>();
    foreach (var t in doc.RootElement.GetProperty("tree").EnumerateArray())
    {
        var path = t.GetProperty("path").GetString() ?? "";
        if (path.StartsWith("dist/") && path.EndsWith(".yaml"))
            result.Add(path["dist/".Length..]);
    }
    return result;
}

static async Task<string> FetchRawAsync(string url)
{
    using var http = NewClient(null);
    return await http.GetStringAsync(url);
}

static HttpClient NewClient(string? token)
{
    var http = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };
    http.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
    http.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.github+json");
    if (!string.IsNullOrEmpty(token))
        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    return http;
}

// Extract info.version (line-based; no multi-line regex backtracking on large specs).
static string? GetVersion(string yaml)
{
    var lines = yaml.Split('\n');
    bool inInfo = false;
    foreach (var raw in lines)
    {
        var line = raw.TrimEnd('\r');
        if (line == "info:") { inInfo = true; continue; }
        if (inInfo)
        {
            if (line.Length > 0 && !char.IsWhiteSpace(line[0])) break; // next top-level key
            var v = MatchVersion(line);
            if (v != null) return v;
        }
    }
    foreach (var raw in lines) { var v = MatchVersion(raw.TrimEnd('\r')); if (v != null) return v; }
    return null;
}

static string? MatchVersion(string line)
{
    var t = line.TrimStart();
    if (!t.StartsWith("version:")) return null;
    if (line == t) return null; // must be indented (nested under info)
    return t.Substring("version:".Length).Trim().Trim('"', '\'');
}

// Extract the set of top-level path keys under `paths:` (handles optional surrounding quotes).
static HashSet<string> GetPaths(string yaml)
{
    var set = new HashSet<string>();
    bool inPaths = false;
    foreach (var raw in yaml.Split('\n'))
    {
        var line = raw.TrimEnd('\r');
        if (line == "paths:") { inPaths = true; continue; }
        if (!inPaths) continue;
        if (line.Length > 0 && !char.IsWhiteSpace(line[0])) break; // next top-level key
        // Expect exactly two spaces of indent, then optional quote, then '/...:'.
        if (!line.StartsWith("  ") || line.StartsWith("   ")) continue;
        var key = line.Substring(2).TrimEnd();
        if (!key.EndsWith(":")) continue;
        key = key[..^1].Trim().Trim('"', '\'');
        if (key.StartsWith("/")) set.Add(key);
    }
    return set;
}
