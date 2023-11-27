# SignalRJsonProtocolTest
Issue: Blazor apps under .NET8.0 force HubConnections clients to establish connections under JsonProtocol 2.

Steps to reproduce:

1) Run all projects.
2) The console app uses Json Protocol 1 and can connect to the SignalR Hub.
<img width="450" alt="image" src="https://github.com/guilhermecampello/SignalRJsonProtocolTest/assets/43826374/35053222-3090-4257-9d0f-e03c22838776">
3) The blazor app under .NET 7 uses Json Protocol 1 and can connect to SignalR Hub.
<img width="528" alt="image" src="https://github.com/guilhermecampello/SignalRJsonProtocolTest/assets/43826374/8a441254-ae77-49d0-b02e-afd439299f39">
4) The blazor app under .NET 8 uses Json Protocol 2 and can't connect to the SignalR hub which doesn't supports JsonProtocol 2.
<img width="787" alt="image" src="https://github.com/guilhermecampello/SignalRJsonProtocolTest/assets/43826374/a8549840-f0c4-41d4-991d-276026bb8529">

