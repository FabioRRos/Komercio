using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Repository
{
    
    public interface IProdutoRepository
    {   
        Task<IEnumerable<ProdutosModel>> BuscarProdutosAsyncRepository();
        Task<ProdutosModel?> BuscarProdutosByIdAsyncRepository(int id);
        Task<ProdutosModel> AddProdutoAsyncRepository(ProdutosModel produto);
        Task<ProdutosModel?> AlterarProdutoAsyncRepository(ProdutosModel produto, int id);
        Task<ProdutosModel?> BuscarProdutosByCodBarAsyncRepository(string productcodbar);
        Task<ProdutosModel?> AdicionarProdutoNoEstoqueAsyncRepository(string productcodbar, int productstock);
        Task<ProdutosModel?> RemoverProdutoNoEstoqueAsyncRepository(string productcodbar, int productstock);
        
    }
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly AppDbContext _appDbContext;

        public ProdutoRepository (AppDbContext appContext)
        {
            _appDbContext = appContext;
        }

        /// <summary>
        /// Busca todos os produtos da tabela Product.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProdutosModel>>BuscarProdutosAsyncRepository()
        {
            var produto =  await _appDbContext.products.ToListAsync();
            return produto;
        }
        /// <summary>
        /// Busca os produtos pelo Id na taabela Product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProdutosModel?> BuscarProdutosByIdAsyncRepository(int id)
        {
           var produto =  await _appDbContext.products.FindAsync(id);
            //se for nulo, é nulo.
            return produto;
        }

        /// <summary>
        /// Adiciona os proutos na tebela product.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public async Task<ProdutosModel> AddProdutoAsyncRepository(ProdutosModel produto)
        {
            _appDbContext.Add(produto);
            
            await _appDbContext.SaveChangesAsync();

            return produto;
        }
        /// <summary>
        /// Metodo para alterar o produto na tabela Product.
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProdutosModel?> AlterarProdutoAsyncRepository(ProdutosModel produto, int id)
        {
            var produtoAtual =  await _appDbContext.products.FindAsync(id);

            if (produto == null)
            {
                return produtoAtual;
            }
            _appDbContext.Entry(produto).CurrentValues.SetValues(produto);
            await _appDbContext.SaveChangesAsync();

            return produto;

        }


        /// <summary>
        /// Metodo para buscar produto pelo código de barras na tabela Product.
        /// </summary>
        /// <param name="productcodbar"></param>
        /// <returns></returns>
        public async Task<ProdutosModel?> BuscarProdutosByCodBarAsyncRepository(string productcodbar)
        {
           var produto =  await _appDbContext.products
                                .FirstOrDefaultAsync(p => p.Productcodbar == productcodbar);
            //se for nulo, é nulo.
            return produto;
        }


        public async Task<ProdutosModel?> RemoverProdutoNoEstoqueAsyncRepository(string productcodbar, int productstock)
        {
            var produto = await _appDbContext.products
                                .FirstOrDefaultAsync(p => p.Productcodbar == productcodbar);
            if (produto == null)
            {
                return new ProdutosModel();
            }

                produto.Productstock -= productstock;
                await _appDbContext.SaveChangesAsync();
                return produto;        
        }


                public async Task<ProdutosModel?> AdicionarProdutoNoEstoqueAsyncRepository(string productcodbar, int productstock)
        {
            var produto = await _appDbContext.products
                                .FirstOrDefaultAsync(p => p.Productcodbar == productcodbar);
            if (produto == null)
            {
                return new ProdutosModel();
            }

                produto.Productstock += productstock;
                await _appDbContext.SaveChangesAsync();
                return produto;        
        }

    }
}