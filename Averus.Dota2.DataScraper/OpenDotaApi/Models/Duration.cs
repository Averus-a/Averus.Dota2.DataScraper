namespace Averus.Dota2.DataScraper.OpenDotaApi.Models
{
    using Newtonsoft.Json;

    public class Duration
    {
        [JsonProperty("duration_bin")]
        public int? DurationBin { get; set; }

        [JsonProperty("games_played")]
        public int? GamesPlayed { get; set; }

        [JsonProperty("wins")]
        public int? Wins { get; set; }
    }
}
