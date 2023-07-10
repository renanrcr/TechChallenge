using FluentValidation;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Application.Validations.Clientes
{
    public class CadastraClienteValidation : ValidationBase<Cliente>
    {
        public CadastraClienteValidation()
        {
            ValidarId();
            ValidarDataCadastro();
            ValidarNome();
            ValidarEmail();
        }

        public void ValidarNome()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("Informe um nome.");
        }

        public void ValidarEmail()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Informe um e-mail válido.");
        }
    }
}