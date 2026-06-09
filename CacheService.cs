using System.Net;
using System.Net.Http.Json;

public class CacheService
{
    private readonly HttpClient _httpClient;
    private readonly Dictionary<string, PokemonDto> _cache = new(StringComparer.OrdinalIgnoreCase);

    public CacheService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(PokemonDto? Data, bool IsCached)> GetPokemonAsync(string name)
    {
        string cleanName = name.Trim().ToLower();

        if (_cache.TryGetValue(cleanName, out var cachedData))
        {
            return (cachedData, true);
        }

        try
        {
            var response = await _httpClient.GetFromJsonAsync<PokemonDto>($"https://pokeapi.co/api/v2/pokemon/{cleanName}");
            if (response != null)
            {
                _cache[cleanName] = response;
            }
            return (response, false);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return (null, false);
        }
    }
}