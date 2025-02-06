using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
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
}