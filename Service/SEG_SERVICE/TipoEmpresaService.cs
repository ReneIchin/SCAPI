using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Service.SEG_SERVICE
{
    public class TipoEmpresaService : ITiposEmpresas
    {
        private readonly DB_SEG _db;

        public TipoEmpresaService(DB_SEG context)
        {
            _db = context;
        }
        public async Task<C_TIPOS_EMPRESAS> GetTipoEmpresa(Guid id)
        {
            try
            {
                var response = await _db.C_TIPOS_EMPRESAS.FindAsync(id);
                return response == null ? new C_TIPOS_EMPRESAS() : response;
            }
            catch (Exception)
            {
                return new C_TIPOS_EMPRESAS();
            }
        }
        public async Task<List<C_TIPOS_EMPRESAS>> GetTiposEmpresas(bool status)
        {
            try
            {
                var response = status == true ? await _db.C_TIPOS_EMPRESAS.ToListAsync() : await _db.C_TIPOS_EMPRESAS.Where(x => x.STATUS == true).ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<C_TIPOS_EMPRESAS>();
            }
        }
        public async Task<string> CreateTiposEmpresas(C_TIPOS_EMPRESAS c_TIPOS_EMPRESAS)
        {
            try
            {
                c_TIPOS_EMPRESAS.TIPO_EMPRESA_ID = Guid.NewGuid();
                c_TIPOS_EMPRESAS.STATUS = true;

                _db.C_TIPOS_EMPRESAS.Add(c_TIPOS_EMPRESAS);
                await _db.SaveChangesAsync();
                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> UpdateTiposEmpresas(C_TIPOS_EMPRESAS c_TIPOS_EMPRESAS)
        {
            try
            {
                _db.Entry(c_TIPOS_EMPRESAS).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return "Update";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> DeleteTiposEmpresas(Guid id)
        {
            try
            {
                var response = await _db.C_TIPOS_EMPRESAS.FindAsync(id);

                if (response == null)
                    return "No existe el registro";

                _db.C_TIPOS_EMPRESAS.Remove(response);
                await _db.SaveChangesAsync();
                return "Delete";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> ChangeStatusTiposEmpresas(Guid id)
        {
            try
            {
                var response = await _db.C_TIPOS_EMPRESAS.FindAsync(id);

                if (response == null)
                    return "No existe el registro";
                response.STATUS = true;

                return await UpdateTiposEmpresas(response);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
