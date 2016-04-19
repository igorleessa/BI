using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BIWebServices.CORE
{
    public class CriptografiaFO
    {

        public static string EncriptarMD5(string TokenAcesso)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(TokenAcesso));

                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar hash MD5: " + ex.Message);
            }

        }
    }
}