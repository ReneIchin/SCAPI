using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface IEmpresas
    {
        public Task<C_EMPRESAS> GetEmpresa(Guid id);
        public Task<List<C_EMPRESAS>> GetEmpresas(bool status);
        public Task<string> CreateEmpresas(C_EMPRESAS c_EMPRESAS);
        public Task<string> UpdateEmpresas(C_EMPRESAS c_EMPRESAS);
        public Task<string> ChangeStatusEmpresas(Guid id, bool status);
    }
}
