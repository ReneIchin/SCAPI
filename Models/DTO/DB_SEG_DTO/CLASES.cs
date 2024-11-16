namespace SCAPI.Models.DTO.DB_SEG_DTO
{
    public class CLASES
    {
    }

    public class GET_SISTEMA_MODULO
    {
        public Guid SISTEMA_ID { get; set; }
        public Guid GRUPO_MODULO_ID { get; set; }
    }

    public class DATOS_RESUM_USUARIO
    {
        public int TOTAL_USUARIO { get; set; }
        public int USUARIOS_ACTIVOS { get; set; }
        public int USUARIOS_DESACTIVADOS { get; set; }

    }



}
