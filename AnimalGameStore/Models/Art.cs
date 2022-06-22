using System.Text.Json.Serialization;

namespace AnimalGameStore.Models;
public class Art
{
    [JsonPropertyName("file-name")]
    public string? Name { get; set; }

    [JsonPropertyName("hasFake")]
    public bool HasFake { get; set; }

    [JsonPropertyName("buy-price")]
    public int BuyPrice { get; set; }

    [JsonPropertyName("sell-price")]
    public int SellPrice { get; set; }

    [JsonPropertyName("museum-desc")]
    public string? MuseumDescription { get; set; }
}
