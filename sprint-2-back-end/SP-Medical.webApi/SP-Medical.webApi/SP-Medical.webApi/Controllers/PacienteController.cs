using Microsoft.AspNetCore.Authorization;
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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository Pac { get; set; }

    public PacienteController()
    {
        Pac = new PacienteRepository();
    }

    [Authorize(Roles = "3")]
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(Pac.Listar());
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [Authorize(Roles = "2")]
    [HttpGet("Tudo")]
    public IActionResult ListarTudo()
    {
        try
        {
            return Ok(Pac.ListarTudo());
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPost]
    public IActionResult Cadastro(Paciente NovoPac)
    {
        try
        {
            Pac.Cadastrar(NovoPac);
            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [Authorize(Roles = "2")]
    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        try
        {
            Pac.Deletar(id);
            return StatusCode(204);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [Authorize(Roles = "2")]
    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, Paciente NovoPac)
    {
        try
        {
            Pac.Atualizar(id, NovoPac);
            return StatusCode(204);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
}
