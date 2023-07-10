using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.src.Adapters.Driving.Api.Controllers.Base;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.Pedidos;

namespace TechChallenge.src.Adapters.Driving.Api.Controllers
{
    public class PedidoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(INotificador notificador,
            IMediator mediator,
            IMapper mapper,
            IPedidoRepository pedidoRepository)
            : base(notificador)
        {
            _mediator = mediator;
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<PedidoDTO>>(await _pedidoRepository.ObterTodos()));
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CadastraPedidoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}