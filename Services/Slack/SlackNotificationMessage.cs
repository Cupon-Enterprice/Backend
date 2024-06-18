using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.Services.Slack;

public class SlackNotificationService : ISlackNotificationService
{
public readonly string _webhookUrl;


public SlackNotificationService(IConfiguration configuration)
{
    _webhookUrl = configuration["Slack:WebhookUrl"];
}

public async Task SendNotificationAsync(string message)
{
    var slackMessage = new SlackMessage { Text = message };
    var json = JsonSerializer.Serialize(slackMessage);
    var content = new StringContent(json, Encoding.UTF8, "application/json");

    using var httpClient = new HttpClient();
    await httpClient.PostAsync(_webhookUrl, content);
}
}

public class SlackMessage
{
public string Text { get; set; }
}