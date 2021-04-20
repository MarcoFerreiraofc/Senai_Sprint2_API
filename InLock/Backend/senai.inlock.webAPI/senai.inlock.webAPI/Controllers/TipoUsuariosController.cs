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
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<TipoUsuarioDomain> listaTipoUsuario = _tipoUsuarioRepository.Listar();

            return Ok(listaTipoUsuario);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cria um objeto "funcionarioBuscado" que irá receber o "funcionarioBuscado" no banco de dados
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);
            // um "=" é atribuição, um "==" é uma comparação

            // verifica se nenhum funcionário foi encontrado
            if (tipoUsuarioBuscado == null)
            {
                // caso não seja encontrado, retorna um status code 404 - Not Found com uma mensagem personalizada
                return NotFound("Nenhum tipo usuário encontrado!");
            }

            // caso seja encontrado, retorna o funcionário buscado com um status code 200 - Ok
            return Ok(tipoUsuarioBuscado);
        }


    }
}
