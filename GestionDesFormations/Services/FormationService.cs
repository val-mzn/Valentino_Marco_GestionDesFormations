using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionDesFormations
{
    class FormationService
    {
        public List<Formation> formations = new List<Formation>();
        private SaisieHelper sh = new SaisieHelper();

        public void ajouterFormation()
        {
            Console.WriteLine();
            string nom = sh.DemandeNom("nom: ");
            int code = sh.DemandeCode("code: ");
            while(getFormation(code) != null)
            {
                Console.WriteLine("Il y a deja une formation avec ce code");
                code = sh.DemandeCode("code: ");
            }
            int niveau = sh.DemandeCode("niveau: ");
            Console.WriteLine();

            Formation formation = new Formation() { nom = nom, code = code, niveau = niveau };
            formations.Add(formation);
        }

        public void listerFormation()
        {
            Console.WriteLine("\nAffichage des formations: ");
            Console.WriteLine("--------------------");

            foreach (Formation f in formations)
            {
                int total = 0;
                foreach (Matiere m in f.matieres)
                {
                    total += m.nb_heures;
                }
                Console.WriteLine("Matière: " + f.nom);
                Console.WriteLine("Code: " + f.code + ", Niveau: " + f.niveau + ", Total Heures: " + formatNumber(total));
                Console.WriteLine("--------------------\n");
            }
        }

        public Formation getFormation(int code)
        {
            try
            {
                Formation result = formations.Where(f => f.code == code).First();
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
