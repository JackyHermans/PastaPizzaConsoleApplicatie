using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PastaPizzaNet
{
    public class Klant
    {
        private int klantIDValue;
        private string naamValue;

        public Klant()
        {
            if (Naam == null)
            {
                this.KlantID = 0;
                this.Naam = "Onbekende klant";
            }
        }
        public Klant(int klantID = 0, string naam = null)
        {
            this.KlantID = klantID;
            this.Naam = naam;
        }
        public int KlantID
        {
            get
            {
                return klantIDValue;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Klantnummer moet groter dan of gelijk aan 0 zijn!");
                }
                klantIDValue = value;
            }
        }

        public string Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (value == null)
                {
                    new Klant(0, "Onbekende klant");
                }
                naamValue = value;
            }
        }

        public override string ToString()
        {
            return ($"{Naam} ") ;
        }

        public string OpslaanKlanten()
        {
            StringBuilder wegschrijven = new StringBuilder();
            wegschrijven.Append($"{this.KlantID}#{this.Naam}");
            return wegschrijven.ToString();
        }

    }
}
