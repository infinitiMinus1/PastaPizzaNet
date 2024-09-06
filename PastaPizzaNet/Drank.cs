using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public abstract class Drank : IBedrag
    {
        public Drank(Dranken drink)
        {

            Drink = drink;

        }
        public decimal Prijs { get; protected set; }

        private Dranken drink;

        public Dranken Drink
        {
            get { return drink; }
            set { drink = value; }
        }

        public abstract decimal BerekenBedrag();

        public abstract override string ToString();

        public abstract string SchrijfWeg();

    }
}
