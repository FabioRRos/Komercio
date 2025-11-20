using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


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





    public (List<ProductDTO>, List<string>) FileImport(string filename)
        {
            List<ProductDTO> ProductList = new List<ProductDTO>();
            List<string> errorImput =new List<string>();
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

    }
}
