using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    internal class Bestelling
    {
        public Bestelling(GekozenGerecht gerecht = null, int aantal = 1, Drank drank = null, Dessert dessert = null, Klant klant = null)
        {
            Aantal = aantal;
            Klant = klant;
            Drank = drank;
            Dessert = dessert;
            Gerecht = gerecht;
        }
        public Bestelling()
        {

        }
        private Klant klant;

        public Klant Klant
        {
            get => klant; set
            {
                klant = value == null ? new Klant() : value;
            }
        }

        public int Aantal { get; set; } = 1;

        private GekozenGerecht gerecht;

        public GekozenGerecht Gerecht
        {
            get { return gerecht; }
            set { gerecht = value; }
        }

        private Drank drank;

        public Drank Drank
        {
            get { return drank; }
            set { drank = value; }
        }

        private Dessert dessert;

        public Dessert Dessert
        {
            get { return dessert; }
            set { dessert = value; }
        }

        bool Korting => Gerecht != null && Drank != null && Dessert != null;

        public decimal Totaal()
        {
            decimal totaal = 0;
            List<IBedrag> Bedrag = new List<IBedrag>();
            Bedrag.Add(Gerecht);
            Bedrag.Add(Dessert);
            Bedrag.Add(Drank);
            foreach (IBedrag item in Bedrag)
            {
                totaal += item != null ? item.BerekenBedrag() : 0;
            }
            if (Korting)
            {
                totaal *= 0.9m;
            }
            return totaal * Aantal;
        }

        public string Rekening()
        {
            string korting = "";
            if (Korting)

            {
                korting = "(met korting 10%)";
            }

            decimal totaal = Totaal();
            StringBuilder tot = new StringBuilder();
            tot.AppendLine($"Klant: {Klant.Naam} Klant nr: {Klant.KlantId}");
            tot.AppendLine("==========Rekening===========");
            tot.AppendLine(Gerecht != null ? $"{Gerecht.Gerecht.ToString()} {Gerecht.ToString()}" : "Geen hoofdgerecht");
            tot.AppendLine(Dessert != null ? $"Dessert: {Dessert.ToString()} " : "Geen dessert");
            tot.AppendLine(Drank != null ? $"{Drank.ToString()} " : "Geen drank");
            tot.AppendLine($"Aantal: {Aantal}");
            tot.AppendLine($"Totaal van deze bestelling {korting}: {totaal} Euro");

            return tot.ToString();
        }
        public string SchrijfWeg()
        {
            try
            {
                string nagerecht = Dessert != null ? Dessert.NaGerecht.ToString() : "";
                string drinken = Drank != null ? Drank.SchrijfWeg() : "";
                string hoofdgerecht = Gerecht != null ? Gerecht.SchrijfWeg() : "";

                return $"{Klant.KlantId}#{hoofdgerecht}#{drinken}#{nagerecht}#{Aantal}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Er is een fout opgetreden: {ex.Message}");
                return "Er is een fout opgetreden bij het opslaan van de bestelling.";
            }
        }
    }
}
