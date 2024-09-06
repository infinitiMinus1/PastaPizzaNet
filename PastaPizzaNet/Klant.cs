using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Klant
    {
        public static List<int> gebruikteKlantNummers = new List<int>();

        public Klant(string naam = "onbekend")
        {
            Naam = naam;
            KlantId = CreateNumber();
        }

        public string Naam { get; set; }

        public int KlantId { get; private set; }

        public string SchrijfWeg()
        {
            return $"#{KlantId} {Naam}";
        }
        private int CreateNumber()  // zodat geen klanten dezelfde nummer kunnen hebben

        {
            if (Naam != "onbekend")
            {
                int grootsteGetal = gebruikteKlantNummers.Any() ? gebruikteKlantNummers.Max() + 1 : 1;
                gebruikteKlantNummers.Add(grootsteGetal);
                return grootsteGetal;
            }
            else
            {
                return 0;         //behalve onbekende, die hebben allemaal een 0 als klantId
            }
        }
    }
}



