using Dapper;
using Datos.dto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class OrdenesPagoRepository: IOrdenesPagoRepository
    {
        protected readonly string _connectionString;
        public OrdenesPagoRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }
        public async Task<List<OrdenPagoDto>> ListarOrdenPago()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                var resultado = await connection.QueryAsync<OrdenPagoDto>("sp_ListarOrdenesPago", CommandType.StoredProcedure);
                List<OrdenPagoDto> listOrdenes=resultado.Cast<OrdenPagoDto>().ToList();
                await connection.CloseAsync();
                return listOrdenes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
