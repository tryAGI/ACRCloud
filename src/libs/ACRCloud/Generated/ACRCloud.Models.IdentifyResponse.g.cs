
#nullable enable

namespace ACRCloud
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class IdentifyResponse
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("status")]
        public global::ACRCloud.Status? Status { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("metadata")]
        public global::ACRCloud.Metadata? Metadata { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("result_type")]
        public int? ResultType { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("cost_time")]
        public double? CostTime { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifyResponse" /> class.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="metadata"></param>
        /// <param name="resultType"></param>
        /// <param name="costTime"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public IdentifyResponse(
            global::ACRCloud.Status? status,
            global::ACRCloud.Metadata? metadata,
            int? resultType,
            double? costTime)
        {
            this.Status = status;
            this.Metadata = metadata;
            this.ResultType = resultType;
            this.CostTime = costTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifyResponse" /> class.
        /// </summary>
        public IdentifyResponse()
        {
        }

    }
}