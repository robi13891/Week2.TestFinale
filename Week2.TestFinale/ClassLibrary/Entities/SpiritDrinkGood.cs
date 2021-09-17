using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class SpiritDrinkGood : Good
    {
        public float GradazioneAlcolica { get; set; }
        public Tipo Tipo { get; set; }

        public SpiritDrinkGood(string codice, string descrizione, double prezzo, int quantita, 
            float gradazione, Tipo tipo)
            : base(codice, descrizione, prezzo, quantita)
        {
            GradazioneAlcolica = gradazione;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return base.ToString() + $"Tipo: {Tipo}\n" +
                $"Gradazione alcolica: {GradazioneAlcolica.ToString("0.0")}%";
        }
    }
    public enum Tipo
    {
        Whisky=1,
        Wodka,
        Grappa,
        Gin,
        Other
    }
}
