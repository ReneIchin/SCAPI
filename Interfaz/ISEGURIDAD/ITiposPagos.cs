using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface ITiposPagos
    {
        public Task<C_TIPO_PAGO> GetTipoPago(Guid id);
        public Task<List<C_TIPO_PAGO>> GetTiposPagos(bool status);
        public Task<string> CreateTiposPagos(C_TIPO_PAGO c_TIPO_PAGO);
        public Task<string> UpdateTiposPagos(C_TIPO_PAGO c_TIPO_PAGO);
        public Task<string> DeleteTiposPagos(Guid id);
        public Task<string> ChangeStatusTiposPagos(Guid id);
    }
}
