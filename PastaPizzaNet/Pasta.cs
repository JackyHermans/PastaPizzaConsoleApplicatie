using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Pasta : Gerecht
    {
        public Pasta(string naam, decimal prijs, string omschrijving = null)
            : base(naam, prijs)
        {
            this.Omschrijving = omschrijving;
        }
        public string Omschrijving { get; set; }

        
        public override string ToString()
        {
            return base.ToString() + ' ' + Omschrijving;
        }

        public override string opslaanGerecht()
        {
            StringBuilder wegschrijven = new StringBuilder();
            wegschrijven.Append($"pasta#{this.Naam}#{this.Prijs}#{this.Omschrijving}");
            return wegschrijven.ToString();
        }
    }
}
