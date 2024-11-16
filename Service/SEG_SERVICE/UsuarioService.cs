using Microsoft.EntityFrameworkCore;
using SCAPI.Helpers;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;
using SCAPI.Models.DTO.DB_SEG_DTO;

namespace SCAPI.Service.SEG_SERVICE
{
    public class UsuarioService : IUsuario
    {
        private readonly DB_SEG _db;

        public UsuarioService(DB_SEG context)
        {
            _db = context;
        }

        public async Task<C_USUARIOS> GetUsuario(Guid id)
        {
            try
            {
                var response = await _db.C_USUARIOS.FindAsync(id);
                return response == null ? new C_USUARIOS() : response;
            }
            catch (Exception)
            {
                return new C_USUARIOS();
            }
        }
        public async Task<List<C_USUARIOS>> GetUsuariosAll()
        {
            try
            {
                var response = await _db.C_USUARIOS.ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<C_USUARIOS>();
            }
        }
        public async Task<C_USUARIOS> LoginUser(LOGIN_USER lOGIN_USER)
        {
            try
            {
                var password = new Password().Encrypt(lOGIN_USER.PASSWORD);
                var response = await _db.C_USUARIOS.Include(x => x.USUARIO_ROLES).Where(x => x.USERNAME == lOGIN_USER.USERNAME && x.PASSWORD == password).FirstOrDefaultAsync();

                return response == null ? new C_USUARIOS() : response;
            }
            catch (Exception)
            {
                return new C_USUARIOS();
            }
        }

        public async Task<string> CreateUsuario(C_USUARIOS c_USUARIOS)
        {
            try
            {
                c_USUARIOS.USUARIO_ID = Guid.NewGuid();
                c_USUARIOS.PASSWORD = new Password().Encrypt(c_USUARIOS.PASSWORD);
                c_USUARIOS.FECHA_REG = DateTime.Now;
                c_USUARIOS.STATUS = true;

                _db.C_USUARIOS.Add(c_USUARIOS);
                await _db.SaveChangesAsync();

                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> UpdateUsuario(C_USUARIOS c_USUARIOS)
        {
            try
            {
                //c_USUARIOS.FECHA_REG = DateTime.Now;
                //incluir datos de actualizacion

                var response = await _db.C_USUARIOS.AsNoTracking().Where(x => x.USUARIO_ID == c_USUARIOS.USUARIO_ID).FirstOrDefaultAsync(); //consultar el registro

                if (response == null)
                    return "sin registros de usuario";

                if (!string.IsNullOrWhiteSpace(c_USUARIOS.PASSWORD))
                {
                    var password = new Password().Encrypt(c_USUARIOS.PASSWORD);

                    if (password != response.PASSWORD)
                    {
                        c_USUARIOS.PASSWORD = password;
                    }
                    else
                    {
                        c_USUARIOS.PASSWORD = response.PASSWORD;
                    }
                }
                else
                {
                    c_USUARIOS.PASSWORD = response.PASSWORD;
                }


                _db.Entry(c_USUARIOS).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return "Update";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> DeleteUsuario(Guid id)
        {
            try
            {
                var response = await _db.C_USUARIOS.FindAsync(id);

                if (response == null)
                    return "El usuario no existe";

                _db.C_USUARIOS.Remove(response);
                await _db.SaveChangesAsync();

                return "Delete";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public async Task<string> ChangeStatusUsuario(Guid id, bool status)
        {
            try
            {
                var response = await _db.C_USUARIOS.FindAsync(id); //consultar el registro
                if (response == null)
                    return "No existe el registro";
                response.STATUS = status;
                return await UpdateUsuario(response);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


    }
}
