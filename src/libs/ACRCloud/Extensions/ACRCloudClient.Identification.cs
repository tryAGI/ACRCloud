#nullable enable

namespace ACRCloud;

public sealed partial class ACRCloudClient
{
    private readonly string? _accessKey;
    private readonly string? _accessSecret;

    /// <summary>
    /// Creates an ACRCloud client configured for signed identification requests.
    /// </summary>
    /// <param name="host">Project host from the ACRCloud console, for example identify-eu-west-1.acrcloud.com.</param>
    /// <param name="accessKey">Project access key.</param>
    /// <param name="accessSecret">Project access secret used to sign requests.</param>
    /// <param name="httpClient">Optional HTTP client.</param>
    public ACRCloudClient(
        string host,
        string accessKey,
        string accessSecret,
        global::System.Net.Http.HttpClient? httpClient = null)
        : this(
            httpClient: httpClient,
            baseUri: CreateBaseUri(host),
            authorizations: null,
            options: null,
            disposeHttpClient: httpClient is null)
    {
        _accessKey = accessKey ?? throw new global::System.ArgumentNullException(nameof(accessKey));
        _accessSecret = accessSecret ?? throw new global::System.ArgumentNullException(nameof(accessSecret));
    }

    private static global::System.Uri CreateBaseUri(string host)
    {
        host = host ?? throw new global::System.ArgumentNullException(nameof(host));
        return new global::System.Uri($"https://{host.TrimEnd('/')}", global::System.UriKind.Absolute);
    }

    /// <summary>
    /// Identifies an audio sample using the credentials supplied to the client constructor.
    /// </summary>
    public global::System.Threading.Tasks.Task<global::ACRCloud.IdentifyResponse> IdentifyAudioAsync(
        byte[] sample,
        string sampleName,
        global::ACRCloud.AutoSDKRequestOptions? requestOptions = default,
        global::System.Threading.CancellationToken cancellationToken = default)
    {
        return IdentifySignedAsync(
            sample: sample,
            sampleName: sampleName,
            dataType: "audio",
            requestOptions: requestOptions,
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Identifies a fingerprint sample using the credentials supplied to the client constructor.
    /// </summary>
    public global::System.Threading.Tasks.Task<global::ACRCloud.IdentifyResponse> IdentifyFingerprintAsync(
        byte[] sample,
        string sampleName,
        global::ACRCloud.AutoSDKRequestOptions? requestOptions = default,
        global::System.Threading.CancellationToken cancellationToken = default)
    {
        return IdentifySignedAsync(
            sample: sample,
            sampleName: sampleName,
            dataType: "fingerprint",
            requestOptions: requestOptions,
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Identifies a sample with a caller-specified ACRCloud data_type value.
    /// </summary>
    public global::System.Threading.Tasks.Task<global::ACRCloud.IdentifyResponse> IdentifySignedAsync(
        byte[] sample,
        string sampleName,
        string dataType,
        global::ACRCloud.AutoSDKRequestOptions? requestOptions = default,
        global::System.Threading.CancellationToken cancellationToken = default)
    {
        if (_accessKey is not { Length: > 0 } || _accessSecret is not { Length: > 0 })
        {
            throw new global::System.InvalidOperationException(
                "Use the ACRCloudClient(host, accessKey, accessSecret) constructor for signed identification helpers.");
        }

        sample = sample ?? throw new global::System.ArgumentNullException(nameof(sample));
        sampleName = sampleName ?? throw new global::System.ArgumentNullException(nameof(sampleName));
        dataType = dataType ?? throw new global::System.ArgumentNullException(nameof(dataType));

        const string signatureVersion = "1";
        var timestamp = global::System.DateTimeOffset.UtcNow
            .ToUnixTimeSeconds()
            .ToString(global::System.Globalization.CultureInfo.InvariantCulture);
        var signature = CreateSignature(
            accessKey: _accessKey,
            accessSecret: _accessSecret,
            dataType: dataType,
            signatureVersion: signatureVersion,
            timestamp: timestamp);

        var request = new global::ACRCloud.IdentifyRequest(
            sample: sample,
            samplename: sampleName,
            accessKey: _accessKey,
            sampleBytes: sample.LongLength,
            timestamp: timestamp,
            signature: signature,
            dataType: dataType,
            signatureVersion: signatureVersion);

        return IdentifyAsync(
            request: request,
            requestOptions: requestOptions,
            cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Creates the base64 HMAC-SHA1 signature required by ACRCloud Identify Protocol V1.
    /// </summary>
    public static string CreateSignature(
        string accessKey,
        string accessSecret,
        string dataType,
        string signatureVersion,
        string timestamp)
    {
        var stringToSign = string.Join(
            "\n",
            "POST",
            "/v1/identify",
            accessKey,
            dataType,
            signatureVersion,
            timestamp);

#pragma warning disable CA5350 // ACRCloud Identify Protocol V1 requires HMAC-SHA1 signatures.
        var hash = global::System.Security.Cryptography.HMACSHA1.HashData(
            key: global::System.Text.Encoding.ASCII.GetBytes(accessSecret),
            source: global::System.Text.Encoding.ASCII.GetBytes(stringToSign));
#pragma warning restore CA5350

        return global::System.Convert.ToBase64String(hash);
    }
}
