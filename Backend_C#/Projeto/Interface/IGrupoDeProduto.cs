using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Models;

namespace Projeto.Interface
{
    public interface IGrupoDeProduto
    {
       Task<ServiceResponse<IEnumerable<GrupoDeProduto>>>BuscaGrupoDeProdutoService();
       Task<ServiceResponse<GrupoDeProduto>> CadastrarGrupoDeProdutoService(GrupoDeProduto grupoProduto);
       Task<ServiceResponse<GrupoDeProduto>> DeletarGrupoDeProdutoService(int id);
    }
}