namespace Averus.Dota2.DataScraper.OpenDotaApi.Models
{
    using Newtonsoft.Json;
    using System;

    public class Match
    {
        [JsonProperty("match_id")]
        public long? MatchId { get; set; }

        [JsonProperty("start_time")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("duration")]
        public long? Duration { get; set; }

        [JsonProperty("radiant_win")]
        public bool? RadiantWin { get; set; }

        [JsonProperty("leagueid")]
        public int? Leagueid { get; set; }

        [JsonProperty("league_name")]
        public string LeagueName { get; set; }

        [JsonProperty("radiant")]
        public bool? Radiant { get; set; }

        [JsonProperty("player_slot")]
        public long? PlayerSlot { get; set; }

        [JsonProperty("account_id")]
        public long? AccountId { get; set; }

        [JsonProperty("kills")]
        public int? Kills { get; set; }

        [JsonProperty("deaths")]
        public int? Deaths { get; set; }

        [JsonProperty("assists")]
        public int? Assists { get; set; }
    }
}
