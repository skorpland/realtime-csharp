using System.Diagnostics;
using Powerbase.Realtime;
using Powerbase.Realtime.Socket;
using Client = Powerbase.Realtime.Client;

namespace RealtimeTests;

internal static class Helpers
{
    private const string ApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZS1kZW1vIiwicm9sZSI6ImFub24iLCJleHAiOjE5ODM4MTI5OTZ9.CRXP1A7WOeoJeXxjNni43kdQwgnWNReilDMblYTn_I0";

    private const string SocketEndpoint = "ws://127.0.0.1:54321/realtime/v1";
    private const string RestEndpoint = "http://localhost:54321/rest/v1";

    public static Powerbase.Postgrest.Client RestClient() => new(RestEndpoint, new Powerbase.Postgrest.ClientOptions());

    public static Client SocketClient()
    {
        var client = new Client(SocketEndpoint, new ClientOptions
        {
            Parameters = new SocketOptionsParameters
            {
                ApiKey = ApiKey
            }
        });

        client.AddDebugHandler((_, message, _) => Debug.WriteLine(message));

        return client;
    }
}