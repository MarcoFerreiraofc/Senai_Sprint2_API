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
    public class TipoHabilidadeController : ControllerBase
    {
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }

        public TipoHabilidadeController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoHabilidadeRepository.Listar());
        }
    }
}
