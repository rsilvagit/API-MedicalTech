using MedicalTech.Dto;
using MedicalTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace MedicalTech.Controllers
{
    [Route("/controller")]
    public class PacienteController : Controller
    {
        private readonly MedicalTechContext _context;
        public PacienteController(MedicalTechContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<PacienteDto>> Get()
        {
            var listPacienteModel=_context.Pacientes.ToList();
            List<PacienteDto>listGetPacientes= new List<PacienteDto>();
            foreach (var item in listPacienteModel)
            {
                var pacienteDto = new PacienteDto();
                pacienteDto.Id = item.Id;
                pacienteDto.NomeCompleto = item.NomeCompleto;
                pacienteDto.Cpf = item.Cpf;
                pacienteDto.DataNascimento = item.DataNascimento;
                pacienteDto.Telefone = item.Telefone;
                pacienteDto.ContatoDeEmergencia = item.ContatoDeEmergencia;
                pacienteDto.ContadorTotalAtendimentos = item.ContadorTotalAtendimentos;
                pacienteDto.StatusAtendimento = item.StatusdeAtendimento;
                pacienteDto.Convenio = item.Convenio;
                pacienteDto.ListaCuidadosEspecifios = item.ListaCuidadosEspecifios;
                pacienteDto.ListaDeAlergias=item.ListaDeAlergias;
                

                listGetPacientes.Add(pacienteDto);
            }
            return Ok(listGetPacientes);
        }
        [HttpGet("{id}")]
        public ActionResult<PacienteDto> Get([FromRoute] int id)
        {
            var pacienteModel = _context.Pacientes.Find(id);
            if (pacienteModel == null)
            {
                return BadRequest("Não foi localizado em nosso cadastro o paciente com o id informado");
            }
            var pacienteDto = new PacienteDto();
            pacienteDto.Id = pacienteModel.Id;
            pacienteDto.NomeCompleto = pacienteModel.NomeCompleto;
            pacienteDto.Cpf = pacienteModel.Cpf;
            pacienteDto.DataNascimento = pacienteModel.DataNascimento;
            pacienteDto.Telefone = pacienteModel.Telefone;
            pacienteDto.ContatoDeEmergencia = pacienteModel.ContatoDeEmergencia;
            pacienteDto.ContadorTotalAtendimentos = pacienteModel.ContadorTotalAtendimentos;
            pacienteDto.StatusAtendimento = pacienteModel.StatusdeAtendimento;
            pacienteDto.Convenio = pacienteModel.Convenio;
            pacienteDto.ListaCuidadosEspecificos = pacienteModel.ListaCuidadosEspecificos;
            pacienteDto.ListaDeAlergias = pacienteModel.ListaDeAlergias;

            return Ok(pacienteDto);
        };
        [HttpPost]
        public ActionResult<PacienteDto>Post([FromBody]PacienteDto pacienteDto)
        {
            if (pacienteDto.Cpf == "12345678901")
            {
                return StatusCode(StatusCodes.Status409Conflict, "CPF já cadastrado em nosso sistema");
            }
            Paciente model = new Paciente();
            model.NomeCompleto=pacienteDto.NomeCompleto;
            model.Cpf= pacienteDto.Cpf;
            model.DataNascimento = pacienteDto.DataNascimento;
            model.Telefone=pacienteDto.Telefone;
            model.ContatoDeEmergencia = pacienteDto.ContatoDeEmergencia;
            model.Convenio=pacienteDto.Convenio;
            model.ListaCuidadosEspecificos = string.Join(" | ", pacienteDto.ListaCuidadosEspecificos!);
            model.ListaDeAlergias = string.Join(" | ", pacienteDto.ListaDeAlergias!);
            model.StatusdeAtendimento = pacienteDto.StatusAtendimento;
            model.ContadorTotalAtendimentos = pacienteDto.ContadorTotalAtendimentos;

            return Ok(pacienteDto);
        }
    }
}
