using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIA_8.Models
{
    internal class Multa : IExportable , IComparable<Multa>
    {
        public string Patente { get; set; }
        public double Importe { get; set; }
        public Multa()
        {
        }
        public Multa(string pate, double imp)
        {

            if (pate.Length == 6 || pate.Length ==7)
            {
                    Patente = pate;
            }
            else
            {
              throw new PatenteExeption();
            }
        
            Importe= imp;
            
        }

        public string Cadena()
        {
            return $@"Patente: {Patente} - Importe : {Importe}";
        }

        public int CompareTo(Multa other)
        {
            if (other != null)
            {
                return this.Patente.CompareTo(other.Patente);
            }
            return -1;
        }

        public void Importar(string cadena)
        {
            string[] cadenaS = cadena.Split(';');
            string pate = cadenaS[0];
            double imp = Convert.ToDouble(cadenaS[1]);

            if (pate.Length == 6 || pate.Length == 7)
            {
                Patente = pate;
            }
            else
            {
                throw new PatenteExeption();
            }

            Importe = imp;
        }
    }
}
