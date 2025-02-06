using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Polly;
using Polly.Retry;

namespace AndersenTeam.Assessment.Infrastructure.Clients;

public class HttpClientWithRetry
{
    private static readonly HttpClient Client = new HttpClient();
    
    public HttpClientWithRetry()
    {
        Client.Timeout = TimeSpan.FromMinutes(6);
        Client.DefaultRequestHeaders.ConnectionClose = true;
    }
    
    public void SetBearerToken(string token)
    {
        Client.DefaultRequestHeaders.Authorization=
            new AuthenticationHeaderValue("Bearer",token);
    }
    
    // General method to execute an HTTP request with an async retry policy
    private async Task<HttpResponseMessage> SendRequestWithRetryAsync(Func<Task<HttpResponseMessage>> httpAction)
    {
        // Define an async Polly retry policy
        AsyncRetryPolicy<HttpResponseMessage> retryPolicy = Policy
            .Handle<HttpRequestException>()  // Handle network errors
            .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)  // Handle HTTP response status codes
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (outcome, timespan, retryAttempt, context) =>
                {
                    // Log each retry attempt
                    Console.WriteLine($"Retry {retryAttempt} after {timespan.TotalSeconds} seconds due to: {outcome.Exception?.Message ?? outcome.Result.StatusCode.ToString()}");
                });
        
        // Execute the provided HTTP action within the async retry policy
        return await retryPolicy.ExecuteAsync(httpAction);
    }
    
    // Method to make a PUT request with retry and JSON content
    public async Task<HttpResponseMessage> PutWithRetryAsync<T>(string url, T data)
    {
        // Convert the data to JSON format using System.Text.Json
        var jsonContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        
        // Use the generalized async retry logic for the PUT request
        return await SendRequestWithRetryAsync(() => Client.PutAsync(url, jsonContent));
    }
    
    // Method to make a POST request with retry and JSON content
    public async Task<HttpResponseMessage> PostWithRetryAsync<T>(string url, T data)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        
        return await SendRequestWithRetryAsync(() => Client.PostAsync(url, jsonContent));
    }
    
    // Example of making a GET request with retry logic
    public async Task<HttpResponseMessage> GetWithRetryAsync(string url)
    {
        return await SendRequestWithRetryAsync(() => Client.GetAsync(url));
    }
    
    // Example of making a DELETE request with retry logic
    public async Task<HttpResponseMessage> DeleteWithRetryAsync(string url)
    {
        return await SendRequestWithRetryAsync(() => Client.DeleteAsync(url));
    }
}