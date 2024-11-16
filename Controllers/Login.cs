using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DTO.DB_SEG_DTO;

namespace SCAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Login : ControllerBase
    {

        private readonly IUsuario _usuario;

        public Login(IUsuario usuario)
        {
            this._usuario = usuario;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost("LoginUser")]
        public async Task<ActionResult> LoginUser(LOGIN_USER lOGIN_USER)
        {
            try
            {
                var response = await _usuario.LoginUser(lOGIN_USER);

                if(response == null)
                    return NotFound();

                var datos = new RESPONSE_LOGIN()
                {
                    USUARIO_ID = response.USUARIO_ID.ToString(),
                    USERNAME = response.USERNAME,
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }



    }
}
