using PizzaDelivery.Core.Models;
using PizzaDelivery.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace PizzaDelivery.Services.Services
{
    public class BaseService : IBaseService
    {
        private readonly ILogErroService _logErroService;

        public BaseService(ILogErroService logErroService)
        {
            _logErroService = logErroService;
        }

        public async Task<Exception> GravarLogErroERetornarExcecaoAsync(string mensagem, Exception exception, [CallerMemberName] string metodo = null)
        {
            await _logErroService.GravarLogErroAsync(mensagem, exception, metodo);

            throw new Exception(mensagem);
        }
    }
}