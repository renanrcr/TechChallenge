using TechChallenge.src.Core.Application.Validations.IdentificacoesPedido;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.IdentificacoesPedido;
using TechChallenge.src.Core.Domain.Enums;

namespace TechChallenge.src.Core.Domain.Entities
{
    public class IdentificacaoPedido : EntidadeBase<Guid>
    {
        public string? Valor { get; private set; }
        public ETipoIdentificacaoPedido TipoIdentificacaoPedido { get; private set; }
        public Pedido? Pedido { get; private set; }

        public async Task<IdentificacaoPedido> Cadastrar(IIdentificacaoPedidoRepository identificacaoPedidoRepository, CadastraIdentificacaoPedidoCommand command)
        {
            Id = Guid.NewGuid();
            Valor = command.Valor;
            TipoIdentificacaoPedido = (ETipoIdentificacaoPedido)command.TipodIdentificacaoPedido;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraIdentificacaoPedidoValidation(identificacaoPedidoRepository));

            return this;
        }
    }
}