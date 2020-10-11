using System;
using System.Text;

namespace ServiceApi.Business.Common
{
    public static class Helper
    {
        public static string EncryptPassword(string password)
        {
            string encrptedPassword = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            encrptedPassword = Convert.ToBase64String(encode);
            return encrptedPassword;
        }
    }
}
