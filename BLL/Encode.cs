using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace BLL
{
    public class Encode
    {
        public static string GenerateMD5(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
                byte[] buffer = Encoding.Default.GetBytes(txt);
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
