using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Enums;

namespace TechChallenge.src.Core.Domain.Commands.IdentificacoesPedido
{
    public class CadastraIdentificacaoPedidoCommand : IRequest<IdentificacaoDTO>
    {
        public string? Valor { get; set; }
        public int TipodIdentificacaoPedido { get; set; } = (int)ETipoIdentificacaoPedido.CPF;
    }
}