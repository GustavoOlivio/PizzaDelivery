using PizzaDelivery.Core.Models;

namespace PizzaDelivery.Repository.Interfaces.Pedidos
{
    public interface IPedidoRepository
    {
        Task<int> CriarPedidoAsync(PedidoModel pedido);
        Task AtualizarPedidoAsync(PedidoModel pedido);
        Task ExcluirPedidoAsync(int pedidoId);
        Task<IEnumerable<PedidoModel>> ObterPedidosAsync(string filtroStatus, int statusPedido);
        Task<PedidoModel> ObterPedidoAsync(int pedidoId);
    }
}