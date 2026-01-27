using System;

namespace TechTutorPlay.Security
{
    // Questa classe gestisce la logica di accesso simulata per il portale
    class LoginSecurity
    {
        static void Main(string[] args)
        {
            // Definiamo le credenziali di test per il tuo progetto educativo
            string usernameCorretto = "admin@techtutorplay.tech";
            int pinSicurezza = 2026; // L'anno del tuo grande progetto

            Console.WriteLine("=== TechTutorPlay: Sistema di Accesso Protetto ===");

            // Chiediamo all'utente di inserire il PIN (simulazione)
            Console.Write("Inserire il PIN di accesso per l'amministratore: ");
            string inputUtente = Console.ReadLine();

            // Convertiamo l'input in numero e verifichiamo se è corretto
            if (inputUtente == pinSicurezza.ToString())
            {
                // Messaggio in caso di successo
                Console.WriteLine("\n[SUCCESS] Accesso autorizzato a TechTutorPlay Lab.");
                Console.WriteLine($"Benvenuto, {usernameCorretto}!");
            }
            else
            {
                // Messaggio in caso di errore (Simula un log di sicurezza)
                Console.WriteLine("\n[ERROR] PIN errato. Tentativo di accesso registrato.");
            }

            // Mantiene la finestra aperta per vedere il risultato
            Console.WriteLine("\nPremere un tasto per terminare la sessione di test.");
            Console.ReadKey();
        }
    }
}
