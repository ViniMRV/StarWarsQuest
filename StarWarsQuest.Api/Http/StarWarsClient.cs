using StarWarsQuest.Api.Models;


namespace StarWarsQuest.Api.Http;

public class StarWarsClient
{
    private readonly HttpClient _httpClient;

    public StarWarsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SwapiPeopleResponse> GetCharacter(string name)
    {
        var response = await _httpClient.GetFromJsonAsync<SwapiPeopleResponse>($"people?search={name}");

        return response;

    }

    public async Task<SwapiStarshipResponse> GetSpaceship(string name)
    {
        var response = await _httpClient.GetFromJsonAsync<SwapiStarshipResponse>($"starships?search={name}");

        return response;
    }

    public async Task<SwapiPlanetResponse> GetPlanet(string name)
    {
        var response = await _httpClient.GetFromJsonAsync<SwapiPlanetResponse>($"planets?search={name}");

        return response;
    }

}
