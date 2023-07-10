using FluentValidation;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Application.Validations.IdentificacoesPedido
{
    public class CadastraIdentificacaoPedidoValidation : ValidationBase<IdentificacaoPedido>
    {
        public CadastraIdentificacaoPedidoValidation()
        {
            ValidarId();
            ValidarDataCadastro();
        }

        public void ValidarValor()
        {
            RuleFor(x => x.Valor).NotNull().NotEmpty().WithMessage("Informe um valor.");
        }
    }
}