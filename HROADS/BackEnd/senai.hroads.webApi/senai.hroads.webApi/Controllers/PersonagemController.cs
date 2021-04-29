using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagemController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personagemRepository.Listar().OrderBy(c => c.IdPersonagem));
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_personagemRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagem novoPersonagem)
        {
            try
            {
                _personagemRepository.Cadastrar(novoPersonagem);

                return NoContent();
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);

            }

        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _personagemRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);

            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Personagem personagemAtualizado)
        {
            _personagemRepository.Atualizar(id, personagemAtualizado);

            return StatusCode(200);
        }
    }
}
