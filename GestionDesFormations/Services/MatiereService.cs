using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionDesFormations
{
    class MatiereService
    {
        private List<Matiere> matieres = new List<Matiere>();
        private SaisieHelper sh = new SaisieHelper();
        private FormationService fs;

        public MatiereService(FormationService fs)
        {
            this.fs = fs;
        }

        public void ajouterMatiere()
        {
            Console.WriteLine();
            if (fs.formations.Count == 0)
            {
                Console.WriteLine("Vous devez au moins ajouter une formation avant\n");
                return;
            }

            string nom = sh.DemandeNom("nom: ");
            int code = sh.DemandeCode("code: ");
            while (getMatieres(code) != null)
            {
                Console.WriteLine("Il y a deja une matières avec ce code");
                code = sh.DemandeCode("code: ");
            }
            int nb_heures = sh.DemandeCode("nb heures: ");

            Console.Write("formation: ");
            Formation formation = null;
            do
            {
                int id;
                int.TryParse(Console.ReadLine(), out id);
                formation = fs.getFormation(id);
                if(formation == null) { Console.WriteLine("Aucune formation ne contient cette Id"); }            
            }
            while (formation == null);
            Console.WriteLine();

            Matiere matiere = new Matiere() { nom = nom, code = code, nb_heures = nb_heures, formation = formation };
            matieres.Add(matiere);
            formation.matieres.Add(matiere);
        }

        public void listerMatiere()
        {
            Console.WriteLine("\nAffichage des matières: ");
            Console.WriteLine("--------------------");
            foreach (Matiere m in matieres)
            {
                Console.WriteLine("Matière: " + m.nom);
                Console.WriteLine("Code: " + m.code + ", Nombre d'heures: " + m.nb_heures + ", Formation: " + m.formation.nom);
                Console.WriteLine("--------------------\n");
            }
        }

        public void totalNbHeures()
        {
            int total = 0;
            foreach(Matiere m in matieres)
            {
                total += m.nb_heures;
            }
            Console.WriteLine("\nAffichage du total d'heures: ");
            Console.WriteLine("--------------------");
            Console.WriteLine("Nombre d'heures total: " + formatNumber(total));
            Console.WriteLine("--------------------\n");
        }

        public Matiere getMatieres(int code)
        {
            try
            {
                Matiere result = matieres.Where(f => f.code == code).First();
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static string formatNumber(int number)
        {

            int index = 0;
            string result = "";
            foreach (char c in number.ToString())
            {
                if ((number.ToString().Length - index) % 3 == 0 && index != 0)
                {
                    result += ".";
                }
                result += c;
                index++;
            }
            return result;
        }
    }
}
