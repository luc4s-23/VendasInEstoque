using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Entities;
using BackEnd.Services;
using BackEnd.DTO;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoEntradaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ItemEntradaService _itemEntradaService;

        public LancamentoEntradaController(AppDbContext context, ItemEntradaService itemEntradaService)
        {
            _context = context;
            _itemEntradaService = itemEntradaService;
        }

        [HttpPost("criar-lancamento")]
        public IActionResult Create([FromBody] LancamentoEntradaDTO lancamentoEntradaDTO)
        {
            var lancamentoEntrada = new LancamentoEntrada
            {
                Fornecedor = lancamentoEntradaDTO.Fornecedor,
                NumeroNF_Entrada = lancamentoEntradaDTO.NumeroNF_Entrada,
                ValorTotal = lancamentoEntradaDTO.ValorTotal
            };
            _context.LancamentoEntradas.Add(lancamentoEntrada);
            _context.SaveChanges();
            return Ok(lancamentoEntrada);
        }

        [HttpGet("buscar-todos-lancamentos")]
        public IActionResult BuscarTodosLancamento()
        {
            var Lancamentos = _context.LancamentoEntradas.ToList();

            return Ok(Lancamentos);
        }

        [HttpGet("buscar-lancamento-por-id/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var lancamento = _context.LancamentoEntradas.Find(id);

            return Ok(lancamento);
        }

        [HttpGet("buscar-de-lancamento-completo-por-id/{id}")]
        public IActionResult BuscarCompletaPorId(int id)
        {
            var lancamento = _context.LancamentoEntradas.Find(id);
            if (lancamento == null)
                return NotFound("Lançamento não encontrado");

            var itens = _context.ItensEntrada
                .Where(i => i.Id_LancamentoEntrada_FK == id)
                .ToList();

            var resultado = new
            {
                LancamentoEntrada = lancamento,
                ItemEntrada = itens
            };

            return Ok(resultado);
        }

        [HttpDelete("DeletarPorId/{id}")]
        public IActionResult DeletarPorId(int id)
        {
            var itemDeletado = _context.LancamentoEntradas.Find(id);
            if (itemDeletado == null)
                return NotFound("Lançamento não pode ser deletado, pois não existe");

            _context.LancamentoEntradas.Remove(itemDeletado);
            _context.SaveChanges();
            _itemEntradaService.DeletarPorId(itemDeletado.Id);
            return Ok(itemDeletado);
        }
    }
}

