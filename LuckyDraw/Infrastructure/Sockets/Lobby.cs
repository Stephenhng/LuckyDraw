using LuckyDraw.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace LuckyDraw.Infrastructure.Sockets;

public class Lobby(UserManager<ApplicationUser> userManager) : Hub
{
    private readonly ConcurrentDictionary<ApplicationUser, HashSet<string>> Users = [];

    public override async Task OnConnectedAsync()
    {
        var username = Context.GetHttpContext()?.Request.Query["username"];
        var user = await userManager.FindByNameAsync(username!);
        if (user == null) return;

        var connections = Users.GetOrAdd(user, _ => []);
        connections.Add(Context.ConnectionId);
        await NotifyAsync(user.UserName ?? string.Empty, $"{user.UserName} has connected.");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var username = Context.GetHttpContext()?.Request.Query["username"];
        var user = await userManager.FindByNameAsync(username!);
        if (user == null) return;

        if (Users.TryGetValue(user, out var connections))
        {
            connections.Remove(Context.ConnectionId);
            if (connections.Count == 0)
                Users.TryRemove(user, out _);
            await NotifyAsync(user.UserName ?? string.Empty, $"{user.UserName} has disconnected.");
        }
        await base.OnDisconnectedAsync(exception);
    }

    public async Task NotifyAsync(string userName, string notificationMessage)
    {
        await Clients.All.SendAsync("ReceivedMessage", userName, notificationMessage);
    }
}
