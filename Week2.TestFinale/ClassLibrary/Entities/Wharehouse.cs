using ClassLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Wharehouse : IEnumerable<IMerciGiacenza>
    {
        public Guid IdMagazzino { get; }
        public string Indirizzo { get; set; }
        public double ImportoTotMerciGiacenza { get; set; }
        public DateTime DataUltimaOperazione { get; set; }

        public List<IMerciGiacenza> MerciGiacenza;

        public Wharehouse(string indirizzo)
        {
            IdMagazzino = Guid.NewGuid();
            ImportoTotMerciGiacenza = 0;
            DataUltimaOperazione = DateTime.Now;
            MerciGiacenza = new List<IMerciGiacenza>();
        }
        public override string ToString()
        {
            return $"[{IdMagazzino}] {Indirizzo}\n" +
                $"Importo totale merci giacenza: {ImportoTotMerciGiacenza}\n" +
                $"Data ultima operazione: {DataUltimaOperazione.ToString("U")}\n";
        }
        public static void StockList(Wharehouse magazzino)
        {
            Console.WriteLine("==DATI MAGAZZINO E ELENCO MERCI==\n");
            Console.WriteLine(magazzino.ToString());
            if (magazzino.MerciGiacenza.Count != 0)
            {
                foreach (IMerciGiacenza merci in magazzino.MerciGiacenza)
                {
                    Console.WriteLine(merci);
                    Console.WriteLine("----");
                }
                
            }
            else { throw new GoodException("No goods stored yet"); }

        }
        public static int ElencoProdottiInGiacenza(Wharehouse magazzino)
        {
            if (magazzino.MerciGiacenza.Count != 0)
            {
                int count = 0;

                foreach (IMerciGiacenza merci in magazzino.MerciGiacenza)
                {
                    count++;
                    Console.WriteLine($"---#{count}---\n" + merci);
                }

                Console.WriteLine("-------\n");
                Console.WriteLine("Numero da eliminare:");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int index);
                while (!(isCorrect && index >= 1 && index <= count))
                {
                    Console.WriteLine("Scelta non valida!\nNumero da eliminare:");
                    isCorrect = int.TryParse(Console.ReadLine(), out index);
                }
                return index;
            }
            else throw new GoodException("No Goods stored yet");
        }
        public static void EliminaProdotto(Wharehouse magazzino, int numero)
        {
            int count = 0;
            foreach (IMerciGiacenza merci in magazzino.MerciGiacenza)
            {
                count++;
                if (count == numero)
                {
                    magazzino = magazzino - merci;
                    Console.WriteLine("Merce rimossa con successo");
                    Console.WriteLine("Premi un tasto per tornare al menu");
                    Console.ReadLine();
                    break;
                }
            }
        }
        public static Wharehouse operator +(Wharehouse magazzino, IMerciGiacenza item)
        {
            magazzino.MerciGiacenza.Add(item);
            magazzino.DataUltimaOperazione = DateTime.Now;
            magazzino.ImportoTotMerciGiacenza += item.Prezzo * item.QuantitaGiacenza;
            return magazzino;
        }
        public static Wharehouse operator -(Wharehouse magazzino, IMerciGiacenza item)
        {
            magazzino.MerciGiacenza.Remove(item);
            magazzino.DataUltimaOperazione = DateTime.Now;
            magazzino.ImportoTotMerciGiacenza -= item.Prezzo * item.QuantitaGiacenza;
            return magazzino;
        }


        #region Implementazione IEnumerable
        public IEnumerator<IMerciGiacenza> GetEnumerator()
        {
            foreach (IMerciGiacenza item in MerciGiacenza)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        #endregion
    }
}

