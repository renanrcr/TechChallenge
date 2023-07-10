using AutoMapper;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Domain.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<CategoriaProdutoDTO, CategoriaProduto>().ReverseMap();
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
            CreateMap<IdentificacaoDTO, IdentificacaoPedido>().ReverseMap();
            CreateMap<PedidoDTO, Pedido>().ReverseMap();
            CreateMap<ItemPedidoDTO, ItemPedido>().ReverseMap();
        }
    }
}