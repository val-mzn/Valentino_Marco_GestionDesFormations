using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDesFormations
{
    class SaisieHelper
    {
        public int DemandeEntreValeur(int min, int max)
        {
            int choice = min - 1;
            while (choice < min || choice > max)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice < min || choice > max)
                    {
                        Console.WriteLine("Entrée non valide doit être comprie entre: (" + max + "-" + min + ")");
                    }
                }
                catch
                {
                    Console.WriteLine("Entrée non valide doit être comprie entre: (" + max + "-" + min + ")");
                }
            }
            return choice;
        }

        public string DemandeNom(string message)
        {
            string nom = "";
            while (nom == "")
            {
                Console.Write(message);
                nom = Console.ReadLine();
                int n;

                if (nom == "")
                {
                    Console.WriteLine("Le nom ne peux pas etre vide");
                }
                else if (!char.IsUpper(nom[0]))
                {
                    Console.WriteLine("Le nom doit commencer par une majuscule");
                    nom = "";
                }
                else if (int.TryParse(nom, out n))
                {
                    Console.WriteLine("Le nom doit contenir une lettre");
                    nom = "";
                }
            }
            return nom;
        }

        public int DemandeCode(string message)
        {
            int code = -1;
            while (code <= 0)
            {

                Console.Write(message);
                var entry = Console.ReadLine();
                bool isInteger = int.TryParse(entry, out code);
                if (!isInteger)
                {
                    Console.WriteLine("Le code doit etre numérique");
                    code = -1;
                }
                else if (code <= 0)
                {
                    Console.WriteLine("Le code doit etre suppérieur a 0");
                }

            }
            return code;
        }
    }
}
