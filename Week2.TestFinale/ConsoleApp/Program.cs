using ClassLibrary.Entities;
using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region dati di prova
            List<IMerciGiacenza> merciProva = new List<IMerciGiacenza>()
            {
                new ElectronicGood("EG-001","iPad",700,2,"Apple"),
                new ElectronicGood("EG-002","Galaxy 100",370,1,"Samsung"),
                new PerishableGood("PG-001","Salmone Norvegia",12,10,new DateTime(2022,12,12),
                ModalitaConservazione.Freezer),
                new PerishableGood("PG-002","Torta Sacher",5.50,70,new DateTime(2021,11,12),
                ModalitaConservazione.Freezer),

            };
            #endregion

            Console.WriteLine("==NUOVO MAGAZZINO==\n");
            Console.Write("Indirizzo: ");
            string indirizzo = Console.ReadLine();
            while (string.IsNullOrEmpty(indirizzo))
            {
                Console.WriteLine("Inserimento non valido!");
                Console.Write("Indirizzo: ");
                indirizzo = Console.ReadLine();
            }
            Wharehouse magazzino = new(indirizzo);
            //dati di prova
            magazzino.MerciGiacenza = merciProva;
            magazzino.ImportoTotMerciGiacenza = 2275;

            Console.Clear();
            bool isTrue = true;
            do
            {
                Console.Clear();
                Console.WriteLine("==MENU MAGAZZINO==\n");
                Console.WriteLine("[1] Ricevere Merci\n[2] Rimuovere Merci\n" +
                    "[3] Stampa dati Magazzino e Merci in Giacenza\n" +
                    "[4] Esci\n");
                Console.Write(">> ");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int index);
                while (!(isCorrect && index >= 1 && index <= 4))
                {
                    Console.WriteLine("Scelta non valida!");
                    Console.Write(">> ");
                    isCorrect = int.TryParse(Console.ReadLine(), out index);
                }
                switch (index)
                {
                    case 1:// aggiungere
                        Console.Clear();
                        IMerciGiacenza merce = Good.AcquisisciDatiMerce();
                        if (merce != null)
                        {
                            magazzino = magazzino + merce;
                        }
                        break;
                    case 2://togliere
                        Console.Clear();
                        try
                        {
                            int numero = Wharehouse.ElencoProdottiInGiacenza(magazzino);
                            Wharehouse.EliminaProdotto(magazzino, numero);
                        }
                        catch (GoodException gex)
                        {
                            Console.WriteLine(gex.Message);
                            Console.WriteLine("\n\nPremi un tasto per tornare al menu");
                            Console.ReadLine();
                        }
                        break;
                    case 3: //stampa dati
                        Console.Clear();
                        try
                        {
                            Wharehouse.StockList(magazzino);
                            Console.WriteLine("\n\nPremi un tasto per tornare al menu");
                            Console.ReadLine();
                        }
                        catch (GoodException gex)
                        {
                            Console.WriteLine(gex.Message);
                            Console.WriteLine("\n\nPremi un tasto per tornare al menu");
                            Console.ReadLine();
                        }
                        break;
                    case 4:
                        isTrue = false;
                        break;
                }
            } while (isTrue);
            Console.WriteLine("Arrivederci!");



        }
    }
}
