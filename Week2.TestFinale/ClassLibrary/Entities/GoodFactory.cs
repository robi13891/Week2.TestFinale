using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public static class GoodFactory
    {
        public static IMerciGiacenza NuovaMerce(int tipoMerce, string codice, string descrizione
                                                , double prezzo, int quantita)
        {
            if (tipoMerce == 1)//electronic
            {
                Console.WriteLine("Produttore: ");
                string produttore = Console.ReadLine();
                if (string.IsNullOrEmpty(produttore)) produttore = "Produttore Sconosciuto";
                return new ElectronicGood(codice, descrizione, prezzo, quantita, produttore);
            }
            else if (tipoMerce == 2)//perishable
            {
                Console.WriteLine("Data scadenza (yyyy/mm/dd): ");
                DateTime dataScadenza = DateTime.Parse(Console.ReadLine()); //dovrei mettere controllo anche qua
                Console.WriteLine("Conservazione:\n(1)freezer\n(2)fridge\n(3)shelf");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int tipo);
                while (!(isCorrect && tipo >= 1 && tipo <= 3))
                {
                    Console.WriteLine("Scelta non valida!");
                    Console.WriteLine("Conservazione:\n(1)freezer\n(2)fridge\n(3)shelf");
                    isCorrect = int.TryParse(Console.ReadLine(), out tipo);
                }
                return new PerishableGood(codice, descrizione, prezzo, quantita, dataScadenza, 
                    (ModalitaConservazione)tipo);
            }
            else//drinks
            {
                Console.WriteLine("Gradazione Alcolica: ");
                float gradazione = float.Parse(Console.ReadLine()); //dovrei mettere controllo anche qua
                Console.WriteLine("tipo:\n(1)Whisky\n(2)Wodka\n(3)Grappa\n(4)Gin\n(5)Other");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int tipo);
                while (!(isCorrect && tipo >= 1 && tipo <= 5))
                {
                    Console.WriteLine("Scelta non valida!");
                    Console.WriteLine("tipo:\n(1)Whisky\n(2)Wodka\n(3)Grappa\n(4)Gin\n(5)Other");
                    isCorrect = int.TryParse(Console.ReadLine(), out tipo);
                }
                return new SpiritDrinkGood(codice, descrizione, prezzo, quantita, gradazione, (Tipo)tipo);
            }


        }
    }
}
