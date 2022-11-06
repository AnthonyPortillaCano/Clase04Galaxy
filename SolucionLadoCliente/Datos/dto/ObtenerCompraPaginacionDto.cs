using Datos.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.dto
{
    public class ObtenerCompraPaginacionDto
    {
        public List<Compra> ListarCompra { get; set; }
        public int Cantidad { get; set; }
    }
}
