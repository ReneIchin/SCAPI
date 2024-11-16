using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Service.SEG_SERVICE
{
    public class AccionesService : IAcciones
    {
        private readonly DB_SEG _db;

        public AccionesService(DB_SEG context)
        {
            _db = context;
        }


        public async Task<C_ACCIONES> GetAccion(Guid id)
        {
            try
            {
                var response = await _db.C_ACCIONES.FindAsync(id);

                return response == null ? new C_ACCIONES() : response;
            }
            catch (Exception)
            {
                return new C_ACCIONES();
            }
        }
        public async Task<List<C_ACCIONES>> GetAcciones(bool status)
        {
            try
            {
                var response = status == true ? await _db.C_ACCIONES.ToListAsync() : await _db.C_ACCIONES.Where(x => x.STATUS == true).ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<C_ACCIONES>();
            }
        }

    }
}
