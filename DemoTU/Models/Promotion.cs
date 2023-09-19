using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTU.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public Diplome Diplome { get; set; }
        public List<Eleve> Eleves { get; } = new List<Eleve>();


        public override string ToString()
        {
            return $"Promotion {Nom} ({Debut.Year}-{Fin.Year}) - Diplôme {Diplome.Code} - {Eleves.Count} élèves";
        }
    }
}
