using PizzaDelivery.Core.Models;
using PizzaDelivery.Repository.Interfaces.Pedidos;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.Services.Pedidos.Interfaces;

namespace PizzaDelivery.Services.Services.Pedidos
{
    public class PedidoService : IPedidoService
    {

        private readonly IPedidoRepository _pedidoRepository;
        private readonly IBaseService _baseService;

        public PedidoService(IPedidoRepository pedidoRepository, IBaseService baseService)
        {
            _pedidoRepository = pedidoRepository;
            _baseService = baseService;
        }

        public async Task<bool> CriarPedidoAsync(PedidoModel pedido)
        {
            try
            {
                var pedidoId = await _pedidoRepository.CriarPedidoAsync(pedido);

                return pedidoId > 0;
            }
            catch (Exception exception)
            {
                throw await _baseService.GravarLogErroERetornarExcecaoAsync("Erro ao criar pedido", exception);
            }
        }

        public async Task AtualizarPedidoAsync(PedidoModel pedido)
        {
            try
            {
                await _pedidoRepository.AtualizarPedidoAsync(pedido);
            }
            catch (Exception exception)
            {
                throw await _baseService.GravarLogErroERetornarExcecaoAsync("Erro ao atualizar o pedido", exception);
            }
        }
        
        public async Task ExcluirPedidoAsync(int pedidoId)
        {
            try
            {
                await _pedidoRepository.ExcluirPedidoAsync(pedidoId);
            }
            catch (Exception exception)
            {
                throw await _baseService.GravarLogErroERetornarExcecaoAsync("Erro ao excluir o pedido", exception);
            }
        }
        
        public async Task<IEnumerable<PedidoModel>> ObterPedidosAsync(int statusPedido = 0)
        {
            try
            {
                var filtroStatus = string.Empty;

                if (statusPedido is not 0)
                    filtroStatus = string.Concat("WHERE [Status] = @statusPedido");

                return await _pedidoRepository.ObterPedidosAsync(filtroStatus, statusPedido);
            }
            catch (Exception exception)
            {
                throw await _baseService.GravarLogErroERetornarExcecaoAsync("Erro ao obter lista de pedidos", exception);
            }
        }
        
        public async Task<PedidoModel> ObterPedido(int pedidoId)
        {
            try
            {
                return await _pedidoRepository.ObterPedidoAsync(pedidoId);
            }
            catch (Exception exception)
            {
                throw await _baseService.GravarLogErroERetornarExcecaoAsync("Erro ao obter detalhes do pedido", exception);
            }
        }
    }
}