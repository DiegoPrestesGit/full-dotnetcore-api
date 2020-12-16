using becaApi.Data;
using becaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace becaApi.Controllers
{
    [ApiController]
    [Route("estoque")]
    public class EstoqueProduto : ControllerBase
    {
        // TESTADO
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Estoque>>> Index([FromServices] DataContext context)
        {
            var estoqueCompleto = await context.Estoques.ToListAsync();
            return estoqueCompleto;
        }

        // TESTADO
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Estoque>> GetById([FromServices] DataContext context, int id)
        {
            var estoque = await context.Estoques.AsNoTracking().FirstOrDefaultAsync(estoq => estoq.Id == id);
            return estoque;
        }

        // TESTADO
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Estoque>> Create([FromServices] DataContext context, [FromBody] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                context.Estoques.Add(estoque);
                await context.SaveChangesAsync();
                return estoque;
            }
            else
            {
                Console.WriteLine("Presta atenção na sua model");
                return BadRequest(ModelState);
            }
        }

        // TESTADO
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Estoque>> Update([FromServices] DataContext context, [FromBody] Estoque estoque)
        {
            if (estoque.Id == 0)
            {
                Console.WriteLine("Preciso do ID para alterar o produto certo!");
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Estoques.Update(estoque);
                    await context.SaveChangesAsync();
                    return estoque;
                }
                catch { return NotFound(); }
            }
            else
            {
                Console.WriteLine("Presta atenção na sua model");
                return BadRequest(ModelState);
            }
        }

        // TESTADO
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Estoque>> Delete([FromServices] DataContext context, int id)
        {
            var estoque = await context.Estoques.AsNoTracking().FirstOrDefaultAsync(estoq => estoq.Id == id);
            if (estoque == null)
            {
                return NotFound();
            }
            context.Estoques.Remove(estoque);
            await context.SaveChangesAsync();
            return estoque;
        }
    }
}
