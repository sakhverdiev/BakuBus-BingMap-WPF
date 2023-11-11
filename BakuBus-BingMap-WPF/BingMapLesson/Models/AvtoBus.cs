using System.Text.Json.Serialization;

namespace BingMapLesson.Models;

public  class AvtoBus
{
    [JsonPropertyName("@attributes")]
    public Attributes attributes { get; set; }
}
