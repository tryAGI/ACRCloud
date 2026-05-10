
#nullable enable

namespace ACRCloud
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class IdentifyRequest
    {
        /// <summary>
        /// Audio file or fingerprint file.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("sample")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required byte[] Sample { get; set; }

        /// <summary>
        /// Audio file or fingerprint file.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("samplename")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Samplename { get; set; }

        /// <summary>
        /// Project access key.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("access_key")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string AccessKey { get; set; }

        /// <summary>
        /// File size in bytes. ACRCloud recommends short clips and documents a maximum below 5 MB.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("sample_bytes")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required long SampleBytes { get; set; }

        /// <summary>
        /// Unix timestamp used in the request signature.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("timestamp")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Timestamp { get; set; }

        /// <summary>
        /// Base64-encoded HMAC-SHA1 signature.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("signature")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Signature { get; set; }

        /// <summary>
        /// audio or fingerprint.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("data_type")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string DataType { get; set; }

        /// <summary>
        /// Signature protocol version. Use 1.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("signature_version")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SignatureVersion { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifyRequest" /> class.
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
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public IdentifyRequest(
            byte[] sample,
            string samplename,
            string accessKey,
            long sampleBytes,
            string timestamp,
            string signature,
            string dataType,
            string signatureVersion)
        {
            this.Sample = sample ?? throw new global::System.ArgumentNullException(nameof(sample));
            this.Samplename = samplename ?? throw new global::System.ArgumentNullException(nameof(samplename));
            this.AccessKey = accessKey ?? throw new global::System.ArgumentNullException(nameof(accessKey));
            this.SampleBytes = sampleBytes;
            this.Timestamp = timestamp ?? throw new global::System.ArgumentNullException(nameof(timestamp));
            this.Signature = signature ?? throw new global::System.ArgumentNullException(nameof(signature));
            this.DataType = dataType ?? throw new global::System.ArgumentNullException(nameof(dataType));
            this.SignatureVersion = signatureVersion ?? throw new global::System.ArgumentNullException(nameof(signatureVersion));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifyRequest" /> class.
        /// </summary>
        public IdentifyRequest()
        {
        }

    }
}