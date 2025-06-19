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
    public class EntradaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntradaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Compra
        [HttpGet]
        public IActionResult GetEntradas()
        {
            var compras = _context.Entradas.ToList();
            return Ok(compras);
        }

        // GET: /Compra/{id}
        [HttpGet("{id}")]
        public IActionResult GetEntrada(int id)
        {
            var compra = _context.Entradas.Find(id);

            if (compra == null)
            {
                return NotFound();
            }

            return Ok(compra);
        }

        // POST: /Compra
        [HttpPost]
        public IActionResult PostCompra(Entrada entrada)
        {
            _context.Entradas.Add(entrada);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEntrada), new { id = entrada.Id }, entrada);
        }

        // PUT: /Compra/{id}
        [HttpPut("{id}")]
        public IActionResult PutCompra(int id, Entrada entrada)
        {
            if (id != entrada.Id)
            {
                return BadRequest();
            }

            _context.Entry(entrada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!_context.Entradas.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: /Compra/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCompra(int id)
        {
            var compra = _context.Entradas.Find(id);
            if (compra == null)
            {
                return NotFound();
            }

            _context.Entradas.Remove(compra);
            _context.SaveChanges();

            return NoContent();
        }
    }
}