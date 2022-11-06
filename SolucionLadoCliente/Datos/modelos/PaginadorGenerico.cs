using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.modelos
{
    public class PaginadorGenerico<T> where T:class
    {
        public int PaginaActual { get; set; }
        public int RegistroPorPagina { get; set; }

        public int TotalRegistros { get; set; }

        public int TotalPagina { get; set; }

        public List<T> Resultado { get; set; }
    }
}
