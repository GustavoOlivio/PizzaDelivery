using System.Runtime.CompilerServices;

namespace PizzaDelivery.Services.Interfaces
{
    public interface IBaseService
    {
        Task<Exception> GravarLogErroERetornarExcecaoAsync(string mensagem, Exception exception, [CallerMemberName] string metodo = null);
    }
}