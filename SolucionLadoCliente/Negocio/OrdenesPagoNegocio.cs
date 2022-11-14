using Datos.dto;
using Datos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class OrdenesPagoNegocio: IOrdenesPagoNegocio
    {
        protected IOrdenesPagoRepository _ordenesPagoRpository;
        protected readonly string _connectionString;
        public OrdenesPagoNegocio(string connectionString)
        {
            _connectionString = connectionString;
            _ordenesPagoRpository=new OrdenesPagoRepository(connectionString);
        }
        public async Task<List<OrdenPagoDto>> ListOrdenPago()
        {
            return await _ordenesPagoRpository.ListarOrdenPago();
        }
    }
}
