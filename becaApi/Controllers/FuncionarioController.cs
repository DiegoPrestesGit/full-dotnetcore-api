using becaApi.Data;
using becaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace becaApi.Controllers
{
    [ApiController]
    [Route("funcionario")]
    public class FuncionarioController : ControllerBase
    {
        // TESTAR
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Funcionario>>> Index([FromServices] DataContext context)
        {
            var funcionarios = await context.ListaFuncionarios.ToListAsync();
            return funcionarios;
        }

        // TESTAR
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Funcionario>> GetById([FromServices] DataContext context, int id)
        {
            var funcionario = await context.ListaFuncionarios.AsNoTracking().FirstOrDefaultAsync(func => func.Id == id);
            return funcionario;
        }

        [HttpGet]
        [Route("funcao/{funcao}")]
        public async Task<ActionResult<List<Funcionario>>> GetByFuncao([FromServices] DataContext context, string funcao)
        {
            var funcionarios = await context.ListaFuncionarios.Where(func => func.Funcao == funcao).ToListAsync();
            return funcionarios;
        }

        // TESTAR
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Funcionario>> Create([FromServices] DataContext context, [FromBody] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                context.ListaFuncionarios.Add(funcionario);
                await context.SaveChangesAsync();
                return funcionario;
            }
            else
            {
                Console.WriteLine("Presta atenção na sua model");
                return BadRequest(ModelState);
            }
        }

        // TESTAR
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Funcionario>> Update([FromServices] DataContext context, [FromBody] Funcionario funcionario)
        {
            if (funcionario.Id == 0)
            {
                Console.WriteLine("Preciso do ID para alterar o produto certo!");
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.ListaFuncionarios.Update(funcionario);
                    await context.SaveChangesAsync();
                    return funcionario;
                }
                catch
                {
                    return NotFound();
                }
            }
            else
            {
                Console.WriteLine("Presta atenção na sua model");
                return BadRequest(ModelState);
            }
        }

        // TESTAR
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Funcionario>> Delete([FromServices] DataContext context, int id)
        {
            var funcionario = await context.ListaFuncionarios.AsNoTracking().FirstOrDefaultAsync(prod => prod.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            context.ListaFuncionarios.Remove(funcionario);
            await context.SaveChangesAsync();
            return funcionario;
        }
    }
}
