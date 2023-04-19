using MedicalTech.Dto;
using MedicalTech.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTech.Controllers
{
    [Route("[controller]")]
        public class EnfermeiroController : Controller
    {
        private readonly MedicalTechContext _context;
        public EnfermeiroController(MedicalTechContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<EnfermeiroDto>> Get()
        {
            var listEnfermeiroModel=_context.Enfermeiros;
            List<EnfermeiroDto>listGetDto= new List<EnfermeiroDto>();

            foreach (var item in listEnfermeiroModel)
            {
                var enfermeiroDto = new EnfermeiroDto();
                listGetDto.Add(enfermeiroDto);
            }
            
            return Ok(listGetDto);
        }
    }
}
