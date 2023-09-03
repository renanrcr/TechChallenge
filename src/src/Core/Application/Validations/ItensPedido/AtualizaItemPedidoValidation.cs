using TechChallenge.src.Core.Application.Validations.ItensPedido.Base;
using TechChallenge.src.Core.Domain.Adapters;

namespace TechChallenge.src.Core.Application.Validations.ItensPedido
{
    public class AtualizaItemPedidoValidation : ItemPedidoBaseValidation
    {
        public AtualizaItemPedidoValidation(IItemPedidoRepository itemPedidoRepository
            , IProdutoRepository produtoRepository)
            : base(itemPedidoRepository, produtoRepository)
        {
            ValidarDataAtualizacao();
        }
    }
}