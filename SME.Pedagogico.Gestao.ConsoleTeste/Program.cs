using System;

namespace SME.Pedagogico.Gestao.ConsoleTeste
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter a password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Hashed: {0}", Data.Functionalities.Cryptography.HashPassword(password));
        }
    }
}