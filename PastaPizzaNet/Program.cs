using PastaPizzaNet;
using System.Linq.Expressions;

//Klanten
Klant unknown = new();
Klant nr001 = new("Tom Brady");
var nr002 = new Klant("Peter Griffin");
Klant nr003 = new("Jan Jannsen");
//gerechten
var scampi = new Pasta("spaghetti scampi", 10, "met kaas en scampis");
var bolognese = new Pasta("Spaghetti Bolognese", 10m, "met gehakt en tomatensaus");
var hawaii = new Pizza("Pizza hawaii", 10, new List<string> { "ananas", "kaas" });
var bbq = new Pizza("Pizza Barbeque", 12, new List<string> { "crispy bacon", "BBQ_saus", "kaas" });
var carbonara = new Pizza("Pizza Carbonara", 8, new List<string> { "hesp", "kaas" });

List<Gerecht> beschikbareGerechten = new List<Gerecht>();
beschikbareGerechten.Add(scampi);
beschikbareGerechten.Add(bolognese);
beschikbareGerechten.Add(hawaii);
beschikbareGerechten.Add(bbq);
beschikbareGerechten.Add(carbonara);

//drank
var koffie = new WarmeDrank(Dranken.Koffie);
var cola = new FrisDrank(Dranken.CocaCola);
var water = new FrisDrank(Dranken.Water);
var limonade = new FrisDrank(Dranken.Limonade);
//desert
Dessert cake = new(Desserten.Cake);
Dessert tiramisu = new(Desserten.Tiramisu);
Dessert ijs = new(Desserten.Ijs);



//enkele bestellingen

GekozenGerecht hoofd1 = new(hawaii, new List<Extras> { }, Grootte.klein);
Bestelling nr1 = new Bestelling(gerecht: hoofd1, drank: cola, aantal: 2, klant: nr001);

GekozenGerecht hoofd2 = new(bbq, new List<Extras> { Extras.kaas }, Grootte.groot);
Bestelling nr2 = new Bestelling(gerecht: hoofd2, drank: koffie, dessert: cake, aantal: 2, klant: nr002);

GekozenGerecht hoofd3 = new(bolognese, new List<Extras> { Extras.kaas, Extras.look }, Grootte.groot);
Bestelling nr3 = new Bestelling(gerecht: hoofd3, drank: limonade, aantal: 2, klant: nr002);

GekozenGerecht hoofd4 = new(bolognese, new List<Extras> { Extras.kaas, Extras.look }, Grootte.groot);
Bestelling nr4 = new Bestelling(gerecht: hoofd4, dessert: tiramisu, aantal: 1);

Bestelling nr5 = new(drank: cola, klant: nr003, aantal: 5);

GekozenGerecht hoofd6 = new(carbonara, new List<Extras> { Extras.brood }, Grootte.groot);
Bestelling nr6 = new(gerecht: hoofd6, drank: cola, aantal: 2, dessert: tiramisu, klant: nr003);

Bestelling nr7 = new(drank: cola, aantal: 2);

GekozenGerecht hoofd8 = new(bolognese, new List<Extras> { Extras.kaas, Extras.look, Extras.look }, Grootte.groot);
Bestelling nr8 = new(gerecht: hoofd8, drank: limonade, klant: nr002, aantal: 6, dessert: cake);
//bestellingen in een lijst 

List<Bestelling> bestellingLijst = new List<Bestelling>();
bestellingLijst.Add(nr1);
bestellingLijst.Add(nr2);
bestellingLijst.Add(nr3);
bestellingLijst.Add(nr4);
bestellingLijst.Add(nr5);
bestellingLijst.Add(nr6);
bestellingLijst.Add(nr7);
bestellingLijst.Add(nr8);

void toonAlleBestellingen()
{
    var alleRekeningen = bestellingLijst.Select(b => b.Rekening());
    int i = 0;
    foreach (var rekening in alleRekeningen)
    {
        Console.WriteLine($"Bestelling {++i}");
        Console.WriteLine(rekening);
    }
}

void toonOpNaamGesorteerd()
{
    var opNaamGesorteerd = bestellingLijst.OrderBy(b => b.Klant.Naam);
    foreach (var afschrift in opNaamGesorteerd)
    {
        Console.WriteLine(afschrift.Rekening());
    }
}
void toonTotalenPerKlant(string klantNaam)
{
    var klantRekeningen = bestellingLijst.Where(b => b.Klant.Naam == klantNaam);
    var Totaal = klantRekeningen.Sum(b => b.Totaal());

    foreach (var rekening in klantRekeningen)
    {
        Console.WriteLine(rekening.Rekening());
    }
    Console.WriteLine($"Totaal uitgegeven: {Totaal} Euro");
}

void gegroepeerdPerKlantEnTotaalBedragVoorBekenden()
{
    var gekendeKlanten = bestellingLijst.Where(b => b.Klant.Naam != "onbekend")
        .GroupBy(b => b.Klant.Naam);
    var onbekenden = bestellingLijst.Where(b => b.Klant.Naam == "onbekend");
    foreach (var client in gekendeKlanten)
    {
        decimal totaalBedrag = client.Sum(b => b.Totaal());
        Console.WriteLine($"De bestellingen van: {client.Key}");
        Console.WriteLine();
        foreach (var rekening in client)
        {
            Console.WriteLine(rekening.Rekening());
        }
        Console.WriteLine($"Totaal uitgegeven bedrag: {totaalBedrag}");
        Console.WriteLine("#########################################################################");
    }
    foreach (var client in onbekenden)
    {
        Console.WriteLine($"onbekende klanten");
        Console.WriteLine();
        foreach (var rekening in onbekenden)
        {
            Console.WriteLine(rekening.Rekening());
        }
    }
}

string bestandsPlaats = "C:/Downloads/pizzaPastaGegevens/";
if (!Directory.Exists(bestandsPlaats))
{
    Directory.CreateDirectory(bestandsPlaats);
}

void schrijfKlantGegevens()
{
    try
    {
        using (var schrijver = new StreamWriter(bestandsPlaats + "Klanten.txt"))
        {
            var klanten = bestellingLijst.Select(o => o.Klant).OrderBy(m => m.KlantId).Where(n => n.KlantId != 0).Distinct();
            foreach (var klant in klanten)
            {
                schrijver.WriteLine(klant.SchrijfWeg());
            }
        }
        Console.WriteLine($"bestand schrijven naar {bestandsPlaats} geslaagd");
    }

    catch (Exception ex)
    {
        Console.WriteLine($"Er is een fout opgetreden bij het schrijven van de klantgegevens: {ex.Message}");

    }
}

void schrijfGerechten()
{
    try
    {
        using (var schrijver = new StreamWriter(bestandsPlaats + "Gerechten.txt"))
        {
            var gerechten = beschikbareGerechten.Select(o => o);
            foreach (var gerecht in gerechten)
            {
                schrijver.WriteLine(gerecht.SchrijfWeg());
            }
        }
        Console.WriteLine($"bestand schrijven naar {bestandsPlaats} geslaagd");
    }

    catch (Exception ex)
    {
        Console.WriteLine($"Er is een fout opgetreden bij het schrijven van de gerechten: {ex.Message}");

    }
}

void schrijfBestellingen()
{
    try
    {
        using (var schrijver = new StreamWriter(bestandsPlaats + "bestelGegevens.txt"))
        {
            var alleRekeningen = bestellingLijst.Select(b => b.Rekening());
            int teller = 0;
            foreach (var order in alleRekeningen)
            {
                schrijver.WriteLine($"Order {++teller}\n\n{order}");
            }

        }
        Console.WriteLine($"gegevens opslaan in {bestandsPlaats} gelukt");
    }

    catch (Exception ex)
    {
        Console.WriteLine($"Er is een fout opgetreden bij het schrijven van de bestel geschiedenis: {ex.Message}");

    }

}

//schrijfBestellingen();
//schrijfGerechten();
//schrijfKlantGegevens();
//toonAlleBestellingen();
//toonOpNaamGesorteerd();
//toonTotalenPerKlant("Jan Jannsen");
//gegroepeerdPerKlantEnTotaalBedragVoorBekenden();