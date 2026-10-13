# CLAUDE.md

Guidance for Claude Code in this repo. The workspace `CLAUDE.md` one level up still applies.

## Releases: one package per Firefly III version

**Every Firefly III version that publishes an API spec gets its own `FireflyIIINet` package**,
built from that version's own spec and released in order. Never fold several server versions into
one package. The owner asked for this after 6.7.4, 6.7.6 and 6.7.7 were folded into 6.7.8: "next
time i do want 1 per server version".

- `dotnet run scripts/check-spec-version.cs -- --diff` lists the published specs; vendor each new
  one in `api/` and release them oldest first, one version per commit.
- A server version with no spec of its own (6.6.3, 6.7.3, 6.7.5, 6.7.9) has no API to build from,
  so it gets no package.
- `<Version>` in `src/FireflyIIINet/FireflyIIINet.csproj` is the server version; a 4th component
  (6.7.8.1) is a client-only revision against that same version.
- The owner dispatches **Release to NuGet** (`release-nuget.yml`) with the version; it pushes the
  package, then creates the `v<version>` tag and the GitHub release.
