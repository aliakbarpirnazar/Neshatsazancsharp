using System.Security.Cryptography;
using System.Text;

namespace _0_Framework.Application
{
    public class HashGenerators
    {
        public static string MD5Encoding(string password)
        {
            Byte[] mainByte;
            Byte[] encodeByte;

            MD5 md5;

            md5 = new MD5CryptoServiceProvider();
            mainByte = ASCIIEncoding.Default.GetBytes(password);
            encodeByte = md5.ComputeHash(mainByte);

            return BitConverter.ToString(encodeByte);
        }
    }
}
