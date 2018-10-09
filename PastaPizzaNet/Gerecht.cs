using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public abstract class Gerecht : IBedrag
    {
        private string naamValue;
        private decimal prijsValue;

        public Gerecht(string naam, decimal prijs)
        {
            this.Naam = naam;
            this.Prijs = prijs;
        }
        public string Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                naamValue = value;
            }
        }
        public decimal Prijs
        {
            get
            {
                return prijsValue;
            }
            set
            {
               prijsValue = value ;
            }
        }

        public decimal BerekenBedrag()
        {
            return Prijs;
        }

        public override string ToString()
        {
            return $"{Naam} <{Prijs} euro> ";
        }

        public abstract string opslaanGerecht();
    }
}
