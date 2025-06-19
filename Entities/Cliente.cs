using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasInEstoque.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; } 
        public string? telefone { get; set; }
        public string? Cnpj { get; set; } 
        public string? Endereco { get; set; } 

    }

}