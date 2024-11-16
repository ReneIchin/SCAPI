using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface ISistemas
    {
        public Task<C_SISTEMAS> GetSistema(Guid id);
        public Task<List<C_SISTEMAS>> GetSistemas(bool status);
    }
}
