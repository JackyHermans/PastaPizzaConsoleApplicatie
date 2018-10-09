using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace PastaPizzaNet
{
    public class Frisdrank : Drank
    {
        private decimal prijsValue;
        private Enum.Drank[] frisdranken = new Enum.Drank[] { Enum.Drank.Water, Enum.Drank.Limonade, Enum.Drank.CocaCola };
        private Enum.Drank naamValue;

        public Frisdrank(Enum.Drank naam)
            : base (naam)
        {
            switch (naam)
            {
                case Enum.Drank.Water:
                    Prijs = 2.0m;
                    break;
                case Enum.Drank.Limonade:
                    Prijs = 2.0m;
                    break;
                case Enum.Drank.CocaCola:
                    Prijs = 2.0m;
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
                if (!frisdranken.Contains(value))
                {
                    throw new Exception($"FOUT! {value} is géén frisdrank!");
                }
                naamValue = value;
            }
        }
    }
}
