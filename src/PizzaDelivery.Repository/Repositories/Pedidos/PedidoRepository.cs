using PizzaDelivery.Core.Models;
using PizzaDelivery.Repository.Interfaces;
using PizzaDelivery.Repository.Interfaces.Pedidos;

namespace PizzaDelivery.Repository.Repositories.Pedidos
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IMasterRepository _masterRepository;

        public PedidoRepository(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public async Task<int> CriarPedidoAsync(PedidoModel pedido)
        {
            var query = @"INSERT INTO [dbo].[Pedido]
                                ([NomeCliente]
                                ,[EMail]
                                ,[Pedido]
                                ,[Valor]
                                ,[Status])
                          VALUES
                                (@NomeCliente,
                                 @EMail,
                                 @Pedido,
                                 @Valor,
                                 @Status)
                          SELECT SCOPE_IDENTITY()";

            return await _masterRepository.InserirAsync(query, pedido);
        }

        public async Task AtualizarPedidoAsync(PedidoModel pedido)
        {
            var query = @"UPDATE [dbo].[Pedido]
                          SET [NomeCliente] = @NomeCliente,
                                [EMail] = @EMail,
                                [Pedido] = @Pedido,
                                [Valor] = @Valor,
                                [Status] = @Status
                          WHERE [Id] = @Id";

            await _masterRepository.UpdateOrDeleteAsync(query, pedido);
        }
        
        public async Task ExcluirPedidoAsync(int pedidoId)
        {
            var query = "DELETE dbo.[Pedido] WHERE Id = @pedidoId";

            await _masterRepository.UpdateOrDeleteAsync(query, new { pedidoId });
        }

        public async Task<IEnumerable<PedidoModel>> ObterPedidosAsync(string filtroStatus, int statusPedido)
        {
            var query = @$"SELECT * FROM dbo.[Pedido]
                            {filtroStatus}
                                ORDER BY 1 DESC";

            return await _masterRepository.ObterListaAsync<PedidoModel>(query, new { statusPedido });
        }

        public async Task<PedidoModel> ObterPedidoAsync(int pedidoId)
        {
            var query = @"SELECT * FROM dbo.[Pedido]
                              WHERE [Id] = @pedidoId";

            return await _masterRepository.ObterUnicoResultadoAsync<PedidoModel>(query, new { pedidoId });
        }
    }
}