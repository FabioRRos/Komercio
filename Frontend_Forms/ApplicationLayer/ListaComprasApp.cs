using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.ApplicationLayer
{
    public class ListaComprasApp
    {
        private readonly ProdutoApp _produtoApp;
        private readonly ItensListaCompraService _itensListaCompraService;
        private readonly ListaCompraService _listaCompraService;


        public ListaComprasApp(ProdutoApp produtoApp,
            ListaCompraService listaCompraService,
            ItensListaCompraService itensListaCompraService)
        {
            _produtoApp = produtoApp;
            _listaCompraService = listaCompraService;
            _itensListaCompraService = itensListaCompraService;
        }


        //Chamadas API LISTACOMPRA
        public async Task<ServiceResponse<ListaComprasDTO>> CriarListaComprasApp(ListaComprasDTO listaCompra)
        {
            ServiceResponse<ListaComprasDTO> serviceResponse = new ServiceResponse<ListaComprasDTO>();

            listaCompra.DataCriacaoLista = DateTimeOffset.Now;

            serviceResponse = ListaComprasDTO.ValidaLista(listaCompra);

            if (serviceResponse.Sucesso == false)
            {
                return serviceResponse;
            }

            serviceResponse = await _listaCompraService.CriarListaComprasService(serviceResponse.Dados);


            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ListaComprasDTO>>> BuscarListasDeCompra()
        {
            return await _listaCompraService.BuscarTodasAsListas();

        }



        // CHAMADAS API ITENS LISTA COMPRAS
        public async Task<ServiceResponse<List<ItemListaCompraDTO>>> BuscarItensListaDeComprasById(int id)
        {
            var serviceResponse = new ServiceResponse<List<ItemListaCompraDTO>>();
            if (id <= 0)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Id invalido";
                return serviceResponse;
            }

            serviceResponse = await _itensListaCompraService.ListarItensDaCompraPorId(id);

            return serviceResponse;
        }



        // CHAMA PRODUTOS

        public async Task<List<ProductDTO>>BuscarProdutos()
        {
            var listaProduto = new List<ProductDTO>();

            (listaProduto,_) = await _produtoApp.BuscaListaDeProdutoEGrupo();


            return listaProduto;
        }
    }
}
