using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeraAplicacion
{
    internal class Estadistica
    {
        public double media(double[] serie)
        {
            double suma = 0;
            for (int i = 0; i < serie.Length; i++)
            {
                suma += serie[i];
            }
            double media = suma / serie.Length;
            return media;
        }
        public double mediana(double[] serie)
        {
            Array.Sort(serie);
            int n = serie.Length;
            if (n % 2 == 0)
                return (serie[n / 2 - 1] + serie[n / 2]) / 2;
            else
                return serie[n / 2];
        }
        public double desviacionTipica(double[] serie, double media)
        {
            return Math.Sqrt(varianza(serie, media));
        }
        public double mediaArmonica(double[] serie)
        {
            int n = serie.Length;
            return n / serie.Sum(x => 1 / x);
        }
        public double varianza(double[] serie, double media)
        {
            return serie.Average(n => Math.Pow(n - media, 2));
        }
        public double moda(double[] serie)
        {
            var grupos = serie.GroupBy(n => n);
            var moda = grupos.OrderByDescending(g => g.Count()).First().Key;
            return moda;
        }
        public double desviacionEstandar(double[] serie, double media)
        {
            return Math.Sqrt(varianza(serie, media));
        }
        public double rango(double[] serie)
        {
            return serie.Max() - serie.Min();
        }
        public double frecuencia(double[] serie, double valor)
        {
            return serie.Count(n => n == valor);
        }
    }
}