using Datos.dto;
using Datos.modelos;
using Datos.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Negocio
{
    public class CompraNegocio: ICompraNegocio
    {
        protected ICompraRepository _compraRepository;
        protected readonly string _connectionString;
        public CompraNegocio(DbContext context,string connectString)
        {
            _connectionString = connectString;
            _compraRepository = new CompraRepository(context, _connectionString);
        }
        public async Task<List<Compra>> GetAll()
        {
            return await _compraRepository.GetAll();
        }
        public async Task<Compra> GetById(int id)
        {
            return await _compraRepository.GetById(id);
        }
        public async Task Insert(Compra compra)
        {
            await _compraRepository.Insert(compra);
        }
        public void Update(Compra compra)
        {
            _compraRepository.Update(compra);
        }
        public void UpdateFieldsSave(Compra compra)
        {
            _compraRepository.UpdateFieldsSave(compra);
        }
        public async Task Delete(int id)
        {
            await _compraRepository.Delete(id);
        }
        public async Task<ObtenerCompraPaginacionDto> ObtenerCompra(int skip, int take)
        {
            return await _compraRepository.obtenerCompra(skip, take);
        }
    }
}