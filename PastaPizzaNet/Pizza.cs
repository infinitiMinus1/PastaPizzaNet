using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Pizza : Gerecht
    {
        public Pizza (string name, decimal prijs, List<string> onderdelen)
            : base (name, prijs)
        {
            Onderdelen = onderdelen ?? new List<string>();
        }
        private List<string> onderdelen;

        public List<string> Onderdelen
        {
            get { return onderdelen; }
            set { onderdelen = value; }
        }
        public override decimal BerekenBedrag() {
            return Prijs;
        }
        public override string ToString()
        {
            string onderdelenString = string.Join(" - ", Onderdelen);

            return $"{base.ToString()} {onderdelenString}";


        }
        public override string SchrijfWeg()
        {
            string onderdelenString = string.Join("#", Onderdelen);
            return $"Pizza#{Naam}-{Prijs}-{onderdelenString}";
        }
    }
}
