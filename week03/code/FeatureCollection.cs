using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Root object representing the entire GeoJSON feature collection returned by USGS.
/// </summary>
public class FeatureCollection
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; }

    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }

    [JsonPropertyName("bbox")]
    public List<double> Bbox { get; set; }
}

/// <summary>
/// Metadata info about the feed.
/// </summary>
public class Metadata
{
    [JsonPropertyName("generated")]
    public long Generated { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("api")]
    public string Api { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}

/// <summary>
/// Each earthquake event feature in the collection.
/// </summary>
public class Feature
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }

    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}

/// <summary>
/// Properties describing the earthquake event (including place and magnitude).
/// </summary>
public class Properties
{
    [JsonPropertyName("mag")]
    public double? Mag { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("updated")]
    public long Updated { get; set; }

    [JsonPropertyName("tz")]
    public int? Tz { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    [JsonPropertyName("felt")]
    public int? Felt { get; set; }

    [JsonPropertyName("cdi")]
    public double? Cdi { get; set; }

    [JsonPropertyName("mmi")]
    public double? Mmi { get; set; }

    [JsonPropertyName("alert")]
    public string Alert { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("tsunami")]
    public int Tsunami { get; set; }

    [JsonPropertyName("sig")]
    public int Sig { get; set; }

    [JsonPropertyName("net")]
    public string Net { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("ids")]
    public string Ids { get; set; }

    [JsonPropertyName("sources")]
    public string Sources { get; set; }

    [JsonPropertyName("types")]
    public string Types { get; set; }

    [JsonPropertyName("nst")]
    public int? Nst { get; set; }

    [JsonPropertyName("dmin")]
    public double? Dmin { get; set; }

    [JsonPropertyName("rms")]
    public double? Rms { get; set; }

    [JsonPropertyName("gap")]
    public double? Gap { get; set; }

    [JsonPropertyName("magType")]
    public string MagType { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
}

/// <summary>
/// Geometry info (coordinates) about the earthquake event.
/// </summary>
public class Geometry
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// Coordinates are [longitude, latitude, depth]
    /// </summary>
    [JsonPropertyName("coordinates")]
    public List<double> Coordinates { get; set; }
}
