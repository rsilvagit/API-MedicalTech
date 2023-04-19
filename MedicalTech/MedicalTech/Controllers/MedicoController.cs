using Microsoft.AspNetCore.Mvc;

namespace MedicalTech.Controllers
{
    public class MedicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
