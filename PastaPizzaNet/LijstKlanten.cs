using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PastaPizzaNet
{
    public class LijstKlanten
    {
        public List<Klant> getKlanten()
        {
            return new List<Klant>
            {
                // klant 0
                new Klant(1, "Jan Janssen"),
                // klant 1
                new Klant(2, "Piet Peeters"),
            };
        }
    }
}
