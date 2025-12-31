using Komercio.Models;
using Komercio.Services;
using Komercio.UI.Forms.Product.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.ApplicationLayer
{
    public class ProdutoApp
    {
        //Injeção das dependências.
        private readonly ProductService _productService;
        private readonly ProductDescriptionService _productDescriptionService;
        private readonly ProductSubgroupService _productSubgroupService;
        private readonly ProductGroupService _productGroupService;
        
        private readonly EmployeeServiceApp _employeesServiceApp;

        // Variáveis utilizadas na classe.
        internal ProductDTO _productDTO = new ProductDTO();

        // Lista utilizadas na classe.

        public ProdutoApp(ProductService productService, ProductDescriptionService productAndGroupAndSubgroup, ProductSubgroupService productSubgroupService, ProductGroupService productGroupService, EmployeeServiceApp employeesServiceApp)
        {
            _productSubgroupService = productSubgroupService;
            _productGroupService = productGroupService;
            _productService = productService;
            _productDescriptionService = productAndGroupAndSubgroup;

            _employeesServiceApp = employeesServiceApp;
        }

        //POST de produto (salva eles)
        public async Task<bool> CadastrarProduto(ProductDTO product)
        {
            var returnSatus = await _productService.CreateProductAsync(product);

            return returnSatus;
        }
        // AQUI ELE BUSCA PRODUTO, GRUPO E SUBGRUPO EM UMA TACADA SÓ. É ÚTIL AS VEZES.
        public async Task<ProductDescriptionDTO> Description()
        {
            var response = await _productDescriptionService.GetProductDescriptionAsync();

            var description = new ProductDescriptionDTO();

            description.Product = response.Product;
            description.Group = response.Group.OrderBy(p => p.ProductgroupName).ToList();
            description.Subgroup = response.Subgroup.OrderBy(p => p.ProductsubgroupName).ToList();

            return description;
        }

        // AQUI EU FAÇO O GET DO PRODUTO PELO CODIGO DE BARRAS.

        public async Task<ProductDTO> BuscarProdutoPorCodigoDeBarras(string CodBar)
        {
            return await _productService.GetProductByCodbad(CodBar);
        }

        // AQUI SERÁ O PUT PARA REALIZAR ALTERAÇÃO DO PRODUTO

        public async Task<bool> AlterarProduto(ProductDTO produto)
        {
            return await _productService.PutProductAtt(produto);
        }

        // put de produtos no estoque
        public async Task<ProductDTO> EntradaEstoqueCodigoDeBarras(string codBarras, int quantidade)
        {
            return await _productService.PutProductInStock(codBarras, quantidade);
        }


        // abre o arquivo no diretório que recebo e retorno a lista de produtos que estavam com a formatação correta + a quantidade de itens que deram erro.

        public (List<ProductDTO>, int erros) BuscarEAbrirArquivo(string caminhoArquivo)
        {

            var (productList, errorProductList) = _productDTO.FileImport(caminhoArquivo);
            int erros = errorProductList.Count;
            return (productList, erros);
        }

        //Aqui eu faço a importação da lista item a item
        //Como já fiz a validação dos campos e do layout, eu garanto que se der erro sera uma excessão.
        public async Task<int> CadastrarProdutosEmLote(List<ProductDTO> productDTO)
        {
            var error = 0;

            foreach (var product in productDTO)
            {
                try
                {
                    await _productService.CreateProductAsync(product);
                }
                catch
                {
                    error++;
                }

            }
            return error;
        }


        // o mesmo de cima mas com progress bar

        public async Task<int> CadastrarProdutosEmLotePB(List<ProductDTO> productDTO,IProgress<int> progress)
        {
            var error = 0;
            var processados = 0;

            foreach (var product in productDTO)
            {
                try
                {
                    await _productService.CreateProductAsync(product);
                }
                catch (Exception)
                {
                    error++;
                    // possível log futuro, preciso pensar sobre
                }

                processados++;

                if (progress != null)
                    progress.Report(processados);
            }

            return error;
        }






        //busca casada de lista de produtos e lista de grupo.
        public async Task<(List<ProductDTO>, List<ProductgroupDTO>)> BuscaListaDeProdutoEGrupo()
        {
            var product = await _productService.GetProductInStockAsync();
            var productGroup = await _productGroupService.GetProductGroupAsync();

            return (product, productGroup);
        }

        //sempre que precisar realizar um filtro por nome do produto, é esse carinha aqui
        public List<ProductDTO> FiltroDeProdutos(List<ProductDTO> product,string valor)
        {
            List<ProductDTO> list = new List<ProductDTO>();

            foreach (var prod in product)
            {
                bool encontrou =
            prod.productGroup != null &&
            valor != null &&
            prod.productGroup.IndexOf(
                valor,
                StringComparison.OrdinalIgnoreCase) >= 0;

                if (encontrou)
                {
                    list.Add(prod);
                }
                else
                {
                    continue;
                }
            }

            return list;
        }


        //get para notificação de baixa do produto
        public async Task<List<ProductNotificationSettingsDTO>> ListaDeProdutosParaNotificacao()
        {
            var productList = await _productService.GetProductNotificationSettingAsync();
            productList = productList.OrderBy(p => p.Productname).ToList();
            return productList;
        }

        //put para notificação de baixa do produto

        public async Task<bool> AtualizarListaDeProdutosParaNotificacao(List<ProductNotificationSettingsDTO> productListChenged)
        {
            return await _productService.PutProductNotification(productListChenged);
        }

        //Sempre que quiser descartar um produto, utiliar esse cara
        public Task<bool> AtualizaStatusDoProdutoEmDescarte(DescarteProdutoDTO descarteProdutoDTO)
        {
            return _productService.PutDescarteProduto(descarteProdutoDTO);
        }

        // get da lista de grupos de produtos
        public async Task<List<ProductgroupDTO>> GetListaDeGrupoDeProduto()
        {
            var productGroups =  await _productGroupService.GetProductGroupAsync();
            productGroups = productGroups
            .OrderBy(p => p.ProductgroupName)
            .ToList();
            return productGroups;
        }


        // get da lista de subgrupos de produtos
        public async Task<List<ProductSubgroupDTO>> GetListaDeSubGrupoDeProduto()
        {

            var productSubGroups =  await _productSubgroupService.GetProductSubgroupAsync();
            productSubGroups = productSubGroups
            .OrderBy(p => p.ProductsubgroupName)
            .ToList();
            return productSubGroups;
        }


        //Cadastro grupo de produto
        public async Task<bool>CadastrarGrupoDeProduto(ProductgroupDTO productGroup)
        {
            return await _productGroupService.CreateGroup(productGroup);
        }

        // cadastro subgrupo de produto
        public async Task<bool> SalvarSubGrupo(ProductSubgroupDTO ProductDTOSave)
        {
            return await _productSubgroupService.CreateSubGroup(ProductDTOSave);
        }
    }




}
