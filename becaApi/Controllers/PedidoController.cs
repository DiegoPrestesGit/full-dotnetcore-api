﻿using becaApi.Data;
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
    [Route("pedido")]
    public class PedidoController : ControllerBase
    {
        // TESTADO
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Pedido>>> Index([FromServices] DataContext context)
        {
            var pedidos = await context.Pedidos.ToListAsync();
            return pedidos;
        }

        // TESTADO
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Pedido>> GetById([FromServices] DataContext context, int id)
        {
            var pedido = await context.Pedidos.AsNoTracking().FirstOrDefaultAsync(pedido => pedido.Id == id);
            return pedido;
        }

        // TESTAR
        [HttpGet]
        [Route("pedidos/{id:int}")]
        public async Task<ActionResult<List<Pedido>>> GetAllByCliente([FromServices] DataContext context, int id)
        {
            var pedidos = await context.Pedidos.Include(pedido => pedido.Cliente.Id == id)
                .AsNoTracking()
                .Where(pedido => pedido.Cliente.Id == id)
                .ToListAsync();
            return pedidos;
        }

        // TESTAR PONTOS DO CLIENTE
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Pedido>> Create([FromServices] DataContext context, [FromBody] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                var cliente = await context.Clientes.AsNoTracking().FirstOrDefaultAsync(cli => cli.Id == pedido.ClienteId);

                cliente.Pontos += pedido.PontosTotais;

                if(cliente.Pontos >= 1000)
                {
                    cliente.FlagDesconto = true;
                    cliente.Pontos -= 1000;
                }

                if (pedido.Valor >= 150.00)
                {
                    await context.Funcionarios.ForEachAsync(func => func.Salario *= 1.05);
                }

                if (cliente.FlagDesconto)
                {
                    pedido.Valor *= 0.8;
                }
                if(cliente.Pedidos == null)
                {
                    cliente.Pedidos = new List<Pedido>();
                }
                cliente.Pedidos.Add(pedido);
                context.Pedidos.Add(pedido);
                context.Clientes.Update(cliente);
                await context.SaveChangesAsync();
                return pedido;
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
        public async Task<ActionResult<Pedido>> Update([FromServices] DataContext context, [FromBody] Pedido pedido)
        {
            if (pedido.Id == 0)
            {
                Console.WriteLine("Preciso do ID para alterar o pedido certo!");
                return BadRequest(ModelState);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Pedidos.Update(pedido);
                    await context.SaveChangesAsync();
                    return pedido;
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
        public async Task<ActionResult<Pedido>> Delete([FromServices] DataContext context, int id)
        {
            var pedido = await context.Pedidos.AsNoTracking().FirstOrDefaultAsync(prod => prod.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }
            context.Pedidos.Remove(pedido);
            await context.SaveChangesAsync();
            return pedido;
        }
    }
}
