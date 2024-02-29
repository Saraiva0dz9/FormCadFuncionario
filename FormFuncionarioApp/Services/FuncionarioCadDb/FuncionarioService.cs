using FormFuncionario.Models;
using FormFuncionario.Services.Requisicao;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FormFuncionario.Services.FuncionarioCadDb
{
    public class FuncionarioService(IRequisicaoService requisicaoService, IConfiguration configuration, ILogger<FuncionarioService> logger): IFuncionarioService
    {
        private readonly IRequisicaoService _requisicaoService = requisicaoService;
        private readonly string _url = configuration["URL:API"];
        private readonly ILogger<FuncionarioService> _logger = logger;

        public async Task PostFuncionario(Funcionario funcionario)
        {
            try
            {
                var json = JsonSerializer.Serialize(funcionario);

                var response = await _requisicaoService.SendAsync(
                    url: _url,
                    rota: "FormController/postfuncionario",
                    json: json,
                    httpMethod: HttpMethod.Post
                    );

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Erro ao tentar cadastrar funcionário");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar funcionário");
                throw;
            }
        }
    }
}
