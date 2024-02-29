using FormFuncionario.Models;

namespace FormFuncionario.Services.Requisicao
{
    public interface IRequisicaoService
    {
        Task<PierResposta> SendAsync(string url, string rota, string json, Dictionary<string, string> query, HttpMethod httpMethod);
        Task<PierResposta> SendAsync(string url, string rota, Dictionary<string, string> query, HttpMethod httpMethod);
        Task<PierResposta> SendAsync(string url, string rota, string json, HttpMethod httpMethod);
        Task<PierResposta> SendAsync(string url, string rota, HttpMethod httpMethod);
    }
}
