using Datos.dto;
using Datos.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public interface ICompraNegocio
    {
        Task<List<Compra>> GetAll();

        Task<Compra> GetById(int id);

        Task Insert(Compra compra);

        void Update(Compra compra);

        void UpdateFieldsSave(Compra compra);

        Task Delete(int id);

        Task<ObtenerCompraPaginacionDto> ObtenerCompra(int skip, int take);
    }
}
