using TechChallenge.src.Core.Application.Validations.ItensPedido.Base;

namespace TechChallenge.src.Core.Application.Validations.ItensPedido
{
    public class AtualizaItemPedidoValidation : ItemPedidoBaseValidation
    {
        public AtualizaItemPedidoValidation()
        {
            ValidarDataAtualizacao();
        }
    }
}