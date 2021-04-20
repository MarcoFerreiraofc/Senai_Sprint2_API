using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webAPI.Domains;
using senai.inlock.webAPI.Interfaces;
using senai.inlock.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> listaEstudios = _estudioRepository.Listar();

            return Ok(listaEstudios);
        }


        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound(new { mensagem = "Estúdio não encontrado!" });
            }

            try
            {
                _estudioRepository.Atualizar(id, estudioAtualizado);

                return NoContent();
            }

            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cria um objeto "funcionarioBuscado" que irá receber o "funcionarioBuscado" no banco de dados
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);
            // um "=" é atribuição, um "==" é uma comparação

            // verifica se nenhum funcionário foi encontrado
            if (estudioBuscado == null)
            {
                // caso não seja encontrado, retorna um status code 404 - Not Found com uma mensagem personalizada
                return NotFound("Nenhum estúdio encontrado!");
            }

            // caso seja encontrado, retorna o funcionário buscado com um status code 200 - Ok
            return Ok(estudioBuscado);
        }


        [HttpGet("buscar/{buscado}")]
        public IActionResult GetByName(string buscado)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorNome(buscado);

            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estúdio encontrado!");
            }
            else
                return Ok(estudioBuscado);
        }


        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try // tenta executar...
            {
                // se o conteúdo do nome e/ou do sobrenome do novo funcionário estar vazio ou com um espaço em branco...
                if (String.IsNullOrWhiteSpace(novoEstudio.nomeEstudio))
                {
                    // retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Campo 'nome' obrigatório!");
                }

                // se estiver tudo preenchido...
                else
                    // faz a chamada para o método Cadastrar
                    _estudioRepository.Cadastrar(novoEstudio);

                // e retorna o status code 201 - Created
                return StatusCode(201);
            }

            // se não conseguiu executar...
            catch (Exception codErro)
            {
                // retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz a chamada para o método .Deletar
            _estudioRepository.Deletar(id);

            // retorna o status code 204 - No Content
            return StatusCode(204);
        }


    }
}
