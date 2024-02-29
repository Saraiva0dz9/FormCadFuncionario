using FormFuncionario.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Mime;
using System.Text;

namespace FormFuncionario.Services.Requisicao
{
    public class RequisicaoService : IRequisicaoService
    {
        private static readonly HttpClient _httpClient = new();

        private string GetUri(string url, Dictionary<string, string> query, string rota)
        {
            if (query is not null)
                return QueryHelpers.AddQueryString($"{url}/api/{rota}", query!);

            return $"{url}/api/{rota}";
        }

        public async Task<PierResposta> SendAsync(string url, string rota, string json, Dictionary<string, string> query, HttpMethod httpMethod)
        {
            var uri = GetUri(url, query, rota);

            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(uri),
                Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json),
            };

            var data = await _httpClient.SendAsync(request);

            return new PierResposta(data.Headers.ToString(), await data.Content.ReadAsStringAsync(), data.StatusCode, data.IsSuccessStatusCode);
        }

        public async Task<PierResposta> SendAsync(string url, string rota, Dictionary<string, string> query, HttpMethod httpMethod)
        {
            var uri = GetUri(url, query, rota);

            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(uri),
            };

            var data = await _httpClient.SendAsync(request);

            return new PierResposta(data.Headers.ToString(), await data.Content.ReadAsStringAsync(), data.StatusCode, data.IsSuccessStatusCode);
        }

        public async Task<PierResposta> SendAsync(string url, string rota, string json, HttpMethod httpMethod)
        {
            var uri = $"{url}/api/{rota}";

            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(uri),
                Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json),
            };

            var data = await _httpClient.SendAsync(request);

            return new PierResposta(data.Headers.ToString(), await data.Content.ReadAsStringAsync(), data.StatusCode, data.IsSuccessStatusCode);
        }

        public async Task<PierResposta> SendAsync(string url, string rota, HttpMethod httpMethod)
        {
            var uri = $"{url}/api/{rota}";

            var request = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(uri),
            };

            var data = await _httpClient.SendAsync(request);

            return new PierResposta(data.Headers.ToString(), await data.Content.ReadAsStringAsync(), data.StatusCode, data.IsSuccessStatusCode);
        }
    }
}
