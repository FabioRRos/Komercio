using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Models;

namespace Projeto.Interface
{
    public interface IProduct
    {   
        Task<IEnumerable<ProdutosModel>> BuscarProdutosAsyncService();
        Task<ProdutosModel> AddProdutoAsyncService(ProdutosModel produto);
        Task<ProdutosModel?> BuscarProdutosByIdAsyncService(int id);
        Task<ProdutosModel?> AlterarProdutoAsyncService(ProdutosModel produto, int id);

    }
} 