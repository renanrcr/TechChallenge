using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.Pedidos
{
    public class ListaPedidoCommand : IRequest<IList<PedidosDTO>>
    {
    }
}
