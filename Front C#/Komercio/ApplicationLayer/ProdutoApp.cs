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

        // Variáveis utilizadas na classe.


        // Lista utilizadas na classe.

        public ProdutoApp(ProductService productService, ProductDescriptionService productAndGroupAndSubgroup, ProductSubgroupService productSubgroupService, ProductGroupService productGroupService)
        {
            _productSubgroupService = productSubgroupService;
            _productGroupService = productGroupService;
            _productService = productService;
            _productDescriptionService = productAndGroupAndSubgroup;
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
    }
}
