using System.Text.Json.Serialization;

namespace AnimalGameStore.Models;
public class Fossil
{
    [JsonPropertyName("file-name")]
    public string? Name { get; set; }

    [JsonPropertyName("price")]
    public int Price { get; set; }

    [JsonPropertyName("museum-phrase")]
    public string? MuseumPhrase { get; set; }
}
