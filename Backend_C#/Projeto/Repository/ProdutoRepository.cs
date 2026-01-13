using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Repository
{
    public class ProdutoRepository
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




    }
}