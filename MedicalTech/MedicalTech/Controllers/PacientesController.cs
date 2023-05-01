using MedicalTech.Dto;
using MedicalTech.Models;
using MedicalTech.Enumerador;
using Microsoft.AspNetCore.Mvc;


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
            try
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar a requisição.");
            }
        }
        [HttpGet("{identificador}")]
        public ActionResult<PacienteGetDTO> Get([FromRoute] int identificador)
        {
            try
            {
                var pacienteModel = _context.Pacientes.Find(identificador);
                if (pacienteModel == null)
                {
                    return BadRequest($"Não foi localizado em nosso cadastro o paciente com o id {identificador} ");
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao buscar o paciente");
            }
        }
        [HttpPost]
        public ActionResult<PacientePostDTO> Post([FromBody] PacientePostDTO pacientePostDTO)
        {
            try
            {
                if (pacientePostDTO.ContatoDeEmergencia == "")
                {
                    return StatusCode(400, "O preenchimento do campo contato de emergência é obrigatório ");
                }

                if (CpfJaCadastrado(pacientePostDTO.Cpf))
                {
                    return StatusCode(StatusCodes.Status409Conflict, "CPF já cadastrado em nosso sistema");
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
            catch
            {
                return StatusCode(500, $"Ocorreu um erro ao cadastrar o paciente: {pacientePostDTO}");
            }
        }

        [HttpDelete("{identificador}")]
        public ActionResult Delete([FromRoute] int identificador)
        {
            try
            {
                var pdelete = _context.Pacientes.Find(identificador);
                if (pdelete != null)
                {
                    _context.Pacientes.Remove(pdelete);
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound($"Id {identificador} não está registrado em nossa base de dados");
                }
            }
            catch
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir o paciente com: {identificador}");
            }
        }


        [HttpPut("{identificador}")]
        public ActionResult<PacientePutDTO> Put(int identificador, [FromBody] PacientePutDTO pacientePutDto)
        {
            try
            {
                var pacienteModel = _context.Pacientes.Where(w => w.Id == identificador).FirstOrDefault();
                if (pacienteModel == null)
                {
                    return NotFound($"Id {identificador} não localizado em nossa base de dados");
                }
                if (CpfJaCadastrado(pacientePutDto.Cpf))
                {
                    return Conflict($"Já existe um paciente candastrado no cpf {pacientePutDto.Cpf} em nossa base de dados");
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
            catch
            {
                return StatusCode(400, $"Constam dados invalidos na requisição de atualização do paciente: {pacientePutDto}");
            }
        }
        [HttpPut("{identificador}/Status")]
        public ActionResult<PacientePutStatusDTO> Put(int identificador, [FromBody] PacientePutStatusDTO statusDTO)
        {
            try
            {
                var pacienteModel = _context.Pacientes.FirstOrDefault(p => p.Id == identificador);
                if (pacienteModel == null)
                {
                    return NotFound($"Não foi loicalizado em nossa base de dados o paciente com id: {identificador}");
                }

                pacienteModel.StatusdeAtendimento = (StatusAtendimentoEnum)statusDTO.StatusAtendimento;

                _context.SaveChanges();

                return Ok($"Paciente ID {identificador} teve seu status de atendimento atualizado para {statusDTO.StatusAtendimento}");
            }
            catch
            {
                return BadRequest($"Constam dados invalidos na requisição de atualização do paciente com id: {identificador}");
            }
        }
        private bool CpfJaCadastrado(string cpf)
        {
            return _context.Pacientes.Any(p => p.Cpf == cpf);
        }

    }
}
