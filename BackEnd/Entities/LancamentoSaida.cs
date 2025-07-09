using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class LancamentoSaida
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("Cliente")]
        public int Id_Cliente_FK { get; set; }
        public int? NumeroNF_Saida { get; set; }
        public decimal? ValorTotal { get; set; }
        public DateTime DataSaida { get; set; }

    }
}