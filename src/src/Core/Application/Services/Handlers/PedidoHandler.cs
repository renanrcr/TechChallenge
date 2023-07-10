using AutoMapper;
using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Application.Services;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.Pedidos;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Handlers
{
    public class PedidoHandler : BaseService, 
        IRequestHandler<CadastraPedidoCommand, PedidoDTO>,
        IRequestHandler<AtualizaPedidoCommand, PedidoDTO>,
        IRequestHandler<DeletaPedidoCommand, PedidoDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoHandler(INotificador notificador, 
            IPedidoRepository pedidoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<PedidoDTO> Handle(CadastraPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Pedido().Cadastrar(request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _pedidoRepository.Adicionar(entidade);

            return _mapper.Map<PedidoDTO>(entidade);
        }

        public async Task<PedidoDTO> Handle(AtualizaPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Pedido().Atualizar(request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _pedidoRepository.Atualizar(entidade);

            return _mapper.Map<PedidoDTO>(entidade);
        }

        public async Task<PedidoDTO> Handle(DeletaPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Pedido().Deletar(request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _pedidoRepository.Atualizar(entidade);

            return _mapper.Map<PedidoDTO>(entidade);
        }
    }
}