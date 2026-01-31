using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Repository
{

    public interface IGrupoDeProdutoRepository
    {
        Task<IEnumerable<GrupoDeProduto>> BuscaGrupoDeProdutoRepository();
        Task<GrupoDeProduto> CadastrarGrupoDeProdutoRepository(GrupoDeProduto grupoProduto);
        Task<ServiceResponse<GrupoDeProduto>> DeletarGrupoDeProdutoRepository(int id);
    }

    public class GrupoDeProdutoRepository : IGrupoDeProdutoRepository
    {
        private readonly AppDbContext _appDbContext;

        public GrupoDeProdutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Busca grupo de produto na tabela product_group.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GrupoDeProduto>> BuscaGrupoDeProdutoRepository()
        {
            var productGroup = await _appDbContext.product_group.ToListAsync();
            return productGroup;
        }

        /// <summary>
        /// Salva o grupo na tabela product_group.
        /// </summary>
        /// <param name="grupoProduto"></param>
        /// <returns></returns>
        public async Task<GrupoDeProduto> CadastrarGrupoDeProdutoRepository(GrupoDeProduto grupoProduto)
        {
            await _appDbContext.product_group.AddAsync(grupoProduto);
            //await _appDbContext.SaveChangesAsync();
            return grupoProduto;
        }

        /// <summary>
        /// Deleta o grupo de produto pelo Id da ta bela product_group;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GrupoDeProduto>> DeletarGrupoDeProdutoRepository(int id)
        {
            var response = new ServiceResponse<GrupoDeProduto>();
            var grupo = await _appDbContext.product_group.FindAsync(id);
            if (grupo == null)
            {
                response.Mensagem = "Não conseguimos localizar o id";
                response.Sucesso = false;
                return response;
            }
            _appDbContext.product_group.Remove(grupo);
            await _appDbContext.SaveChangesAsync();
            response.Dados = grupo;
            response.Sucesso = true;
            response.Mensagem = "Grupo de produto removido com sucesso";
            return response;
        }



    }
}