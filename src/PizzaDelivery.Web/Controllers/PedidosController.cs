using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Core.Models;
using PizzaDelivery.Services.Pedidos.Interfaces;

namespace PizzaDelivery.Web.Controllers
{
    [Route("pedidos")]
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }

        [Route("criar")]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View());
        }

        [Route("criarpedido")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoModel pedidoModel)
        {
            if (ModelState.IsValid)
            {
                await _pedidoService.CriarPedidoAsync(pedidoModel);

                return RedirectToAction(nameof(List));
            }

            return View(pedidoModel);
        }

        [Route("listar")]
        public async Task<IActionResult> List(int statusPedido)
        {
            var listaPedidos = await _pedidoService.ObterPedidosAsync(statusPedido);

            return View(listaPedidos);
        }

        [Route("editar/{pedidoId}")]
        public async Task<IActionResult> Edit(int pedidoId)
        {
            var pedido = await _pedidoService.ObterPedidoAsync(pedidoId);

            return View(pedido);
        }

        [Route("atualizar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PedidoModel pedidoModel)
        {
            if (ModelState.IsValid)
            {
                await _pedidoService.AtualizarPedidoAsync(pedidoModel);

                return RedirectToAction(nameof(List));
            }

            return View(pedidoModel);
        }

        [Route("excluir/{pedidoId}")]
        public async Task<IActionResult> Delete(int pedidoId)
        {
            var pedido = await _pedidoService.ObterPedidoAsync(pedidoId);

            return View(pedido);
        }

        [Route("excluirpedido/{pedidoId}")]
        public async Task<IActionResult> ConfirmDelete(int pedidoId)
        {
            await _pedidoService.ExcluirPedidoAsync(pedidoId);

            return RedirectToAction(nameof(List));
        }
    }
}