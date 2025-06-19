using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasInEstoque.Data;
using VendasInEstoque.Entities;

namespace VendasInEstoque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private AppDbContext _context;
        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("NovoCliente")]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return Ok(cliente);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("AtualizarCliente/{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] Cliente cliente)
        {
            var clienteExistente = _context.Clientes.Find(id);
            if (clienteExistente == null)
            {
                return NotFound();
            }
            if (cliente.NomeCompleto != null)
                clienteExistente.NomeCompleto = cliente.NomeCompleto;

            if (cliente.telefone != null)
                clienteExistente.telefone = cliente.telefone;

            if (cliente.Cnpj != null)
                clienteExistente.Cnpj = cliente.Cnpj;

            if (cliente.Endereco != null)
                clienteExistente.Endereco = cliente.Endereco;


            _context.SaveChanges();
            return Ok(clienteExistente);
        }
    }
}