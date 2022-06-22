using AnimalGameStore.Models;
using System.Text.Json;

namespace AnimalGameStore.Services;
public class HttpGetServices
{
    private readonly HttpClient _httpClient;

    public HttpGetServices()
    {
        _httpClient = new HttpClient();
    }

    public async Task<Fossil?> GetFossilAsync(string fossilName)
    {
        if (string.IsNullOrWhiteSpace(fossilName))
            return null;

        string url = $"https://acnhapi.com/v1/fossils/{fossilName}";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        string s = await response.Content.ReadAsStringAsync();

        Fossil? fossil = JsonSerializer.Deserialize<Fossil>(s);

        return fossil;

    }
}
