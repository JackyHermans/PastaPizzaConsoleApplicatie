using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace PastaPizzaNet
{
    public class BesteldGerecht : IBedrag
    {
        //private List<Extra> extraValue;
        private Gerecht gerechtValue;

        public BesteldGerecht(Gerecht gerecht, Grootte grootte, List<Extra> extra = null)
        {
            this.Gerecht = gerecht;
            this.Grootte = grootte;
            this.Extra = extra;
        }
        public Grootte Grootte { get; set; }

        public List<Extra> Extra
        { get; set; }

        public Gerecht Gerecht
        {
            get
            {
                return gerechtValue;
            }
            set
            {
                gerechtValue = value;
            }
        }

        public override string ToString()
        {
            StringBuilder weergave = new StringBuilder();
            weergave.Append($"{Gerecht} ");
            weergave.Append($" <{Grootte}> ");
            if (Extra != null)
            {
                weergave.Append($" extra: ");
                foreach (var extra in Extra)
                {
                    weergave.Append($" {extra}");
                }
            }
            weergave.Append($" <bedrag: {BerekenBedrag()} euro>");
            return weergave.ToString();
        }

        public decimal BerekenBedrag()
        {
            decimal prijs = 0;
            prijs += Gerecht.BerekenBedrag();
            if (Grootte == Grootte.Groot)
            {
                prijs += 3;
            }

            if (Extra != null)
            {
                if (Extra.Count != 0)
                {
                    prijs += Extra.Count;
                }
            }
            
            // veroorzaakt ruis!!!
            //if (Extra != null)
            //{
            //    foreach (var extra in Extra)
            //    {
            //        prijs += 1;
            //    }
            //}
            return prijs;
        }

        public string opslaanBesteldGerecht()
        {
            StringBuilder wegschrijvenGerecht = new StringBuilder();
            wegschrijvenGerecht.Append($"{this.Gerecht.Naam}-{this.Grootte}-");
            if (this.Extra != null)
            {
                wegschrijvenGerecht.Append($"{this.Extra.Count}-");
                foreach (var extra in Extra)
                {
                    wegschrijvenGerecht.Append($"{extra}-");
                }
            }
            else
            {
                wegschrijvenGerecht.Append("0-");
            }
            return wegschrijvenGerecht.ToString().Substring(0, wegschrijvenGerecht.Length - 1);
        }
    }
}
