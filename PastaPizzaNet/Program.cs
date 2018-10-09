using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Enum;

namespace PastaPizzaNet
{
    class Program
    {
        delegate void lijstNagerechten(Dessert[] desserts);
        public static void Main(string[] args)
        {
            var Bestellingen = new LijstBestellingen().getBestellingen();
            var Gerechten = new LijstGerechten().getGerechten();
            var Klanten = new LijstKlanten().getKlanten();
            var Desserts = new LijstDesserts().getDesserts();
            var Dranken = new LijstDranken().getDranken();
            List<Gerecht> dishes = new List<Gerecht>();
            List<Dessert> nagerechten = new List<Dessert>();
            List<Extra> supplementen = new List<Extra>();
            List<Bestelling> BestellingenFromFile = new List<Bestelling>();

            // Lijst van alle bestellingen
            Console.WriteLine("Lijst van alle bestellingen:");

            foreach (var gerecht in Gerechten)
            {
                if (gerecht.Naam.ToUpper().StartsWith("PIZ"))
                {
                    Action<string, decimal, List<String>> pizza = (naam, prijs, onderdelen) => new Pizza(naam, prijs, onderdelen);
                }
                else
                {
                    Action <string, decimal, string> pasta = (naam, prijs, omschrijving) => new Pasta(naam, prijs, omschrijving);
                }
            }

            int teller = 1;

            foreach (var bestelling in Bestellingen)
            {
                Console.WriteLine($"Bestelling {teller}:");
                Console.WriteLine(bestelling);
                Console.WriteLine("************************************************");
                teller++;
            }

            Console.WriteLine();
            Console.ReadKey();

            // Lijst van bestellingen van Jan Janssen en het totaalbedrag ervan

            Console.WriteLine("Bestellingen van klant Jan Janssen:");
            Console.WriteLine();
            decimal eindtotaalJanJanssen = 0.0m;

            var bestellingenJanJanssen =
                from bestellingJanJanssen in Bestellingen
                where (bestellingJanJanssen.Klant.Naam == Klanten[0].Naam)
                select new
                {
                    klantJanJanssen = bestellingJanJanssen.Klant,
                    gerechtJanJanssen = bestellingJanJanssen.BesteldGerecht,
                    drankJanJanssen = bestellingJanJanssen.Drank,
                    dessertJanJanssen = bestellingJanJanssen.Dessert,
                    aantalJanJanssen = bestellingJanJanssen.Aantal,
                    bedragJanJanssen = bestellingJanJanssen.Bedrag
                };

            if (bestellingenJanJanssen != null)
            {
                foreach (var bestellingJanJanssen in bestellingenJanJanssen)
                {
                    if (bestellingJanJanssen.klantJanJanssen != null)
                    {
                        Console.WriteLine($"Klant: {bestellingJanJanssen.klantJanJanssen}");
                    }
                    if (bestellingJanJanssen.gerechtJanJanssen != null)
                    {
                        Console.WriteLine($"Gerecht: {bestellingJanJanssen.gerechtJanJanssen}");
                    }
                    if (bestellingJanJanssen.drankJanJanssen != null)
                    {
                        Console.WriteLine($"Drank: {bestellingJanJanssen.drankJanJanssen}");
                    }
                    if (bestellingJanJanssen.dessertJanJanssen != null)
                    {
                        Console.WriteLine($"Dessert: {bestellingJanJanssen.dessertJanJanssen}");
                    }
                    Console.WriteLine($"Aantal: {bestellingJanJanssen.aantalJanJanssen}");
                    Console.WriteLine($"Bedrag van deze bestelling: {bestellingJanJanssen.bedragJanJanssen} euro");
                    Console.WriteLine();
                    eindtotaalJanJanssen += bestellingJanJanssen.bedragJanJanssen;
                }
                Console.WriteLine($"Het totaal bedrag van alle bestellingen van klant Jan Janssen: {eindtotaalJanJanssen} euro");
                Console.ReadKey();

            }

            // Alle bestellingen, gegroepeerd per klant.
            // Voor de bekende klanten: totaalbedrag van alle bestellingen tonen.

            Console.WriteLine();
            Console.WriteLine("Bestellingen gegroepeerd per klant");
            Console.WriteLine("+ totaalbedrag van alle bestellingen voor de bekende klanten");
            Console.WriteLine();
            decimal eindtotaalPerKlant = 0.0m;

            var bestellingenPerKlant =
                from order in Bestellingen
                group order by order.Klant;
                
            foreach (var perKlant in bestellingenPerKlant)   
            {
                foreach (var bekendeKlant in perKlant)
                {
                    if (bekendeKlant.Klant.Naam != "Onbekende klant")
                    {
                        Console.WriteLine($"Bestellingen van {bekendeKlant.Klant.Naam}");
                        Console.WriteLine();
                        Console.WriteLine($"Klant: {bekendeKlant.Klant.Naam}");
                        if (bekendeKlant.BesteldGerecht != null)
                        {
                            Console.WriteLine($"Gerecht: {bekendeKlant.BesteldGerecht}");
                        }
                        if (bekendeKlant.Drank != null)
                        {
                            Console.WriteLine($"Drank: {bekendeKlant.Drank}");
                        }
                        if (bekendeKlant.Dessert != null)
                        {
                            Console.WriteLine($"Dessert: {bekendeKlant.Dessert}");
                        }
                        Console.WriteLine($"Aantal: {bekendeKlant.Aantal}");
                        Console.WriteLine($"Bedrag van deze bestelling: {bekendeKlant.Bedrag} euro");
                        Console.WriteLine();
                        eindtotaalPerKlant += bekendeKlant.Bedrag;
                    }
                    else
                    {
                        Console.WriteLine("Onbekende klanten:");
                        Console.WriteLine();
                        Console.WriteLine($"Klant: {bekendeKlant.Klant.Naam}");
                        if (bekendeKlant.BesteldGerecht != null)
                        {
                            Console.WriteLine($"Gerecht: {bekendeKlant.BesteldGerecht}");
                        }
                        if (bekendeKlant.Drank != null)
                        {
                            Console.WriteLine($"Drank: {bekendeKlant.Drank}");
                        }
                        if (bekendeKlant.Dessert != null)
                        {
                            Console.WriteLine($"Dessert: {bekendeKlant.Dessert}");
                        }
                        Console.WriteLine($"Aantal: {bekendeKlant.Aantal}");
                        Console.WriteLine($"Bedrag van deze bestelling: {bekendeKlant.Bedrag} euro");
                        Console.WriteLine();
                    }
                }
                if (eindtotaalPerKlant != 0)
                {
                    Console.WriteLine($"Het totaal bedrag van alle bestellingen van klant {perKlant.Key}: {eindtotaalPerKlant} euro");
                    Console.WriteLine();
                    eindtotaalPerKlant = 0;
                }
                Console.WriteLine("***********************************************");
                Console.WriteLine();
                Console.ReadKey();
            }

            // DEEL 2

            string directorynaam = @"C:\Data\";

            try
            {
                // wegschrijven klanten

                using (var schrijver = new StreamWriter(directorynaam + "klanten.txt", false))
                {
                    foreach (var client in Klanten)
                    {
                        schrijver.WriteLine(client.OpslaanKlanten());
                    }
                }  
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het wegschrijven van de klanten");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                // wegschrijven gerechten

                using (var schrijver = new StreamWriter(directorynaam + "gerechten.txt", false))
                {
                    var gerechtenDistinct =
                        (from dish in Gerechten select dish).Distinct();

                    foreach (var dish in gerechtenDistinct)
                    {
                        schrijver.WriteLine(dish.opslaanGerecht());
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het wegschrijven van de gerechten");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                // wegschrijven bestellingen

                using (var schrijver = new StreamWriter(directorynaam + "bestellingen.txt", false))
                {
                    foreach (var order in Bestellingen)
                    {
                        schrijver.WriteLine(order.opslaanBestelling());
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het wegschrijven van de bestellingen");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                // klanten inlezen
                Console.WriteLine("Klanten inlezen");
                List<Klant> klantenlijst = new List<Klant>();

                string klantRegel;
                int klantNr;
                string klantNaam;

                using (var lezer = new StreamReader(directorynaam + "klanten.txt"))
                {
                    while ((klantRegel = lezer.ReadLine()) != null)
                    {
                        string[] data = klantRegel.Split(new Char[] { '#' });

                        klantNr = int.Parse(data[0]);
                        klantNaam = data[1];

                        klantenlijst.Add(
                            new Klant
                            {
                                KlantID = klantNr,
                                Naam = klantNaam
                            });
                    }
                }

            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het lezen van het klantenbestand");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                // gerechten inlezen
                Console.WriteLine("Gerechten inlezen");
                string gerechtType;
                string gerechtNaam;
                decimal gerechtPrijs;
                
                string gerechtRegel;

                using (var lezer = new StreamReader(directorynaam + "gerechten.txt"))
                {
                    while ((gerechtRegel = lezer.ReadLine()) != null)
                    {
                        string[] data = gerechtRegel.Split(new Char[] { '#' });

                        gerechtType = data[0];
                        gerechtNaam = data[1];
                        gerechtPrijs = decimal.Parse(data[2]);
                        if (gerechtType.ToUpper() != "PIZZA")
                        {
                            dishes.Add(new Pasta(data[1], decimal.Parse(data[2]), data[3]));
                        }
                        else
                        {
                            List<string> gerechtOnderdelen = new List<string>();
                            if (gerechtRegel.IndexOf("#") > 2)
                            {
                                foreach (string ingrediënt in data)
                                {
                                    gerechtOnderdelen.Add(ingrediënt);
                                }
                            }
                            dishes.Add(new Pizza(data[1], decimal.Parse(data[2]), gerechtOnderdelen));
                        }
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het lezen van het gerechtenbestand");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                // bestellingen inlezen
                Console.WriteLine("Bestellingen inlezen");

                Klant client = null;
                string bestelRegel;
                string naamGerecht;
                Grootte afmeting;
                BesteldGerecht besteldgerecht = null;
                Dessert nagerecht= null;
                List<Klant> clientList = new List<Klant>();
                Drank consumptie = null;
                
                using (var lezer = new StreamReader(directorynaam + "bestellingen.txt"))
                {
                    while ((bestelRegel = lezer.ReadLine()) != null)
                    {
                        // klant
                        string[] data = bestelRegel.Split(new Char[] { '#' });

                        int klantNr = int.Parse(data[0]);
                        besteldgerecht = null;

                        client = new Klant(0, "Onbekende klant");

                        var gevondenKlant = Klanten.Where(k => k.KlantID == klantNr).FirstOrDefault();

                        if ( gevondenKlant != null)
                        {
                            client.KlantID = gevondenKlant.KlantID;
                            client.Naam = gevondenKlant.Naam;
                        }
                       
                        //foreach (var klant in Klanten)
                        //{
                        //    klantNr = klant.KlantID;
                        //    client = klant;
                        //    if (klantNr != 0)
                        //    {
                        //        client.Naam = klant.Naam;
                        //    }
                        //    else
                        //    {
                        //        client = new Klant(0, "Onbekende klant");
                        //    }
                            
                        //}

                        // gerecht
                        afmeting = Grootte.Klein;
                        if (data[1].Length > 0)

                        {
                            // gerecht naam
                            string[] besteldGerechtData = data[1].Split(new Char[] { '-' });
                            naamGerecht = besteldGerechtData[0];
                            
                            Gerecht gekozenDish = dishes.Where(d => d.Naam == naamGerecht).First();
                            
                            // gerecht afmeting
                            afmeting = (Enum.Grootte)System.Enum.Parse(typeof(Grootte), besteldGerechtData[1]);


                            // gerecht extra's
                            var supplement = new List<Extra>();
                            if (Convert.ToInt32(besteldGerechtData[2]) != 0)
                            {
                                for (int tel = 1; tel <= Convert.ToInt32(besteldGerechtData[2]); tel++)
                                {
                                    Extra toebehoren = (Extra)System.Enum.Parse(typeof(Extra), besteldGerechtData[tel + 2]);
                                    supplement.Add(toebehoren);
                                }
                            }
                            besteldgerecht = new BesteldGerecht(gekozenDish, afmeting, supplement);
                        }

                        //foreach (var dish in dishes)
                        //{
                        //    naamGerecht = dish.Naam;
                        //    decimal prijs = dish.Prijs;
                        //    besteldgerecht = new BesteldGerecht(dish, afmeting, supplement);
                        //}

                        // dranken

                        if (data[2] != null)
                        {
                            var drankData = data[2].Split(new Char[] { '-' });
                            if (drankData[0] == "F")
                            {
                                consumptie = new Frisdrank((Enum.Drank)System.Enum.Parse(typeof(Enum.Drank), drankData[1])); 
                            }
                            else if (drankData[0] == "W")
                            {
                                consumptie = new Warmedrank((Enum.Drank)System.Enum.Parse(typeof(Enum.Drank), drankData[1]));
                            }
                            else
                            {
                                consumptie = null;
                            }
                        }

                        // nagerecht

                        if (data[3].Length > 0)
                        {
                            nagerecht = new Dessert((Enum.Dessert)System.Enum.Parse(typeof(Enum.Dessert), data[3]));
                        }
                        else
                        {
                            nagerecht = null;
                        }

                        // aantal ==> data[4]

                        Bestelling order = new Bestelling(besteldgerecht, consumptie, nagerecht, int.Parse(data[4]), client);

                        BestellingenFromFile.Add(order);   
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij inlezen bestellingen");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var order in BestellingenFromFile)
            {
                Console.WriteLine(order.ToString());
                Console.WriteLine("-----------------------");
            }
        }
    }
}
