using Newtonsoft.Json;
using System.Collections.Generic;

namespace CultureCompass.API
{
    internal class APIResponse
    {
        [JsonProperty("routes")]
        public List<Route> Routes { get; set; }
    }

    internal class Route
    {
        [JsonProperty("bounds")]
        public Bounds Bounds { get; set; }

        [JsonProperty("legs")]
        public List<Leg> Legs { get; set; }
    }

    internal class Bounds
    {
        [JsonProperty("northeast")]
        public Location Northeast { get; set; }

        [JsonProperty("southwest")]
        public Location Southwest { get; set; }
    }

    internal class Location
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    internal class Leg
    {
        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("steps")]
        public List<Step> Steps { get; set; }
    }

    internal class Distance
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }

    internal class Duration
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }

    internal class Step
    {
        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("end_location")]
        public Location EndLocation { get; set; }

        [JsonProperty("start_location")]
        public Location StartLocation { get; set; }
    }
}