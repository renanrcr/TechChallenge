using TechChallenge.src.Core.Application.Notificacoes;

namespace TechChallenge.src.Core.Domain.Adapters
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}