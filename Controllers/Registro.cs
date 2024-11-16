using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SCAPI.Interfaz.ISEGURIDAD;

namespace SCAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Registro : ControllerBase
    {

        private readonly IEmpresas _empresas;

        public Registro(IEmpresas empresas)
        {
            this._empresas = empresas;
        }

        //[HttpPost("Create")]
        //public async Task<ActionResult> Create()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound(e.Message);
        //    }
        //}


        


    }
}
