using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasInEstoque.Entities;

namespace VendasInEstoque.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Saida> Saidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}