using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace PastaPizzaNet
{
    public abstract class Drank : IBedrag
    {
        private string naamValue;
        private decimal prijsValue;

        public Drank(Enum.Drank naam)
        {
            this.Naam = naam;
        }
        public abstract Enum.Drank Naam { get; set; }

        public abstract decimal Prijs { get; set; }

        public decimal BerekenBedrag()
        {
            return Prijs;
        }

        public override string ToString()
        {
            return $"{Naam} <{Prijs} euro>";
        }
    }
}
