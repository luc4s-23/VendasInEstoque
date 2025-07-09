using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class ItemEntrada
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Item")]
        public int Id_Item_FK { get; set; }
        public decimal? ValorUnitario { get; set; }
        public int? QuantidadeEntrada { get; set; }

        [ForeignKey("LancamentoEntrada")]
        public int Id_LancamentoEntrada_FK { get; set; }
    }
}