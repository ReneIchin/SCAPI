using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Service.SEG_SERVICE
{
    public class UsuarioKeyService : IUsuarioKey
    {
        private readonly DB_SEG _db;
        public UsuarioKeyService(DB_SEG db) 
        {
            this._db = db;
        }
        public async Task<USUARIO_KEY> GetUsuario(Guid id)
        {
            try
            {
                var response = await _db.USUARIO_KEY.FindAsync(id);

                if (response == null)
                    return new USUARIO_KEY();

                return response;
            }
            catch (Exception)
            {
                return new USUARIO_KEY();
            }
        }

        public async Task<USUARIO_KEY> GetUsuarioKey(Guid id, Boolean status, string api_key)
        {
            try
            {
                var response = await _db.USUARIO_KEY.Where(x=>x.API_KEY == api_key && x.STATUS == status && x.USUARIO_ID == id).FirstOrDefaultAsync();

                if (response == null)
                    return new USUARIO_KEY();

                return response;
            }
            catch (Exception)
            {
                return new USUARIO_KEY();
            }
        }

    }
}

//rene estuvo aqui, derechos reservados
