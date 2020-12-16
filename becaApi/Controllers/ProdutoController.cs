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
    [Route("produto")]
    public class ProdutoController : ControllerBase
    {
        // TESTADO
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Index([FromServices] DataContext context)
        {
            var produtos = await context.Produtos.ToListAsync();
            return produtos;
        }

        // TESTADO
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos.AsNoTracking().FirstOrDefaultAsync(produto => produto.Id == id);
            return produto;
        }

        // TESTAR
        [HttpGet]
        [Route("fornecedor/{id:int}")]
        public async Task<ActionResult<List<Produto>>> GetAllByFornecedor([FromServices] DataContext context, int id)
        {
            var produtos = await context.Produtos.Where(prod => prod.FornecedorId == id).ToListAsync();
            return produtos;
        }

        [HttpGet]
        [Route("estoque/{id:int}")]
        public async Task<ActionResult<List<Produto>>> GetAllByEstoque([FromServices] DataContext context, int id)
        {
            var produtos = await context.Produtos.Where(prod => prod.EstoqueId == id).ToListAsync();
            return produtos;
        }

        [HttpGet]
        [Route("pedido/{id:int}")]
        public async Task<ActionResult<List<Produto>>> GetAllByPedido([FromServices] DataContext context, int id)
        {
            var produtos = await context.Produtos.Where(prod => prod.PedidoId == id).ToListAsync();
            
            return produtos;
        }

        // TESTADO
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Create([FromServices] DataContext context, [FromBody] Produto produto)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(produto);
                await context.SaveChangesAsync();
                return produto;
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
        public async Task<ActionResult<Produto>> Update([FromServices] DataContext context, [FromBody] Produto produto)
        {
            if(produto.Id == 0)
            {
                Console.WriteLine("Preciso do ID para alterar o produto certo!");
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Produtos.Update(produto);
                    await context.SaveChangesAsync();
                    return produto;
                }
                catch{return NotFound();}
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
        public async Task<ActionResult<Produto>> Delete([FromServices] DataContext context, int id)
        {
            var produto = await context.Produtos.AsNoTracking().FirstOrDefaultAsync(prod => prod.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();
            return produto;
        }
    }
}
