using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Service.SEG_SERVICE
{
    public class ModuloService : IModulos
    {
        private readonly DB_SEG _db;

        public ModuloService(DB_SEG context)
        {
            _db = context;
        }
        public async Task<C_MODULOS> GetModulos(Guid id)
        {
            try
            {
                var response = await _db.C_MODULOS.FindAsync(id);
                return response == null ? new C_MODULOS() : response;
            }
            catch (Exception)
            {
                return new C_MODULOS();
            }
        }
        public async Task<List<C_MODULOS>> GetModulosAllGPO(Guid id)
        {
            try
            {
                var response = await _db.C_MODULOS.Where(x => x.GRUPO_MODULO_ID == id).ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<C_MODULOS>();
            }
        }

        public async Task<string> CreateModulos(C_MODULOS c_MODULOS)
        {
            try
            {
                c_MODULOS.MODULO_ID = Guid.NewGuid();
                c_MODULOS.FECHA_REG = DateTime.Now;

                _db.C_MODULOS.Add(c_MODULOS);
                await _db.SaveChangesAsync();
                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> UpdateModulos(C_MODULOS c_MODULOS)
        {
            try
            {
                _db.Entry(c_MODULOS).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return "Update";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> DeleteModulos(Guid id)
        {
            try
            {
                var response = await _db.C_MODULOS.FindAsync(id);
                if (response == null)
                    return "El registro no existe";

                _db.C_MODULOS.Remove(response);
                await _db.SaveChangesAsync();
                return "Delete";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> ChangeStatusModulos(Guid id, bool status)
        {
            try
            {
                var response = await _db.C_MODULOS.FindAsync(id);
                if (response == null)
                    return "El registro no existe";

                response.STATUS = status;
                return await UpdateModulos(response);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
