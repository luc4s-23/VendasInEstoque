using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasInEstoque.Entities
{
    public class Estoque
    {
        public int Id { get; set; }
        public int Id_item_FK { get; set; }
        public string? NomeItem { get; set; }
        public DateTime DataAtualizacao { get; set; }

    }
}