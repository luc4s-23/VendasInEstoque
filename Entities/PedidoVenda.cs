using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasInEstoque.Entities
{
    public class PedidoVenda
    {
        public int Id { get; set; }
        public string? DataVenda { get; set; } 
        public int IdClienteFK { get; set; }
        public decimal ValorTotal { get; set; }
        public List<Item>? ItensVendidos { get; set; }

       
    }
}