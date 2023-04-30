using MedicalTech.Dto;
using MedicalTech.Models;
using Microsoft.AspNetCore.Mvc;


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
        public ActionResult<EnfermeiroGetDTO> Get([FromRoute] int id)
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
            if (!TryValidateModel(enfermeiroPostDto.InstEnsFormacao)) { return StatusCode(400, "O campos obrigatorio InstEnsEnsino não está preenchidos estão nulos ou com dados inválidos"); }
            if (!TryValidateModel(enfermeiroPostDto.Cofen)) { return StatusCode(400, "O campos obrigatorio Cofen não está preenchidos estão nulos ou com dados inválidos"); }

            if (string.IsNullOrEmpty(enfermeiroPostDto.Cpf))
            {
                return StatusCode(400, "O campo CPF é obrigatório e não foi preenchido");
            }
            if (_context.Enfermeiros.Any(e => e.Cpf == enfermeiroPostDto.Cpf))
            {
                return StatusCode(409, "Já existe um enfermeiro com o mesmo CPF");
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
        [HttpPut("{id}")]
        public ActionResult<EnfermeiroPutDTO> Put(int id, [FromBody] EnfermeiroPutDTO enfermeiroPutDto)
        {
            var enfermeiroModel = _context.Enfermeiros.Where(w => w.Id == id).FirstOrDefault();
            if (enfermeiroModel == null)
            {
                return NotFound("Id não localizado!!! Certifique-se de informar o id e cpf correspondente ao enfermeiro que deseja atualizar os dados");
            }
            if (_context.Pacientes.Any(p => p.Cpf == enfermeiroPutDto.Cpf && p.Id != id))
            {
                return BadRequest("Já existe um CPF cadastrado neste paciente, a alteração deste CPF não é permitida");
            }

            enfermeiroModel.NomeCompleto = enfermeiroPutDto.NomeCompleto;
            enfermeiroModel.Cpf = enfermeiroPutDto.Cpf;
            enfermeiroModel.DataNascimento = enfermeiroPutDto.DataNascimento;
            enfermeiroModel.Telefone = enfermeiroPutDto.Telefone;
            enfermeiroModel.Cofen = enfermeiroPutDto.Cofen;
            enfermeiroModel.InstEnsFormacao = enfermeiroPutDto.InstEnsFormacao;
            _context.Enfermeiros.Attach(enfermeiroModel);
            _context.SaveChanges();
            return Ok(enfermeiroPutDto);
        }

    }
}
