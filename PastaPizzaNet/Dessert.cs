using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace PastaPizzaNet
{
    public class Dessert : IBedrag
    {
        
        public decimal prijsValue;
        public Enum.Dessert[] desserts = new Enum.Dessert[] { Enum.Dessert.Tiramisu, Enum.Dessert.Ijs, Enum.Dessert.Cake };
        public Enum.Dessert naamValue;
                
        public Dessert (Enum.Dessert naam)
        {
            switch (naam)
            {
                case Enum.Dessert.Tiramisu:
                    Naam = Enum.Dessert.Tiramisu;
                    Prijs = 3.0m;
                    break;
                case Enum.Dessert.Ijs:
                    Naam = Enum.Dessert.Ijs;
                    Prijs = 3.0m;
                    break;
                case Enum.Dessert.Cake:
                    Naam = Enum.Dessert.Cake;
                    Prijs = 2.0m;
                    break;
                default:
                    break;
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
                if (value <= 0)
                {
                    throw new Exception("Prijs moet groter dan 0 zijn!");
                }
                prijsValue = value;
            }
        }

        public Enum.Dessert Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (!desserts.Contains(value))
                {
                    throw new Exception($"FOUT! {value} is geen dessert!");
                }
                naamValue = value;
            }
        }

        public override string ToString()
        {
            return $"{Naam} <{Prijs} euro>";
        }

        public decimal BerekenBedrag()
        {
            return Prijs;
        }
    }
}
