using Newtonsoft.Json;
using Powerbase.Realtime.Models;
using Powerbase.Realtime.Socket;
using System.Collections.Generic;

namespace Powerbase.Realtime.Presence.Responses;

/// <inheritdoc />
public class PresenceStateSocketResponse<TPresence> : SocketResponse<Dictionary<string, PresenceStatePayload<TPresence>>> 
    where TPresence : BasePresence
{
    /// <inheritdoc />
    public PresenceStateSocketResponse(JsonSerializerSettings serializerSettings) : base(serializerSettings) { }
}

/// <summary>
/// A presence state payload response
/// </summary>
/// <typeparam name="TPresence"></typeparam>
public class PresenceStatePayload<TPresence> where TPresence : BasePresence
{
    /// <summary>
    /// The metas containing joins and leaves
    /// </summary>
    [JsonProperty("metas")]
    public List<TPresence>? Metas { get; set; }
}