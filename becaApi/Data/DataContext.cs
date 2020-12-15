using becaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace becaApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<EstoqueProduto> Estoques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ONE TO MANY => FORNECEDOR E PRODUTO
            modelBuilder.Entity<Fornecedor>()
            .HasMany(forn => forn.ProdutosOferecidos)
            .WithOne(prod => prod.Fornecedor)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            // ONE TO MANY => CLIENTE E PEDIDO
            modelBuilder.Entity<Cliente>()
            .HasMany(cli => cli.Pedidos)
            .WithOne(pedido => pedido.Cliente)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            // ONE TO MANY => ESTOQUE E PRODUTO
            modelBuilder.Entity<EstoqueProduto>()
            .HasMany(estoque => estoque.Produtos)
            .WithOne(prod => prod.Estoque)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            // MANY TO MANY => PEDIDO E PRODUTO
            modelBuilder.Entity<PedidoProdutoRelation>()
            .HasKey(relation => new { relation.PedidoId, relation.ProdutoId });

            modelBuilder.Entity<PedidoProdutoRelation>()
            .HasOne(relation => relation.Pedido)
            .WithMany(pedido => pedido.ProdutosPedidos)
            .HasForeignKey(relation => relation.PedidoId);

            modelBuilder.Entity<PedidoProdutoRelation>()
            .HasOne(relation => relation.Produto)
            .WithMany(produto => produto.ProdutosPedidos)
            .HasForeignKey(relation => relation.ProdutoId);

        }
    }
}
