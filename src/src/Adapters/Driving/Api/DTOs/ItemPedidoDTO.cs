namespace TechChallenge.src.Adapters.Driving.Api.DTOs
{
    public class ItemPedidoDTO
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public decimal Quantidade { get; set; }
    }
}