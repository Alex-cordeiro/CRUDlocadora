using CRMLocadora.Models;
using CRMLocadora.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMLocadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            this._clienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public List<Cliente> Get()
        {
            return _clienteService.FindAll();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public Cliente GetById(int id)
        {
            return _clienteService.FindById(id);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            var retorno = _clienteService.Save(cliente);

            if (retorno)
               return Ok("Cliente criado com sucesso!!");

            return BadRequest("Não foi possível inserir o dado!!");
        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        public IActionResult UpdateCliente([FromBody] Cliente cliente)
        {
            var retornoInsercao = _clienteService.Update(cliente);
            if (retornoInsercao)
                return Ok("Atualizado");
            return BadRequest("falha ao Atualizar!");
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] Cliente cliente)
        {
            if(_clienteService.Delete(cliente.Id))
                    return Ok("Cliente Deletado com sucesso!");
            return BadRequest("Ops!, Falha na operação!");
        }
    }
}
