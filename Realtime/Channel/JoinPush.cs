using System.Collections.Generic;
using Newtonsoft.Json;
using Powerbase.Realtime.Broadcast;
using Powerbase.Realtime.PostgresChanges;
using Powerbase.Realtime.Presence;

namespace Powerbase.Realtime.Channel;

internal class JoinPush
{
	[JsonProperty("config")]
	public JoinPushConfig Config { get; private set; }

	public JoinPush(BroadcastOptions? broadcastOptions = null, PresenceOptions? presenceOptions = null, List<PostgresChangesOptions>? postgresChangesOptions = null)
	{
		Config = new JoinPushConfig
		{
			Broadcast = broadcastOptions,
			Presence = presenceOptions,
			PostgresChanges = postgresChangesOptions ?? new List<PostgresChangesOptions>()
		};
	}

	internal class JoinPushConfig
	{
		[JsonProperty("broadcast", NullValueHandling = NullValueHandling.Ignore)]
		public BroadcastOptions? Broadcast { get; set; }

		[JsonProperty("presence", NullValueHandling = NullValueHandling.Ignore)]
		public PresenceOptions? Presence { get; set; }

		[JsonProperty("postgres_changes", NullValueHandling = NullValueHandling.Ignore)]
		public List<PostgresChangesOptions> PostgresChanges { get; set; } = new List<PostgresChangesOptions> { };
	}
}