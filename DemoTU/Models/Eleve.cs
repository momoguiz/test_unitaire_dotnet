using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTU.Models
{
    public class Eleve
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public List<Promotion> Promotions { get; } = new List<Promotion>();

        public override string ToString()
        {
            return $"{Prenom} {Nom}";
        }
    }
}
