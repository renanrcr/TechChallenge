using TechChallenge.src.Core.Domain.Enums;

namespace TechChallenge.src.Adapters.Driving.Api.DTOs
{
    public class PedidoDTO
    {
        public Guid IdentificacaoPedidoId { get; set; }
        public string? NumeroPedido { get; set; }
        public EStatusPedido EstatusPedido { get; set; }
    }
}