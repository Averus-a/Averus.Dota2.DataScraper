namespace Averus.Dota2.DataScraper.OpenDotaApi.Models
{
    using Newtonsoft.Json;

    public class Matchup
    {
        [JsonProperty("hero_id")]
        public int? HeroId { get; set; }

        [JsonProperty("games_played")]
        public int? GamesPlayed { get; set; }

        [JsonProperty("wins")]
        public int? Wins { get; set; }
    }
}
