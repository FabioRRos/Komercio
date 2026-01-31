using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Interface;
using Projeto.Models;
using Projeto.Repository;

namespace Projeto.Service
{
    public class GrupoDeProdutoService : IGrupoDeProduto
    {

        private readonly GrupoDeProdutoRepository _grupoDeProdutoRepository;

        public GrupoDeProdutoService(GrupoDeProdutoRepository grupoDepProdutoRepository)
        {
            _grupoDeProdutoRepository = grupoDepProdutoRepository;
        }
        /// <summary>
        /// Solicita a lista de grupo de produto.
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<IEnumerable<GrupoDeProduto>>> BuscaGrupoDeProdutoService()
        {
            var response = new ServiceResponse<IEnumerable<GrupoDeProduto>>();

            try
            {
                var grupo = await _grupoDeProdutoRepository.BuscaGrupoDeProdutoRepository();
                response.Dados = grupo;
                response.Mensagem = "Grupo listado com sucesso"!;
            }
            catch
            {
                response.Sucesso = false;
                response.Mensagem = "Não consegui carregar a lista de grupo de produtos";
                return response;
            }
            return response;
        }

        /// <summary>
        /// Verifica antes de cadastrar
        /// </summary>
        /// <param name="grupoProduto"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GrupoDeProduto>> CadastrarGrupoDeProdutoService(GrupoDeProduto grupoProduto)
        {
            var response = new ServiceResponse<GrupoDeProduto>();

            if (grupoProduto == null)
            {
                response.Mensagem = "Grupo invalido";
                response.Sucesso = false;
            }

            if (grupoProduto.Subgroup_id == null)
            {
                grupoProduto.Subgroup_id = 0;
            }

            var grupo = await _grupoDeProdutoRepository.CadastrarGrupoDeProdutoRepository(grupoProduto);

            if (grupo == null)
            {
                response.Sucesso = false;
                response.Mensagem = "Não foi possivel salvar o grupo";
            }

            response.Dados = grupo;
            response.Sucesso = true;
            response.Mensagem = "Grupo criado com sucesso";

            return response;
        }
        /// <summary>
        /// Valida o id antes de realizar o delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GrupoDeProduto>> DeletarGrupoDeProdutoService(int id)
        {
            var response = new ServiceResponse<GrupoDeProduto>();

            if (id == null)
            {
                response.Sucesso = false;
                response.Mensagem = "Id invalido.";
            }

            response = await _grupoDeProdutoRepository.DeletarGrupoDeProdutoRepository(id);

            return response;
        }
    }
}