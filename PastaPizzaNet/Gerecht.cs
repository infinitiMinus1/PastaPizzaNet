using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public abstract class Gerecht
    {
        public Gerecht(string naam, decimal prijs) {

			Naam = naam;
			Prijs = prijs;
		}


		private string naam;

		public string Naam
		{
			get { return naam; }
			set { naam = value; }
		}
		private decimal prijs;

		public decimal Prijs
		{
			get { return prijs; }
			set { prijs = value; }
		}
        public abstract decimal BerekenBedrag();

		public virtual string ToString()
		{
			return $"Gerecht: {Naam} ({Prijs} Euro) ";				
		}
		public abstract string SchrijfWeg();

    }

}
