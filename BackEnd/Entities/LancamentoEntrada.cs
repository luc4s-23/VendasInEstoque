using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class LancamentoEntrada
    {
        [Key]
        public int Id { get; set; }
        public string? Fornecedor { get; set; } = string.Empty;
        public int? NumeroNF_Entrada { get; set; }
        public decimal? ValorTotal { get; set; }
    }
}