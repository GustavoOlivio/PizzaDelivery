using System.Runtime.CompilerServices;

namespace PizzaDelivery.Services.Interfaces
{
    public interface ILogErroService
    {
        Task GravarLogErroAsync(string mensagem, Exception exception, string metodo);
    }
}