using PizzaDelivery.Core.Models;
using PizzaDelivery.Repository.Interfaces;
using PizzaDelivery.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace PizzaDelivery.Services.Services
{
    public class LogErroService : ILogErroService
    {
        private readonly ILogErroRepository _logErroRepository;

        public LogErroService(ILogErroRepository logErroRepository)
        {
            _logErroRepository = logErroRepository;
        }

        public async Task GravarLogErroAsync(string mensagem, Exception exception, string metodo)
        {
            var logErro = new LogErroModel
            {
                Data = DateTime.Now,
                Descricao = mensagem,
                StackTrace = exception.StackTrace,
                Local = metodo
            };

            await _logErroRepository.GravarLogErroAsync(logErro);
        }
    }
}