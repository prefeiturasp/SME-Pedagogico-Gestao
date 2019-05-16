using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SME.Pedagogico.Gestao.ConsoleTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Hashed: {0}", Data.Functionalities.Cryptography.HashPassword(password));
        }
    }
}
