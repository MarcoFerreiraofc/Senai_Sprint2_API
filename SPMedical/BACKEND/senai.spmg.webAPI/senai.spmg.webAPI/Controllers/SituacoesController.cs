﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.spmg.webAPI.Domains;
using senai.spmg.webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmg.webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SituacoesController : ControllerBase
    {
        private ISituacaoRepository _situacaoRepository;

        public SituacoesController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_situacaoRepository.Listar());
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Situacoes situacaoBuscada = _situacaoRepository.BuscarPorId(id);

                if (situacaoBuscada == null)
                {
                    return NotFound("Nenhuma situação encontrada!");
                }

                return Ok(situacaoBuscada);
            }
            catch (Exception codErro)
            {
                return BadRequest(codErro);
            }
        }


    }
}
