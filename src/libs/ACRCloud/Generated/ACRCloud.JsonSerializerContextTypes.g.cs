
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete

namespace ACRCloud
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class JsonSerializerContextTypes
    {
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, string>? StringStringDictionary { get; set; }

        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, object>? StringObjectDictionary { get; set; }

        /// <summary>
        /// Runtime object lists used by dynamic JSON payloads such as tool arguments.
        /// </summary>
        public global::System.Collections.Generic.List<object>? ObjectList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public global::System.Text.Json.JsonElement? JsonElement { get; set; }

        /// <summary>
        ///
        /// </summary>
        public global::ACRCloud.IdentifyRequest? Type0 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public byte[]? Type1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string? Type2 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public long? Type3 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::ACRCloud.IdentifyResponse? Type4 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::ACRCloud.Status? Type5 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::ACRCloud.Metadata? Type6 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int? Type7 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public double? Type8 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::ACRCloud.MusicMetadata>? Type9 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::ACRCloud.MusicMetadata? Type10 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::ACRCloud.LocalizedName? Type11 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::ACRCloud.LocalizedName>? Type12 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public object? Type13 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<object>? Type14 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::ACRCloud.MusicMetadata>? ListType0 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::ACRCloud.LocalizedName>? ListType1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<object>? ListType2 { get; set; }
    }
}