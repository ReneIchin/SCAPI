namespace SCAPI.Models.DTO.DB_SEG_DTO
{
    public class C_MODULO_DTO
    {
        public Guid SISTEMA_ID { get; set; }
        public Guid MODULO_ID { get; set; }
        public Guid GRUPO_MODULO_ID { get; set; }
        public string MODULO { get; set; } = null!;
        public int ORDEN { get; set; }
        public string? ICONO { get; set; }
        public string? RUTA { get; set; }

    }
}
