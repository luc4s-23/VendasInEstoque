
using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Entities;
using BackEnd.DTO;
using BackEnd.Services;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("/")]
    public class ItemEntradaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ItemEntradaService _itemEntradaService;
        public ItemEntradaController(AppDbContext context, ItemEntradaService itemEntradaService)
        {
            _context = context;
            _itemEntradaService = itemEntradaService;
        }
        [HttpPost("registrar-itens/{idLancamento}")]
        public IActionResult RegistrarItens(int idLancamento, [FromBody] List<ItemEntradaDTO> itensDto)
        {
            if (_context.LancamentoEntradas.Find(idLancamento) == null)
                return NotFound("Lançamento não existe no banco de dados");

            if (itensDto == null)
                return BadRequest();

            foreach (var dTO in itensDto)
            {
                var item = new ItemEntrada
                {
                    Id_Item_FK = dTO.Id_Item_FK,
                    ValorUnitario = dTO.ValorUnitario,
                    QuantidadeEntrada = dTO.QuantidadeEntrada,
                    Id_LancamentoEntrada_FK = idLancamento
                };
                _context.ItensEntrada.Add(item);
            }
            _context.SaveChanges();
            return Ok();
        }
        
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var item = _context.ItensEntrada.Find(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpGet("BuscarEntradas")]
        public IActionResult BuscarTodosEntradas()
        {
            List<ItemEntrada> itemEntradas = _context.ItensEntrada.ToList();

            return Ok(itemEntradas);
        }

        //Metodo Put deve ser feito daqui

        // [HttpPut("atualizar-registro/{Id_LancamentoEntrada_FK}")]
        // public IActionResult Atualizar(int Id_LancamentoEntrada_FK, [FromBody] List<ItemEntradaDTO> itensAtualizados)
        // {
        //     var registrosExistentes  = _itemEntradaService.ListarRegistroEntrada(Id_LancamentoEntrada_FK);

        //     if (registrosExistentes == null || registrosExistentes.Any())
        //         return NotFound($"Nenhum registro com o ID {Id_LancamentoEntrada_FK} encontrado no banco de dados");

        //     foreach (var dTO in itensAtualizados)
        //     {
        //         var itemNoBanco = registrosExistentes.FirstOrDefault(x => x.Id_Item_FK == dTO.Id_Item_FK);
        //         if (itemNoBanco != null)
        //         {
        //             itemNoBanco.Id_Item_FK = dTO.Id_Item_FK;
        //             itemNoBanco.QuantidadeEntrada = dTO.QuantidadeEntrada;
        //             itemNoBanco.ValorUnitario = dTO.ValorUnitario;
        //         }
        //     }
        //      _context.SaveChanges();
        //     return Ok("Itens atualizados");
        // }
        
        [HttpDelete("deleter-por-id/{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.ItensEntrada.FirstOrDefault(e => e.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            _context.ItensEntrada.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{IdLancamentoFk}")]
        public IActionResult DeletarPorLancamento(int IdLancamentoFk)
        {
            var ItensEntradaDeletar = _context.ItensEntrada
                .Where(i => i.Id_LancamentoEntrada_FK == IdLancamentoFk)
                .ToList();
            if (ItensEntradaDeletar == null || ItensEntradaDeletar.Count == 0)
                return NotFound();
            _context.ItensEntrada.RemoveRange(ItensEntradaDeletar);
            _context.SaveChanges();
            return Ok();
        }

    }
}