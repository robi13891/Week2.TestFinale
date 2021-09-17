using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public abstract class Good : IMerciGiacenza
    {
        public string CodiceMerce { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public DateTime DataRicevimento { get; set; }
        public int QuantitaGiacenza { get; set; }

        public Good(string codiceMerce, string descrizione, double prezzo, int quantita)
        {
            CodiceMerce = codiceMerce;
            Descrizione = descrizione;
            Prezzo = prezzo;
            DataRicevimento = DateTime.Now;
            QuantitaGiacenza = quantita;
        }

        public override string ToString()
        {
            return $"[{CodiceMerce}] {Descrizione} \nPrezzo: {Prezzo} \n" +
                $"Data ricevimento: {DataRicevimento.ToString("U")}\n" +
                $"Quantita giacenza: {QuantitaGiacenza}\n";
        }

        public static IMerciGiacenza AcquisisciDatiMerce()
        {
            Console.WriteLine("==DATI MERCE==\n");
            Console.WriteLine("Tipologia:");
            Console.WriteLine("[1] Electronic\n[2] Perishable\n[3] Spirit Drink");
            bool isCorrect = int.TryParse(Console.ReadLine(), out int tipoMerce);
            while(!(isCorrect && tipoMerce>=1 && tipoMerce <= 3))
            {
                Console.WriteLine("Scelta non valida!");
                Console.WriteLine("[1] Electronic\n[2] Perishable\n[3] Spirit Drink");
                isCorrect = int.TryParse(Console.ReadLine(), out tipoMerce);
            }
            Console.Write("Codice merce: ");
            string codice = Console.ReadLine();
            while (string.IsNullOrEmpty(codice))
            {
                Console.WriteLine("Inserimento non valido");
                Console.Write("Codice merce: ");
                codice = Console.ReadLine();
            }
            Console.Write("Descrizione: ");
            string descrizione = Console.ReadLine();
            if (string.IsNullOrEmpty(descrizione)) descrizione = "---";
            Console.Write("Prezzo Unitario: ");
            bool isDouble = double.TryParse(Console.ReadLine(), out double prezzoUnit);
            while (!(isDouble && prezzoUnit > 0))
            {
                Console.WriteLine("Formato prezzo non valido o prezzo negativo");
                Console.WriteLine("Prezzo Unitario: ");
                isDouble = double.TryParse(Console.ReadLine(), out prezzoUnit);
            }
            Console.Write("Quantita: ");
            bool isInt = int.TryParse(Console.ReadLine(), out int quantita);
            while (!(isInt && quantita > 0))
            {
                Console.WriteLine("Inserimento quantita non valido!");
                Console.Write("Quantita: ");
                isInt = int.TryParse(Console.ReadLine(), out quantita);
            }
            return GoodFactory.NuovaMerce(tipoMerce, codice, descrizione, prezzoUnit, quantita);
        }

    }
}
