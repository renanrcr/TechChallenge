using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.ItensPedido
{
    public class AtualizaItemPedidoCommand : IRequest<ItemPedidoDTO>
    {
        public Guid Id { get; set; }
        public decimal Quantidade { get; set; }
    }
}