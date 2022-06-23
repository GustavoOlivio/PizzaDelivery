using System.ComponentModel.DataAnnotations;

namespace PizzaDelivery.Core.Models
{
    public class LogErroModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string StackTrace { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
    }
}