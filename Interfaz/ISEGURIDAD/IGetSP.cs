using SCAPI.Models.DTO.DB_SEG_DTO;

namespace SCAPI.Interfaz.ISEGURIDAD
{
    public interface IGetSP
    {
        public Task<C_MODULO_DTO> getSistemaModulo(Guid id);
        public Task<DATOS_RESUM_USUARIO> GetDatosResumenUsuario();
    }

}
