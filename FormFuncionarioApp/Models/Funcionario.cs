using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FormFuncionario.Models
{
    public class Funcionario
    {
        [JsonPropertyName("idFuncionario")]
        public int IdFuncionario { get; set; }

        [JsonPropertyName("nome")]
        public string NomeCompleto => $"{FirstName} {Sobrenome}";

        [JsonPropertyName("dt_nascimento")]
        [Required(ErrorMessage = "Preencha a data antes de salvar.")]
        public DateTime? DataNacimento { get; set; }

        [JsonPropertyName("cpf")]
        [Required(ErrorMessage = "Preencha o CPF antes de salvar.")]
        public string Cpf { get; set; }

        [JsonPropertyName("endereco")]
        [Required(ErrorMessage = "Preencha o endereço antes de salvar.")]
        public string Endereco { get; set; }

        [JsonPropertyName("sexo")]
        [Required(ErrorMessage = "Selecione uma opção.")]
        public string Sexo { get; set; }
        public string FirstName { get; set; }
        public string Sobrenome { get; set; }
    }
}
