using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Entities;
using BackEnd.Data;


namespace BackEnd.Controllers
{
    [ApiController]
    [Route("/")]
    public class ItemController : ControllerBase
    {
        private AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("NovoItem")]
        public ActionResult<Item> Create([FromBody] Item Item)
        {
            _context.Itens.Add(Item);
            _context.SaveChanges();
            return Ok(Item);
        }

        [HttpGet("buscarItens")]
        public ActionResult<IEnumerable<Item>> GetAll()
        {
            var Itens = _context.Itens.ToList();
            return Ok(Itens);
        }

        [HttpGet("BuscarItem/{id}")]
        public ActionResult<Item> GetById(int id)
        {
            var item = _context.Itens.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPut("AtualizarItem/{id}")]
        public IActionResult Update(int id, [FromBody] Item updatedItem)
        {
            var item = _context.Itens.Find(id);
            if (item == null)
                return NotFound();

            if (updatedItem.Nome != null)
                item.Nome = updatedItem.Nome;
            if (updatedItem.PrecoVenda != null)
                item.PrecoVenda = updatedItem.PrecoVenda;
            if (updatedItem.QntMinima != null)
                item.QntMinima = updatedItem.QntMinima;

            _context.Update(item);
            _context.SaveChanges();

            return Ok(item);
        }

        [HttpDelete("DeletarItem/{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Itens.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();

            _context.Remove(item);
            _context.SaveChanges();
            return Ok(item);
        }
    }
}