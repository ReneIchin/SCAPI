using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface IAcciones
    {
        public Task<C_ACCIONES> GetAccion(Guid id);
        public Task<List<C_ACCIONES>> GetAcciones(bool status);

    }
}
