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
        [HttpGet("{id}")]
        public ActionResult<EnfermeiroDto> Get([FromRoute] int id) 
        {
            var enfermeiroModel = _context.Enfermeiros.Find(id);

            if(enfermeiroModel==null) 
            {
                return NotFound("Não foi localizado em nosso cadastro o enfermeiro com o id informado");
            }

            EnfermeiroDto enfermeiroDto= new EnfermeiroDto();
            enfermeiroDto.Id = enfermeiroModel.Id;
            enfermeiroDto.NomeCompleto = enfermeiroModel.NomeCompleto;
            enfermeiroDto.Cpf=enfermeiroModel.Cpf;
            enfermeiroDto.Cofen=enfermeiroModel.Cofen;
            enfermeiroDto.DataNascimento = enfermeiroModel.DataNascimento;
            enfermeiroDto.Telefone = enfermeiroModel.Telefone;
            enfermeiroDto.InstEnsFormacao = enfermeiroModel.InstEnsFormacao;
            
            return Ok(enfermeiroDto);

        }
    }
}
