using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasInEstoque.Entities
{
    public class Compra
    {
        public int Id { get; set; }
        public string? Fornecedor { get; set; } 
        public DateTime DataCompra { get; set; }
        public List<Item>? ItensComprados { get; set; }
        public decimal ValorTotal { get; set; }
        public string? FileNF { get; set; } 

    }
}