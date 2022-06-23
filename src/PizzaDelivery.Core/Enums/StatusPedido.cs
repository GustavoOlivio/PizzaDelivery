using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Core.Enums
{
    public enum StatusPedido
    {
        [Display(Name = "Em Andamento")]
        EmAndamento = 1,

        [Display(Name = "Pronto")]
        Pronto = 2
    }
}