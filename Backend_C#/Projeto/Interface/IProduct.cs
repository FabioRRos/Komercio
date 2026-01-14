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
        Task<ServiceResponse<IEnumerable<ProdutosModel>>> BuscarProdutosAsyncService();

        Task<ServiceResponse<ProdutosModel>> AddProdutoAsyncService(ProdutosModel produto);

        Task<ServiceResponse<ProdutosModel>> BuscarProdutosByIdAsyncService(int id);

        Task<ServiceResponse<ProdutosModel>> AlterarProdutoAsyncService(ProdutosModel produto, int id);

        Task<ServiceResponse<ProdutosModel>> BuscarProdutosByCodBarAsyncService(string productcodbar);

        Task<ServiceResponse<bool>> DesativarProdutoService(int id);

        Task<ServiceResponse<ProdutosModel>> RemoverProdutoNoEstoqueAsyncService(string productcodbar, int productstock);
    }
} 