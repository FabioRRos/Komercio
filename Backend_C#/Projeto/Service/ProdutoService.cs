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
    public class ProdutoService : IProduct
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
        public async Task<ServiceResponse<IEnumerable<ProdutosModel>>> BuscarProdutosAsyncService()
        {
            var response = new ServiceResponse<IEnumerable<ProdutosModel>>();

            try
            {
                var produtos = await _produtoRepository.BuscarProdutosAsyncRepository();
                response.Dados = produtos;
                response.Mensagem = "Produtos listados com sucesso.";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }
        /// <summary>
        /// Busca o produto de acordo com o Id dele.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ServiceResponse<ProdutosModel>> BuscarProdutosByIdAsyncService(int id)
        {
            var response = new ServiceResponse<ProdutosModel>();

            try
            {
                var produto = await _produtoRepository.BuscarProdutosByIdAsyncRepository(id);

                if (produto == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Produto não encontrado ou Id invalido.";
                    return response;
                }

                response.Dados = produto;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }


        /// <summary>
        /// Cria o produto - Valida os dados do produto antes de persistir os dados.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<ProdutosModel>> AddProdutoAsyncService(ProdutosModel produto)
        {
            var response = new ServiceResponse<ProdutosModel>();

            try
            {
                ProdutosModel productValidator = new ProdutosModel(); // Renomeado para clareza
                var status = productValidator.ProductValidation(produto);

                if (!status)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Dados do produto inválidos.";
                    return response;
                }

                var produtoRetornado = await _produtoRepository.AddProdutoAsyncRepository(produto);

                response.Dados = produtoRetornado;
                response.Mensagem = "Produto cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }

        /// <summary>
        /// Metodo Post para salvar alteração.
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<ProdutosModel>> AlterarProdutoAsyncService(ProdutosModel produto, int id)
        {
            var response = new ServiceResponse<ProdutosModel>();

            try
            {
                ProdutosModel productValidator = new ProdutosModel();
                var status = productValidator.ProductValidation(produto);

                if (!status)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Dados do produto inválidos.";
                    return response;
                }

                var produtoRetornado = await _produtoRepository.AlterarProdutoAsyncRepository(produto, id);

                if (produtoRetornado == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Produto não localizado.";
                    return response;
                }

                response.Dados = produtoRetornado;
                response.Mensagem = "Produto alterado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }
        /// <summary>
        /// Metodo para validar o código de barras antes de solicitar.
        /// </summary>
        /// <param name="productcodbar"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<ProdutosModel>> BuscarProdutosByCodBarAsyncService(string productcodbar)
        {
            var response = new ServiceResponse<ProdutosModel>();

            try
            {
                if (string.IsNullOrEmpty(productcodbar))
                {
                    response.Sucesso = false;
                    response.Mensagem = "Código de barras invalido!";
                    return response;
                }

                var produto = await _produtoRepository.BuscarProdutosByCodBarAsyncRepository(productcodbar);

                if (produto == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Produto não encontrado.";
                    return response;
                }

                response.Dados = produto;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return response;
        }

        /// <summary>
        /// Desativa o produto com base no id informado. 
        /// Basicamente eu chamo o bucarprodutobyid, altero o obj e faço o post com o status "False"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ServiceResponse<bool>> DesativarProdutoService(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var produto = await _produtoRepository.BuscarProdutosByIdAsyncRepository(id);

                if (produto == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Produto não encontrado ou Id invalido.";
                    return response;
                }

                produto.Status = false;

                var produtoRetornado = await _produtoRepository.AlterarProdutoAsyncRepository(produto, produto.Id);

                if (produtoRetornado == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = "Erro ao tentar desativar o produto.";
                    response.Dados = false;
                    return response;
                }

                response.Dados = true;
                response.Mensagem = "Produto desativado com sucesso.";
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
                response.Dados = false;
            }

            return response;
        }


        /// <summary>
        /// Esse metodo serve para adicionar produtos no estoque da tabela Product.
        /// </summary>
        /// <param name="productcodbar"></param>
        /// <param name="productstock"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<ProdutosModel>> RemoverProdutoNoEstoqueAsyncService(string productcodbar, int productstock)
        {
            var response = new ServiceResponse<ProdutosModel>();


            if (productcodbar == "")
            {
                response.Sucesso = false;
                response.Mensagem = "Código de barras inválido";
                return response;
            }

            if (productstock <= 0)
            {
                response.Sucesso = false;
                response.Mensagem = "Quantidade inválida";
                return response;
            }


            var produto = await _produtoRepository.RemoverProdutoNoEstoqueAsyncRepository(productcodbar, productstock);


            if (produto == null || produto.Id == 0)
            {
                response.Sucesso = false;
                response.Mensagem = "Produto não encontrado ou erro ao atualizar.";
                return response;
            }

            response.Dados = produto;
            response.Mensagem = "Estoque atualizado com sucesso!";

            return response;
        }



        /// <summary>
        /// Adicionar produto no estoque da tabela Product.
        /// </summary>
        /// <param name="productcodbar"></param>
        /// <param name="productstock"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<ProdutosModel>> AdicionarProdutoNoEstoqueAsyncService(string productcodbar, int productstock)
        {
            var response = new ServiceResponse<ProdutosModel>();


            if (productcodbar == "")
            {
                response.Sucesso = false;
                response.Mensagem = "Código de barras inválido";
                return response;
            }

            if (productstock <= 0)
            {
                response.Sucesso = false;
                response.Mensagem = "Quantidade inválida";
                return response;
            }


            var produto = await _produtoRepository.AdicionarProdutoNoEstoqueAsyncRepository(productcodbar, productstock);


            if (produto == null || produto.Id == 0)
            {
                response.Sucesso = false;
                response.Mensagem = "Produto não encontrado ou erro ao atualizar.";
                return response;
            }

            response.Dados = produto;
            response.Mensagem = "Estoque atualizado com sucesso!";

            return response;
        }

    }



}