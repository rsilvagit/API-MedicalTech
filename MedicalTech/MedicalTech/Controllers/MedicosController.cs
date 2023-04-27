using MedicalTech.Dto;
using MedicalTech.Enum;
using MedicalTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace MedicalTech.Controllers
{
    [Route("api/[controller]")]

    public class MedicosController : ControllerBase
    {
        private readonly MedicalTechContext _context;

        public MedicosController(MedicalTechContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<MedicoGetDTO>> Get()
        {
            var listMedicoModel = _context.Medicos;
            List<MedicoGetDTO> listGetDto = new List<MedicoGetDTO>();

            foreach (var item in listMedicoModel)
            {
                var medicoDto = new MedicoGetDTO();
                medicoDto.Id = item.Id;
                medicoDto.NomeCompleto = item.NomeCompleto;
                medicoDto.Cpf = item.Cpf;
                medicoDto.DataNascimento = item.DataNascimento;
                medicoDto.Telefone = item.Telefone;
                medicoDto.EspClinica = (EspClinicaEnum)item.EspClinica;
                medicoDto.InstEnsinoForm = item.InstEnsinoForm;
                medicoDto.Crm = item.Crm;
                medicoDto.StatusSistema = item.StatusSistema;
                listGetDto.Add(medicoDto);
            }

            return Ok(listGetDto);
        }
        [HttpGet("{id}")]
              public ActionResult<MedicoGetDTO> Get([FromRoute] string id)
        {
            var medicoModel = _context.Medicos.Find(id);
            if (medicoModel == null)
            {
                return NotFound("Não foi localizado em nosso cadastro o médico com o id informado");
            }
            var getDto = new MedicoGetDTO();
            getDto.Id = medicoModel.Id;
            getDto.NomeCompleto = medicoModel.NomeCompleto;
            getDto.Cpf = medicoModel.Cpf;
            getDto.DataNascimento = medicoModel.DataNascimento;
            getDto.Telefone = medicoModel.Telefone;
            getDto.EspClinica = (EspClinicaEnum) medicoModel.EspClinica;
            getDto.InstEnsinoForm = medicoModel.InstEnsinoForm;
            getDto.Crm = medicoModel.Crm;
            getDto.StatusSistema = medicoModel.StatusSistema;
            return (getDto);
        }
        [HttpPost]
        
               public ActionResult<MedicoPostDTO> Post([FromBody] MedicoPostDTO medicoPostDTO)
        {
            if (CpfJaCadastrado(medicoPostDTO.Cpf))
            {
                return StatusCode(StatusCodes.Status409Conflict, "CPF já cadastrado em nosso sistema");
            }
            if (!ValidarCPF(medicoPostDTO.Cpf))
            {
                return BadRequest("CPF invalido");
            }

            Medico model = new Medico();
            model.NomeCompleto = medicoPostDTO.NomeCompleto;
            model.Cpf = medicoPostDTO.Cpf;
            model.DataNascimento = medicoPostDTO.DataNascimento;
            model.Telefone = medicoPostDTO.Telefone;
            model.EspClinica = medicoPostDTO.EspClinica;
            model.StatusSistema = medicoPostDTO.StatusSistema;
            _context.Medicos.Add(model);
            _context.SaveChanges();
            return Created(Request.Path, medicoPostDTO);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var mdelete = _context.Medicos.Find(id);
            if (mdelete != null)
            {
                _context.Medicos.Remove(mdelete);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("/medicos{id}")]
        public ActionResult<MedicoPutDTO> Put(int id, [FromBody] MedicoPutDTO medicoPutDTO)
        {
            var medicoPut = _context.Medicos.Where(w => w.Id == id).FirstOrDefault();
            if(medicoPut == null)
            {
                return NotFound("Id não localizado!!! Certifique-se de informar o id e cpf correspondente ao medico que deseja atualizar os dados");
            }
            if (ValidarCPF(medicoPutDTO.Cpf))
            {
                return BadRequest("CPF inválido");
            }
            if (CpfJaCadastrado(medicoPutDTO.Cpf))
            {
                return BadRequest();
            }

            medicoPut.NomeCompleto = medicoPutDTO.NomeCompleto;
            medicoPut.EspClinica = (EspClinicaEnum)medicoPutDTO.EspClinica;
            medicoPut.Telefone = medicoPutDTO.Telefone;
            medicoPut.DataNascimento = medicoPutDTO.DataNascimento;
            medicoPut.InstEnsinoForm = medicoPutDTO.InstEnsinoForm;

            _context.Medicos.Attach(medicoPut);
            _context.SaveChanges();
            return Ok(medicoPutDTO);


        }
        private bool CpfJaCadastrado(string cpf)
        {
            return _context.Medicos.Any(p => p.Cpf == cpf);
        }

        private static bool ValidarCPF(string cpf)
        {
            const int tamanhoCpf = 11;
            int[] multiplicadoresPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadoresSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Replace(".", "").Replace("-", "");
            if (string.IsNullOrEmpty(cpf) || cpf.Length != tamanhoCpf)
            {
                return false;
            }
            int soma = 0;
            for (int i = 0; i < multiplicadoresPrimeiroDigito.Length; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * multiplicadoresPrimeiroDigito[i];
            }
            int resto = soma % 11;
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;
            if (primeiroDigito != int.Parse(cpf[9].ToString()))
            {
                return false;
            }
            soma = 0;
            for (int i = 0; i < multiplicadoresSegundoDigito.Length; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * multiplicadoresSegundoDigito[i];
            }
            resto = soma % 11;
            int segundoDigito = resto < 2 ? 0 : 11 - resto;
            if (segundoDigito != int.Parse(cpf[10].ToString()))
            {
                return false;
            }
            return true;
        }





    }

}
