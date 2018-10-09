using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace PastaPizzaNet
{
    public class Warmedrank : Drank
    {
        private decimal prijsValue;
        private Enum.Drank[] warmedranken = new Enum.Drank[] { Enum.Drank.Koffie, Enum.Drank.Thee };
        private Enum.Drank naamValue;

        public Warmedrank(Enum.Drank naam)
            : base(naam)
        {
            switch (naam)
            {
                case Enum.Drank.Koffie:
                    Prijs = 2.5m;
                    break;
                case Enum.Drank.Thee:
                    Prijs = 2.5m;
                    break;
                default:
                    break;
            }
        }
        public override decimal Prijs
        {
            get
            {
                return prijsValue;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception("Prijs moet groter dan 0 zijn");
                }
                prijsValue = value;
            }
        }

        public override Enum.Drank Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (!warmedranken.Contains(value))
                {
                    throw new Exception($"FOUT! {value} is géén warme drank!");
                }
                naamValue = value;
            }
        }
    }
}
