
#nullable enable

namespace ACRCloud
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MusicMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("acrid")]
        public string? Acrid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("album")]
        public global::ACRCloud.LocalizedName? Album { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("artists")]
        public global::System.Collections.Generic.IList<global::ACRCloud.LocalizedName>? Artists { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("duration_ms")]
        public int? DurationMs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("score")]
        public int? Score { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("external_ids")]
        public object? ExternalIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("external_metadata")]
        public object? ExternalMetadata { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("play_offset_ms")]
        public int? PlayOffsetMs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("db_begin_time_offset_ms")]
        public int? DbBeginTimeOffsetMs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("db_end_time_offset_ms")]
        public int? DbEndTimeOffsetMs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("sample_begin_time_offset_ms")]
        public int? SampleBeginTimeOffsetMs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("sample_end_time_offset_ms")]
        public int? SampleEndTimeOffsetMs { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicMetadata" /> class.
        /// </summary>
        /// <param name="acrid"></param>
        /// <param name="title"></param>
        /// <param name="album"></param>
        /// <param name="artists"></param>
        /// <param name="releaseDate"></param>
        /// <param name="durationMs"></param>
        /// <param name="score"></param>
        /// <param name="externalIds"></param>
        /// <param name="externalMetadata"></param>
        /// <param name="playOffsetMs"></param>
        /// <param name="dbBeginTimeOffsetMs"></param>
        /// <param name="dbEndTimeOffsetMs"></param>
        /// <param name="sampleBeginTimeOffsetMs"></param>
        /// <param name="sampleEndTimeOffsetMs"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public MusicMetadata(
            string? acrid,
            string? title,
            global::ACRCloud.LocalizedName? album,
            global::System.Collections.Generic.IList<global::ACRCloud.LocalizedName>? artists,
            string? releaseDate,
            int? durationMs,
            int? score,
            object? externalIds,
            object? externalMetadata,
            int? playOffsetMs,
            int? dbBeginTimeOffsetMs,
            int? dbEndTimeOffsetMs,
            int? sampleBeginTimeOffsetMs,
            int? sampleEndTimeOffsetMs)
        {
            this.Acrid = acrid;
            this.Title = title;
            this.Album = album;
            this.Artists = artists;
            this.ReleaseDate = releaseDate;
            this.DurationMs = durationMs;
            this.Score = score;
            this.ExternalIds = externalIds;
            this.ExternalMetadata = externalMetadata;
            this.PlayOffsetMs = playOffsetMs;
            this.DbBeginTimeOffsetMs = dbBeginTimeOffsetMs;
            this.DbEndTimeOffsetMs = dbEndTimeOffsetMs;
            this.SampleBeginTimeOffsetMs = sampleBeginTimeOffsetMs;
            this.SampleEndTimeOffsetMs = sampleEndTimeOffsetMs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicMetadata" /> class.
        /// </summary>
        public MusicMetadata()
        {
        }
    }
}