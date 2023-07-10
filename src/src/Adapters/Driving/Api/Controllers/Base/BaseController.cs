using Microsoft.AspNetCore.Mvc;
using TechChallenge.src.Core.Application.Notificacoes;
using TechChallenge.src.Core.Domain.Adapters;

namespace TechChallenge.src.Adapters.Driving.Api.Controllers.Base
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool IsOperacaoValida => !_notificador.TemNotificacao();

        protected List<Notificacao> ObterNotificacoes() => _notificador.ObterNotificacoes();
    }
}