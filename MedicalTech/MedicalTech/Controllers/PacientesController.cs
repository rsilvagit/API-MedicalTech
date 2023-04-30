using MedicalTech.Dto;
using MedicalTech.Models;
using MedicalTech.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MedicalTech.Controllers
{
    [Route("api/[controller]")]
    public class PacientesController : Controller
    {
        private readonly MedicalTechContext _context;
        public PacientesController(MedicalTechContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<PacienteGetDTO>> Get()
        {
            var listPacienteModel = _context.Pacientes.ToList();
            List<PacienteGetDTO> listGetPacientes = new List<PacienteGetDTO>();
            foreach (var item in listPacienteModel)
            {
                var pacienteDto = new PacienteGetDTO();
                pacienteDto.Id = item.Id;
                pacienteDto.NomeCompleto = item.NomeCompleto;
                pacienteDto.Cpf = item.Cpf;
                pacienteDto.DataNascimento = item.DataNascimento;
                pacienteDto.Telefone = item.Telefone;
                pacienteDto.ContatoDeEmergencia = item.ContatoDeEmergencia;
                pacienteDto.ContadorTotalAtendimentos = item.ContadorTotalAtendimentos;
                pacienteDto.StatusdeAtendimento = item.StatusdeAtendimento;
                pacienteDto.Convenio = item.Convenio;
                pacienteDto.ListaCuidadosEspecificos = item.ListaCuidadosEspecificos!.Split('|').ToList();
                pacienteDto.ListaDeAlergias = item.ListaDeAlergias!.Split('|').ToList();


                listGetPacientes.Add(pacienteDto);
            }
            return Ok(listGetPacientes);
        }
        [HttpGet("{id}")]
        public ActionResult<PacienteGetDTO> Get([FromRoute] int id)
        {
            var pacienteModel = _context.Pacientes.Find(id);
            if (pacienteModel == null)
            {
                return BadRequest("Não foi localizado em nosso cadastro o paciente com o id informado");
            }
            var pacienteDto = new PacienteGetDTO();
            pacienteDto.Id = pacienteModel.Id;
            pacienteDto.NomeCompleto = pacienteModel.NomeCompleto;
            pacienteDto.Cpf = pacienteModel.Cpf;
            pacienteDto.DataNascimento = pacienteModel.DataNascimento;
            pacienteDto.Telefone = pacienteModel.Telefone;
            pacienteDto.ContatoDeEmergencia = pacienteModel.ContatoDeEmergencia;
            pacienteDto.ContadorTotalAtendimentos = pacienteModel.ContadorTotalAtendimentos;
            pacienteDto.StatusdeAtendimento = pacienteModel.StatusdeAtendimento;
            pacienteDto.Convenio = pacienteModel.Convenio;
            pacienteDto.ListaCuidadosEspecificos = pacienteModel.ListaCuidadosEspecificos!.Split('|').ToList();
            pacienteDto.ListaDeAlergias = pacienteModel.ListaDeAlergias!.Split('|').ToList();

            return Ok(pacienteDto);
        }
        [HttpPost("[Controller]")]
        public ActionResult<PacientePostDTO> Post([FromBody] PacientePostDTO pacientePostDTO, PessoaPostDTO pessoaPostDTO)

        {
            if (!TryValidateModel(pacientePostDTO.ContatoDeEmergencia)) { return StatusCode(400, "O preenchimento do campo contato de emergência é obrigatório "); }
            if (!TryValidateModel(pessoaPostDTO.DataNascimento)) { return StatusCode(400, "O preenchimento do campo Data de Nascimento com uma data válida é obrigatório "); }

            
            if (CpfJaCadastrado(pacientePostDTO.Cpf))
            {
                return StatusCode(StatusCodes.Status409Conflict, "CPF já cadastrado em nosso sistema");
            }
            if (pacientePostDTO.DataNascimento == null || pacientePostDTO.ContatoDeEmergencia == null)
            {
                return BadRequest("Preencha os campos obrigatórios, Data de Nascimento e contato de emergência");
            }

            Paciente model = new Paciente();
            model.NomeCompleto = pacientePostDTO.NomeCompleto;
            model.Cpf = pacientePostDTO.Cpf;
            model.DataNascimento = pacientePostDTO.DataNascimento;
            model.Telefone = pacientePostDTO.Telefone;
            model.ContatoDeEmergencia = pacientePostDTO.ContatoDeEmergencia;
            model.Convenio = pacientePostDTO.Convenio;
            model.ListaCuidadosEspecificos = string.Join("|", pacientePostDTO.ListaCuidadosEspecificos!);
            model.ListaDeAlergias = string.Join("|", pacientePostDTO.ListaDeAlergias!);
            model.StatusdeAtendimento = pacientePostDTO.StatusAtendimento;
            model.ContadorTotalAtendimentos = pacientePostDTO.ContadorTotalAtendimentos;
            _context.Pacientes.Add(model);
            _context.SaveChanges();
            return Created(Request.Path, pacientePostDTO);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var pdelete = _context.Pacientes.Find(id);
            if (pdelete != null)
            {
                _context.Pacientes.Remove(pdelete);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("{id}")]
        public ActionResult<PacientePutDTO> Put(int id, [FromBody] PacientePutDTO pacientePutDto)
        {
            var pacienteModel = _context.Pacientes.Where(w => w.Id == id).FirstOrDefault();
            if (pacienteModel == null)
            {
                return NotFound("Id não localizado!!! Certifique-se de informar o id e cpf correspondente ao paciente que deseja atualizar os dados");
            }
            if (_context.Pacientes.Any(p => p.Cpf == pacientePutDto.Cpf && p.Id != id))
            {
                return BadRequest("Já existe um CPF cadastrado neste paciente, a alteração deste CPF não é permitida");
            }
           
            pacienteModel.NomeCompleto = pacientePutDto.NomeCompleto;
            pacienteModel.Cpf = pacientePutDto.Cpf;
            pacienteModel.DataNascimento = pacientePutDto.DataNascimento;
            pacienteModel.Telefone = pacientePutDto.Telefone;
            pacienteModel.ContatoDeEmergencia = pacientePutDto.ContatoDeEmergencia;
            pacienteModel.Convenio = pacientePutDto.Convenio;
            pacienteModel.ListaCuidadosEspecificos = string.Join("|", pacientePutDto.ListaCuidadosEspecificos!);
            pacienteModel.ListaDeAlergias = string.Join("|", pacientePutDto.ListaDeAlergias!);
            pacienteModel.StatusdeAtendimento = pacientePutDto.StatusdeAtendimento;
            pacienteModel.ContadorTotalAtendimentos = pacientePutDto.ContadorTotalAtendimentos;
            _context.Pacientes.Attach(pacienteModel);
            _context.SaveChanges();
            return Ok(pacientePutDto);
        }
        [HttpPut("{id}/Status")]
        public ActionResult<PacientePutStatusDTO> Put(int id, [FromBody] PacientePutStatusDTO statusDTO)
        {
            var pacienteModel = _context.Pacientes.FirstOrDefault(p => p.Id == id);
            if (pacienteModel == null)
            {
                return NotFound("Paciente não encontrado.");
            }

            if (!Enum.StatusAtendimentoEnum.IsDefined(typeof(StatusAtendimentoEnum), statusDTO.StatusAtendimento))
            {
                return BadRequest("O status de atendimento informsdo  é inválido. Informe uma das seguintes opções válidas:\n0 - Aguardando_Atendimento\n1 - Em_Atendimento\n2 - Atendido\n3 - Nao_Atendido");
            }

            pacienteModel.StatusdeAtendimento = (StatusAtendimentoEnum)statusDTO.StatusAtendimento;

            _context.SaveChanges();


            return Ok($"Paciente ID {id} teve seu status de atendimento atualizado para {statusDTO.StatusAtendimento}");
        }

        private bool CpfJaCadastrado(string cpf)
        {
            return _context.Pacientes.Any(p => p.Cpf == cpf);
        }

    }
}
