using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace PastaPizzaNet
{
    class LijstBestellingen
    {
        public List<Bestelling> getBestellingen()
        {
            var klanten = new LijstKlanten().getKlanten();
            var gerechten = new LijstGerechten().getGerechten();
            var dranken = new LijstDranken().getDranken();
            var desserts = new LijstDesserts().getDesserts();
            
            // bestelling 1
            List<Extra> extraBest1 = new List<Extra> { Extra.Kaas, Extra.Look };
            BesteldGerecht besteldGerecht1 = new BesteldGerecht(gerechten[0], Grootte.Groot, extraBest1);
            Bestelling bestelling1 = new Bestelling(besteldGerecht1, dranken[0], desserts[1], 2, klanten[0]);

            // bestelling 2
            BesteldGerecht besteldGerecht2 = new BesteldGerecht(gerechten[0], Grootte.Klein);
            Bestelling bestelling2 = new Bestelling(besteldGerecht2, dranken[0], desserts[0], 1, klanten[1]);

            // bestelling 3
            BesteldGerecht besteldGerecht3 = new BesteldGerecht(gerechten[1], Grootte.Groot);
            Bestelling bestelling3 = new Bestelling(besteldGerecht3, dranken[4], desserts[1], 1, klanten[1]);

            // bestelling 4
            List<Extra> extraBest4 = new List<Extra> { Extra.Look };
            BesteldGerecht besteldGerecht4 = new BesteldGerecht(gerechten[2], Grootte.Klein, extraBest4);
            Bestelling bestelling4 = new Bestelling(besteldGerecht4, null, null, 1, null);

            // bestelling 5
            BesteldGerecht besteldGerecht5 = new BesteldGerecht(gerechten[3], Grootte.Klein);
            Bestelling bestelling5 = new Bestelling(besteldGerecht5, dranken[2], null, 1, klanten[0]);

            // bestelling 6
            List<Extra> extraBest6 = new List<Extra> { Extra.Kaas };
            BesteldGerecht besteldGerecht6 = new BesteldGerecht(gerechten[4], Grootte.Groot, extraBest6);
            Bestelling bestelling6 = new Bestelling(besteldGerecht6, dranken[2], desserts[2], 1, klanten[1]);

            // bestelling 7
            Bestelling bestelling7 = new Bestelling(null, dranken[3], null, 3, klanten[1]);

            // bestelling 8
            Bestelling bestelling8 = new Bestelling(null, null, desserts[0], 1, klanten[0]);

            return new List<Bestelling> { bestelling1, bestelling2, bestelling3, bestelling4, bestelling5, bestelling6, bestelling7 , bestelling8 };
        }
    }
}
