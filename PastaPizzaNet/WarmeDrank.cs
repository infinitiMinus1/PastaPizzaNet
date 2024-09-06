using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class WarmeDrank : Drank
    {
        private static readonly List<Dranken> warmeDranken = new List<Dranken>
        {
            Dranken.Koffie,
            Dranken.Thee
        };

        public WarmeDrank(Dranken drink)
        : base(drink)
        {

            Prijs = warmeDranken.Contains(drink) ? 2.5m : throw new ArgumentException("Ongeldige warme dranknaam.");

        }

        public override decimal BerekenBedrag()
        {
            return Prijs;
        }
        public override string ToString()
        {
            return $"Drank: {Drink} (prijs: {Prijs} Euro)";
        }
        public override string SchrijfWeg()
        {
            return $"W-{Drink}";
        }
    }
}
