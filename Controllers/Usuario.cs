using Microsoft.AspNetCore.Mvc;
using SCAPI.Interfaz.ISEGURIDAD;

namespace SCAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Usuario : ControllerBase
    {
        private readonly IUsuario _usuario;

        public Usuario(IUsuario usuario)
        {
            this._usuario = usuario;
        }

        [HttpGet("ObtenerUsuario/{id}")]
        public async Task<ActionResult> ObtenerUsuario(Guid id)
        {
            try
            {
                var response = await _usuario.GetUsuario(id);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

    }
}
