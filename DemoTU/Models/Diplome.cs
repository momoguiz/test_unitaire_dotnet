using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTU.Models
{
    public class Diplome
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public int Niveau { get; set; }
        public List<Promotion> Promotions { get; } = new List<Promotion>();

        public override string ToString()
        {
            return Nom;
        }
    }
}
