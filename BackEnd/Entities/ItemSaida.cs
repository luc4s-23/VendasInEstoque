using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class ItemSaida
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Item")]
        public int Id_Item_FK { get; set; }
        public int? QuantidadeSaida { get; set; }

        [ForeignKey("LancamentoSaida")]
        public int Id_LancamentoSaida_FK { get; set; }
    }
}