using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class LijstDesserts
    {
        public List<Dessert> getDesserts()
        {
            return new List<Dessert>
            {
                // dessert nr 0
                new Dessert(Enum.Dessert.Tiramisu),
                // dessert nr 1
                new Dessert(Enum.Dessert.Ijs),
                // dessert nr 2
                new Dessert(Enum.Dessert.Cake),
            };
        }
    }
}
