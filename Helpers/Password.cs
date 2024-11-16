using System.Security.Cryptography;
using System.Text;

namespace SCAPI.Helpers
{
    public class Password
    {
        public string Encrypt(String PASSWORD)
        {
            var keyByte = Encoding.UTF8.GetBytes("H8w,(wb6qxORSFe^(McRmtyDE!j7e,._}.Hl4.I]Jf[Rv%EGTq-S),");
            var cadena = "";
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(PASSWORD));
                cadena = this.ByteToString(hmacsha256.Hash);
            }
            return cadena;
        }

        public String ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2");
            }
            return sbinary;
        }
    }

    public class User
    {
        public string? USUARIO { get; set; }

        public Guid USUARIO_ID { get; set; }

        public User Identity(String user)
        {
            var ID = user.Split('%');

            if (ID.Length == 2)
            {
                return new User() { USUARIO = ID[0], USUARIO_ID = new Guid(ID[1]) };
            }
            return new User();

        }
    }

}
