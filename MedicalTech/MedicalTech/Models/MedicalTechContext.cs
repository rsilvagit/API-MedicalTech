using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MedicalTech.Dto;
using MedicalTech.Base;

namespace MedicalTech.Models
{
    public class MedicalTechContext : DbContext
    {
        public MedicalTechContext(DbContextOptions<MedicalTechContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>().HasIndex(p => new { p.Cpf }).IsUnique(true);
            modelBuilder.Entity<Medico>().HasData(new[]
            {
                new Medico()
                {
                    NomeCompleto = "Maria de Fatima",
                    DataNascimento = new DateTime(1990, 09, 30),
                    Cpf = "07363796220",
                    Id=1,
                    Crm = "133122244",
                    EspClinica = "Cirurgia Geral",
                    InstEnsinoForm = "USP",
                    StatusSistema = false,
                    Telefone = "6126469720",
                    TotalAtendimentos = 10,
                },
                new Medico()
                {
                    NomeCompleto = "Carlos Fontes",
                    DataNascimento = new DateTime(1980, 05, 10),
                    Cpf = "00963896220",
                    Id=2,
                    Crm = "8975622244",
                    EspClinica = "Pediatria",
                    InstEnsinoForm = "URGS/RS",
                    StatusSistema = true,
                    Telefone = "6126460098",
                    TotalAtendimentos = 34,
                }

            });
            modelBuilder.Entity<Enfermeiro>().HasData(new[]
            {
                new Enfermeiro()
                {
                    NomeCompleto = "Thomaz Antunes",
                    DataNascimento = new DateTime(1986, 04, 25),
                    Cpf = "0096388765",
                    Id=3,
                    Cofen = "9871256",
                    InstEnsFormacao = "PUC/PR",
                    Telefone = "4578945678",
                },
                new Enfermeiro()
                {
                    NomeCompleto = "Tania Lozartana",
                    DataNascimento = new DateTime(1980, 03, 15),
                    Cpf = "0096385612",
                    Id=4,
                    Cofen = "9873456",
                    InstEnsFormacao = "UniRitter",
                    Telefone = "457898965",
                }
            });
            modelBuilder.Entity<Paciente>().HasData(new[]
            {
            new Paciente()
                    {
                        NomeCompleto = "Clovis Pinheiro",
                        DataNascimento = new DateTime(1960, 08, 25),
                        Cpf = "00098712",
                        Id=5,
                        Telefone = "4578987654",
                        ContatoDeEmergencia = "67908765413",
                        ListaCuidadosEspecifios = "Deficiente Visual",
                        ListaDeAlergias = "Alergico a penicilina",
                        Convenio = "UNIMED",
                        StatusdeAtendimento = "Aguardando",
                        ContadorTotalAtendimentos = 15,
                    },
                new Paciente()
                    {
                        NomeCompleto = "José da Silva",
                        DataNascimento = new DateTime(1985, 05, 12),
                        Cpf = "12345678900",
                        Id=6,
                        Telefone = "11987654321",
                        ContatoDeEmergencia = "11999999999",
                        ListaCuidadosEspecifios = "Diabetes",
                        ListaDeAlergias = "Nenhuma",
                        Convenio = "Bradesco Saúde",
                        StatusdeAtendimento = "Aguardando",
                        ContadorTotalAtendimentos = 5,
                    },



                new Paciente()
                {
                     NomeCompleto = "Maria Oliveira",
                     DataNascimento = new DateTime(1990, 10, 20),
                     Cpf = "98765432100",
                     Id=7,
                     Telefone = "21987654321",
                     ContatoDeEmergencia = "21999999999",
                     ListaCuidadosEspecifios = "Hipertensão",
                     ListaDeAlergias = "Alergica a camarão",
                     Convenio = "Amil",
                     StatusdeAtendimento = "Em atendimento",
                     ContadorTotalAtendimentos = 10,
                },

                new Paciente()
                {
                    NomeCompleto = "Pedro Santos",
                    DataNascimento = new DateTime(1978, 03, 08),
                    Cpf = "23456789000",
                    Id=8,
                    Telefone = "31987654321",
                    ContatoDeEmergencia = "31999999999",
                    ListaCuidadosEspecifios = "Asma",
                    ListaDeAlergias = "Alergico a amendoim",
                    Convenio = "Unimed",
                    StatusdeAtendimento = "Aguardando",
                    ContadorTotalAtendimentos = 2,
                },

                new Paciente()
                {
                    NomeCompleto = "Ana Paula Fernandes",
                    DataNascimento = new DateTime(1982, 07, 15),
                    Cpf = "34567890100",
                    Id=9,
                    Telefone = "21987654321",
                    ContatoDeEmergencia = "21999999999",
                    ListaCuidadosEspecifios = "Ansiedade",
                    ListaDeAlergias = "Nenhuma",
                    Convenio = "SulAmérica",
                    StatusdeAtendimento = "Em atendimento",
                    ContadorTotalAtendimentos = 7,
                },

                new Paciente()
                {
                    NomeCompleto = "Fernando Souza",
                    DataNascimento = new DateTime(1995, 01, 30),
                    Cpf = "45678901200",
                    Id=10,
                    Telefone = "11987654321",
                    ContatoDeEmergencia = "11999999999",
                    ListaCuidadosEspecifios = "Nenhuma",
                    ListaDeAlergias = "Alergico a poeira",
                    Convenio = "Bradesco Saúde",
                    StatusdeAtendimento = "Aguardando",
                    ContadorTotalAtendimentos = 1,
                },
                new Paciente()
                {
                    NomeCompleto = "Luiz Carlos Rodrigues",
                    DataNascimento = new DateTime(1975, 06, 10),
                    Cpf = "67890123400",
                    Id=11,
                    Telefone = "11987654321",
                    ContatoDeEmergencia = "11999999999",
                    ListaCuidadosEspecifios = "Insuficiência renal",
                    ListaDeAlergias = "Alergico a morango",
                    Convenio = "Unimed",
                    StatusdeAtendimento = "Em atendimento",
                    ContadorTotalAtendimentos = 3,
                },

                new Paciente()
                {
                    NomeCompleto = "Larissa Silva",
                    DataNascimento = new DateTime(2000, 02, 14),
                    Cpf = "78901234500",
                    Id=12,
                    Telefone = "21987654321",
                    ContatoDeEmergencia = "21999999999",
                    ListaCuidadosEspecifios = "Nenhuma",
                    ListaDeAlergias = "Nenhuma",
                    Convenio = "Amil",
                    StatusdeAtendimento = "Aguardando",
                    ContadorTotalAtendimentos = 0,
                },

                new Paciente()
                {
                    NomeCompleto = "Renato Souza",
                    DataNascimento = new DateTime(1989, 11, 20),
                    Cpf = "89012345600",
                    Id=13,
                    Telefone = "11987654321",
                    ContatoDeEmergencia = "11999999999",
                    ListaCuidadosEspecifios = "Nenhuma",
                    ListaDeAlergias = "Alergico a penicilina",
                    Convenio = "SulAmérica",
                    StatusdeAtendimento = "Aguardando",
                    ContadorTotalAtendimentos = 4,
                } 
            });

        }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Enfermeiro> Enfermeiros { get; set; }
        
    }
}
