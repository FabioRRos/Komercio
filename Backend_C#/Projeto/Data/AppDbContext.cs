using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        readonly string _url;

        public DbSet<ProdutosModel> products { get; set; }
        public DbSet<GrupoDeProduto> product_group{get;set;}
    }
}