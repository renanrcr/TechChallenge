using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.ItensPedido
{
    public class DeletaItemPedidoCommand : IRequest<ItemPedidoDTO>
    {
        public Guid Id { get; set; }
    }
}