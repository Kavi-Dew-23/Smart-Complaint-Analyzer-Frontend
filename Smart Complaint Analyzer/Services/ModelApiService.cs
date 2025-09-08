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
    private readonly HttpClient _http;
    public ModelApiService(HttpClient http)
    { 
        _http = http;
        
    }

    public async Task<PredictResponse> PredictAsync(string feedback)
    {
        
        var response = await _http.PostAsJsonAsync("http://127.0.0.1:8000/predict", new { text = feedback }); 
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<PredictResponse>();
    }
}
