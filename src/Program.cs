using System;
using System.Collections.Generic;
using TechTutorPlay.Models;

namespace TechTutorPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creiamo un database virtuale usando una lista di oggetti "Student"
            List<Student> databaseStudenti = new List<Student>();

            // Aggiungiamo te come amministratore e primo studente
            databaseStudenti.Add(new Student(1, "Daniele", "admin@techtutorplay.tech"));
            databaseStudenti.Add(new Student(2, "Marco Rossi", "marco@example.com"));

            Console.WriteLine("=== TechTutorPlay Enterprise Manager ===");

            // Simuliamo l'iscrizione automatica per tutti gli studenti nel database
            foreach (var s in databaseStudenti)
            {
                s.Enroll();
                Console.WriteLine($"Studente: {s.Name} | Email: {s.Email} | Status: {(s.IsEnrolled ? "Attivo" : "Inattivo")}");
            }

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Operazione completata. Sistema in attesa...");
            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;

namespace TechTutorPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creiamo lo studente Daniele
            Student daniele = new Student(1, "Daniele", "admin@techtutorplay.tech");
            daniele.Enroll();

            // Aggiungiamo dei voti simulati
            daniele.AggiungiVoto(8.5);
            daniele.AggiungiVoto(9.0);
            daniele.AggiungiVoto(7.5);

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Media voti di {daniele.Name}: {daniele.CalcolaMedia():F2}"); // F2 arrotonda a 2 decimali
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Premi un tasto per chiudere il sistema...");
            Console.ReadKey();
        }
    }
}