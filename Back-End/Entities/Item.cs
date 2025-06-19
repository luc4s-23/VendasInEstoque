using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasInEstoque.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string? Nome { get; set; } 
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

      
    }
}