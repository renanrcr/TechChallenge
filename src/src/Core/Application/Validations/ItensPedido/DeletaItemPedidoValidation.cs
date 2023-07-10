using TechChallenge.src.Core.Application.Validations.ItensPedido.Base;

namespace TechChallenge.src.Core.Application.Validations.ItensPedido
{
    public class DeletaItemPedidoValidation : ItemPedidoBaseValidation
    {
        public DeletaItemPedidoValidation()
        {
            ValidarDataExclusao();
        }
    }
}