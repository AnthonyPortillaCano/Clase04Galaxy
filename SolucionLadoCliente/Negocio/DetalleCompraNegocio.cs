using Datos.dto;
using Datos.modelos;
using Datos.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DetalleCompraNegocio: IDetalleCompraNegocio
    {
        protected  IDetalleCompraRepository _detalleCompraRepository;

        protected readonly string _connectionString;
        public DetalleCompraNegocio(DbContext context,string connectionString)
        {
            _connectionString = connectionString;
            _detalleCompraRepository = new DetalleCompraRepository(context, _connectionString);
        }
        public async Task<List<DetalleCompra>> GetAll()
        {
            return await _detalleCompraRepository.GetAll();
        }
        public async Task<DetalleCompra> GetById(int id)
        {
            return await _detalleCompraRepository.GetById(id);
        }
        public async Task<DetalleCompra> GetByOrderSecuenciaCompra(int? ordenSecuencia,int? IdCompra)
        {
            return await _detalleCompraRepository.GetByOrderSecuenciaCompra(ordenSecuencia, IdCompra);
        }

        public async Task Insert(DetalleCompra detalleCompra)
        {
          await   _detalleCompraRepository.Insert(detalleCompra);
        }
        public void Update(DetalleCompra detalleCompra)
        {
            _detalleCompraRepository.Update(detalleCompra);
        }
        public async Task Delete(int id)
        {
            await _detalleCompraRepository.Delete(id);
        }
        public async  Task<List<DetalleComprasDto>> ObtenerDetalleCompra(int idCompra)
        {
           return await _detalleCompraRepository.ObtenerDetalleCompra(idCompra);
        }
        public async Task DeleteList(int idCompra)
        {
            await _detalleCompraRepository.DeleteListDetalleCompra(idCompra);
        }

    }
}
