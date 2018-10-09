using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class LijstDranken
    {
        public List<Drank> getDranken()
        {
            return new List<Drank>
            {
                // drank nr 0
                new Frisdrank (Enum.Drank.Water),
                // drank nr 1
                new Frisdrank (Enum.Drank.Limonade),
                // drank nr 2
                new Frisdrank (Enum.Drank.CocaCola),
                // drank nr 3
                new Warmedrank (Enum.Drank.Koffie),
                // drank nr 4
                new Warmedrank (Enum.Drank.Thee),
            };
        }
    }
}
