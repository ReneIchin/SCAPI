using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Service.SEG_SERVICE
{
    public class TipoContratoService : ITipoContrato
    {
        private readonly DB_SEG _db;

        public TipoContratoService(DB_SEG db)
        {
            _db = db;
        }
        public async Task<C_TIPO_CONTRATO> GetTipoContrato(Guid id)
        {
            try
            {
                var response = await _db.C_TIPO_CONTRATO.FindAsync(id);
                if (response == null)
                    return new C_TIPO_CONTRATO();

                return response;
            }
            catch (Exception)
            {
                return new C_TIPO_CONTRATO();
            }
        }
        public async Task<List<C_TIPO_CONTRATO>> GetTipoContratos(bool status)
        {
            try
            {
                var response = status == true ? await _db.C_TIPO_CONTRATO.Where(x => x.STATUS == true).ToListAsync() : await _db.C_TIPO_CONTRATO.ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<C_TIPO_CONTRATO>();
            }
        }
        public async Task<string> CreateTipoContrato(C_TIPO_CONTRATO c_TIPO_CONTRATO)
        {
            try
            {
                c_TIPO_CONTRATO.TIPO_CONTRATO_ID = Guid.NewGuid();
                c_TIPO_CONTRATO.STATUS = true;

                _db.Add(c_TIPO_CONTRATO);
                await _db.SaveChangesAsync();
                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> UpdateTipoContrato(C_TIPO_CONTRATO c_TIPO_CONTRATO)
        {
            try
            {
                _db.Entry(c_TIPO_CONTRATO).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return "Update";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> DeleteTipoContrato(Guid id)
        {
            try
            {
                var response = await _db.C_TIPO_CONTRATO.FindAsync(id);

                if (response == null)
                    return "No existe ningun registro";

                _db.C_TIPO_CONTRATO.Remove(response);
                await _db.SaveChangesAsync();
                return "Delete";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> ChangeStatusTipoContrato(Guid id, bool status)
        {
            try
            {
                var response = await _db.C_TIPO_CONTRATO.FindAsync(id);

                if (response == null)
                    return "No existe ningun registro";

                response.STATUS = status;

                return await UpdateTipoContrato(response);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
