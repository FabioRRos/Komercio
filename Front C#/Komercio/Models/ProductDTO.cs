using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

//################################

    }


}
