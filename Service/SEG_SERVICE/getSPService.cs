using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;
using SCAPI.Models.DTO.DB_SEG_DTO;

namespace SCAPI.Service.SEG_SERVICE
{
    public class getSPService : IGetSP
    {

        public readonly DTO_CONTEXT _db;

        public getSPService(DTO_CONTEXT db)
        {
            _db = db;
        }

        public async Task<C_MODULO_DTO> getSistemaModulo(Guid id)
        {
            try
            {
                var response = await _db.C_MODULO_DTO
             .FromSqlRaw("EXEC SP_UTILIDADES_ID @parametro1, @parametro2, ''",
                 new SqlParameter("@parametro1", "C_MODULOS"),
                 new SqlParameter("@parametro2", id.ToString()))
             .ToListAsync();

                var result = response.FirstOrDefault();

                if (result == null)
                    return new C_MODULO_DTO();

                return result;
            }
            catch (Exception)
            {
                return new C_MODULO_DTO();
            }
        }

        public async Task<DATOS_RESUM_USUARIO> GetDatosResumenUsuario()
        {
            try
            {
                var response = await _db.DATOS_RESUM_USUARIO
                 .FromSqlRaw("EXEC SP_UTILIDADES_ID @parametro1, NULL, ''",
                 new SqlParameter("@parametro1", "DATOS_RESUM_USUARIO"))
             .ToListAsync();

                var result = response.FirstOrDefault();

                if (result == null)
                    return new DATOS_RESUM_USUARIO();

                return result;
            }
            catch (Exception e)
            {
                return new DATOS_RESUM_USUARIO();
            }
        }

    }
}
