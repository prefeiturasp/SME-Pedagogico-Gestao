using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SME.Pedagogico.Gestao.Data.Functionalities
{
    public static class Cryptography
    {
        private static string CleanString(string originalString, string[] parameters)
        {
            foreach (string character in parameters)
                originalString = originalString.Replace(character, string.Empty);

            return (originalString);
        }

        public static string CreateHashKey()
        {
            byte[] salt = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
                string hashKey = Convert.ToBase64String(salt);

                // Descomentar a linha abaixo para retirar do token os caracteres indesejados
                //refreshToken = CleanString(refreshToken, new string[] { "+", "=", "/" });

                return (hashKey);
            }
        }

        public static string HashPassword(string password, string salt)
        {
            return (Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)));
        }

        public static string HashPassword(string password)
        {
            return (HashPassword(password, "hUwq6ri6SyU6xb3ef4vuCg=="));
        }
    }
}