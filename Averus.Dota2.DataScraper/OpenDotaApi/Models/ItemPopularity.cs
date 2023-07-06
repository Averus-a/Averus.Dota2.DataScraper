namespace Averus.Dota2.DataScraper.OpenDotaApi.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ItemPopularity
    {
        [JsonProperty("start_game_items")]
        public Dictionary<string, long> StartGameItems { get; set; }

        [JsonProperty("early_game_items")]
        public Dictionary<string, long> EarlyGameItems { get; set; }

        [JsonProperty("mid_game_items")]
        public Dictionary<string, long> MidGameItems { get; set; }

        [JsonProperty("late_game_items")]
        public Dictionary<string, long> LateGameItems { get; set; }
    }
}
