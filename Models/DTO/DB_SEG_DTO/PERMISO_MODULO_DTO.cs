using SCAPI.Models.DB_SEGURIDAD;

namespace SCAPI.Models.DTO.DB_SEG_DTO
{
    public class PERMISO_MODULO_DTO
    {
        public Guid SISTEMA_ID { get; set; }
        public Guid GRUPO_MODULO_ID { get; set; }
        public Guid MODULO_ID { get; set; }
        public Guid ROL_ID { get; set; }
        public Guid EMPRESA_ID { get; set; }
        public List<Guid> ACCION_ID { get; set; }
        public List<C_ACCIONES> ACCIONES_ { get; set; }
    }

    public class PERMISO_MODULO_CREATE_DTO
    {
        public Guid MODULO_ID { get; set; }
        public Guid ROL_ID { get; set; }
        public Guid EMPRESA_ID { get; set; }
        public Guid ACCION_ID { get; set; }
        public bool STATUS { get; set; }
    }

}
