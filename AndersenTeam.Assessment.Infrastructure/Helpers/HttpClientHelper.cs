using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AndersenTeam.Assessment.Infrastructure.Helpers;

public static class HttpClientHelper
{
    public static async Task<HttpResponseMessage?> SendRequest<T>(T data, string token)
    {
        HttpClientHandler clientHandler=new HttpClientHandler();
        clientHandler.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
        clientHandler.ServerCertificateCustomValidationCallback=(sender,cert,chain,sslPolicyErrors)=>{return true;};
        using HttpClient client = new HttpClient(clientHandler)
        {
            BaseAddress = new Uri(UriHelper.BaseUri),
            Timeout = TimeSpan.FromMinutes(2),
            DefaultRequestVersion = HttpVersion.Version20 // Enforce HTTP/2.0 to match the HAR log
        };
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        client.BaseAddress=new Uri(UriHelper.BaseUri);
        
        client.DefaultRequestHeaders.Authorization=
            new AuthenticationHeaderValue("Bearer",
                token);
        
        var content=new StringContent(JsonSerializer.Serialize(data),Encoding.UTF8,"application/json");
        
        var message=new HttpRequestMessage(HttpMethod.Put,UriHelper.AssessmentEditUri)
        {
            Content=content
        };
        HttpResponseMessage? response=null;
        try
        {
            response=await client.SendAsync(message);
            
        }
        catch(Exception e)
        {
            Debug.WriteLine(e.Message,e);
        }
        
        return response;
    }
    
    public static async Task<TModelDto?> SendGetRequestAnonymousAsync<TModelDto>(string requestUri, 
        params string[] parameters)
        where TModelDto : class
    {
        using HttpClient client = GetHttpClient();
        client.BaseAddress = new Uri(UriHelper.BaseUri);
        var uri = GenerateUri(requestUri, parameters);
        HttpResponseMessage? response = null;
        try
        {
            response = await client.GetAsync(uri).ConfigureAwait(false);

        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message, e);
        }

        if (response is not null && response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync(typeof(TModelDto))) as TModelDto;
        }

        return null;
    }

    private static HttpClient GetHttpClient()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        HttpClient client = new HttpClient(clientHandler)
        {
            Timeout = TimeSpan.FromMinutes(2),
            DefaultRequestVersion = HttpVersion.Version20 // Enforce HTTP/2.0 to match the HAR log
        };
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        return client;
    }

    private static Uri GenerateUri(string requestUri, params string?[]? parameters)
    {
        var uri = $@"{UriHelper.BaseUri}{requestUri}";
        return new Uri(parameters is null || !parameters.Any()
            ? uri
            : parameters.Aggregate(uri,
                (current, parameter) =>
                    current + (parameter is null ? "/null" :
                        string.IsNullOrEmpty(parameter.ToString()) ? string.Empty : $@"/{parameter.ToString()}")));
    }

}