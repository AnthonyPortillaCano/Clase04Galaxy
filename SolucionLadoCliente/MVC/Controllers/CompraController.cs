using Datos.dto;
using Datos.modelos;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace MVC.Controllers
{
    [Route("Compra")]
    public class CompraController : BaseController
    {
        public CompraController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        private readonly int _registrarPorPagina = 10;
        private PaginadorGenerico<Compra> paginadorGenerico;

        [Route("Listar")]
        public async  Task<IActionResult> Listar(int pagina=1)
        {
            int skyp = (pagina - 1) * _registrarPorPagina;
            ObtenerCompraPaginacionDto obtenerPaginacion = await _unitOfWork.compraNegocio.ObtenerCompra(skyp, _registrarPorPagina);
            int _totalRegistros = obtenerPaginacion.Cantidad;
            var _totalPaginas = (int)Math.Ceiling((double)_totalRegistros / _registrarPorPagina);
            paginadorGenerico = new PaginadorGenerico<Compra>()
            {
                RegistroPorPagina = _registrarPorPagina,
                TotalRegistros = _totalRegistros,
                TotalPagina = _totalPaginas,
                PaginaActual = pagina,
                Resultado = obtenerPaginacion.ListarCompra
            };
            return View(paginadorGenerico);
        }
        [HttpPost]
        [Route("Eliminar")]
        public async Task<IActionResult> EliminarCompra(int id)
        {
            await _unitOfWork.detalleCompraNegocio.DeleteList(id);
            await _unitOfWork.compraNegocio.Delete(id);
            var resultado = await _unitOfWork.CommitAsync();
             if(resultado>0)
            {
                return RedirectToAction("Listar");
            }
             return View(resultado);
        }
    }
}
