using FormFuncionarioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormFuncionarioAPI.Controllers
{
    [ApiController]
    [Route("api/FormController")]
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioContexto _context;

        public FuncionarioController(FuncionarioContexto funcionarioContexto)
        {
            _context = funcionarioContexto;
        }

        [HttpPost("postfuncionario")]
        public async Task<ActionResult<Funcionario>> PostFuncionario(Funcionario funcionario)
        {
            try
            {
                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
