namespace Averus.Dota2.DataScraper.OpenDotaApi
{
    using Averus.Dota2.DataScraper.OpenDotaApi.Models;
    using Averus.Dota2.DataScraper.Utils;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Match = Models.Match;

    public class HeroesEndpoint
    {
        private readonly JsonFormatter _formatter;

        public HeroesEndpoint(JsonFormatter formatter)
        {
            _formatter = formatter;
        }

        public async Task<List<Hero>> GetDataAsync(CancellationToken? token = default) =>
            await _formatter.DeserializeAsync<List<Hero>>("heroes");

        public async Task<List<Match>>
            GetRecentMatchesAsync(int heroId, CancellationToken? token = default) =>
            await _formatter.DeserializeAsync<List<Match>>($"heroes/{heroId}/matches", null, token);

        public async Task<List<Matchup>> GetMatchUpsAsync(int heroId, CancellationToken? token = default) =>
            await _formatter.DeserializeAsync<List<Matchup>>($"heroes/{heroId}/matchups", null, token);

        public async Task<List<Duration>> GetDurationsAsync(int heroId, CancellationToken? token = default) =>
            await _formatter.DeserializeAsync<List<Duration>>($"heroes/{heroId}/durations", null, token);

        public async Task<List<Player>> GetPlayersAsync(int heroId, CancellationToken? token = default) =>
            await _formatter.DeserializeAsync<List<Player>>($"heroes/{heroId}/players", null, token);

        public async Task<ItemPopularity> GetItemPopularityAsync(int heroId, CancellationToken? token = default) =>
            await _formatter.DeserializeAsync<ItemPopularity>($"heroes/{heroId}/itemPopularity", null, token);
    }
}
