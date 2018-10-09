using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Enum;

namespace PastaPizzaNet
{
    class Bestelling : IBedrag
    {
        private int aantalValue;
        private Klant klantValue;
        private BesteldGerecht besteldGerechtValue;
        private Drank drankValue;
        private Dessert dessertValue;

        //public void lijstNagerechten(Dessert[] desserts)
        //{
        //    foreach (Dessert nagerecht in desserts)
        //    {
        //        nagerecht.Naam = Dessert.Naam;
        //        nagerecht.Prijs = Dessert.Prijs;
        //    }
        //}


        public Bestelling(BesteldGerecht besteldgerecht, Drank drank, Dessert dessert, int aantal, Klant klant = null)
        {
            
            this.Klant = klant;
            this.BesteldGerecht = besteldgerecht;
            this.Drank = drank;
            this.Dessert = dessert;
            this.Aantal = aantal;
        }



        public int Aantal
        {
            get
            {
                return aantalValue;
            }
            set
            {
                //if (value <= 1)
                //{
                //    throw new Exception("Aantal moet groter dan 1 zijn!");
                //}
                aantalValue = value;
            }
        }

        public Klant Klant
        {
            get
            {
                return klantValue;
            }
            set
            {
                if (value == null)
                {
                    Klant = new Klant(0, "Onbekende klant");
                }
                else
                {
                    klantValue = value;
                }
            }
        }
        
        public BesteldGerecht BesteldGerecht
        {
            get
            {
                return besteldGerechtValue;
            }
            set
            {
                besteldGerechtValue = value;
            }
        }

        public Drank Drank
        {
            get
            {
                return drankValue;
            }
            set
            {
                drankValue = value;
            }
        }

        public Dessert Dessert
        {
            get
            {
                return dessertValue;
            }
            set
            {
                dessertValue = value;
            }
        }

        public decimal Bedrag
        {
            get
            {
                return BerekenBedrag();
            }
            private set { }
        }

        public decimal BerekenBedrag()
        {

            decimal prijs = 0.00m;
            decimal korting = 0.10m;

            prijs = BesteldGerecht != null ? BesteldGerecht.BerekenBedrag() : 0;
            prijs += Drank != null ? Drank.BerekenBedrag() : 0;
            prijs += Dessert != null ? Dessert.BerekenBedrag() : 0;
            prijs = prijs * Aantal;
            
            if (BesteldGerecht != null && Drank != null && Dessert != null)
            {
                prijs = prijs * (1 - korting);
            }
            return prijs;
        }

        public override string ToString()
        {
            StringBuilder weergave = new StringBuilder($"Klant:{Klant}" + Environment.NewLine);

            if (BesteldGerecht != null)
            {
                if (BesteldGerecht.Gerecht != null)
                {
                    weergave.Append($"Gerecht: {BesteldGerecht}" + Environment.NewLine);
                }
            }
            if (Drank != null)
            {
                weergave.Append($"Drank: {Drank}" + Environment.NewLine);
            }
            if (Dessert != null)
            {
                weergave.Append($"Dessert: {Dessert}" + Environment.NewLine);
            }
            weergave.Append($"Aantal: {Aantal}" + Environment.NewLine);
            weergave.Append($"Bedrag van deze bestelling: {BerekenBedrag()} euro");
            return weergave.ToString();
        }

        public string opslaanBestelling()
        {
            StringBuilder wegschrijven = new StringBuilder();
            if (Klant.Naam == "Onbekende klant")
            {
                Klant.KlantID = 0;
            }
            wegschrijven.Append($"{this.Klant.KlantID}#");                          //klantID + #
            if (BesteldGerecht != null)
            {
                wegschrijven.Append(BesteldGerecht.opslaanBesteldGerecht());
            }
            wegschrijven.Append("#");                                               //(gerecht) + #
            if (Drank != null)
            {
                if (Drank.GetType().Name == "Frisdrank")
                {
                    wegschrijven.Append($"F-{Drank.Naam}");
                }
                else
                {
                    wegschrijven.Append($"W-{Drank.Naam}");
                }
            }
            wegschrijven.Append("#");                                               //(drank) + #
            if (Dessert != null)
            {
                wegschrijven.Append(this.Dessert.Naam);
            }                                                                       //(dessert)
            wegschrijven.Append($"#{this.Aantal}");                                 // # + aantal
            return wegschrijven.ToString();
        }
    }
}
