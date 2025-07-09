using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Entities;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("/")]
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

        [HttpGet("BuscarCliente/{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var cliente = _context.Clientes.ToList();
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
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

            _context.Update(clienteExistente);
            _context.SaveChanges();
            return Ok(clienteExistente);
        }

        [HttpDelete("ApagarCliente/{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
