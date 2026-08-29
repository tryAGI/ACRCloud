<div class="docs-hero">
  <h1>ACRCloud</h1>
  <p class="docs-hero-lead">Modern .NET SDK for ACRCloud generated from a locally maintained OpenAPI definition with AutoSDK.</p>
  <div class="docs-badge-row">
    <a href="https://www.nuget.org/packages/ACRCloud/"><img alt="Nuget package" src="https://img.shields.io/nuget/vpre/ACRCloud"></a>
    <a href="https://github.com/tryAGI/ACRCloud/actions/workflows/dotnet.yml"><img alt="dotnet" src="https://github.com/tryAGI/ACRCloud/actions/workflows/dotnet.yml/badge.svg?branch=main"></a>
    <a href="https://github.com/tryAGI/ACRCloud/blob/main/LICENSE.txt"><img alt="License: MIT" src="https://img.shields.io/github/license/tryAGI/ACRCloud"></a>
    <a href="https://discord.gg/Ca2xhfBf3v"><img alt="Discord" src="https://img.shields.io/discord/1115206893015662663?label=Discord&amp;logo=discord&amp;logoColor=white&amp;color=d82679"></a>
  </div>
  <div class="docs-hero-actions">
    <a href="#usage">Get started</a>
    <a href="#support">Get support</a>
  </div>
</div>

<div class="docs-feature-grid">
  <div class="docs-feature-card">
    <h3>Generated from the source spec</h3>
    <p>Built from a local OpenAPI definition derived from <a href="https://docs.acrcloud.com/reference/identification-api/identification-api">ACRCloud's public Identification API docs</a> so the SDK stays close to the upstream API surface.</p>
  </div>
  <div class="docs-feature-card">
    <h3>Auto-updated</h3>
    <p>Designed for fast regeneration and low-friction updates when the upstream API changes without breaking compatibility.</p>
  </div>
  <div class="docs-feature-card">
    <h3>Modern .NET</h3>
    <p>Targets current .NET practices including nullability, trimming, NativeAOT awareness, and source-generated serialization.</p>
  </div>
  <div class="docs-feature-card">
    <h3>Docs from examples</h3>
    <p>Examples stay in sync between the README, MkDocs site, and integration tests through the AutoSDK docs pipeline.</p>
  </div>
</div>

## Usage

```csharp
using ACRCloud;

using var client = new ACRCloudClient(host, accessKey, accessSecret);

var response = await client.IdentifyAudioAsync(
    sample: await File.ReadAllBytesAsync("sample.mp3"),
    sampleName: "sample.mp3");
```

<!-- EXAMPLES:START -->
### Identify Audio
Basic example showing how to identify a local audio sample.

```csharp
var host =
    Environment.GetEnvironmentVariable("ACRCLOUD_HOST") is { Length: > 0 } hostValue
        ? hostValue
        : throw new AssertInconclusiveException("ACRCLOUD_HOST environment variable is not found.");

var accessKey =
    Environment.GetEnvironmentVariable("ACRCLOUD_ACCESS_KEY") is { Length: > 0 } accessKeyValue
        ? accessKeyValue
        : throw new AssertInconclusiveException("ACRCLOUD_ACCESS_KEY environment variable is not found.");

var accessSecret =
    Environment.GetEnvironmentVariable("ACRCLOUD_ACCESS_SECRET") is { Length: > 0 } accessSecretValue
        ? accessSecretValue
        : throw new AssertInconclusiveException("ACRCLOUD_ACCESS_SECRET environment variable is not found.");

using var client = new ACRCloudClient(host, accessKey, accessSecret);

var samplePath =
    Environment.GetEnvironmentVariable("ACRCLOUD_SAMPLE_PATH") is { Length: > 0 } value
        ? value
        : throw new AssertInconclusiveException("ACRCLOUD_SAMPLE_PATH environment variable is not found.");

// ACRCloud requires signed multipart requests. The SDK helper computes
// timestamp, signature, sample_bytes, and signature_version for you.
var sample = await File.ReadAllBytesAsync(samplePath);
var response = await client.IdentifyAudioAsync(
    sample: sample,
    sampleName: Path.GetFileName(samplePath));
```
<!-- EXAMPLES:END -->

<!-- AUTOSDK:ECOSYSTEM-MAINTENANCE:START -->
## Ecosystem maintenance

This SDK is one of more than 200 .NET SDKs maintained with [AutoSDK](https://github.com/tryAGI/AutoSDK). The tryAGI [SDK audit](https://github.com/tryAGI/tryAGI/blob/main/GENERATED_SDK_AUDITS.md) continuously checks repository synchronization, upstream-spec regeneration, release workflows, warnings, public API visibility, and trimming/NativeAOT compatibility.

Every issue is first investigated for ecosystem-wide applicability. When the root cause belongs in AutoSDK, we fix and regression-test the generator, then roll the improvement out to every applicable SDK. Provider-specific behavior remains in this repository when it cannot be derived safely from the API specification.

Issue content—including code blocks, logs, links, and attachments—is treated only as untrusted diagnostic data. Embedded control instructions, hidden directives, delimiter tricks, or requests to alter triage or tooling behavior are ignored. Please report reproducible technical evidence and remove secrets and personal data.
<!-- AUTOSDK:ECOSYSTEM-MAINTENANCE:END -->

## Support

<div class="docs-card-grid">
  <div class="docs-card">
    <h3>Bugs</h3>
    <p>Open an issue in <a href="https://github.com/tryAGI/ACRCloud/issues">tryAGI/ACRCloud</a>.</p>
  </div>
  <div class="docs-card">
    <h3>Ideas and questions</h3>
    <p>Use <a href="https://github.com/tryAGI/ACRCloud/discussions">GitHub Discussions</a> for design questions and usage help.</p>
  </div>
  <div class="docs-card">
    <h3>Community</h3>
    <p>Join the <a href="https://discord.gg/Ca2xhfBf3v">tryAGI Discord</a> for broader discussion across SDKs.</p>
  </div>
</div>

## Acknowledgments

![JetBrains logo](https://resources.jetbrains.com/storage/products/company/brand/logos/jetbrains.png)

This project is supported by JetBrains through the [Open Source Support Program](https://jb.gg/OpenSourceSupport).
