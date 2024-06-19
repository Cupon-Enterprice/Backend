using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.Services.Slack;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public interface ISlackService
{
    Task SendMessageAsync(string message);
}

public class SlackService : ISlackService
{
    private readonly HttpClient _httpClient;
    private readonly string _webhookUrl;

    public SlackService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _webhookUrl = configuration["Slack:WebhookUrl"];
        Console.WriteLine($"Webhook URL: {_webhookUrl}");
    }

    public async Task SendMessageAsync(string message)
    {
        var payload = new
        {
            text = message
        };

        var jsonPayload = JsonSerializer.Serialize(payload);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(_webhookUrl, content);
        response.EnsureSuccessStatusCode();
    }
}
