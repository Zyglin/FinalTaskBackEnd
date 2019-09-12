using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebFilms.DataAccess
{
    public class PBKDF2Helper
    {
        const int DEFAULT_ITERATIONS = 15_000;
        const int HASH_SIZE = 32;

        public static string CalculateHash(string password)
        {
            return CalculateHash(password, GenerateSalt(12), DEFAULT_ITERATIONS);
        }

        static string CalculateHash(string password, byte[] salt, int iterations)
        {
            using (Rfc2898DeriveBytes Hash = new Rfc2898DeriveBytes(
                Encoding.UTF8.GetBytes(password),
                salt,
                DEFAULT_ITERATIONS
            ))
            {
                byte[] hash = Hash.GetBytes(HASH_SIZE);

                return DEFAULT_ITERATIONS + "|" + Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hash);
            }
        }

        public static bool IsValidHash(string password, string hashToCheck)
        {
            string[] hashParts = hashToCheck.Split('|');
            int iterations = int.Parse(hashParts[0]);
            byte[] salt = Convert.FromBase64String(hashParts[1]);

            string newHash = CalculateHash(password, salt, iterations);
            return hashToCheck == newHash;
        }


        static byte[] GenerateSalt(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[length];
                rng.GetBytes(salt);
                return salt;
            }
        }
    }
}
