using FluentValidation;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Entities;
using TechChallenge.src.Core.Domain.Enums;

namespace TechChallenge.src.Core.Application.Validations.IdentificacoesPedido
{
    public class CadastraIdentificacaoPedidoValidation : ValidationBase<IdentificacaoPedido>
    {
        private IIdentificacaoPedidoRepository _identificacaoPedidoRepository;

        public CadastraIdentificacaoPedidoValidation(IIdentificacaoPedidoRepository identificacaoPedidoRepository)
        {
            _identificacaoPedidoRepository = identificacaoPedidoRepository;

            ValidarId();
            ValidarValor();
            ValidarExisteIdentificacaoCadastrada();
            ValidarDataCadastro();
        }

        public void ValidarValor()
        {
            RuleFor(x => x.TipoIdentificacaoPedido).NotEqual(ETipoIdentificacaoPedido.NAO_IDENTIFICADO)
                .DependentRules(() =>
                {
                    RuleFor(x => x.Valor).NotNull().NotEmpty().WithMessage("Informe um valor.");
                });
        }

        public void ValidarExisteIdentificacaoCadastrada()
        {
            RuleFor(s => s.Valor)
                .MustAsync(ExisteIdentificacaoAsync).WithMessage("Identificação já cadastrada em nossa base de dados.");
        }

        private async Task<bool> ExisteIdentificacaoAsync(string? valor, CancellationToken token)
        {
            return !(await _identificacaoPedidoRepository.Existe(x => !string.IsNullOrEmpty(valor) && x.Valor == valor));
        }
    }
}