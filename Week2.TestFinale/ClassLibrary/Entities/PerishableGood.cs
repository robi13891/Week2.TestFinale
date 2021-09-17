using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class PerishableGood : Good
    {
        public DateTime DataScadenza { get; set; }
        public ModalitaConservazione ModalitaConservazione { get; set; }

        public PerishableGood(string codice, string descrizione, double prezzo, int quantita,
            DateTime scadenza, ModalitaConservazione conservazione)
            : base(codice, descrizione, prezzo, quantita)
        {
            DataScadenza = scadenza;
            ModalitaConservazione = conservazione;
        }

        public override string ToString()
        {
            return base.ToString() + $"Data scadenza: {DataScadenza.ToString("d")}\n" +
                $"Conservazione: {ModalitaConservazione}";
        }
    }
    public enum ModalitaConservazione
    {
        Freezer = 1,
        Fridge,
        Shelf
    }

}
