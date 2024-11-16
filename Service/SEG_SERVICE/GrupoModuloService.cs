using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Service.SEG_SERVICE
{
    public class GrupoModuloService : IGruposModulos
    {
        private readonly DB_SEG _db;

        public GrupoModuloService(DB_SEG context)
        {
            _db = context;
        }

        public async Task<C_GRUPO_MODULO> GetGrupoModulo(Guid id)
        {
            try
            {

                var response = await _db.C_GRUPO_MODULO.FindAsync(id);

                return response == null ? new C_GRUPO_MODULO() : response;

            }
            catch (Exception)
            {
                return new C_GRUPO_MODULO();
            }
        }
        public async Task<List<C_GRUPO_MODULO>> GetGruposModulos(Guid sistema_id, bool status)
        {
            try
            {
                var response = status == true ? await _db.C_GRUPO_MODULO.Where(x => x.SISTEMA_ID == sistema_id).ToListAsync() : await _db.C_GRUPO_MODULO.Where(x => x.STATUS == true && x.SISTEMA_ID == sistema_id).ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<C_GRUPO_MODULO>();
            }
        }
        public async Task<string> CreateGruposModulos(C_GRUPO_MODULO c_GRUPO_MODULO)
        {
            try
            {
                c_GRUPO_MODULO.GRUPO_MODULO_ID = Guid.NewGuid();
                c_GRUPO_MODULO.STATUS = true;

                _db.C_GRUPO_MODULO.Add(c_GRUPO_MODULO);
                await _db.SaveChangesAsync();
                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> UpdateGruposModulos(C_GRUPO_MODULO c_GRUPO_MODULO)
        {
            try
            {
                _db.Entry(c_GRUPO_MODULO).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return "Update";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> DeleteGruposModulos(Guid id)
        {
            try
            {
                var response = await _db.C_GRUPO_MODULO.FindAsync(id);
                if (response == null)
                    return "No existe el registro";

                _db.C_GRUPO_MODULO.Remove(response);
                await _db.SaveChangesAsync();
                return "Delete";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> ChangeStatusGruposModulos(Guid id, bool status)
        {
            try
            {
                var response = await _db.C_GRUPO_MODULO.FindAsync(id);
                if (response == null)
                    return "No existe el registro";

                response.STATUS = status;

                return await UpdateGruposModulos(response);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
