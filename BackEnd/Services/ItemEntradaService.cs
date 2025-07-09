using BackEnd.Data;
using BackEnd.DTO;
using BackEnd.Entities;

namespace BackEnd.Services
{
    public class ItemEntradaService
    {
        private readonly AppDbContext _context;

        public ItemEntradaService(AppDbContext context)
        {
            _context = context;
        }

        public bool DeletarPorId(int IdLancamentoFk)
        {
            var itens = _context.ItensEntrada
                .Where(i => i.Id_LancamentoEntrada_FK == IdLancamentoFk)
                .ToList();

            if (itens == null)
                return false;

            _context.ItensEntrada.RemoveRange(itens);
            _context.SaveChanges();

            return true;
        }

        public List<ItemEntrada> ListarRegistroEntrada(int Id_LancamentoEntrada_FK)
        {
            try
            {
                if (Id_LancamentoEntrada_FK == 0)
                    throw new ArgumentException("O ID do lançamento não pode ser 0.");

                var listaDeRegistros = _context.ItensEntrada
                    .Where(registros => registros.Id_LancamentoEntrada_FK == Id_LancamentoEntrada_FK)
                    .ToList();
                return listaDeRegistros;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<ItemEntradaDTO> BuscarItensParaEdicao(int idLancamentoEntradaFk)
        {
            var registros = _context.ItensEntrada
                .Where(x => x.Id_LancamentoEntrada_FK == idLancamentoEntradaFk)
                .ToList();

            if (registros == null || !registros.Any())
                return new List<ItemEntradaDTO>();

            var listaDTO = registros.Select(item => new ItemEntradaDTO
            {
                Id_Item_FK = item.Id_Item_FK,
                QuantidadeEntrada = item.QuantidadeEntrada,
                ValorUnitario = item.ValorUnitario
            }).ToList();

            return listaDTO;
        }

    }
}