using Komercio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.Services
{
   
    public class SaleService
    {
        //Lista de produtos para controlar o que está em estoque ou não

        public ProductDTO tempProduct = new ProductDTO();

        public BindingList<SalesItensDTO> _productCar = new BindingList<SalesItensDTO>();

        //LISTA DE PRODUTOS EM ESTOQUE. AQUI POSSO MANIPULAR O ESTOQUE QUANDO FOR PRO CARRINHO.
        public List<ProductDTO> listaDeprodutosPraUtilizarNoForm = new List<ProductDTO>();


        // dicionário para não perder tempo com foreach
        private Dictionary<string, ProductDTO> produtosPorCodigo = new Dictionary<string, ProductDTO>();

        private float some = 0;

        public async Task loaddbListaproduto(ProductService productService)
        {
            listaDeprodutosPraUtilizarNoForm = await productService.GetProductInStockAsync();

            for (int i = 0; i < listaDeprodutosPraUtilizarNoForm.Count - 1; i++)
            {
                for (int j = i + 1; j < listaDeprodutosPraUtilizarNoForm.Count; j++)
                {
                    if (string.Compare(listaDeprodutosPraUtilizarNoForm[i].productName,
                                       listaDeprodutosPraUtilizarNoForm[j].productName,
                                       StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        var temp = listaDeprodutosPraUtilizarNoForm[i];
                        listaDeprodutosPraUtilizarNoForm[i] = listaDeprodutosPraUtilizarNoForm[j];
                        listaDeprodutosPraUtilizarNoForm[j] = temp;
                    }
                }
            }

            // peenche o dicionário
            produtosPorCodigo.Clear();
            foreach (ProductDTO produto in listaDeprodutosPraUtilizarNoForm)
            {
                if (!produtosPorCodigo.ContainsKey(produto.productCodbar))
                {
                    produtosPorCodigo.Add(produto.productCodbar, produto);
                }
            }
        }



        public ProductDTO buscaprodutonalista(string cod)
        {
            /*foreach (ProductDTO product in listaDeprodutosPraUtilizarNoForm)
            {
                if (product.productCodbar.Contains(cod))
                {
                    return product;
                }

            }
            
            return null;*/


            ProductDTO produtoEncontrado = null;

            if (produtosPorCodigo.ContainsKey(cod))
            {
                produtoEncontrado = produtosPorCodigo[cod];
            }

            return produtoEncontrado;

        }

        public void CarUpdateInput(SalesItensDTO sale)
        {

            _productCar.Add(sale);

            /*
            foreach (ProductDTO product in listaDeprodutosPraUtilizarNoForm)
            {
                if (product.productCodbar.Contains(sale.Barcode))
                {
                    product.productStock -= sale.Quantity;
                }
            }*/


            ProductDTO produto = buscaprodutonalista(sale.Barcode);
            if (produto != null)
            {
                produto.productStock = produto.productStock - sale.Quantity;
                some += sale.UnitPrice * sale.Quantity;
            }
        }

        public bool RemoveItemCar(string codbar)
        {
            SalesItensDTO item = null;

            foreach (SalesItensDTO p in _productCar)
            {
                if (p.Barcode == codbar)
                {
                    item = p;
                    break;
                }
            }

            if (item != null)
            {
                ProductDTO produto = buscaprodutonalista(codbar);
                if (produto != null)
                {
                    produto.productStock += item.Quantity;
                }

                _productCar.Remove(item);

                some -= item.UnitPrice*item.Quantity ;
                return true;

            }

            return false;
        }


        public float SomeAllItens()
        {
            return some;
        }



        public BindingList<SalesItensDTO> ReturnDTO()
        {
            return _productCar;
        }

    }
}
