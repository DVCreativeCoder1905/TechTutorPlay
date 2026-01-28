using System;

namespace TechTutorPlay
{
    public class Security
    {
        private string AdminPassword = "TechTutor2026"; // Password simulata

        public bool Login(string inputPassword)
        {
            if (inputPassword == AdminPassword)
            {
                Console.WriteLine("[SECURITY] Accesso autorizzato. Benvenuto nel sistema.");
                return true;
            }
            else
            {
                Console.WriteLine("[SECURITY] ERRORE: Password errata. Accesso negato.");
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Security security = new Security();
            
            Console.WriteLine("=== Sistema di Sicurezza TechTutor ===");
            Console.Write("Inserisci la password: ");
            string password = Console.ReadLine();
            
            security.Login(password);
        }
    }
}