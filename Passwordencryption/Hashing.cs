using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Passwordencryption
{
    public enum Supported_HA
    {
        SHA256, SHA384, SHA512
    }
    class Hashing
    {
        public static string ComputeHash(string plainText, Supported_HA hash, byte[] salt)
        {
            int minSaltLength = 4;
            int maxSaltLength = 16;

            byte[] SaltBytes = null;

            if (salt != null)
            {
                SaltBytes = salt;
            }
            else
            {
                Random r = new Random();
                int SaltLength = r.Next(minSaltLength, maxSaltLength);
                SaltBytes = new byte[SaltLength];
                RNGCryptoServiceProvider reg = new RNGCryptoServiceProvider();
                reg.GetNonZeroBytes(SaltBytes);
                reg.Dispose();
            }

            byte[] plainData = ASCIIEncoding.UTF8.GetBytes(plainText);
            byte[] plainDataAndSalt = new byte[plainData.Length + SaltBytes.Length];

            for (int x = 0; x < plainData.Length; x++)
                plainDataAndSalt[x] =  plainData[x];
            for (int n = 0; n < SaltBytes.Length; n++)
                plainDataAndSalt[plainData.Length + n] = SaltBytes[n];

            byte[] hashValue = null;

            switch (hash)
            {
                case Supported_HA.SHA256:
                    SHA256Managed sha = new SHA256Managed();
                    hashValue = sha.ComputeHash(plainDataAndSalt);
                    sha.Dispose();
                    break;
                case Supported_HA.SHA384:
                    SHA384Managed sha1 = new SHA384Managed();
                    hashValue = sha1.ComputeHash(plainDataAndSalt);
                    sha1.Dispose();
                    break;
                case Supported_HA.SHA512:
                    SHA512Managed sha2 = new SHA512Managed();
                    hashValue = sha2.ComputeHash(plainDataAndSalt);
                    sha2.Dispose();
                    break;

            }

            byte[] result = new byte[hashValue.Length + SaltBytes.Length];

            for (int x = 0; x < hashValue.Length; x++)
                result[x] = hashValue[x];
            for (int n = 0; n < SaltBytes.Length; n++)
                result[hashValue.Length + n] = SaltBytes[n];

            return Convert.ToBase64String(result);

        }

        public static bool Confirm(string plainText , string hashValue, Supported_HA hash)
        {
            byte[] hashBytes = Convert.FromBase64String(hashValue);
            int hashSize = 0;

            switch (hash)
            {
                case Supported_HA.SHA256:
                    hashSize = 32;
                    break;
                case Supported_HA.SHA384:
                    hashSize = 48;
                    break;
                case Supported_HA.SHA512:
                    hashSize = 64;
                    break;
            }
            byte[] saltBytes = new byte[hashBytes.Length - hashSize];

            for (int x = 0; x < saltBytes.Length; x++)
                saltBytes[x] = hashBytes[hashSize + x];

            string NewHash = ComputeHash(plainText, hash, saltBytes);

            return (hashValue == NewHash);
        }
    }
}
