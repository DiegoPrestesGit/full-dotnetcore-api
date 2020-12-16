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
    [Route("fornecedor")]
    public class FornecedorController : ControllerBase
    {
        // TESTADO
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Fornecedor>>> Index([FromServices] DataContext context)
        {
            var fornecedor = await context.Fornecedores.ToListAsync();
            return fornecedor;
        }

        // TESTADO
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Fornecedor>> GetById([FromServices] DataContext context, int id)
        {
            var fornecedor = await context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(forn => forn.Id == id);
            return fornecedor;
        }

        // TESTADO
        [HttpGet]
        [Route("produto/{id:int}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedorByProduto([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos.AsNoTracking().FirstOrDefaultAsync(produto => produto.Id == id);
            var fornecedor = await context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(forn => forn.Id == produto.FornecedorId);
            return fornecedor;
        }

        // TESTADO
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Fornecedor>> Create([FromServices] DataContext context, [FromBody] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                context.Fornecedores.Add(fornecedor);
                await context.SaveChangesAsync();
                return fornecedor;
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
        public async Task<ActionResult<Fornecedor>> Update([FromServices] DataContext context, [FromBody] Fornecedor fornecedor)
        {
            if (fornecedor.Id == 0)
            {
                Console.WriteLine("Preciso do ID para alterar o produto certo!");
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Fornecedores.Update(fornecedor);
                    await context.SaveChangesAsync();
                    return fornecedor;
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

        // TESTADO
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Fornecedor>> Delete([FromServices] DataContext context, int id)
        {
            var fornecedor = await context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(prod => prod.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            context.Fornecedores.Remove(fornecedor);
            await context.SaveChangesAsync();
            return fornecedor;
        }
    }
}
