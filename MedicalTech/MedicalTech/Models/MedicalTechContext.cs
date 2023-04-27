using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MedicalTech.Dto;
using MedicalTech.Base;
using MedicalTech.Enum;


namespace MedicalTech.Models
{
    public class MedicalTechContext : DbContext
    {
        public MedicalTechContext(DbContextOptions<MedicalTechContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>().HasIndex(m => new { m.Cpf }).IsUnique(true);
            modelBuilder.Entity<Medico>().HasIndex(m => new { m.Crm }).IsUnique(true);
            modelBuilder.Entity<Medico>().HasData(new[]
            {
                new Medico()
                {
                    NomeCompleto = "Maria de Fatima",
                    DataNascimento = new DateTime(1990, 09, 30),
                    Cpf = "207.138.120-36",
                    Id=1,
                    Crm = "4887-RS",
                    EspClinica =EspClinicaEnum.Ginecologia,
                    InstEnsinoForm = "Unisinos",
                    StatusSistema = StatusSistemaEnum.Ativo,
                    Telefone = "6126469720",
                    TotalAtendimentos = 10,
                },
                new Medico()
                {
                    NomeCompleto = "Carlos Fontes",
                    DataNascimento = new DateTime(1980, 05, 10),
                    Cpf = "918.293.130-53",
                    Id=2,
                    Crm = "9117-RS",
                    EspClinica = EspClinicaEnum.Neurologia,
                    InstEnsinoForm = "URGS/RS",
                    StatusSistema = StatusSistemaEnum.Inativo,
                    Telefone = "6126460098",
                    TotalAtendimentos = 34,
                }

            });
            modelBuilder.Entity<Enfermeiro>().HasIndex(e => new { e.Cpf }).IsUnique(true);
            modelBuilder.Entity<Enfermeiro>().HasIndex(e => new { e.Cofen }).IsUnique(true);
            modelBuilder.Entity<Enfermeiro>().HasData(new[]
            {
                new Enfermeiro()
                {
                    NomeCompleto = "Thomaz Antunes",
                    DataNascimento = new DateTime(1986, 04, 25),
                    Cpf = "573.053.080-30",
                    Id=3,
                    Cofen = "9871256",
                    InstEnsFormacao = "PUC/PR",
                    Telefone = "4578945678",
                },
                new Enfermeiro()
                {
                    NomeCompleto = "Tania Lozartana",
                    DataNascimento = new DateTime(1980, 03, 15),
                    Cpf = "024.306.570-15",
                    Id=4,
                    Cofen = "9873456",
                    InstEnsFormacao = "UniRitter",
                    Telefone = "457898965",
                }
            });
            modelBuilder.Entity<Paciente>().HasIndex(p => new { p.Cpf }).IsUnique(true);
            modelBuilder.Entity<Paciente>().HasData(new[]
            {
            new Paciente()
                    {
                        NomeCompleto = "Clovis Pinheiro",
                        DataNascimento = new DateTime(1960, 08, 25),
                        Cpf = "364.835.440-06",
                        Id=5,
                        Telefone = "4578987654",
                        ContatoDeEmergencia = "67908765413",
                        ListaCuidadosEspecificos= "Deficiente Visual",
                        ListaDeAlergias = "Alergico a penicilina",
                        Convenio = "UNIMED",
                        StatusdeAtendimento = StatusAtendimentoEnum.Em_Atendimento,
                        ContadorTotalAtendimentos = 15,
                    },
                new Paciente()
                    {
                        NomeCompleto = "José da Silva",
                        DataNascimento = new DateTime(1985, 05, 12),
                        Cpf = "768.168.230-95",
                        Id=6,
                        Telefone = "11987654321",
                        ContatoDeEmergencia = "11999999999",
                        ListaCuidadosEspecificos = "Diabetes",
                        ListaDeAlergias = "Nenhuma",
                        Convenio = "Bradesco Saúde",
                        StatusdeAtendimento = StatusAtendimentoEnum.Aguardando_Atendimento,
                        ContadorTotalAtendimentos = 5,
                    },



                new Paciente()
                {
                     NomeCompleto = "Maria Oliveira",
                     DataNascimento = new DateTime(1990, 10, 20),
                     Cpf = "015.128.240-46",
                     Id=7,
                     Telefone = "21987654321",
                     ContatoDeEmergencia = "21999999999",
                     ListaCuidadosEspecificos = "Hipertensão",
                     ListaDeAlergias = "Alergica a camarão",
                     Convenio = "Amil",
                     StatusdeAtendimento = StatusAtendimentoEnum.Em_Atendimento,
                     ContadorTotalAtendimentos = 10,
                },

                new Paciente()
                {
                    NomeCompleto = "Pedro Santos",
                    DataNascimento = new DateTime(1978, 03, 08),
                    Cpf = "022.185.900-42",
                    Id=8,
                    Telefone = "31987654321",
                    ContatoDeEmergencia = "31999999999",
                    ListaCuidadosEspecificos = "Asma",
                    ListaDeAlergias = "Alergico a amendoim",
                    Convenio = "Unimed",
                    StatusdeAtendimento = StatusAtendimentoEnum.Nao_Atendido,
                    ContadorTotalAtendimentos = 2,
                },

                new Paciente()
                {
                    NomeCompleto = "Ana Paula Fernandes",
                    DataNascimento = new DateTime(1982, 07, 15),
                    Cpf = "511.755.110-99",
                    Id=9,
                    Telefone = "21987654321",
                    ContatoDeEmergencia = "21999999999",
                    ListaCuidadosEspecificos = "Ansiedade",
                    ListaDeAlergias = "Nenhuma",
                    Convenio = "SulAmérica",
                    StatusdeAtendimento = StatusAtendimentoEnum.Em_Atendimento,
                    ContadorTotalAtendimentos = 7,
                },

                new Paciente()
                {
                    NomeCompleto = "Fernando Souza",
                    DataNascimento = new DateTime(1995, 01, 30),
                    Cpf = "966.931.580-80",
                    Id=10,
                    Telefone = "11987654321",
                    ContatoDeEmergencia = "11999999999",
                    ListaCuidadosEspecificos = "Nenhuma",
                    ListaDeAlergias = "Alergico a poeira",
                    Convenio = "Bradesco Saúde",
                    StatusdeAtendimento = StatusAtendimentoEnum.Em_Atendimento,
                    ContadorTotalAtendimentos = 1,
                },
                new Paciente()
                {
                    NomeCompleto = "Luiz Carlos Rodrigues",
                    DataNascimento = new DateTime(1975, 06, 10),
                    Cpf = "002.958.820-00",
                    Id=11,
                    Telefone = "11987654321",
                    ContatoDeEmergencia = "11999999999",
                    ListaCuidadosEspecificos = "Insuficiência renal|Cadeirante",
                    ListaDeAlergias = "Alergico a morango|Alergico Lactose",
                    Convenio = "Unimed",
                    StatusdeAtendimento = StatusAtendimentoEnum.Aguardando_Atendimento,
                    ContadorTotalAtendimentos = 3,
                },

                new Paciente()
                {
                    NomeCompleto = "Larissa Silva",
                    DataNascimento = new DateTime(2000, 02, 14),
                    Cpf = "631.192.340-87",
                    Id=12,
                    Telefone = "21987654321",
                    ContatoDeEmergencia = "21999999999",
                    ListaCuidadosEspecificos = "Nenhuma",
                    ListaDeAlergias = "Nenhuma",
                    Convenio = "Amil",
                    StatusdeAtendimento = StatusAtendimentoEnum.Atendido,
                    ContadorTotalAtendimentos = 0,
                },

                new Paciente()
                {
                    NomeCompleto = "Renato Souza",
                    DataNascimento = new DateTime(1989, 11, 20),
                    Cpf = "629.783.790-22",
                    Id=13,
                    Telefone = "51995783456",
                    ContatoDeEmergencia = "11999999999",
                    ListaCuidadosEspecificos = "Nenhuma",
                    ListaDeAlergias = "Alergico a penicilina",
                    Convenio = "SulAmérica",
                    StatusdeAtendimento = StatusAtendimentoEnum.Atendido,
                    ContadorTotalAtendimentos = 4,
                },
                new Paciente()
{
                NomeCompleto = "Ana Silva",
                DataNascimento = new DateTime(1995, 05, 12),
                Cpf = "492.470.580-23",
                Id = 14,
                Telefone = "11987651234",
                ContatoDeEmergencia = "11999999999",
                ListaCuidadosEspecificos = "Cuidados com pressão alta",
                ListaDeAlergias = "Não tem",
                Convenio = "Unimed",
                StatusdeAtendimento = StatusAtendimentoEnum.Aguardando_Atendimento,
                ContadorTotalAtendimentos = 2,
                }

        });

        }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Enfermeiro> Enfermeiros { get; set; }
        
    }
}
