using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaDelivery.Core.Enums;
using PizzaDelivery.Core.Models;
using PizzaDelivery.Services.Pedidos.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;

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

        public ActionResult Index()
        {
            return View();
        }

        [Route("criar")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("create")]
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
            var pedido = await _pedidoService.ObterPedido(pedidoId);

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
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Route("excluirpedido")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int pedidoId)
        {
            await _pedidoService.ObterPedido(pedidoId);

            return RedirectToAction(nameof(List));
        }
    }
}