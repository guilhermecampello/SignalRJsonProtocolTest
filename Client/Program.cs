// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

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
            Console.WriteLine("Connecting from console application...");
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