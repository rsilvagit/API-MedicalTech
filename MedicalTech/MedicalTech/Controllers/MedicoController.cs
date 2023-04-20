using MedicalTech.Dto;
using MedicalTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalTech.Controllers
{
    [Route("/[controller]")]

    public class MedicoController : ControllerBase
    {
        private readonly MedicalTechContext _context;
        
        public MedicoController(MedicalTechContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<MedicoDto>> Get()
    {
        var listMedicoModel =_context.Medicos;
        List<MedicoDto> listGetDto = new List<MedicoDto>();

        foreach (var item in listMedicoModel)
        {
            var medicoDto = new MedicoDto();
            medicoDto.Id = item.Id;
            medicoDto.NomeCompleto = item.NomeCompleto;
            medicoDto.Cpf = item.Cpf;
            medicoDto.DataNascimento = item.DataNascimento;
            medicoDto.Telefone = item.Telefone;
            medicoDto.EspClinica = item.EspClinica;
            medicoDto.InstEnsinoForm = item.InstEnsinoForm;
            medicoDto.Crm= item.Crm;
            medicoDto.StatusSistema = item.StatusSistema;
                listGetDto.Add(medicoDto);
        }

        return Ok(listGetDto);
    }
        [HttpGet("{id}")]
        public ActionResult<MedicoDto> Get([FromRoute] int id)
        {
            var medicoModel = _context.Medicos.Find(id);
            if (medicoModel == null)
            {
                return NotFound("Não foi localizado em nosso cadastro o médico com o id informado");
            }
            var medicoDto = new MedicoDto();
            medicoDto.Id = medicoModel.Id;
            medicoDto.NomeCompleto = medicoModel.NomeCompleto;
            medicoDto.Cpf = medicoModel.Cpf;
            medicoDto.DataNascimento = medicoModel.DataNascimento;
            medicoDto.Telefone = medicoModel.Telefone;
            medicoDto.EspClinica = medicoModel.EspClinica;
            medicoDto.InstEnsinoForm = medicoModel.InstEnsinoForm;
            medicoDto.Crm = medicoModel.Crm;
            medicoDto.StatusSistema = medicoModel.StatusSistema;
            return(medicoDto);
        }


    }
    
}
