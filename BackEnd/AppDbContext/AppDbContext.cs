using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Entities;


namespace BackEnd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<ItemEntrada> ItensEntrada { get; set; }
        public DbSet<ItemSaida> ItensSaida { get; set; }
        public DbSet<LancamentoEntrada> LancamentoEntradas { get; set; }
        public DbSet<LancamentoSaida> LancamentoSaidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}