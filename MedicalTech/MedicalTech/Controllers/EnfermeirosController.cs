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
            try
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
            catch
            {
                return StatusCode(500, $"Erro ao obter a lista de enfermeiros");
            }
        }
        [HttpGet("{identificador}")]
        public ActionResult<EnfermeiroGetDTO> Get([FromRoute] int identificador)
        {
            try
            {
                var enfermeiroModel = _context.Enfermeiros.Find(identificador);

                if (enfermeiroModel == null)
                {
                    return NotFound($"Não foi localizado em nosso cadastro o enfermeiro com o id {identificador}");
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
            catch
            {
                
                return StatusCode(500, $"Ocorreu um erro ao buscar o enfermeiro com id {identificador}");
            }
        }
        [HttpPost]
        public ActionResult<EnfermeiroPostDTO> Post([FromBody] EnfermeiroPostDTO enfermeiroPostDto)
        {
            try
            {
                if (enfermeiroPostDto.InstEnsFormacao=="")
                {
                    return StatusCode(400, "O campo obrigatório InstEnsEnsino não está preenchido ou está nulo");
                }
                if (enfermeiroPostDto.Cofen=="")
                {
                    return StatusCode(400, "O campo obrigatório Cofen não está preenchido ou está nulo");
                }

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
            catch
            {
                return StatusCode(500, $"Ocorreu um erro ao tentar salvar o enfermeiro: {enfermeiroPostDto}");
            }
        }
        [HttpDelete("{identificador}")]
        public ActionResult Delete([FromRoute] int identificador)
        {
            try
            {
                var edelete = _context.Enfermeiros.Find(identificador);
                if (edelete != null)
                {
                    _context.Enfermeiros.Remove(edelete);
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound($"Ñão foi encontrado em nosso sistema o enfermeiro com id {identificador}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir o enfermeiro com identificador: {identificador}");
            }
        }
        [HttpPut("{identificador}")]
        public ActionResult<EnfermeiroPutDTO> Put(int identificador, [FromBody] EnfermeiroPutDTO enfermeiroPutDto)
        {
            try
            {
                var enfermeiroModel = _context.Enfermeiros.Where(w => w.Id == identificador).FirstOrDefault();
                if (enfermeiroModel == null)
                {
                    return NotFound("Id não localizado!!! Certifique-se de informar o id e cpf correspondente ao enfermeiro que deseja atualizar os dados");
                }
                if (_context.Enfermeiros.Any(e => e.Cpf == enfermeiroPutDto.Cpf))
                {
                    return StatusCode(409, "Já existe um enfermeiro com o mesmo CPF");
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
            catch
            {
                return StatusCode(500, $"Erro ao atualizar enfermeiro: {enfermeiroPutDto}");
            }
        }

    }
}
