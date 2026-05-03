#nullable enable

namespace ACRCloud
{
    public partial interface IACRCloudClient
    {
        /// <summary>
        /// Identify audio or fingerprint<br/>
        /// Identifies an audio file or fingerprint file. ACRCloud requires HMAC-SHA1<br/>
        /// request signing over method, path, access key, data type, signature version,<br/>
        /// and timestamp.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::ACRCloud.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::ACRCloud.IdentifyResponse> IdentifyAsync(

            global::ACRCloud.IdentifyRequest request,
            global::ACRCloud.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Identify audio or fingerprint<br/>
        /// Identifies an audio file or fingerprint file. ACRCloud requires HMAC-SHA1<br/>
        /// request signing over method, path, access key, data type, signature version,<br/>
        /// and timestamp.
        /// </summary>
        /// <param name="sample">
        /// Audio file or fingerprint file.
        /// </param>
        /// <param name="samplename">
        /// Audio file or fingerprint file.
        /// </param>
        /// <param name="accessKey">
        /// Project access key.
        /// </param>
        /// <param name="sampleBytes">
        /// File size in bytes. ACRCloud recommends short clips and documents a maximum below 5 MB.
        /// </param>
        /// <param name="timestamp">
        /// Unix timestamp used in the request signature.
        /// </param>
        /// <param name="signature">
        /// Base64-encoded HMAC-SHA1 signature.
        /// </param>
        /// <param name="dataType">
        /// audio or fingerprint.
        /// </param>
        /// <param name="signatureVersion">
        /// Signature protocol version. Use 1.
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::ACRCloud.IdentifyResponse> IdentifyAsync(
            byte[] sample,
            string samplename,
            string accessKey,
            long sampleBytes,
            string timestamp,
            string signature,
            string dataType,
            string signatureVersion,
            global::ACRCloud.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}