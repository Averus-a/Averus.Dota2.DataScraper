namespace Averus.Dota2.DataScraper.Utils
{
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;
    public sealed class JsonFormatter : IDisposable
    {
        private readonly RequestHandler _request;
        public JsonFormatter(RequestHandler request)
        {
            _request = request;
        }

        public async Task<T> DeserializeAsync<T>(string url, string parameters = null, CancellationToken? cancellationToken = null) where T : class
        {
            var response = await _request.GetResponseAsync(url, parameters, cancellationToken.GetValueOrDefault());

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public void Dispose()
        {
            _request?.Dispose();
        }
    }
}
