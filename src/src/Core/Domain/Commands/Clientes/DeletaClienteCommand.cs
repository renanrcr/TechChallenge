using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.Clientes
{
    public class DeletaClienteCommand : IRequest<ClienteDTO>
    {
        public Guid Id { get; set; }
    }
}