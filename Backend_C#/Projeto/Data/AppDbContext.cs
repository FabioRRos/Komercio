using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Data
{
    public class AppDbContext :DbContext
    {
        string _url;

        public AppDbContext(DbContextOptions options): base(options){}
        public DbSet<ProdutosModel> products { get; set; }
    }
}