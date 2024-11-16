using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Service.SEG_SERVICE
{
    public class EmpresaService : IEmpresas
    {

        private readonly DB_SEG _db;

        public EmpresaService(DB_SEG context)
        {
            _db = context;
        }

        public async Task<C_EMPRESAS> GetEmpresa(Guid id)
        {
            try
            {
                var response = await _db.C_EMPRESAS.FindAsync(id);

                return response == null ? new C_EMPRESAS() : response;
            }
            catch (Exception)
            {
                return new C_EMPRESAS();
            }
        }
        public async Task<List<C_EMPRESAS>> GetEmpresas(bool status)
        {
            try
            {
                var response = await _db.C_EMPRESAS.ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<C_EMPRESAS>();
            }
        }
        public async Task<string> CreateEmpresas(C_EMPRESAS c_EMPRESAS)
        {
            try
            {
                c_EMPRESAS.EMPRESA_ID = Guid.NewGuid();
                c_EMPRESAS.FECHA_REG = DateTime.Now;
                c_EMPRESAS.FECHA_ULT_ACT = DateTime.Now;
                c_EMPRESAS.STATUS = true;

                _db.C_EMPRESAS.Add(c_EMPRESAS);
                await _db.SaveChangesAsync();

                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> UpdateEmpresas(C_EMPRESAS c_EMPRESAS)
        {
            try
            {
                c_EMPRESAS.FECHA_ULT_ACT = DateTime.Now;

                _db.Entry(c_EMPRESAS).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return "Update";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> ChangeStatusEmpresas(Guid id, bool status)
        {
            try
            {
                var response = await _db.C_EMPRESAS.FindAsync(id);
                if (response == null)
                    return "El registro no exite";

                response.STATUS = status;
                response.FECHA_ULT_ACT = DateTime.Now;

                return await UpdateEmpresas(response);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
