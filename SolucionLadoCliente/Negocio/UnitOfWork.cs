using Datos.modelos;

namespace Negocio
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly BDEmpresaContext _context;
        protected readonly string _connectionString;
        public UnitOfWork(BDEmpresaContext context,string connectionString)
        {
            _context = context;
             _connectionString = connectionString;
            compraNegocio = new CompraNegocio(_context, _connectionString);
            detalleCompraNegocio = new DetalleCompraNegocio(_context, connectionString);
            personaNegocio = new PersonaNegocio(connectionString);
        }
        public ICompraNegocio compraNegocio { get; private set; }
        public IDetalleCompraNegocio detalleCompraNegocio { get; private set; }
        public IPersonaNegocio personaNegocio { get; private set; }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
