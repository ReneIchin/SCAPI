using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Service.SEG_SERVICE
{
    public class TipoPagoService : ITiposPagos
    {
        private readonly DB_SEG _db;

        public TipoPagoService(DB_SEG context)
        {
            _db = context;
        }
        public async Task<C_TIPO_PAGO> GetTipoPago(Guid id)
        {
            try
            {
                var response = await _db.C_TIPO_PAGO.FindAsync(id);
                return response == null ? new C_TIPO_PAGO() : response;
            }
            catch (Exception)
            {
                return new C_TIPO_PAGO();
            }
        }
        public async Task<List<C_TIPO_PAGO>> GetTiposPagos(bool status)
        {
            try
            {
                var response = status == true ? await _db.C_TIPO_PAGO.ToListAsync() : await _db.C_TIPO_PAGO.Where(x => x.STATUS == true).ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<C_TIPO_PAGO>();
            }
        }
        public async Task<string> CreateTiposPagos(C_TIPO_PAGO c_TIPO_PAGO)
        {
            try
            {
                c_TIPO_PAGO.TIPO_PAGO_ID = Guid.NewGuid();
                c_TIPO_PAGO.STATUS = true;

                _db.C_TIPO_PAGO.Add(c_TIPO_PAGO);
                await _db.SaveChangesAsync();
                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> UpdateTiposPagos(C_TIPO_PAGO c_TIPO_PAGO)
        {
            try
            {
                _db.Entry(c_TIPO_PAGO).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return "Update";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> DeleteTiposPagos(Guid id)
        {
            try
            {
                var response = await _db.C_TIPO_PAGO.FindAsync(id);
                if (response == null)
                    return "No existe el Registro";

                _db.C_TIPO_PAGO.Remove(response);
                await _db.SaveChangesAsync();
                return "Delete";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> ChangeStatusTiposPagos(Guid id)
        {
            try
            {
                var response = await _db.C_TIPO_PAGO.FindAsync(id);
                if (response == null)
                    return "No existe el Registro";

                response.STATUS = false;

                return await UpdateTiposPagos(response);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
