using SCAPI.Models.DB_SEGURIDAD;
using SCAPI.Models.DTO.DB_SEG_DTO;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface IUsuario
    {
        public Task<C_USUARIOS> GetUsuario(Guid id);
        public Task<List<C_USUARIOS>> GetUsuariosAll();
        public Task<C_USUARIOS> LoginUser(LOGIN_USER lOGIN_USER);
        public Task<string> CreateUsuario(C_USUARIOS c_USUARIOS);
        public Task<string> UpdateUsuario(C_USUARIOS c_USUARIOS);
        public Task<string> DeleteUsuario(Guid id);
        public Task<string> ChangeStatusUsuario(Guid id, bool status);


    }
}
