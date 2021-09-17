using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class ElectronicGood : Good
    {
        public string Produttore { get; set; }

        public ElectronicGood(string codice, string descrizione, double prezzo, int quantita, string produttore) 
            : base(codice, descrizione, prezzo, quantita)
        {
            Produttore = produttore;
        }

        public override string ToString()
        {
            return base.ToString() + $"Produttore: {Produttore}";
        }
    }
}
