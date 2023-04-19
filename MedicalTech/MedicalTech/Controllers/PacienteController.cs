using Microsoft.AspNetCore.Mvc;

namespace MedicalTech.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
