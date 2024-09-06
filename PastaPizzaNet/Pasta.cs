using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    internal class Pasta : Gerecht
    {
        public Pasta(string name, decimal prijs, string beschrijving)
            : base(name, prijs)
        {
            Beschrijving = beschrijving;
        }
        private string beschrijving;

        public string Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }
        public override decimal BerekenBedrag()
        {
            return Prijs;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {Beschrijving}";
                
        }
        public override string SchrijfWeg()
        {
            return $"Pasta#{Naam}-{Prijs}-{Beschrijving}";
        }

    }
}
