using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDesFormations
{
    class Matiere
    {
        public string nom { get; set; }
        public int code { get; set; }
        public int nb_heures { get; set; }
        public Formation formation { get; set; }
    }
}
