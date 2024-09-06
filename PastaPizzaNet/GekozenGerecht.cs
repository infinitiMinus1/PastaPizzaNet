using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
	public class GekozenGerecht : IBedrag
    {

        public GekozenGerecht(Gerecht gerecht, List<Extras> extras , Grootte grootte)
        {
            Gerecht = gerecht;
            Grootte = grootte;
            Extras = extras;

        }

        private Gerecht gerecht;

		public Gerecht Gerecht
		{
			get { return gerecht; }
			set { gerecht = value; }
		}

        private Grootte grootte;

        public Grootte Grootte
        {
            get { return grootte; }
            set { grootte = value; }
        }
        private List<Extras> extras;

        public List<Extras> Extras
            { get { return extras; } set { extras = value; } }


        //public abstract decimal BerekenBedrag();

        public decimal BerekenBedrag()
        {
            decimal prijsExtras = Extras.Count();
            decimal prijsHoofdGerecht = Gerecht.Prijs;
            return  prijsExtras + prijsHoofdGerecht + (Grootte == Grootte.groot ? 3m : 0m);
            
        }
        public string ToString()
        {
            string extrasLijst = string.Join(" - ", Extras);
            string bijgerechten = Extras.Count == 0 ? "" : $"Extra: {extrasLijst}";
            return $"({Grootte}) {bijgerechten} (Prijs: {BerekenBedrag()} Euro)";
        }
        public string SchrijfWeg()
        {
            return $"{Gerecht.Naam}-{Grootte}-{Extras.Count}-{string.Join("-", Extras)}";
        }

    }

}
