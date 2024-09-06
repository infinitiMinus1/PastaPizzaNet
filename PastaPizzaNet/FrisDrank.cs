using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class FrisDrank : Drank
    {
        private static readonly List<Dranken> koudeDranken = new List<Dranken>
        {
            Dranken.Water,
            Dranken.Limonade,
            Dranken.CocaCola
        };
        public FrisDrank(Dranken drink)
            : base(drink)
        {

            Prijs = koudeDranken.Contains(drink) ? 2m : throw new ArgumentException("Ongeldige drank voor FrisDrank");

        }
        
        public override decimal BerekenBedrag() {
            return Prijs;
        }
        public override string ToString()
        {
            return $"Drank: {Drink} (prijs: {Prijs} Euro)";
        }
        public override string SchrijfWeg()
        {
            return $"F-{Drink}";
        }




    }
}
