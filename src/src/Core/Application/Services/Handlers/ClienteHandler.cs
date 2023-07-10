using AutoMapper;
using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Application.Services;
using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Commands.Clientes;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Handlers
{
    public class ClienteHandler : BaseService, 
        IRequestHandler<CadastraClienteCommand, ClienteDTO>
    {
        private IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteHandler(INotificador notificador,
            IClienteRepository clienteRepository,
            IMapper mapper)
            : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Handle(CadastraClienteCommand request, CancellationToken cancellationToken)
        {
            var entidade = await new Cliente().Cadastrar(request);

            Notificar(entidade.ValidationResult);

            if (entidade.IsValid)
                await _clienteRepository.Adicionar(entidade);

            return _mapper.Map<ClienteDTO>(entidade);
        }
    }
}