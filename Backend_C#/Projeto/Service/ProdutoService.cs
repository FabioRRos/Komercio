using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Interface;
using Projeto.Models;
using Projeto.Repository;

namespace Projeto.Service
{
    public class ProdutoService: IProduct
    {

        public readonly ProdutoRepository _produtoRepository;


        public ProdutoService(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        /// <summary>
        /// Busca o produto no repository.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProdutosModel>> BuscarProdutosAsyncService()
        {
           var produto = await _produtoRepository.BuscarProdutosAsyncRepository();

           return produto;
        }
        /// <summary>
        /// Busca o produto de acordo com o Id dele.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProdutosModel?> BuscarProdutosByIdAsyncService(int id)
        {

            var produto = await _produtoRepository.BuscarProdutosByIdAsyncRepository(id);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado ou Id invalido.");
            }
            return produto;
        }


        /// <summary>
        /// Valida os dados do produto antes de persistir os dados.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public async Task<ProdutosModel> AddProdutoAsyncService(ProdutosModel produto)
        {
            
            ProdutosModel product = new ProdutosModel();

            var status = product.ProductValidation(produto);

            if (!status)
            {
                throw new Exception("Dados do produto inválidos.");
            }

            var produtoRetornado =  await _produtoRepository.AddProdutoAsyncRepository(produto);
            return produtoRetornado;
        }

        /// <summary>
        /// Metodo Post para salvar alteração.
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProdutosModel?> AlterarProdutoAsyncService(ProdutosModel produto, int id)
        {

            ProdutosModel product = new ProdutosModel();

            var status = product.ProductValidation(produto);

            if (!status)
            {
                throw new Exception("Dados do produto inválidos.");
            }

            var produtoRetornado = await _produtoRepository.AlterarProdutoAsyncRepository(product,id);

            if (produtoRetornado == null)
            {
                throw new Exception("Produto não localizado.");
            }

            return produtoRetornado;

        }
    }
}