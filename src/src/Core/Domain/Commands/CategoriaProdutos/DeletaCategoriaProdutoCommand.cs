using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Domain.Commands.CategoriaProdutos
{
    public class DeletaCategoriaProdutoCommand : IRequest<CategoriaProdutoDTO>
    {
        public Guid Id { get; set; }
    }
}