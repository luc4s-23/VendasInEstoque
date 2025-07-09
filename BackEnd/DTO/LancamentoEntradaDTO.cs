using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTO
{
    public class LancamentoEntradaDTO
    {
        public string? Fornecedor { get; set; } = string.Empty;
        public int? NumeroNF_Entrada { get; set; }
        public decimal? ValorTotal { get; set; }
    }
}