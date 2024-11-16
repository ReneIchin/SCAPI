namespace SCAPI.Models.DTO.DB_SEG_DTO
{
    public class LOGIN_USER
    {
        public string USERNAME { get; set; } = string.Empty;
        public string PASSWORD { get; set; } = string.Empty;
    }

    public class RESPONSE_LOGIN
    {
        public string USERNAME { get; set; } = string.Empty;
        public string USUARIO_ID { get; set; } = string.Empty;
        public List<string>? ROL_ID { get; set; }
    }


}
