using Dapper;
using Datos.dto;
using Datos.modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class CompraRepository : RepositoryEF<Compra>, ICompraRepository
    {
        protected readonly string _connectionString;
        public CompraRepository(DbContext context,string connectionString) : base(context)
        {
            repositoryEF = new RepositoryEF<Compra>(context);
            _connectionString = connectionString;
        }

        public IRepositoryEF<Compra> repositoryEF { get; set; }

        public async Task<ObtenerCompraPaginacionDto> obtenerCompra(int skip,int take)
        {
            try
            {
                ObtenerCompraPaginacionDto obtenerCompraPaginacionDto = new();
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("Skip", skip);
                parameters.Add("Take", take);
                var resultado = await connection.QueryAsync<Compra>("sp_listarCompras", parameters, commandType: CommandType.StoredProcedure);
                List<Compra> listarCompra = resultado.Cast<Compra>().ToList();
                int cantidad = parameters.Get<int>("Count");
                await connection.CloseAsync();
                obtenerCompraPaginacionDto.ListarCompra = listarCompra;
                obtenerCompraPaginacionDto.Cantidad = cantidad;
                return obtenerCompraPaginacionDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<Compra>> GetAll()
        {
            return await repositoryEF.GetAll();
        }
        public async Task<Compra> GetById(int id)
        {
            return await repositoryEF.GetEntityByIdAsync(id);
        }
        public async Task Insert(Compra compra)
        {
             await repositoryEF.Insert(compra);
        }
        public void Update(Compra compra)
        {
            repositoryEF.Update(compra);
        }
        public void UpdateFieldsSave(Compra compra)
        {
            repositoryEF.UpdateFieldsSave(compra, b => b.NumeroDocumento, c => c.RazonSocial, d => d.Total);
        }
        public async Task Delete(int id)
        {
            Compra compra = await repositoryEF.GetEntityByIdAsync(id);
            repositoryEF.Delete(compra);
        }
    }
}
