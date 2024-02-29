using FormFuncionario.Models;

namespace FormFuncionario.Services.FuncionarioCadDb
{
    public interface IFuncionarioService
    {
        Task PostFuncionario(Funcionario funcionario);
    }
}
