using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasInEstoque.Entities
{
    public class Saida
    {
        public int Id { get; set; }
        public int NF { get; set; }
        public int IdClienteFK { get; set; }
        public int Id_item_FK { get; set; }
        public int QuantidadeSaida { get; set; }
        public decimal ValorUnitarioVenda { get; set; }
        public decimal ValorTotal { get; set; }
        public string? DataVenda { get; set; } 

       
    }
}