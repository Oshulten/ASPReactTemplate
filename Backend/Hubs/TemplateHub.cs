using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs;

public class TemplateHub : Hub
{
    public async Task NewMessage(long username, string message) =>
        await Clients.All.SendAsync("messageReceived", username, message);
}