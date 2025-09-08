using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class PredictResponse
{
    public string Label { get; set; }
    public float Score { get; set; }
}

public class ModelApiService
{
    private readonly HttpClient _client;
    public ModelApiService(HttpClient client) => _client = client;

    public async Task<PredictResponse> PredictAsync(string text)
    {
        var payload = new { text = text };
        var response = await _client.PostAsJsonAsync("predict", payload); // relative path OK (BaseAddress set)
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<PredictResponse>();
    }
}
