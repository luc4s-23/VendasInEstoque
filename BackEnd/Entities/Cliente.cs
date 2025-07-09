using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string? NomeCompleto { get; set; } 
        public string? telefone { get; set; }
        public string? Cnpj { get; set; } 
        public string? Endereco { get; set; } 

    }

}