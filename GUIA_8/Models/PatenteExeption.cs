using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIA_8.Models
{
    internal class PatenteExeption : ApplicationException
    {
        public PatenteExeption(): base("Patente Invalida"){}
        public PatenteExeption(string msg) : base(msg) { }
        public PatenteExeption(string msg,Exception inner) : base(msg,inner) { }
    }
}
