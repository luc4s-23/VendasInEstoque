using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasInEstoque.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Login { get; set; } 
        public string? Senha { get; set; } 
        public string? Email { get; set; }

       
    }
}