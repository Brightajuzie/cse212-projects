using System.Collections.Generic;
using System.Text.Json.Serialization;

// The root object of the GeoJSON structure from the USGS API.
public class FeatureCollection
{
    // The "features" attribute is an array/list of individual earthquake events.
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

// Represents a single earthquake event.
public class Feature
{
    // The "properties" object contains the human-readable data (mag, place).
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}

// Holds the specific data points requested (magnitude and place).
public class Properties
{
    // Magnitude (mag) is a floating-point number.
    [JsonPropertyName("mag")]
    public float Mag { get; set; }
    
    // Location (place) is a string.
    [JsonPropertyName("place")]
    public string Place { get; set; }
}