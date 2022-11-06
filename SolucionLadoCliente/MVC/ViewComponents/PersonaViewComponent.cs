using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace MVC.ViewComponents
{
    public class PersonaViewComponent:ViewComponent
    {
        protected readonly IUnitOfWork _unitOfWork;
        public PersonaViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _unitOfWork.personaNegocio.ListarPersona());
        }
    }
}
