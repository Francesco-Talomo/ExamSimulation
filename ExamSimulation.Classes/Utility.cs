using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExamSimulation.Classes
{
    public class Utility
    {
        public string EncryptPassword(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] resultHash;
            SHA512 shaM = new SHA512Managed();
            resultHash = shaM.ComputeHash(data);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < resultHash.Length; i++)
            {
                result.Append(resultHash[i].ToString("X2").ToLower());
            }
            return result.ToString();
        }
    }
}