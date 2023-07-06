namespace Averus.Dota2.DataScraper
{
    using Averus.Dota2.DataScraper.Utils;
    using OpenDotaApi;
    using System.Net;

    internal class Program
    {


        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello! This is DOTA 2 data scraper build as tool for working on WoF AI bot script.");

            var context = new SteamContext
            {
                Id = 76561198093498586
            };

            using var openDota = new OpenDota(context.Id.ToString());

            var data = await openDota.Heroes.GetDataAsync();

            Console.WriteLine();
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