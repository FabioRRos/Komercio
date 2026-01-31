using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
        [Table("product_subgroup")] 
    public class GrupoDeProduto
    {
        [Key]
        [Column("subgroup_id")]
        public int Subgroup_id { get; set; }
        [Column("subgroup_name")]
        public string? Subgroup_name { get; set; }
    }
}