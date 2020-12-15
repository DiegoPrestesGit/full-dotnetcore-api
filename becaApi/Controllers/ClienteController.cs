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
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        // TESTAR
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Index([FromServices] DataContext context)
        {
            var clientes = await context.Clientes.ToListAsync();
            return clientes;
        }

        // TESTAR
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById([FromServices] DataContext context, int id)
        {
            var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(func => func.Id == id);
            return cliente;
        }

        // TESTAR
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cliente>> Create([FromServices] DataContext context, [FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(cliente);
                await context.SaveChangesAsync();
                return cliente;
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
        public async Task<ActionResult<Cliente>> Update([FromServices] DataContext context, [FromBody] Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                Console.WriteLine("Preciso do ID para alterar o produto certo!");
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Clientes.Update(cliente);
                    await context.SaveChangesAsync();
                    return cliente;
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
        public async Task<ActionResult<Cliente>> Delete([FromServices] DataContext context, int id)
        {
            var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(prod => prod.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();
            return cliente;
        }
    }
}
