using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace MVC.Controllers
{
    [Route("OrdenPago")]
    public class OrdenPagoController : BaseController
    {
        public OrdenPagoController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [Route("MostrarGrafico")]
        public async  Task<IActionResult> MostrarGrafico()
        {
            ViewBag.listOrdenes = await _unitOfWork.ordenesPagoNegocio.ListOrdenPago();
            return View();
        }
    }
}
