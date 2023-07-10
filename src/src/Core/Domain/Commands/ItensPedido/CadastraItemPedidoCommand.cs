using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Domain.Commands.ItensPedido
{
    public class CadastraItemPedidoCommand : IRequest<ItemPedidoDTO>
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
    }
}
