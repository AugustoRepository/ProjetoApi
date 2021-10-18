using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Presentation.Models;
using ProjetoApi.Repository.Contracts;
using ProjetoApi.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProdutoCadastroModel model,
            [FromServices] IProdutoRepository produtoRepository)
        {
             

                try
                {
                    var produto = new Produto();
                    produto.IdProduto = Guid.NewGuid();
                    produto.Nome = model.Nome;
                    produto.Preco = decimal.Parse(model.Preco);
                    produto.Quantidade = int.Parse(model.Quantidade);
                    produto.DataCadastro = DateTime.Now;
                    produto.DataUltimaAlteracao = DateTime.Now;
                    produtoRepository.Create(produto); //gravando..
                    return Ok("Produto cadastrado com sucesso.");
                }
                 catch (Exception e)
                {
                    return StatusCode(500, "Ocorreu um erro: " + e.Message);
                }
                
        
            
        }
        [HttpPut]
        public IActionResult Put(ProdutoEdicaoModel model,
            [FromServices] IProdutoRepository produtoRepository)
        {


            try
            {
                var produto = produtoRepository.GetById(Guid.Parse(model.IdProduto));
                if (produto != null)
                {
                    produto.Nome = model.Nome;
                    produto.Preco = decimal.Parse(model.Preco);
                    produto.Quantidade = int.Parse(model.Quantidade);
                    produto.DataUltimaAlteracao = DateTime.Now;
                    produtoRepository.UpDate(produto);
                    return Ok("produto Autualizado com sucesso.");
                }
                else
                {
                    return StatusCode(400, "Produto nao encontrado no sistema");
                }
            }
            catch (Exception e )
            {
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id ,
            [FromServices] IProdutoRepository produtoRepository
            )
        {
            try
            {
                var produto = produtoRepository.GetById(Guid.Parse(id));
                if (produto != null)
                {
                    produtoRepository.Delete(produto);
                    return Ok("Produto excuido com sucesso.");
                }
                else
                {
                    return StatusCode(400, "Produto nao encontrado no sistema");
                }
            }
            catch (Exception  e)
            {
                return StatusCode(500, "Ocorreu um erro: " + e.Message);

            }
        }
        [ProducesResponseType(typeof(List<ProdutoConsultaModel>), 200)]
        [HttpGet]
        public IActionResult Get([FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                var consulta = produtoRepository.GetAll();

                var result = new List<ProdutoConsultaModel>();

                foreach (var item in consulta)
                {
                    var model = new ProdutoConsultaModel();
                    model.IdProdudo = item.IdProduto.ToString();
                    model.Nome = item.Nome;
                    model.Preco = item.Preco.ToString();
                    model.Quantidade = item.Quantidade.ToString();
                    model.Total = (item.Preco * item.Quantidade).ToString();
                    model.DataCadastro = item.DataCadastro.ToString();
                    model.DataUltimaAlteracao = item.DataUltimaAlteracao.ToString();

                    result.Add(model);
                }
                return Ok(result);
            }
            catch (Exception e )
            {
                return StatusCode(500, "Ocorreu um erro: " + e.Message);

            }
        }
        [ProducesResponseType(typeof(List<ProdutoConsultaModel>), 200)]
        [HttpGet("id")]
        public IActionResult GetById (string id , 
            [FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                var produto = produtoRepository.GetById(Guid.Parse(id));
                if (produto != null)
                {
                    var model = new ProdutoConsultaModel();                    
                    model.IdProdudo = produto.IdProduto.ToString();
                    model.Nome = produto.Nome;
                    model.Preco = produto.Preco.ToString();
                    model.Quantidade = produto.Quantidade.ToString();
                    model.Total = (produto.Preco * produto.Quantidade).ToString();
                    model.DataCadastro = produto.DataCadastro.ToString();
                    model.DataUltimaAlteracao = produto.DataUltimaAlteracao.ToString();

                    return Ok(model);
                }
                else
                {
                    return StatusCode(400, "Produto nao encontrado no sistema");
                }

            }
            catch (Exception e )
            {
                return StatusCode(500, "Ocorreu um erro: " + e.Message);
            }
        }

    }
}
