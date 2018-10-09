using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class LijstGerechten
    {

        public List<Gerecht> getGerechten()
        {
            return new List<Gerecht>
            {
                // gerecht nr 0
                new Pizza ("Pizza Margherita", 8.0m, new List<string> {"Tomatensaus", "Mozarella" }),
                // gerecht nr 1
                new Pizza ("Pizza Napoli", 10.0m, new List<string> {"Tomatensaus", "Mozarella", "Ansjovis", "Kappers", "Olijven" }),
                // gerecht nr 2
                new Pasta ("Lasagna", 15.0m),
                // gerecht nr 3
                new Pasta ("Spaghetti Carbonara", 13.0m, "spek, roomsaus en parmezaanse kaas"),
                // gerecht nr 4
                new Pasta ("Spaghetti Bolognese", 12.0m, "met gehaktsaus"), 
            };   
        }
    }
}
