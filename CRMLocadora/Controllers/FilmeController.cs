using CRMLocadora.Models;
using CRMLocadora.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMLocadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }



        // GET: api/<FilmeController>
        [HttpGet]
        public List<Filme> Get()
        {
            return _filmeService.FindAll();
        }

        // GET api/<FilmeController>/5
        [HttpGet("{id}")]
        public Filme GetById(int id)
        {
            return _filmeService.FindById(id);
        }

        // POST api/<FilmeController>
        [HttpPost]
        public IActionResult Post([FromBody] Filme filme)
        {
            var retorno = _filmeService.Save(filme);

            if (retorno)
                return Ok("Filme criado com sucesso!!");

            return BadRequest("Não foi possível inserir o dado!!");
        }

        // PUT api/<FilmeController>/5
        [HttpPut]
        public IActionResult UpdateFilme([FromBody] Filme filme)
        {
            var retornoInsercao = _filmeService.Update(filme);
            if (retornoInsercao)
                return Ok("Atualizado");
            return BadRequest("falha ao Atualizar!");
        }

        // DELETE api/<FilmeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
               
            if (_filmeService.Delete(id))
                return Ok("Filme Deletado com sucesso!");
            return BadRequest("Ops!, Falha na operação!");
        }
    }
}
