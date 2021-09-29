using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository Con { get; set; }

        public ConsultaController()
        {
            Con = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(Con.ListarCon());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ListarTudo")]
        public IActionResult ListarTudo()
        {
            try
            {
                return Ok(Con.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
