using Azure;
using Microsoft.EntityFrameworkCore;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;
using SCAPI.Models.DTO.DB_SEG_DTO;

namespace SCAPI.Service.SEG_SERVICE
{
    public class PermisoModuloService : IPermisosModulos
    {
        private readonly DB_SEG _db;

        public PermisoModuloService(DB_SEG context)
        {
            _db = context;
        }
        public async Task<PERMISOS_MODULOS> GetPermisoModulos(Guid id)
        {
            try
            {
                var response = await _db.PERMISOS_MODULOS.FindAsync(id);
                return response == null ? new PERMISOS_MODULOS() : response;
            }
            catch (Exception)
            {
                return new PERMISOS_MODULOS();
            }
        }

        public async Task<string> UpdatePmModulos(PERMISO_MODULO_CREATE_DTO pERMISO_MODULO_)
        {
            try
            {

                var getPermiso = await _db.PERMISOS_MODULOS
                    .Where(x =>
                    x.MODULO_ID == pERMISO_MODULO_.MODULO_ID &&
                    x.ROL_ID == pERMISO_MODULO_.ROL_ID &&
                    x.EMPRESA_ID == pERMISO_MODULO_.EMPRESA_ID &&
                    x.ACCION_ID == pERMISO_MODULO_.ACCION_ID).FirstOrDefaultAsync();


                if (getPermiso == null)
                { //No existe el permiso, crear el permiso

                    if (pERMISO_MODULO_.STATUS)
                    {
                        var datos = new PERMISOS_MODULOS();

                        datos.MODULO_ID = pERMISO_MODULO_.MODULO_ID;
                        datos.ROL_ID = pERMISO_MODULO_.ROL_ID;
                        datos.EMPRESA_ID = pERMISO_MODULO_.EMPRESA_ID;
                        datos.ACCION_ID = pERMISO_MODULO_.ACCION_ID;

                        return await CreatePermisoModulos(datos);
                    }
                }
                else
                {
                    if (!pERMISO_MODULO_.STATUS)
                        return await DeletePermisoModulos(getPermiso.PERMISO_MODULO_ID);
                }

                return "No hubo cambios";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public async Task<List<PERMISOS_MODULOS>> GetPermisoModulosAll(Guid idModulo, Guid idEmpresa, Guid idRol)
        {
            try
            {
                var respose = await _db.PERMISOS_MODULOS.Where(x => x.MODULO_ID == idModulo && x.EMPRESA_ID == idEmpresa && x.ROL_ID == idRol).ToListAsync();
                return respose;
            }
            catch (Exception)
            {
                return new List<PERMISOS_MODULOS>();
            }
        }


        public async Task<PERMISO_MODULO_DTO> GetPermisoModulosAllDTO(Guid idModulo, Guid idEmpresa, Guid idRol)
        {
            try
            {
                var datos = await _db.PERMISOS_MODULOS
                    .Where(x => x.MODULO_ID == idModulo && x.EMPRESA_ID == idEmpresa && x.ROL_ID == idRol)
                    .ToListAsync();

                var response = new PERMISO_MODULO_DTO()
                {
                    MODULO_ID = idModulo,
                    EMPRESA_ID = idEmpresa,
                    ROL_ID = idRol,
                    ACCIONES_ = await _db.C_ACCIONES.ToListAsync(),
                    ACCION_ID = datos.Select(x => x.ACCION_ID).ToList()
                };

                return response;
            }
            catch (Exception)
            {
                return new PERMISO_MODULO_DTO();
            }
        }
        public async Task<string> CreatePermisoModulos(PERMISOS_MODULOS pERMISOS_MODULOS)
        {
            try
            {
                pERMISOS_MODULOS.PERMISO_MODULO_ID = Guid.NewGuid();

                _db.PERMISOS_MODULOS.Add(pERMISOS_MODULOS);
                await _db.SaveChangesAsync();
                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> CreatePermisoModulosRange(List<PERMISOS_MODULOS> pERMISOS_MODULOS)
        {
            try
            {
                _db.PERMISOS_MODULOS.AddRange(pERMISOS_MODULOS);
                await _db.SaveChangesAsync();
                return "Create";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> UpdatePermisoModulos(PERMISOS_MODULOS pERMISOS_MODULOS)
        {
            try
            {
                _db.Entry(pERMISOS_MODULOS).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return "Update";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> DeletePermisoModulos(Guid id)
        {
            try
            {
                var response = await _db.PERMISOS_MODULOS.FindAsync(id);
                if (response == null)
                    return "El registro no existe";

                _db.PERMISOS_MODULOS.Remove(response);
                await _db.SaveChangesAsync();
                return "Delete";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
