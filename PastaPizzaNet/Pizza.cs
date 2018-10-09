using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    public class Pizza : Gerecht
    {
        public Pizza(string naam, decimal prijs, List<string> onderdelen = null)
            : base(naam, prijs)
        {
            this.Onderdelen = onderdelen;
        }

        public List<string> Onderdelen
        { get; set; }

        public override string ToString()
        {
            StringBuilder weergave = new StringBuilder();
            weergave.Append(base.ToString());

            foreach (var onderdeel in Onderdelen)
            {
                weergave.Append(onderdeel + " - ");
            }
            return weergave.ToString().Substring(0,weergave.Length-3);
        }

        public override string opslaanGerecht()
        {
            StringBuilder wegschrijven = new StringBuilder();
            wegschrijven.Append($"pizza#{this.Naam}#{this.Prijs}#");
            foreach (var onderdeel in Onderdelen)
            {
                wegschrijven.Append($"{onderdeel}#");
            }
            return wegschrijven.ToString().Substring(0, wegschrijven.Length - 1);
        }
    }
}
