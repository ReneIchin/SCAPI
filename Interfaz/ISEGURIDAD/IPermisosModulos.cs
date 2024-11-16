using SCAPI.Models.DB_SEGURIDAD;
using SCAPI.Models.DTO.DB_SEG_DTO;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface IPermisosModulos
    {
        public Task<PERMISOS_MODULOS> GetPermisoModulos(Guid id);
        public Task<string> UpdatePmModulos(PERMISO_MODULO_CREATE_DTO pERMISO_MODULO_);
        public Task<List<PERMISOS_MODULOS>> GetPermisoModulosAll(Guid idModulo, Guid idEmpresa, Guid idRol);
        public Task<PERMISO_MODULO_DTO> GetPermisoModulosAllDTO(Guid idModulo, Guid idEmpresa, Guid idRol);
        public Task<string> CreatePermisoModulos(PERMISOS_MODULOS pERMISOS_MODULOS);
        public Task<string> CreatePermisoModulosRange(List<PERMISOS_MODULOS> pERMISOS_MODULOS);
        public Task<string> UpdatePermisoModulos(PERMISOS_MODULOS pERMISOS_MODULOS);
        public Task<string> DeletePermisoModulos(Guid id);
    }
}
