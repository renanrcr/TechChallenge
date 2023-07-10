using TechChallenge.src.Core.Application.Validations.ItensPedido;
using TechChallenge.src.Core.Domain.Commands.ItensPedido;

namespace TechChallenge.src.Core.Domain.Entities
{
    public class ItemPedido : EntidadeBase<Guid>
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public decimal Quantidade { get; private set; }
        public Produto? Produto { get; private set; }
        public Pedido? Pedido { get; private set; }

        public async Task<ItemPedido> Cadastrar(CadastraItemPedidoCommand command)
        {
            Id = Guid.NewGuid();
            PedidoId = command.PedidoId;
            ProdutoId = command.ProdutoId;
            Quantidade = command.Quantidade;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraItemPedidoValidation());

            return this;
        }

        public async Task<ItemPedido> Atualizar(AtualizaItemPedidoCommand command)
        {
            Id = command.Id;
            Quantidade = command.Quantidade;
            DataAtualizacao = DateTime.Now;

            await Validate(this, new AtualizaItemPedidoValidation());

            return this;
        }

        public async Task<ItemPedido> Deletar(DeletaItemPedidoCommand command)
        {
            Id = command.Id;
            DataExclusao = DateTime.Now;

            await Validate(this, new DeletaItemPedidoValidation());

            return this;
        }
    }
}