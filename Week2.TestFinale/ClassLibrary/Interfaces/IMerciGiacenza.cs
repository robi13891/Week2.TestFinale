using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IMerciGiacenza
    {
        string CodiceMerce { get; set; }
        string Descrizione { get; set; }
        double Prezzo { get; set; }
        DateTime DataRicevimento { get; set; }
        int QuantitaGiacenza { get; set; }

        static IMerciGiacenza AcquisisciDatiMerce() { return null; }
    }
}
