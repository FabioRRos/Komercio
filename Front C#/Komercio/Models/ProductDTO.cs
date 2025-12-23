using Komercio.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Komercio.Models
{
    public class ProductDTO
    {
        [JsonProperty("id")]
        public int idProduct { get; set; }

        [JsonProperty("product_name")]
        public string productName { get; set; }

        [JsonProperty("product_price")]
        public float productPrice { get; set; }

        [JsonProperty("product_codbar")]
        public string productCodbar { get; set; }

        [JsonProperty("product_group")]
        public string productGroup { get; set; }

        [JsonProperty("product_subgroup")]
        public string productSubgroup { get; set; }

        [JsonProperty("product_stock")]
        public int productStock { get; set; }

        [JsonProperty("product_status")]
        public bool productStatus { get; set; }

        //VALIDA PRODUTO (pode ser usado sempre).
        public ProductDTO ValidaProduto(string name, string preco, string codBarras, string grupo, string subGrupo, string stock)
        {
            var product = new ProductDTO();
            if (name == "")
            {
                throw new ArgumentException("É necessário dizer a descrição do produto!!");
            }

            product.productName = name;
            try
            {
                // verifica se o valor do produto é valido (maior ou igual a zero).
                product.productPrice = float.Parse(preco.Replace("R$", ""));
                if (product.productPrice <= 0)
                {
                    throw new ArgumentException("Preço inválido!");
                }
            }
            catch
            {
                throw new ArgumentException("Preço inválido!", "Atenção");

            }
            product.productCodbar = codBarras;
            product.productGroup = grupo;
            product.productSubgroup = subGrupo;

            try
            {
                product.productStock = int.Parse(stock);

                if (product.productStock < 0)
                {
                    throw new ArgumentException("Quantidade inválida!");
                }
            }
            catch
            {
                throw new ArgumentException("Quantidade inválida!");
            }

           

            return product;
        }

        // Pega um arquivo e transforma em uma lista de produto e uma lista de erro.
        public (List<ProductDTO>, List<string>) FileImport(string filename)
        {
            List<ProductDTO> ProductList = new List<ProductDTO>();
            List<string> errorImput = new List<string>();
            string[] rows = File.ReadAllLines(filename);

            for (int i = 0; i < rows.Length; i++)
            {
                string[] campos = rows[i].Split(';');
                try
                {
                    ProductDTO Product = new ProductDTO
                    {
                        productName = campos[0],
                        productPrice = float.Parse(campos[1]),
                        productCodbar = campos[2],
                        productGroup = campos[3],
                        productSubgroup = campos[4],
                        productStock = int.Parse(campos[5]),
                        productStatus = true
                    };
                    ProductList.Add(Product);
                }
                catch
                {
                    errorImput.Add(rows[i]);
                    continue;
                }

            }
            return (ProductList, errorImput);
        }
        





        public string NormalizeValores(string valor)
        {
            return string.Empty;
        }
    }
}
