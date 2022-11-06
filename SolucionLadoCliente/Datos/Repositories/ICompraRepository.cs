using Datos.dto;
using Datos.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public interface ICompraRepository
    {
        Task<ObtenerCompraPaginacionDto> obtenerCompra(int skip, int take);
        Task<List<Compra>> GetAll();
        Task<Compra> GetById(int id);
        Task Insert(Compra compra);
        void Update(Compra compra);
        void UpdateFieldsSave(Compra compra);
        Task Delete(int id);
    }
}
