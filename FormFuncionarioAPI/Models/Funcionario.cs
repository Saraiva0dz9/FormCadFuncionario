using System.ComponentModel.DataAnnotations;

namespace FormFuncionarioAPI.Models
{
    public class Funcionario
    {
        [Key]
        public int IdFuncionario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime? Dt_nascimento { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
    }
}
