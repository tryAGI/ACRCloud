namespace ACRCloud.IntegrationTests;

[TestClass]
public partial class Tests
{
    private static ACRCloudClient GetAuthenticatedClient()
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

        var client = new ACRCloudClient(host, accessKey, accessSecret);
        
        return client;
    }
}
