using PizzaDelivery.Core.Models;
using PizzaDelivery.Repository.Interfaces;

namespace PizzaDelivery.Repository.Repositories
{
    public class LogErroRepository : ILogErroRepository
    {
        private readonly IMasterRepository _masterRepository;

        public LogErroRepository(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public async Task GravarLogErroAsync(LogErroModel logErro)
        {
            var query = @"INSERT INTO [dbo].[LogErro]
                                ([Descricao]
                                ,[Local]
                                ,[Data])
                          VALUES
                                (@Descricao,
                                 @Local,
                                 @Data)";

            await _masterRepository.InserirAsync(query, logErro);
        }
    }
}