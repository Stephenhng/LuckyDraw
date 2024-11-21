using Microsoft.AspNetCore.SignalR.Client;

namespace LuckyDraw.Infrastructure.Sockets;

public class HubBase : IAsyncDisposable
{
    public HubConnection? HubConnection { get; private set; }

    public async Task ConnectAsync(Uri uri)
    {
        if (HubConnection is not null) return;

        HubConnection = new HubConnectionBuilder().WithUrl(uri).Build();
        await HubConnection.StartAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (HubConnection != null)
            await HubConnection.DisposeAsync();
    }
}
