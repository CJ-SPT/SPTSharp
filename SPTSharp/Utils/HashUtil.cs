using System.Security.Cryptography;
using System.Text;

namespace SPTSharp.Utils
{
    public static class HashUtil
    {
        public static int GenerateAccountId() 
        {
            int min = 1000000;
            int max = 1999999;

            Random random = new Random();
            return random.Next(min, max + 1);
        }

        /// <summary>
        /// Generates a unique 24 character string using SHA256 encryption algorithm.
        /// </summary>
        /// <returns>24 character unique hash</returns>
        public static string GenerateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string currentTime = DateTime.UtcNow.Ticks.ToString();

                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(currentTime));

                StringBuilder stringBuilder = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }

                return stringBuilder.ToString().Substring(0, 24);
            }
        }
    }
}
