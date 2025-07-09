using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
    public class ItemEntradaDTO
    {
        public int Id_Item_FK { get; set; }
        public decimal? ValorUnitario { get; set; }
        public int? QuantidadeEntrada { get; set; }
    }
}