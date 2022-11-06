using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public interface IUnitOfWork
    {
        ICompraNegocio compraNegocio { get;}
        IDetalleCompraNegocio detalleCompraNegocio { get; }
        IPersonaNegocio personaNegocio { get;  }

        Task<int> CommitAsync();
    }
}
