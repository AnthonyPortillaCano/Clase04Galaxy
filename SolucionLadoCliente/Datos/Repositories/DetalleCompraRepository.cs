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
    public class DetalleCompraRepository : RepositoryEF<DetalleCompra>, IDetalleCompraRepository
    {
        protected readonly string _connectionString;
        public DetalleCompraRepository(DbContext context,string connectionString) : base(context)
        {
            repositoryEF = new RepositoryEF<DetalleCompra>(context);
            _connectionString = connectionString;
        }
        public IRepositoryEF<DetalleCompra> repositoryEF;
        public async Task<List<DetalleCompra>> GetAll()
        {
            return await repositoryEF.GetAll();
        }
        public async Task<DetalleCompra> GetById(int id)
        {
            return await repositoryEF.GetEntityByIdAsync(id);
        }
        public async Task<DetalleCompra> GetByOrderSecuenciaCompra(int? orderSecuencia,int? IdCompra)
        {
            DetalleCompra resultado=await repositoryEF.Obtener<DetalleCompra>(a=>a.OrdenSecuencia==orderSecuencia && a.IdCompra==IdCompra);
            return resultado;
        }
        public async Task Insert(DetalleCompra compra)
        {
            await repositoryEF.Insert(compra);
        }
        public void Update(DetalleCompra compra)
        {
            repositoryEF.Update(compra);
        }
        public async Task Delete(int id)
        {
            DetalleCompra detalleCompra = await repositoryEF.GetEntityByIdAsync(id);
            repositoryEF.Delete(detalleCompra);
        }
        public async Task DeleteListDetalleCompra(int idCompra)
        {
            List<DetalleCompra> lista = await repositoryEF.ObtenerList<DetalleCompra>(a => a.IdCompra == idCompra);
            repositoryEF.DeleteList(lista);
        }
        public async Task<List<DetalleComprasDto>> ObtenerDetalleCompra(int idCompra)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            var parameters = new DynamicParameters();
            parameters.Add("IdCompra", idCompra);
            var resultado = await connection.QueryAsync<DetalleCompra>("sp_DetalleCompra", parameters, commandType: CommandType.StoredProcedure);
            List<DetalleComprasDto> listDetalleCompra = resultado.Cast<DetalleComprasDto>().ToList();
            await connection.CloseAsync();
            return listDetalleCompra;
        }
    }
}
