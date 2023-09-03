using AutoMapper;
using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.IdentificacoesPedido;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Application.Services.Handlers
{
    public class IdentificacaoPedidoHandler : BaseService,
        IRequestHandler<CadastraIdentificacaoPedidoCommand, IdentificacaoDTO>
    {
        private readonly IIdentificacaoPedidoRepository _identificacaoPedidoRepository;
        private readonly IMapper _mapper;

        public IdentificacaoPedidoHandler(INotificador notificador,
            IIdentificacaoPedidoRepository identificacaoPedidoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _identificacaoPedidoRepository = identificacaoPedidoRepository;
            _mapper = mapper;
        }

        public async Task<IdentificacaoDTO> Handle(CadastraIdentificacaoPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new IdentificacaoPedido().Cadastrar(_identificacaoPedidoRepository, request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _identificacaoPedidoRepository.Adicionar(entidade);

            return _mapper.Map<IdentificacaoDTO>(entidade);
        }
    }
}