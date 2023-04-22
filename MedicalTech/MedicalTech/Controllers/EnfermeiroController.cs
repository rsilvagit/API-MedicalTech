using MedicalTech.Dto;
using MedicalTech.Models;
using Microsoft.AspNetCore.Mvc;
using CPFValidation;

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
            var listEnfermeiroModel = _context.Enfermeiros;
            List<EnfermeiroDto> listGetDto = new List<EnfermeiroDto>();

            foreach (var item in listEnfermeiroModel)
            {
                var enfermeiroDto = new EnfermeiroDto();
                enfermeiroDto.Id = item.Id;
                enfermeiroDto.NomeCompleto = item.NomeCompleto;
                enfermeiroDto.Cpf = item.Cpf;
                enfermeiroDto.DataNascimento = item.DataNascimento;
                enfermeiroDto.Telefone = item.Telefone;
                enfermeiroDto.Cofen = item.Cofen;
                enfermeiroDto.InstEnsFormacao = item.InstEnsFormacao;
                listGetDto.Add(enfermeiroDto);
            }

            return Ok(listGetDto);
        }
        [HttpGet("{id}")]
        public ActionResult<EnfermeiroDto> Get([FromRoute] int id)
        {
            var enfermeiroModel = _context.Enfermeiros.Find(id);

            if (enfermeiroModel == null)
            {
                return NotFound("Não foi localizado em nosso cadastro o enfermeiro com o id informado");
            }

            EnfermeiroDto enfermeiroDto = new EnfermeiroDto();
            enfermeiroDto.Id = enfermeiroModel.Id;
            enfermeiroDto.NomeCompleto = enfermeiroModel.NomeCompleto;
            enfermeiroDto.Cpf = enfermeiroModel.Cpf;
            enfermeiroDto.Cofen = enfermeiroModel.Cofen;
            enfermeiroDto.DataNascimento = enfermeiroModel.DataNascimento;
            enfermeiroDto.Telefone = enfermeiroModel.Telefone;
            enfermeiroDto.InstEnsFormacao = enfermeiroModel.InstEnsFormacao;

            return Ok(enfermeiroDto);

        }
        [HttpPost]
        public ActionResult<EnfermeiroDto> Post([FromBody] EnfermeiroDto enfermeiroDto)
        {
            if (!ValidarCPF(enfermeiroDto.Cpf))
            {
                return BadRequest("CPF invalido");
            }
            if (CpfJaCadastrado(enfermeiroDto.Cpf))
            {
                return StatusCode(StatusCodes.Status409Conflict, "CPF já cadastrado em nosso sistema");
            }
            Enfermeiro model = new Enfermeiro();
            model.NomeCompleto = enfermeiroDto.NomeCompleto;
            model.Cpf = enfermeiroDto.Cpf;
            model.DataNascimento = enfermeiroDto.DataNascimento;
            model.Telefone = enfermeiroDto.Telefone;
            model.InstEnsFormacao = enfermeiroDto.InstEnsFormacao;
            model.Cofen = enfermeiroDto.Cofen;
            

            return Created(Request.Path, enfermeiroDto);
        }
        private bool CpfJaCadastrado(string cpf)
        {
            return _context.Pacientes.Any(p => p.Cpf == cpf);
        }
        private static bool ValidarCPF(string cpf)
        {
            const int tamanhoCpf = 11;
            int[] multiplicadoresPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadoresSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };


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
