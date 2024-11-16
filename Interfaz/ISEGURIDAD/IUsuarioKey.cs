using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface IUsuarioKey
    {

        public Task<USUARIO_KEY> GetUsuario(Guid id);
        public Task<USUARIO_KEY> GetUsuarioKey(Guid id, Boolean status, string api_key);  
        

    }
}
