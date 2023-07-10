using TechChallenge.src.Core.Application.Validations.IdentificacoesPedido;
using TechChallenge.src.Core.Domain.Commands.IdentificacoesPedido;
using TechChallenge.src.Core.Domain.Enums;

namespace TechChallenge.src.Core.Domain.Entities
{
    public class IdentificacaoPedido : EntidadeBase<Guid>
    {
        public string? Valor { get; private set; }
        public ETipoIdentificacaoPedido TipoIdentificacaoPedido { get; private set; }
        public Pedido? Pedido { get; private set; }

        public async Task<IdentificacaoPedido> Cadastrar(CadastraIdentificacaoPedidoCommand command)
        {
            Id = Guid.NewGuid();
            Valor = command.Valor;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraIdentificacaoPedidoValidation());

            return this;
        }
    }
}