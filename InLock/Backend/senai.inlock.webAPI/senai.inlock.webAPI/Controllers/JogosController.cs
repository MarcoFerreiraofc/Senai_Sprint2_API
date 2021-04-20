using Microsoft.AspNetCore.Authorization;
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
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            List<JogoDomain> listaJogos = _jogoRepository.Listar();

            return Ok(listaJogos);
        }


        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, JogoDomain jogoAtualizado)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            if (jogoBuscado == null)
            {
                return NotFound(new { mensagem = "Jogo não encontrado!" });
            }

            try
            {
                _jogoRepository.Atualizar(id, jogoAtualizado);

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
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);
            // um "=" é atribuição, um "==" é uma comparação

            // verifica se nenhum funcionário foi encontrado
            if (jogoBuscado == null)
            {
                // caso não seja encontrado, retorna um status code 404 - Not Found com uma mensagem personalizada
                return NotFound("Nenhum jogo encontrado!");
            }

            // caso seja encontrado, retorna o funcionário buscado com um status code 200 - Ok
            return Ok(jogoBuscado);
        }


        [HttpGet("buscar/{buscado}")]
        public IActionResult GetByName(string buscado)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorNome(buscado);

            if (jogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado!");
            }
            else
                return Ok(jogoBuscado);
        }


        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try // tenta executar...
            {
                // se o conteúdo do nome e/ou do sobrenome do novo funcionário estar vazio ou com um espaço em branco...
                if (String.IsNullOrWhiteSpace(novoJogo.nomeJogo))
                {
                    // retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Campo 'nomeJogo' obrigatório!");
                }

                if (String.IsNullOrWhiteSpace(novoJogo.descricao))
                {
                    // retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Campo 'descricao' obrigatório!");
                }

                

                // se estiver tudo preenchido...
                else
                    // faz a chamada para o método Cadastrar
                    _jogoRepository.Cadastrar(novoJogo);

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
            _jogoRepository.Deletar(id);

            // retorna o status code 204 - No Content
            return StatusCode(204);
        }
    }
}
