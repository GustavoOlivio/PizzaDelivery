using PizzaDelivery.Core.Models;

namespace PizzaDelivery.Services.Pedidos.Interfaces
{
    public interface IPedidoService
    {
        Task<bool> CriarPedidoAsync(PedidoModel pedido);
        Task AtualizarPedidoAsync(PedidoModel pedido);
        Task ExcluirPedidoAsync(int pedidoId);
        Task<IEnumerable<PedidoModel>> ObterPedidosAsync(int statusPedido = 0);
        Task<PedidoModel> ObterPedidoAsync(int pedidoId);
    }
}