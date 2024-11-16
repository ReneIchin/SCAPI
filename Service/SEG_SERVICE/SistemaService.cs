using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Service.SEG_SERVICE
{
    public class SistemaService : ISistemas
    {
        private readonly DB_SEG _db;
        public SistemaService(DB_SEG context)
        {
            _db = context;
        }
        public async Task<C_SISTEMAS> GetSistema(Guid id)
        {
            try
            {
                var response = await _db.C_SISTEMAS.FindAsync(id);
                return response == null ? new C_SISTEMAS() : response;
            }
            catch (Exception)
            {
                return new C_SISTEMAS();
            }
        }

        public async Task<List<C_SISTEMAS>> GetSistemas(bool status)
        {
            try
            {
                var response = status == true ? await _db.C_SISTEMAS.ToListAsync() : await _db.C_SISTEMAS.Where(x => x.STATUS == true).ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<C_SISTEMAS>();
            }
        }
        public async Task<string> CreateSistemas(C_SISTEMAS c_SISTEMAS)
        {
            try
            {
                c_SISTEMAS.SISTEMA_ID = Guid.NewGuid();
                c_SISTEMAS.STATUS = true;
                c_SISTEMAS.FECHA_REG = DateTime.Now;

                _db.C_SISTEMAS.Add(c_SISTEMAS);
                await _db.SaveChangesAsync();
                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> UpdateSistemas(C_SISTEMAS c_SISTEMAS)
        {
            try
            {
                _db.Entry(c_SISTEMAS).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return "Update";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> DeleteSistemas(Guid id)
        {
            try
            {
                var response = await _db.C_SISTEMAS.FindAsync(id);
                if (response == null)
                    return "No existe el registro";

                _db.C_SISTEMAS.Remove(response);
                await _db.SaveChangesAsync();
                return "Delete";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> ChangeStatusSistemas(Guid id, bool status)
        {
            try
            {
                var response = await _db.C_SISTEMAS.FindAsync(id);
                if (response == null)
                    return "El registro no existe";
                response.STATUS = status;

                return await UpdateSistemas(response);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
