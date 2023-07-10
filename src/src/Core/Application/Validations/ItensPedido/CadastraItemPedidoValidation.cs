using TechChallenge.src.Core.Application.Validations.ItensPedido.Base;

namespace TechChallenge.src.Core.Application.Validations.ItensPedido
{
    public class CadastraItemPedidoValidation : ItemPedidoBaseValidation
    {
        public CadastraItemPedidoValidation()
        {
            ValidarDataCadastro();
        }
    }
}