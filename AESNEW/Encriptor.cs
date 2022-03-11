using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace AESNEW
{
    class Encriptor
    {

        public static string IV = "1a1a1a1a1a1a1a1a";
        public static string Key = "1a1a1a1a1a1a1a1a1a1a1a1a1a1a1a13";

        public static string Encript(string decriped)
        {
            byte[] textByte = ASCIIEncoding.ASCII.GetBytes(decriped);
            AesCryptoServiceProvider endec = new AesCryptoServiceProvider();
            endec.BlockSize = 128;
            endec.KeySize = 256;
            endec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            endec.Key = ASCIIEncoding.ASCII.GetBytes(Key);
            endec.Padding = PaddingMode.PKCS7;
            endec.Mode = CipherMode.CBC;
            ICryptoTransform icrypt = endec.CreateEncryptor(endec.Key, endec.IV);
            byte[] enc = icrypt.TransformFinalBlock(textByte, 0, textByte.Length);
            icrypt.Dispose();
            return Convert.ToBase64String(enc);
            


        }

        public static string Decrypte(string encrypted)
        {

            var check = Form1.verify;
            string password = Form1.password;
            if (check == password)
            {
                
                byte[] textBytes = Convert.FromBase64String(encrypted);
                AesCryptoServiceProvider endec = new AesCryptoServiceProvider();
                endec.BlockSize = 128;
                endec.KeySize = 256;
                endec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
                endec.Key = ASCIIEncoding.ASCII.GetBytes(Key);
                endec.Mode = CipherMode.CBC;
                ICryptoTransform icrypt = endec.CreateDecryptor(endec.Key, endec.IV);
                byte[] enc = icrypt.TransformFinalBlock(textBytes, 0, textBytes.Length);
                icrypt.Dispose();
            }

            /*if (Form1.verify == password)
            {
                return System.Text.ASCIIEncoding.ASCII.GetString(enc);
            }
            else if (Form1.verify != password)
            {
                MessageBox.Show("Use originas key file");
            }*/

            return encrypted;
        }
        

    }
}
