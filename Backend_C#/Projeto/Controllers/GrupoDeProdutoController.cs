using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto.Interface;
using Projeto.Models;

namespace Projeto.Controllers
{
    [Route("api/[controller]")]
    public class GrupoDeProdutoController : Controller
    {
        private readonly IGrupoDeProduto _igrupoDeProduto;
        public GrupoDeProdutoController(IGrupoDeProduto igrupoDeProduto)
        {
            _igrupoDeProduto = igrupoDeProduto;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoDeProduto>>>BuscaGrupoDeProduto()
        {    
            var response = await _igrupoDeProduto.BuscaGrupoDeProdutoService();
            if (response.Sucesso)
            {
                return Ok(response);
            }
            return BadRequest(response.Mensagem);
        }

        [HttpPost]
        public async Task<ActionResult<GrupoDeProduto>>CadastrarGrupoProduto([FromBody] GrupoDeProduto grupoProduto)
        {          
            var response = await _igrupoDeProduto.CadastrarGrupoDeProdutoService(grupoProduto);
            if (response.Sucesso)
            {
                return Ok(response);
            }
            return BadRequest(response.Mensagem);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<ServiceResponse<GrupoDeProduto>>>DeletarGrupoProduto(int id)
        {
            var response = await _igrupoDeProduto.DeletarGrupoDeProdutoService(id);

            return response;
        }
    }
}