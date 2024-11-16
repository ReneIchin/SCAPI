using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface IModulos
    {
        public Task<C_MODULOS> GetModulos(Guid id);
        public Task<List<C_MODULOS>> GetModulosAllGPO(Guid id);
    }
}
