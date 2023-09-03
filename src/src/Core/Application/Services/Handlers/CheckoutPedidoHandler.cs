using AutoMapper;
using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands;
using TechChallenge.src.Core.Domain.Commands.IdentificacoesPedido;
using TechChallenge.src.Core.Domain.Commands.ItensPedido;
using TechChallenge.src.Core.Domain.Commands.Pedidos;

namespace TechChallenge.src.Core.Application.Services.Handlers
{
    public class CheckoutPedidoHandler : BaseService,
        IRequestHandler<CheckoutPedidoCommand, CheckoutPedidoDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly INotificador _notificador;

        public CheckoutPedidoHandler(INotificador notificador
            , IMapper mapper
            , IMediator mediator)
            : base(notificador)
        {
            _mapper = mapper;
            _mediator = mediator;
            _notificador = notificador;
        }

        public async Task<CheckoutPedidoDTO> Handle(CheckoutPedidoCommand request, CancellationToken cancellationToken)
        {
            var checkoutPedido = new CheckoutPedidoDTO();

            var identificacaoPedido = await CadastraIdentificacaoCliente(request.TipodIdentificacaoCliente, request.IdentificacaoCliente);

            if (!_notificador.TemNotificacao())
            {
                var retornoPedido = await CadastraPedido(identificacaoPedido.Id);

                if (!_notificador.TemNotificacao())
                {
                    await AdicionarItens(retornoPedido.IdentificacaoPedidoId, request.ItensPedido);

                    if (!_notificador.TemNotificacao())
                        checkoutPedido.Pedido = retornoPedido;
                }
            }

            return _mapper.Map<CheckoutPedidoDTO>(checkoutPedido);
        }

        private async Task<IdentificacaoDTO> CadastraIdentificacaoCliente(int tipoIdentificacaoCliente, string? valor)
        {
            var commandIdentificacao = new CadastraIdentificacaoPedidoCommand
            {
                TipodIdentificacaoPedido = tipoIdentificacaoCliente,
                Valor = valor,
            };

            var retornoIdentificacao = await _mediator.Send(commandIdentificacao);

            return retornoIdentificacao;
        }

        private async Task<PedidoDTO> CadastraPedido(Guid idIdentificacaoPedido)
        {
            var commandPedido = new CadastraPedidoCommand { IdentificacaoClienteId = idIdentificacaoPedido, };

            var retornoPedido = await _mediator.Send(commandPedido);

            return retornoPedido;
        }

        private Task AdicionarItens(Guid identificacaoPedidoId, IList<ItemPedidoDTO>? ItensPedido)
        {
            return Task.Factory.StartNew(() =>
            {
                ItensPedido?.ToList()
                            .ForEach(async x =>
                            {
                                var commmandItemPedido = new CadastraItemPedidoCommand
                                {
                                    PedidoId = identificacaoPedidoId,
                                    ProdutoId = x.ProdutoId,
                                    Quantidade = x.Quantidade,
                                };

                                await _mediator.Send(commmandItemPedido);
                            });
            });
        }
    }
}