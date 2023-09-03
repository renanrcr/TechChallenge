using TechChallenge.src.Core.Application.Validations.ItensPedido.Base;
using TechChallenge.src.Core.Domain.Adapters;

namespace TechChallenge.src.Core.Application.Validations.ItensPedido
{
    public class CadastraItemPedidoValidation : ItemPedidoBaseValidation
    {
        public CadastraItemPedidoValidation(IItemPedidoRepository itemPedidoRepository
            , IProdutoRepository produtoRepository)
            : base(itemPedidoRepository, produtoRepository)
        {
            ValidarDataCadastro();
        }
    }
}