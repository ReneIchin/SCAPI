using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface IGruposModulos
    {
        public Task<C_GRUPO_MODULO> GetGrupoModulo(Guid id);
        public Task<List<C_GRUPO_MODULO>> GetGruposModulos(Guid sistema_id, bool status);
    }
}
