using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; 

namespace Inventory
{
    class Hash
    {
        public static string ComputeHash(string plainTextPass, byte[] salt)
        {
            int minSaltLength = 4, maxSaltLength = 16;

            byte[] saltBytes = null;
            if(salt != null)
            {
                saltBytes = salt;
            }
            else
            {
                Random r = new Random();
                int SaltLength = r.Next(minSaltLength, maxSaltLength);
                saltBytes = new byte[SaltLength];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(saltBytes);
                rng.Dispose();
            }

            byte[] plainData = ASCIIEncoding.UTF8.GetBytes(plainTextPass);
            byte[] plainDataWithSalt = new byte[plainData.Length + saltBytes.Length];
            
            for(int x = 0; x < plainData.Length; x++)
            {
                plainDataWithSalt[x] = plainData[x];
            }
            for(int n = 0; n < saltBytes.Length; n++)
            {
                plainDataWithSalt[plainData.Length + n] = saltBytes[n];
            }

            byte[] hashValue = null;

            SHA256Managed sha = new SHA256Managed();
            hashValue = sha.ComputeHash(plainDataWithSalt);
            sha.Dispose();

            byte[] result = new byte[hashValue.Length + saltBytes.Length];

            for (int x = 0; x < hashValue.Length; x++)
            {
                result[x] = hashValue[x];
            }
                
            for (int n = 0; n < saltBytes.Length; n++)
            {
                result[hashValue.Length + n] = saltBytes[n];
            }
            return Convert.ToBase64String(result);
        }
        public static bool Confirm(string plainTextPass, string hashValue)
        {
            byte[] hashBytes = Convert.FromBase64String(hashValue);
            int hashSize = 32;

            byte[] saltBytes = new byte[hashBytes.Length - hashSize];

            for (int x = 0; x < saltBytes.Length; x++)
            {
                saltBytes[x] = hashBytes[hashSize + x];
            }
                
            string newHash = ComputeHash(plainTextPass, saltBytes);

            return (hashValue == newHash);
        }
         
    }
}
