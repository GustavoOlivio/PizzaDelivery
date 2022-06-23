using PizzaDelivery.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Core.Models
{
    public class PedidoModel
    {
        [Key]
        [Display(Name = "Código Pedido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do cliente obrigatório!")]
        [Display(Name = "Nome do Cliente")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Nome deve ter no mínimo 10 caracteres, e no máximo 100.")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "E-Mail obrigatório!")]
        //[RegularExpression(@"/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i", ErrorMessage = "E-Mail em formato inválido!")]
        [StringLength(100, ErrorMessage = "O tamanho máximo de caracteres é 100.")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [Required(ErrorMessage = "A descrição do pedido é obrigatória!")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descrição de Pedido")]
        public string Pedido { get; set; }

        [Display(Name = "Valor do Pedido")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Status do pedido é obrigatório!")]
        [Display(Name = "Status do Pedido")]
        public StatusPedido Status { get; set; }
    }
}