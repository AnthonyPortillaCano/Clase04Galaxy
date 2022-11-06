using Datos.dto;
using Datos.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public interface IDetalleCompraNegocio
    {
        Task<List<DetalleCompra>> GetAll();
        Task<DetalleCompra> GetById(int id);

        Task<DetalleCompra> GetByOrderSecuenciaCompra(int? ordenSecuencia, int? IdCompra);

        Task Insert(DetalleCompra detalleCompra);
        void Update(DetalleCompra detalleCompra);
        Task Delete(int id);

        Task<List<DetalleComprasDto>> ObtenerDetalleCompra(int idCompra);

        Task DeleteList(int idCompra);
    }
}
