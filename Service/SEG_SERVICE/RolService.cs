using Microsoft.EntityFrameworkCore;
using SCAPI.Controllers;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;
using System.Reflection.Metadata.Ecma335;

namespace SCAPI.Service.SEG_SERVICE
{
    public class RolService : IRol
    {
        private readonly DB_SEG _db;

        public RolService(DB_SEG db)
        {
            _db = db;
        }

        public async Task<C_ROLES> GetRol(Guid id)
        {
            try
            {
                var response = await _db.C_ROLES.FindAsync(id);
                return response == null ? new C_ROLES() : response;
            }
            catch (Exception)
            {
                return new C_ROLES();
            }
        }
        public async Task<List<C_ROLES>> GetRolAll(bool getDisp)
        {
            try
            {
                var response = getDisp == true ? await _db.C_ROLES.ToListAsync() : await _db.C_ROLES.Where(x => x.STATUS == true).ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<C_ROLES>();
            }
        }
        public async Task<string> CreateRol(C_ROLES c_ROLES)
        {
            try
            {
                c_ROLES.ROL_ID = Guid.NewGuid();
                c_ROLES.STATUS = true;

                _db.C_ROLES.Add(c_ROLES);
                await _db.SaveChangesAsync();

                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> UpdateRol(C_ROLES c_ROLES)
        {
            try
            {
                _db.Entry(c_ROLES).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return "Update";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> DeleteRol(Guid id)
        {
            try
            {
                var response = await _db.C_ROLES.FindAsync(id);

                if (response == null)
                    return "El usuario no existe";

                _db.C_ROLES.Remove(response);
                await _db.SaveChangesAsync();

                return "Delete";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> ChangeStatusRol(Guid id)
        {
            try
            {
                var response = await _db.C_ROLES.AsNoTracking().Where(x => x.ROL_ID == id).FirstOrDefaultAsync(); //consultar el registro

                if (response == null)
                    return "No existe el registro";

                _db.Entry(response).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return "ChangeStatus";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
