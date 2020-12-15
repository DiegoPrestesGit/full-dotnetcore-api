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
            var pedidos = await context.Pedidos.Include(pedido => pedido.ClienteId == id)
                .AsNoTracking()
                .Where(pedido => pedido.ClienteId == id)
                .ToListAsync();
            return pedidos;
        }

        // TESTADO
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Pedido>> Create([FromServices] DataContext context, [FromBody] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                context.Pedidos.Add(pedido);
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