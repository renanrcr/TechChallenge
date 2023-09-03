using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Enums;

namespace TechChallenge.src.Core.Domain.Commands
{
    public class CheckoutPedidoCommand : IRequest<CheckoutPedidoDTO>
    {
        public int TipodIdentificacaoCliente { get; set; } = (int)ETipoIdentificacaoPedido.NAO_IDENTIFICADO;

        public string? IdentificacaoCliente { get; set; }

        public IList<ItemPedidoDTO>? ItensPedido { get; set; }
    }
}