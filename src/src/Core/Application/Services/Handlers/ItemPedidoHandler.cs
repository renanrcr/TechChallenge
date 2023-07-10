using AutoMapper;
using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Application.Services;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.ItensPedido;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Handlers
{
    public class ItemPedidoHandler : BaseService, 
        IRequestHandler<CadastraItemPedidoCommand, ItemPedidoDTO>,
        IRequestHandler<AtualizaItemPedidoCommand, ItemPedidoDTO>,
        IRequestHandler<DeletaItemPedidoCommand, ItemPedidoDTO>
    {
        private readonly IMapper _mapper;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoHandler(INotificador notificador, 
            IItemPedidoRepository itemPedidoRepository,
            IMapper mapper)
            : base(notificador)
        {
            _itemPedidoRepository = itemPedidoRepository;
            _mapper = mapper;
        }

        public async Task<ItemPedidoDTO> Handle(CadastraItemPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new ItemPedido().Cadastrar(request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _itemPedidoRepository.Adicionar(entidade);

            return _mapper.Map<ItemPedidoDTO>(entidade);
        }

        public async Task<ItemPedidoDTO> Handle(AtualizaItemPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new ItemPedido().Atualizar(request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _itemPedidoRepository.Atualizar(entidade);

            return _mapper.Map<ItemPedidoDTO>(entidade);
        }

        public async Task<ItemPedidoDTO> Handle(DeletaItemPedidoCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new ItemPedido().Deletar(request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _itemPedidoRepository.Atualizar(entidade);

            return _mapper.Map<ItemPedidoDTO>(entidade);
        }
    }
}