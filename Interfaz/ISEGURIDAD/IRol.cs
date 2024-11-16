using SCAPI.Models.DB_SEGURIDAD;
using SCAPI.Models.DTO;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface IRol
    {
        public Task<C_ROLES> GetRol(Guid id);
        public Task<List<C_ROLES>> GetRolAll(bool status);

    }
}
