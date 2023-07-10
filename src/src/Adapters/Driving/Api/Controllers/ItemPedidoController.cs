using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.src.Adapters.Driving.Api.Controllers.Base;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.Clientes;
using TechChallenge.src.Core.Domain.Commands.ItensPedido;

namespace TechChallenge.src.Adapters.Driving.Api.Controllers
{
    public class ItemPedidoController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoController(INotificador notificador,
            IMediator mediator,
            IMapper mapper,
            IItemPedidoRepository itemPedidoRepository)
            : base(notificador)
        {
            _mediator = mediator;
            _mapper = mapper;
            _itemPedidoRepository = itemPedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult?> Get()
        {
            if (!ModelState.IsValid) return null;

            return Ok(_mapper.Map<IEnumerable<ItemPedidoDTO>>(await _itemPedidoRepository.ObterTodos()));
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CadastraItemPedidoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}