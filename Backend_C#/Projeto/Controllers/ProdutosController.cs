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



        public ProdutosController(
            IProduct iproduct)
        {
            _iproduct = iproduct;
        }


        [HttpPost]
        public async Task<IActionResult> AddProduto(ProdutosModel produto)
        {

            try
            {
            var product = await _iproduct.AddProdutoAsyncService(produto);
            return Ok(produto);
              
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});   
            }  
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutosModel>>> BuscarProduto()
        {
           var produto =  await _iproduct.BuscarProdutosAsyncService();

            return Ok(produto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosModel>> BuscarProdutoById(int id)
        {
            try
            {
                var produto = await _iproduct.BuscarProdutosByIdAsyncService(id);
                return Ok(produto);
                
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});  
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProdutoById(int id, [FromBody] ProdutosModel produtoAtualizado)
        {
            try
            {
                
            var produto =  await _iproduct.AlterarProdutoAsyncService(produtoAtualizado,id);
            return StatusCode(201,produtoAtualizado);
            
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});  
            }         

        }
    }
}