using PizzaDelivery.Core.Models;

namespace PizzaDelivery.Repository.Interfaces
{
    public interface ILogErroRepository
    {
        Task GravarLogErroAsync(LogErroModel logErro);
    }
}