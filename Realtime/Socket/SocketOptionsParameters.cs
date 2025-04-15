using Newtonsoft.Json;

namespace Powerbase.Realtime.Socket;

/// <summary>
/// Options to initialize a socket.
/// </summary>
public class SocketOptionsParameters
{
    /// <summary>
    /// A user token (used for WALRUS permissions)
    /// </summary>
    [JsonProperty("token")]
    public string? Token { get; set; }

    /// <summary>
    /// A Powerbase hosted public key
    /// </summary>
    [JsonProperty("apikey")]
    public string? ApiKey { get; set; }
}