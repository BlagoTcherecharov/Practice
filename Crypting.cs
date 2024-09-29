using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    internal class Crypting
    {
        public static string encrypt(string password)
        {
            System.Text.StringBuilder encryptedString = new System.Text.StringBuilder();

            for (int i = 0; i < password.Length; i++)
            {
                int letter = Convert.ToInt32(password[i]);
                string hex = letter.ToString("X");

                encryptedString.Append(hex);
            }
            return encryptedString.ToString();
        }

        public static string decrypt(string password)
        {
            StringBuilder decryptedString = new StringBuilder();

            for (int i = 0; i < password.Length; i += 2)
            {
                string hexChar = password.Substring(i, 2);
                int asciiValue = Convert.ToInt32(hexChar, 16);
                char character = (char)asciiValue;

                decryptedString.Append(character);
            }

            return decryptedString.ToString();
        }
    }
}
