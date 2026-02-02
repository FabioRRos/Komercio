using Komercio.Services;
using Komercio.ViewModels;
using Komercio.Models.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Komercio.Presenters
{
    public class ListaCompraPresenter
    {
        private readonly IListaDeCompraService _service;
        public ListaCompraViewModel ViewModel { get; private set; }

        public ListaCompraPresenter(IListaDeCompraService service)
        {
            _service = service;
            ViewModel = new ListaCompraViewModel();
        }

        public async Task CarregarPagina(int? idSelecionado)
        {
            var listas = await _service.ListaDeComprasAtivaService();
            ViewModel.ListasParaAbas = listas;

            int idParaCarregar = 0;

            if (idSelecionado.HasValue && idSelecionado.Value > 0)
            {
                idParaCarregar = idSelecionado.Value;
            }
            else if (listas != null && listas.Any())
            {
                idParaCarregar = listas.First().IdListaCompra;
            }

            if (idParaCarregar > 0)
            {
                ViewModel.IdListaAtiva = idParaCarregar;
                ViewModel.ItensParaGrid = await _service.ItrensDaListaDeCompraService(idParaCarregar);

                // --- NOVIDADE AQUI ---
                // Localiza a lista atual dentro da coleção para pegar o status que veio do Go
                var listaAtual = listas.FirstOrDefault(x => x.IdListaCompra == idParaCarregar);
                if (listaAtual != null)
                {
                    // Se listaAtual.status_lista for null no banco, 
                    // a ViewModel deve receber null aqui.
                    ViewModel.CarregarStatusInicial(listaAtual.StatusLista);
                    ViewModel.NomeListaSelecionada = listaAtual.NomeDaLista;

                }
                ViewModel.CarregarStatusInicial(listaAtual.StatusLista);
                }
        }


        

        /// <summary>
        /// Método chamado pelo clique do botão Salvar na View
        /// </summary>
        public async Task<bool> SalvarAlteracaoStatus()
        {

            if (!ViewModel.PodeSalvar) return false;


            // Criamos o DTO para envio. Como você prefere snake_case no Go, 
            // garantimos que o objeto enviado tenha os dados necessários.
            var dtoParaAtualizar = new ListaComprasDTO
            {
                IdListaCompra = ViewModel.IdListaAtiva,
                StatusLista = ViewModel.StatusLista
                
            };

            var resultado = await _service.AtualizarStatusDaLista(dtoParaAtualizar);

            if (resultado != null)
            {
                // Após salvar com sucesso, o novo status passa a ser o "original"
                ViewModel.CarregarStatusInicial(resultado.StatusLista);
                return true;
            }

            return false;
        }
    }
}