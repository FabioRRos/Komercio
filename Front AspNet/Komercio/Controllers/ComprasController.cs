using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Komercio.Services;
using Komercio.Presenters;
using System.Threading.Tasks;

namespace Komercio.Controllers
{
    public class ComprasController : Controller
    {
        private readonly IListaDeCompraService _listaService;

        public ComprasController(IListaDeCompraService listaService)
        {
            _listaService = listaService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            var presenter = new ListaCompraPresenter(_listaService);
            await presenter.CarregarPagina(id);
            return View("~/Views/Compras/ListaCompra.cshtml", presenter.ViewModel);
        }

        // ADICIONE ESTE MÉTODO ABAIXO:
        [Authorize]
        [HttpPost] // Resolve o erro 405
        [IgnoreAntiforgeryToken] // Evita erro 400 por falta de token no fetch
        public async Task<IActionResult> AtualizarStatus(int id, bool status)
        {
            var presenter = new ListaCompraPresenter(_listaService);

            // Sincroniza os dados na ViewModel do Presenter para o envio
            presenter.ViewModel.IdListaAtiva = id;
            presenter.ViewModel.StatusLista = status;

            // O Presenter agora chama o Service que faz o PUT no Go
            var sucesso = await presenter.SalvarAlteracaoStatus();

            if (sucesso)
            {
                return Ok(); // Retorna 200 para o fetch no JS
            }

            return BadRequest("Não foi possível atualizar o status no backend.");
        }
    }
}