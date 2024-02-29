using Microsoft.EntityFrameworkCore;

namespace FormFuncionarioAPI.Models
{
    public class FuncionarioContexto : DbContext
    {
        public FuncionarioContexto(DbContextOptions<FuncionarioContexto> options) : base(options) {}

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
