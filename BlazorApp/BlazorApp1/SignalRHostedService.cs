using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace BlazorApp1
{
    public class SignalRHostedService : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var hubConnectionBuilder = new HubConnectionBuilder();

                hubConnectionBuilder
                .WithUrl("http://localhost:5000/hubs/chat", options =>
                {

                    options.Headers.Add("X-API-Key", "XXX");
                    options.CloseTimeout = TimeSpan.FromSeconds(10);
                })
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Debug);
                    logging.AddConsole();
                })
                .WithAutomaticReconnect();

            var hubConnection = hubConnectionBuilder.Build();
            while (true)
            {
                try
                {
                    if (hubConnection.State == HubConnectionState.Disconnected)
                    {
                        Console.WriteLine("Connecting from BlazorApp...");
                        await hubConnection.StartAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    await Task.Delay(3000);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
