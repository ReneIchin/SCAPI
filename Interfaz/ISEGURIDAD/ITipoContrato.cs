using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface ITipoContrato
    {
        public Task<C_TIPO_CONTRATO> GetTipoContrato(Guid id);
        public Task<List<C_TIPO_CONTRATO>> GetTipoContratos(bool status);
        public Task<string> CreateTipoContrato(C_TIPO_CONTRATO c_TIPO_CONTRATO);
        public Task<string> UpdateTipoContrato(C_TIPO_CONTRATO c_TIPO_CONTRATO);
        public Task<string> DeleteTipoContrato(Guid id);
        public Task<string> ChangeStatusTipoContrato(Guid id, bool status);
    }
}
