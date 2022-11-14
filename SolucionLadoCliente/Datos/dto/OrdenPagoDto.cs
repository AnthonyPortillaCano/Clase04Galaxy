using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.dto
{
    public class OrdenPagoDto
    {
        public int CodigoOrdenPago { get; set; }
       public int Monto { get; set; }
       public string Moneda { get; set; }

        public string Estado { get; set; }

        public DateTime FechaPago { get; set; }
    }
}
