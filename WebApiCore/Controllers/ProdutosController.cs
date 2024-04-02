using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCore.Data;
using WebApiCore.Data.Entities;
using WebApiCore.Repositories.Interfaces;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produto;

        public ProdutosController(IProdutoRepository produto)
        {
            _produto = produto;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            return await _produto.GetProduto();
        }
                
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _produto.GetProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }
                
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }
            var  result  = await _produto.PutProduto(id, produto);
            if (result)
            {
                return Ok(result);
            }
            
                

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            var result =  _produto.PostProduto(produto);
            return CreatedAtAction("GetProduto", new { id = result }, produto);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _produto.GetProduto(id);
            if (produto == null)
            {
                return NotFound();
            }

            var result =  _produto.DeleteProduto(id);
            if (await result)
            {
                return Ok();
            }
            return NoContent();
        }

        
        
    }
}
