﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_Medical.webApi.Domains;
using SP_Medical.webApi.Interfaces;
using SP_Medical.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical.webApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _MedicoRepository { get; set; }

        public MedicoController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Método responsavel por listar todos os médicos
        /// </summary>
        /// <returns>Uma lista de médicos</returns>
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_MedicoRepository.Listar());
        }

        /// <summary>
        /// Método responsavel por buscar um médico por um id especifico
        /// </summary>
        /// <param name="id">Id do médico a ser buscado</param>
        /// <returns>Medico encontrado</returns>
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_MedicoRepository.Buscar(id));
        }

        /// <summary>
        /// Método responsavel por cadastrar um novo médico
        /// </summary>
        /// <param name="MedicoNovo">Objeto do tipo Médico a ser cadastrado</param>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Medico MedicoNovo)
        {
            _MedicoRepository.Cadastrar(MedicoNovo);

            return StatusCode(201);
        }

        /// <summary>
        /// Método responsavel pela atualização de algum cadastro de médico
        /// </summary>
        /// <param name="MedicoAtualizado">Dados Atualizados</param>
        /// <param name="id">Id do médico a ser atualizado</param>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Medico MedicoAtualizado, int id)
        {
            _MedicoRepository.Atualizar(MedicoAtualizado, id);

            return StatusCode(204);
        }

        /// <summary>
        /// Método responsavel por deletar um médico
        /// </summary>
        /// <param name="id">Id do médico a ser deletado</param>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _MedicoRepository.Deletar(id);

            return StatusCode(203);
        }
    }
}
