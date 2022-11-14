using Datos.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public interface IOrdenesPagoRepository
    {
        Task<List<OrdenPagoDto>> ListarOrdenPago();
    }
}
