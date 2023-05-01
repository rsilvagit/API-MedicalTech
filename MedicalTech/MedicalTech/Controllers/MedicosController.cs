using MedicalTech.Dto;
using MedicalTech.Enumerador;
using MedicalTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using System;

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
            try
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
            catch
            {
                return StatusCode(400, "Não foram localizados médicos em nosso cadastro");
            }
        }
        [HttpGet("{identificador}")]
        public ActionResult<MedicoGetDTO> Get([FromRoute] int identificador)
        {
            try
            {
                var medicoModel = _context.Medicos.Find(identificador);
                if (medicoModel.Id == null)
                {
                    return NotFound("Não foi localizado em nosso cadastro o médico com o id informado");
                }

                var getDto = new MedicoGetDTO();
                getDto.Id = medicoModel.Id;
                getDto.NomeCompleto = medicoModel.NomeCompleto;
                getDto.Cpf = medicoModel.Cpf;
                getDto.DataNascimento = medicoModel.DataNascimento;
                getDto.Telefone = medicoModel.Telefone;
                getDto.EspClinica = (EspClinicaEnum)medicoModel.EspClinica;
                getDto.InstEnsinoForm = medicoModel.InstEnsinoForm;
                getDto.Crm = medicoModel.Crm;
                getDto.StatusSistema = medicoModel.StatusSistema;

                return Ok(getDto);
            }
            catch
            {
                
                return NotFound($"Não foi encontardo em nossa base de dados o medico com o id {identificador}.");
            }
        }

        [HttpPost]
        public ActionResult<MedicoPostDTO> Post([FromBody] MedicoPostDTO medicoPostDTO)
        {
            try
            {
                if (medicoPostDTO.InstEnsinoForm=="")
                {
                    return StatusCode(400, "O preenchimento do campo Instituição de Ensino e Formação é obrigatório ");
                }

                if (medicoPostDTO.Crm=="")
                {
                    return StatusCode(400, "O preenchimento do campo CRM ");
                }
                
                if (CpfJaCadastrado(medicoPostDTO.Cpf))
                {
                    return StatusCode(StatusCodes.Status409Conflict, "CPF já cadastrado em nosso sistema");
                }
                Medico model = new Medico();
                model.NomeCompleto = medicoPostDTO.NomeCompleto;
                model.Cpf = medicoPostDTO.Cpf;
                model.DataNascimento = medicoPostDTO.DataNascimento;
                model.Telefone = medicoPostDTO.Telefone;
                model.InstEnsinoForm= medicoPostDTO.InstEnsinoForm;
                model.Crm = medicoPostDTO.Crm;
                model.EspClinica = medicoPostDTO.EspClinica;
                model.StatusSistema = medicoPostDTO.StatusSistema;
                _context.Medicos.Add(model);
                _context.SaveChanges();
                return Created(Request.Path, medicoPostDTO);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro ao salvar o médico: {medicoPostDTO}");
            }
        }

        [HttpDelete("{identificador}")]
        public ActionResult Delete([FromRoute] int identificador)
        {
            try
            {
                var mdelete = _context.Medicos.Find(identificador);
                if (mdelete != null)
                {
                    _context.Medicos.Remove(mdelete);
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound($"Não foi possivel localizar em nossa base de dados o médico com id {identificador} para exclusão dos dados");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno no servidor ao tentar deletar usuario");
            }
        }
        [HttpPut("/medicos{identificador}")]
        public ActionResult<MedicoPutDTO> Put(int identificador, [FromBody] MedicoPutDTO medicoPutDTO)
        {
            try
            {
                var medicoPut = _context.Medicos.Where(w => w.Id == identificador).FirstOrDefault();
                if (medicoPut == null)
                {
                    return NotFound($"Não foi possivel localizar o medico com id {identificador} para efetuar a atualização dos dados.");
                }
                
                if (CpfJaCadastrado(medicoPutDTO.Cpf))
                {
                    return Conflict($"O cpf {medicoPutDTO.Cpf} já está vinculado a outro medico em nosso sistema");
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
            catch
            {
                return BadRequest("Não foi possivel realizar a atualização dos dados do medico solicitado pois constam dados invalidos na requisição.");
            }
        }
        private bool CpfJaCadastrado(string cpf)
        {
            return _context.Medicos.Any(p => p.Cpf == cpf);
        }

    }

}
