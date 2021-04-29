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
    public class ClasseController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classeRepository.Listar().OrderBy(c => c.IdClasse));
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            return Ok(_classeRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Classe novoClasse)
        {
            try
            {
                _classeRepository.Cadastrar(novoClasse);

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
                _classeRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);

            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Classe classeAtualizado)
        {
            _classeRepository.Atualizar(id, classeAtualizado);

            return StatusCode(200);
        }
    }
}
