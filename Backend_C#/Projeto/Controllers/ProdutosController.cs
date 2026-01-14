using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Interface;
using Projeto.Models;
using Projeto.Service;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProduct _iproduct;

        public ProdutosController(IProduct iproduct)
        {
            _iproduct = iproduct;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduto(ProdutosModel produto)
        {
            var response = await _iproduct.AddProdutoAsyncService(produto);

            if (!response.Sucesso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutosModel>>> BuscarProduto()
        {
            var response = await _iproduct.BuscarProdutosAsyncService();

            if (!response.Sucesso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ProdutosModel>> BuscarProdutoById(int id)
        {
            var response = await _iproduct.BuscarProdutosByIdAsyncService(id);

            if (!response.Sucesso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("codbar/{productcodbar}")]
        public async Task<ActionResult<ProdutosModel>> BuscarProdutoByCodBar(string productcodbar)
        {
            try
            {
                var produto = await _iproduct.BuscarProdutosByCodBarAsyncService(productcodbar);

                if (produto == null)
                {
                    return NotFound(new { message = "Codigo de barras não localizado" });
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProdutoById(int id, [FromBody] ProdutosModel produtoAtualizado)
        {
            var response = await _iproduct.AlterarProdutoAsyncService(produtoAtualizado, id);

            if (!response.Sucesso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DesativarProduto(int id)
        {
            var response = await _iproduct.DesativarProdutoService(id);

            if (!response.Sucesso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        public class EstoqueRequest { public int productstock { get; set; } }
        [HttpPut("removeEstoque/{productcodbar}")]
        public async Task<ActionResult<ServiceResponse<ProdutosModel>>> EntradaNoEstoqueByCodBar(string productcodbar, [FromBody] EstoqueRequest request)
        {

            var response = await _iproduct.RemoverProdutoNoEstoqueAsyncService(productcodbar, request.productstock);
            if (!response.Sucesso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
