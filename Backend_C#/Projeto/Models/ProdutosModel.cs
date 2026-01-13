using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Models
{

    [Table("products")] 
    public class ProdutosModel
    {
        [Key]
        [Column("id")] 
        public int Id { get; set; }

        [Column("productname")] 
        public string? ProductName { get; set; }

        [Column("productprice")]
        public double Productprice { get; set; }

        [Column("productcodbar")]
        public string? Productcodbar { get; set; }

        [Column("productsubgroup")]
        public string? Productsubgroup { get; set; }

        [Column("productgroup")]
        public string? Productgroup { get; set; }

        [Column("productstock")]
        public int Productstock { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        /// <summary>
        /// Valida dados importantes do produto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool ProductValidation(ProdutosModel product)
        {
            if (product.Productprice <0 || product.Productstock <=0)
            {
                return false;
            }
            //se não tiver código de barras, criamos um.

            if (product.Productcodbar == "")
            {
                product.Productcodbar = CreateCodbar();
            }
            return true;
        }   

        /// <summary>
        /// Cria o código de barras.
        /// </summary>
        /// <returns></returns>
        public string CreateCodbar()
        {
            // no futuro precisaremos validar se o código de barras já não existe e está em uso.
            Random random = new Random();
            return  random.Next(100000000,900000000).ToString();
        }
    }
}