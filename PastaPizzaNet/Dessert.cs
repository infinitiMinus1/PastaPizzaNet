using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    internal class Dessert : IBedrag
    {
        public Dessert(Desserten naGerecht) {

            NaGerecht = naGerecht;
            Prijs = naGerecht == Desserten.Cake ? 2m : 3m;


        }
        public decimal Prijs { get; set; }

        private Desserten naGerecht;

        public Desserten NaGerecht
        {
            get { return naGerecht; }
            set {
                switch (value)
                {
                    case Desserten.Tiramisu:
                    case Desserten.Cake:
                    case Desserten.Ijs:
                        naGerecht = value;
                        break;
                    default: throw new ArgumentException("Geen geldig dessert");
                }
                 
            }
        }


        public decimal BerekenBedrag()
        {
            return Prijs;
        }
        public string ToString()
        {
            return $"{NaGerecht} (Prijs: {Prijs} Euro)";
        }
    }
}
