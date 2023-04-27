using MedicalTech.Dto;
using MedicalTech.Models;
using Microsoft.AspNetCore.Mvc;
using CPFValidation;

namespace MedicalTech.Controllers
{
    [Route("api/[controller]")]
    public class EnfermeirosController : Controller
    {
        private readonly MedicalTechContext _context;
        public EnfermeirosController(MedicalTechContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<EnfermeiroGetDTO>> Get()
        {
            var listEnfermeiroModel = _context.Enfermeiros;
            List<EnfermeiroGetDTO> listGetDto = new List<EnfermeiroGetDTO>();

            foreach (var item in listEnfermeiroModel)
            {
                var enfermeiroDto = new EnfermeiroGetDTO();
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
        public ActionResult<EnfermeiroGetDTO> Get([FromRoute]int id) 
        {
            var enfermeiroModel = _context.Enfermeiros.Find(id);

            if (enfermeiroModel == null)
            {
                return NotFound("Não foi localizado em nosso cadastro o enfermeiro com o id informado");
            }

            EnfermeiroGetDTO enfermeiroDto = new EnfermeiroGetDTO();
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
        public ActionResult<EnfermeiroPostDTO> Post([FromBody] EnfermeiroPostDTO enfermeiroPostDto)
        {
           
            if (!ValidarCPF(enfermeiroPostDto.Cpf))
            {
                return BadRequest("CPF invalido");
            } 
            if (CpfJaCadastrado(enfermeiroPostDto.Cpf))
            {
                return StatusCode(StatusCodes.Status409Conflict, "CPF já cadastrado em nosso sistema");
            }
            Enfermeiro model = new Enfermeiro();
            model.NomeCompleto = enfermeiroPostDto.NomeCompleto;
            model.Cpf = enfermeiroPostDto.Cpf;
            model.DataNascimento = enfermeiroPostDto.DataNascimento;
            model.Telefone = enfermeiroPostDto.Telefone;
            model.InstEnsFormacao = enfermeiroPostDto.InstEnsFormacao;
            model.Cofen = enfermeiroPostDto.Cofen;
            _context.Enfermeiros.Add(model);
            _context.SaveChanges();
            return Created(Request.Path, enfermeiroPostDto);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var edelete = _context.Enfermeiros.Find(id);
            if (edelete != null)
            {
                _context.Enfermeiros.Remove(edelete);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
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
