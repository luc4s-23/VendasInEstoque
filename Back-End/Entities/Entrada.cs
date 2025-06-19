using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasInEstoque.Entities
{
    public class Entrada
    {
        public int Id { get; set; }
        public string? Fornecedor { get; set; } 
        public DateTime DataCompra { get; set; }
        public List<Item>? ItensComprados { get; set; }
        public int QuantidadeEntrada  { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }


    }
}