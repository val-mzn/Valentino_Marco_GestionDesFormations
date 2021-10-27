using System;

namespace GestionDesFormations
{
    class Program
    {
        static void Main(string[] args)
        {
            FormationService fs = new FormationService();
            MatiereService ms = new MatiereService(fs);
            SaisieHelper sh = new SaisieHelper();
            
            Console.WriteLine("Hello World!");
            while (true)
            {
                Console.WriteLine(
                    "Que voulez vous faire ?\n" +
                    "1. Créer une nouvelle matière\n" +
                    "2. afficher l'ensemble des matières\n" +
                    "3. afficher le total d'heures\n" +
                    "4. créer une formation\n" +
                    "5. afficher les formations"
                );

                int choice = sh.DemandeEntreValeur(0, 5);
                if (choice == 1) { ms.ajouterMatiere(); }
                else if (choice == 2) { ms.listerMatiere(); }
                else if (choice == 3) { ms.totalNbHeures(); }
                else if (choice == 4) { fs.ajouterFormation(); }
                else if (choice == 5) { fs.listerFormation(); }
            }
        }
    }
}
