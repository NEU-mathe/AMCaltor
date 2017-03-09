using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DecryptImg
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertAndSave(base64(args[0], keyStr), args[1]);
        }

        public static string keyStr = "vb%$78)";
        public static string base64(string filePath, string keyStr)
        {
            string str2;
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                FileStream stream = System.IO.File.OpenRead(filePath);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
                stream.Close();
                byte[] bytes = Encoding.Default.GetBytes(keyStr);
                byte[] buffer3 = new SHA1Managed().ComputeHash(bytes);
                byte[] buffer4 = new byte[8];
                byte[] buffer5 = new byte[8];
                for (int i = 0; i < 8; i++)
                {
                    buffer4[i] = buffer3[i];
                }
                for (int j = 8; j < 0x10; j++)
                {
                    buffer5[j - 8] = buffer3[j];
                }
                provider.Key = buffer4;
                provider.IV = buffer5;
                MemoryStream stream2 = new MemoryStream();
                CryptoStream stream3 = new CryptoStream(stream2, provider.CreateDecryptor(), CryptoStreamMode.Write);
                stream3.Write(buffer, 0, buffer.Length);
                stream3.FlushFinalBlock();
                string str = Convert.ToBase64String(stream2.ToArray());
                stream3.Close();
                stream2.Close();
                str2 = str;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str2;
        }
        public static void ConvertAndSave(string imgText, string imgPath)
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(imgText));
            Bitmap img = new Bitmap(stream);
            img.Save(imgPath);
        }
    }
}
