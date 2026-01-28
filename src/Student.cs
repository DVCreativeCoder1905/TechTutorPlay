using System;

namespace TechTutorPlay.Models
{
    // Definiamo cosa è uno "Studente" nel nostro sistema
    public class Student
    {
        // Proprietà: i dati che ogni studente possiede
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsEnrolled { get; set; } // Indica se è iscritto a un corso

        // Costruttore: serve a creare un nuovo studente in modo rapido
        public Student(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            IsEnrolled = false; // Di base, un nuovo studente non è ancora iscritto
        }

        // Metodo: un'azione che lo studente può compiere
        public void Enroll()
        {
            IsEnrolled = true;
            Console.WriteLine($"[LOG] Lo studente {Name} è stato iscritto con successo.");
        }
    }
}
using System;
using System.Collections.Generic; // Necessario per usare List
using System.Linq; // Necessario per calcolare la media facilmente

namespace TechTutorPlay
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Nuova lista per memorizzare i voti (numeri decimali)
        public List<double> Voti { get; set; } = new List<double>();

        public Student(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        // Funzione per aggiungere un voto
        public void AggiungiVoto(double voto)
        {
            Voti.Add(voto);
            Console.WriteLine($"[LOG] Aggiunto voto {voto} a {Name}.");
        }

        // Funzione per calcolare la media
        public double CalcolaMedia()
        {
            if (Voti.Count == 0) return 0; // Se non ci sono voti, la media è 0
            return Voti.Average(); // Calcola la media matematica di tutti i voti
        }

        public void Enroll()
        {
            Console.WriteLine($"[LOG] {Name} (@techtutorplay.tech) è ora attivo nel database.");
        }
    }
}