﻿using MedicalTech.Dto;
using MedicalTech.Models;
using MedicalTech.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

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
        public ActionResult<List<PacienteDto>> Get()
        {
            var listPacienteModel = _context.Pacientes.ToList();
            List<PacienteDto> listGetPacientes = new List<PacienteDto>();
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
                pacienteDto.ListaCuidadosEspecificos = item.ListaCuidadosEspecificos!.Split('|').ToList();
                pacienteDto.ListaDeAlergias = item.ListaDeAlergias!.Split('|').ToList();


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
            pacienteDto.ListaCuidadosEspecificos = pacienteModel.ListaCuidadosEspecificos!.Split('|').ToList();
            pacienteDto.ListaDeAlergias = pacienteModel.ListaDeAlergias!.Split('|').ToList();

            return Ok(pacienteDto);
        }
        [HttpPost]
        public ActionResult<PacienteDto> Post([FromBody] PacienteDto pacienteDto)
        {
            if (!ValidarCPF(pacienteDto.Cpf))
            {
                return BadRequest("CPF invalido");
            }
            if (CpfJaCadastrado(pacienteDto.Cpf))
            {
                return StatusCode(StatusCodes.Status409Conflict, "CPF já cadastrado em nosso sistema");
            }
            Paciente model = new Paciente();
            model.NomeCompleto = pacienteDto.NomeCompleto;
            model.Cpf = pacienteDto.Cpf;
            model.DataNascimento = pacienteDto.DataNascimento;
            model.Telefone = pacienteDto.Telefone;
            model.ContatoDeEmergencia = pacienteDto.ContatoDeEmergencia;
            model.Convenio = pacienteDto.Convenio;
            model.ListaCuidadosEspecificos = string.Join("|", pacienteDto.ListaCuidadosEspecificos!);
            model.ListaDeAlergias = string.Join("|", pacienteDto.ListaDeAlergias!);
            model.StatusdeAtendimento = pacienteDto.StatusAtendimento;
            model.ContadorTotalAtendimentos = pacienteDto.ContadorTotalAtendimentos;

            return Created(Request.Path, pacienteDto);
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
        public ActionResult<PacienteDto> Put(int id,[FromBody] PacienteDto pacienteDto)
        {
            var pacienteModel = _context.Pacientes.Where(w => w.Id == id).FirstOrDefault();
            if (pacienteModel == null)
            {
                return NotFound("Id não localizado!!! Certifique-se de informar o id e cpf correspondente ao paciente que deseja atualizar os dados");
            }
            if (_context.Pacientes.Any(p=>p.Cpf == pacienteDto.Cpf && p.Id != id))
            {
                return BadRequest("Já existe um CPF cadastrado neste paciente, a alteração deste CPF não é permitida");
            }
            if (!ValidarCPF(pacienteDto.Cpf))
            {
                return BadRequest("CPF Inválido");
            }
            pacienteModel.NomeCompleto = pacienteDto.NomeCompleto;
            pacienteModel.Cpf = pacienteDto.Cpf;
            pacienteModel.DataNascimento = pacienteDto.DataNascimento;
            pacienteModel.Telefone = pacienteDto.Telefone;
            pacienteModel.ContatoDeEmergencia = pacienteDto.ContatoDeEmergencia;
            pacienteModel.Convenio = pacienteDto.Convenio;
            pacienteModel.ListaCuidadosEspecificos = string.Join("|", pacienteDto.ListaCuidadosEspecificos!);
            pacienteModel.ListaDeAlergias = string.Join("|", pacienteDto.ListaDeAlergias!);
            pacienteModel.StatusdeAtendimento = pacienteDto.StatusAtendimento;
            pacienteModel.ContadorTotalAtendimentos = pacienteDto.ContadorTotalAtendimentos;

            _context.Pacientes.Attach(pacienteModel);
            _context.SaveChanges();
            return Ok(pacienteDto);
        }
        [HttpPut("{id}/StatusdeAtendimento")]
        public ActionResult<PacienteDto> Put(int id, [FromBody] PacientePutStatusDTO statusDTO)
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

            pacienteModel.StatusdeAtendimento = statusDTO.StatusAtendimento;

            _context.SaveChanges();


            return Ok(statusDTO);
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

            cpf= cpf.Replace(".","").Replace("-","");
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
