using FluentValidation;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Application.Validations.ItensPedido.Base
{
    public class ItemPedidoBaseValidation : ValidationBase<ItemPedido>
    {
        private IItemPedidoRepository _itemPedidoRepository;
        private IProdutoRepository _produtoRepository;

        public ItemPedidoBaseValidation(IItemPedidoRepository itemPedidoRepository, IProdutoRepository produtoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
            _produtoRepository = produtoRepository;

            ValidarId();
            ValidarPedidoId();
            ValidarProdutoId();
            ValidarExisteProdutoCadastrado();
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

        public void ValidarExisteProdutoCadastrado()
        {
            RuleFor(s => s.Id).NotEmpty()
                .MustAsync(ExisteProduto).WithMessage("Produto não cadastrado.");
        }

        private async Task<bool> ExisteProduto(Guid id, CancellationToken token)
        {
            return await _produtoRepository.Existe(x => x.Id == id);
        }
    }
}