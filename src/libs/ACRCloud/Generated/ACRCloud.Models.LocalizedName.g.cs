
#nullable enable

namespace ACRCloud
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class LocalizedName
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("langs")]
        public global::System.Collections.Generic.IList<object>? Langs { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedName" /> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="langs"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public LocalizedName(
            string? name,
            global::System.Collections.Generic.IList<object>? langs)
        {
            this.Name = name;
            this.Langs = langs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedName" /> class.
        /// </summary>
        public LocalizedName()
        {
        }

    }
}