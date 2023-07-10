using FluentValidation;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Application.Validations.ItensPedido.Base
{
    public class ItemPedidoBaseValidation : ValidationBase<ItemPedido>
    {
        public ItemPedidoBaseValidation()
        {
            ValidarId();
            ValidarPedidoId();
            ValidarProdutoId();
            //ValidarPrecoProduto();
        }

        public void ValidarPedidoId()
        {
            RuleFor(x => x.PedidoId).NotNull().NotEmpty().WithMessage("Informe um Id do pedido válido.");
        }

        public void ValidarProdutoId()
        {
            RuleFor(x => x.ProdutoId).NotNull().NotEmpty().WithMessage("Informe um produto.");
        }

        public void ValidarQuantidadeProduto()
        {
            RuleFor(x => x.ProdutoId).NotNull().NotEmpty().WithMessage("Informe um produto.");
        }

        //public void ValidarPrecoProduto()
        //{
        //    RuleFor(x => x.Produto.TabelaPreco.Preco).Equal(0).WithMessage("Produto sem preço.");
        //}
    }
}