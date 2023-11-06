using TechChallenge.src.Core.Application.Validations.ItensPedido.Base;
using TechChallenge.src.Core.Domain.Adapters;

namespace TechChallenge.src.Core.Application.Validations.ItensPedido
{
    public class DeletaItemPedidoValidation : ItemPedidoBaseValidation
    {
        public DeletaItemPedidoValidation(IItemPedidoRepository itemPedidoRepository
            , IProdutoRepository produtoRepository)
            : base(itemPedidoRepository, produtoRepository)
        {
            ValidarDataExclusao();
        }
    }
}