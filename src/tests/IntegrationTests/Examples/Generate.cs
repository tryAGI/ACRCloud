/*
order: 10
title: Identify Audio
slug: identify-audio

Basic example showing how to identify a local audio sample.
*/

namespace ACRCloud.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_Generate()
    {
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

        //// ACRCloud requires signed multipart requests. The SDK helper computes
        //// timestamp, signature, sample_bytes, and signature_version for you.
        var sample = await File.ReadAllBytesAsync(samplePath);
        var response = await client.IdentifyAudioAsync(
            sample: sample,
            sampleName: Path.GetFileName(samplePath));

        response.Status?.Code.Should().Be(0);
    }
}
