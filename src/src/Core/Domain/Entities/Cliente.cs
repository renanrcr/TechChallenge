using TechChallenge.src.Core.Application.Validations.Clientes;
using TechChallenge.src.Core.Domain.Commands.Clientes;

namespace TechChallenge.src.Core.Domain.Entities
{
    public class Cliente : EntidadeBase<Guid>
    {
        public string? Nome { get; private set; }
        public string? Email { get; private set; }

        public async Task<Cliente> Cadastrar(CadastraClienteCommand command)
        {
            Id = Guid.NewGuid();
            Nome = command.Nome;
            Email = command.Email;
            DataCadastro = DateTime.Now;

            await Validate(this, new CadastraClienteValidation());

            return this;
        }
    }
}