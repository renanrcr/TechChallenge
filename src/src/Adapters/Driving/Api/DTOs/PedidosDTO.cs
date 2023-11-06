namespace TechChallenge.src.Adapters.Driving.Api.DTOs
{
    public class PedidosDTO
    {
        public string? NumeroPedido { get; set; }
        public string? StatusPedido { get; set; }
        public decimal QuantidadeItens { get; set; }
        public decimal TotalDoPedido { get; set; }
        public IList<ItensDTO> ItensPedido { get; set; } = new List<ItensDTO>();
    }

    public class ItensDTO
    {
        public string? Nome { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}