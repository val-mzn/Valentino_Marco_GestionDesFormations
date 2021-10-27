using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDesFormations
{
    class Formation
    {
        public string nom { get; set; }
        public int code { get; set; }
        public int niveau { get; set; }
        public List<Matiere> matieres = new List<Matiere>();

    }
}
