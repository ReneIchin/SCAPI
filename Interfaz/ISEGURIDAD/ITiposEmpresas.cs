using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface ITiposEmpresas
    {
        public Task<C_TIPOS_EMPRESAS> GetTipoEmpresa(Guid id);
        public Task<List<C_TIPOS_EMPRESAS>> GetTiposEmpresas(bool status);
        public Task<string> CreateTiposEmpresas(C_TIPOS_EMPRESAS c_TIPOS_EMPRESAS);
        public Task<string> UpdateTiposEmpresas(C_TIPOS_EMPRESAS c_TIPOS_EMPRESAS);
        public Task<string> DeleteTiposEmpresas(Guid id);
        public Task<string> ChangeStatusTiposEmpresas(Guid id);
    }
}
