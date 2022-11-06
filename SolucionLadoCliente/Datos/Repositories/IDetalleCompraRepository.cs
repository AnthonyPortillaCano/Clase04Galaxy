using Datos.dto;
using Datos.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public interface IDetalleCompraRepository
    {
        Task<List<DetalleCompra>> GetAll();
        Task<DetalleCompra> GetById(int id);
        Task<DetalleCompra> GetByOrderSecuenciaCompra(int? orderSecuencia, int? IdCompra);
        Task Insert(DetalleCompra compra);
        void Update(DetalleCompra compra);
        Task Delete(int id);
        Task DeleteListDetalleCompra(int idCompra);
        Task<List<DetalleComprasDto>> ObtenerDetalleCompra(int idCompra);
    }
}
