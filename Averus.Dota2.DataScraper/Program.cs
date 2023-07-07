namespace Averus.Dota2.DataScraper
{
    using Averus.Dota2.DataScraper.Game;
    using Averus.Dota2.DataScraper.Utils;
    using Newtonsoft.Json;
    using OpenDotaApi;
    using System.Net;

    internal class Program
    {
        private static readonly string DataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello! This is DOTA 2 data scraper build as tool for working on WoF AI bot script.");

            var context = new SteamContext
            {
                Id = 76561198093498586
            };

            using var openDota = new OpenDota(context.Id.ToString());

            var heroes = await openDota.Heroes.GetDataAsync();

            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(DataDirectory);
            }

            File.WriteAllText(Path.Combine(DataDirectory, "hero_base.json"), JsonConvert.SerializeObject(heroes));

            // Grouped by positions
            List<(int, int)> heroByPos = new List<(int, int)>();

            for (int i = 1; i <= 5; i++)
            {
                var pos = i;
                foreach (var hero in heroes)
                {
                    var positions = Teambuilding.GetTeamPosition(hero.Roles);
                    if (positions.Any(x => x == i))
                    {
                        heroByPos.Add(((int)hero.Id, pos));
                    }
                }
            }

            var projection = heroByPos.GroupBy(x => x.Item2, element => element.Item1).ToArray();


            File.WriteAllText(Path.Combine(DataDirectory, "hero_pos.json"), JsonConvert.SerializeObject(projection));

            Console.ReadLine();
        }

        public class SteamContext
        {
            public long Id { get; set; }
        }

        public class OpenDota : IDisposable
        {
            private RequestHandler _request;
            private JsonFormatter _jsonFormatter;

            public OpenDota(string apiKey = null, IWebProxy proxy = null)
            {
                _request = new RequestHandler(apiKey, proxy);
                _jsonFormatter = new JsonFormatter(_request);

                Heroes = new HeroesEndpoint(_jsonFormatter);
            }

            public HeroesEndpoint Heroes { get; private set; }

            public void Dispose()
            {
                _jsonFormatter.Dispose();
            }
        }
    }
}