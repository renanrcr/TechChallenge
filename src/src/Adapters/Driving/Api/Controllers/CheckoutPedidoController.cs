using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.src.Adapters.Driving.Api.Controllers.Base;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands;

namespace TechChallenge.src.Adapters.Driving.Api.Controllers
{
    public class CheckoutPedidoController : BaseController
    {
        private readonly IMediator _mediator;

        public CheckoutPedidoController(INotificador notificador,
            IMediator mediator)
            : base(notificador)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult?> Post(CheckoutPedidoCommand command)
        {
            if (!ModelState.IsValid) return null;

            var entidade = await _mediator.Send(command);

            if (!IsOperacaoValida) return BadRequest(ObterNotificacoes());

            return Ok(entidade);
        }
    }
}