using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Entities{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; } = String.Empty;
        public decimal? PrecoVenda { get; set; }
        public int? QntMinima  { get; set; }

      
    }
}