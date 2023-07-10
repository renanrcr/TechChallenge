using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.CategoriaProdutos
{
    public class CadastraCategoriaProdutoCommand : IRequest<CategoriaProdutoDTO>
    {
        public string? Descricao { get; set; }
    }
}