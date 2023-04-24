using MedicalTech.Dto;
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
        public ActionResult<List<MedicoDto>> Get()
        {
            var listMedicoModel = _context.Medicos;
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
                medicoDto.Crm = item.Crm;
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
            return (medicoDto);
        }
        [HttpPost]
        public ActionResult<MedicoDto> Post([FromBody] MedicoDto medicoDto)
        {
            if (CpfJaCadastrado(medicoDto.Cpf))
            {
                return StatusCode(StatusCodes.Status409Conflict, "CPF já cadastrado em nosso sistema");
            }
            if (!ValidarCPF(medicoDto.Cpf))
            {
                return BadRequest("CPF invalido");
            }

            Medico model = new Medico();
            model.NomeCompleto = medicoDto.NomeCompleto;
            model.Cpf = medicoDto.Cpf;
            model.DataNascimento = medicoDto.DataNascimento;
            model.Telefone = medicoDto.Telefone;
            model.EspClinica = medicoDto.EspClinica;
            model.StatusSistema = medicoDto.StatusSistema;
            return Created(Request.Path, medicoDto);
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
            medicoPut.EspClinica = (Enum.EspClinicaEnum)medicoPutDTO.EspClinica;
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
