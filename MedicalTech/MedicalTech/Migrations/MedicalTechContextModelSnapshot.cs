﻿// <auto-generated />
using System;
using MedicalTech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalTech.Migrations
{
    [DbContext(typeof(MedicalTechContext))]
    partial class MedicalTechContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicalTech.Models.Enfermeiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cofen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstEnsFormacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enfermeiro");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Cofen = "9871256",
                            Cpf = "0096388765",
                            DataNascimento = new DateTime(1986, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InstEnsFormacao = "PUC/PR",
                            NomeCompleto = "Thomaz Antunes",
                            Telefone = "4578945678"
                        },
                        new
                        {
                            Id = 4,
                            Cofen = "9873456",
                            Cpf = "0096385612",
                            DataNascimento = new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InstEnsFormacao = "UniRitter",
                            NomeCompleto = "Tania Lozartana",
                            Telefone = "457898965"
                        });
                });

            modelBuilder.Entity("MedicalTech.Models.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Crm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("EspClinica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstEnsinoForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusSistema")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalAtendimentos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasFilter("[Cpf] IS NOT NULL");

                    b.ToTable("Medico");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "07363796220",
                            Crm = "133122244",
                            DataNascimento = new DateTime(1990, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EspClinica = "Cirurgia Geral",
                            InstEnsinoForm = "USP",
                            NomeCompleto = "Maria de Fatima",
                            StatusSistema = false,
                            Telefone = "6126469720",
                            TotalAtendimentos = 10
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "00963896220",
                            Crm = "8975622244",
                            DataNascimento = new DateTime(1980, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EspClinica = "Pediatria",
                            InstEnsinoForm = "URGS/RS",
                            NomeCompleto = "Carlos Fontes",
                            StatusSistema = true,
                            Telefone = "6126460098",
                            TotalAtendimentos = 34
                        });
                });

            modelBuilder.Entity("MedicalTech.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContadorTotalAtendimentos")
                        .HasColumnType("int");

                    b.Property<string>("ContatoDeEmergencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Convenio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("ListaCuidadosEspecifios")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ListaDeAlergias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusdeAtendimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paciente");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            ContadorTotalAtendimentos = 15,
                            ContatoDeEmergencia = "67908765413",
                            Convenio = "UNIMED",
                            Cpf = "00098712",
                            DataNascimento = new DateTime(1960, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListaCuidadosEspecifios = "Deficiente Visual",
                            ListaDeAlergias = "Alergico a penicilina",
                            NomeCompleto = "Clovis Pinheiro",
                            StatusdeAtendimento = "Aguardando",
                            Telefone = "4578987654"
                        },
                        new
                        {
                            Id = 6,
                            ContadorTotalAtendimentos = 5,
                            ContatoDeEmergencia = "11999999999",
                            Convenio = "Bradesco Saúde",
                            Cpf = "12345678900",
                            DataNascimento = new DateTime(1985, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListaCuidadosEspecifios = "Diabetes",
                            ListaDeAlergias = "Nenhuma",
                            NomeCompleto = "José da Silva",
                            StatusdeAtendimento = "Aguardando",
                            Telefone = "11987654321"
                        },
                        new
                        {
                            Id = 7,
                            ContadorTotalAtendimentos = 10,
                            ContatoDeEmergencia = "21999999999",
                            Convenio = "Amil",
                            Cpf = "98765432100",
                            DataNascimento = new DateTime(1990, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListaCuidadosEspecifios = "Hipertensão",
                            ListaDeAlergias = "Alergica a camarão",
                            NomeCompleto = "Maria Oliveira",
                            StatusdeAtendimento = "Em atendimento",
                            Telefone = "21987654321"
                        },
                        new
                        {
                            Id = 8,
                            ContadorTotalAtendimentos = 2,
                            ContatoDeEmergencia = "31999999999",
                            Convenio = "Unimed",
                            Cpf = "23456789000",
                            DataNascimento = new DateTime(1978, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListaCuidadosEspecifios = "Asma",
                            ListaDeAlergias = "Alergico a amendoim",
                            NomeCompleto = "Pedro Santos",
                            StatusdeAtendimento = "Aguardando",
                            Telefone = "31987654321"
                        },
                        new
                        {
                            Id = 9,
                            ContadorTotalAtendimentos = 7,
                            ContatoDeEmergencia = "21999999999",
                            Convenio = "SulAmérica",
                            Cpf = "34567890100",
                            DataNascimento = new DateTime(1982, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListaCuidadosEspecifios = "Ansiedade",
                            ListaDeAlergias = "Nenhuma",
                            NomeCompleto = "Ana Paula Fernandes",
                            StatusdeAtendimento = "Em atendimento",
                            Telefone = "21987654321"
                        },
                        new
                        {
                            Id = 10,
                            ContadorTotalAtendimentos = 1,
                            ContatoDeEmergencia = "11999999999",
                            Convenio = "Bradesco Saúde",
                            Cpf = "45678901200",
                            DataNascimento = new DateTime(1995, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListaCuidadosEspecifios = "Nenhuma",
                            ListaDeAlergias = "Alergico a poeira",
                            NomeCompleto = "Fernando Souza",
                            StatusdeAtendimento = "Aguardando",
                            Telefone = "11987654321"
                        },
                        new
                        {
                            Id = 11,
                            ContadorTotalAtendimentos = 3,
                            ContatoDeEmergencia = "11999999999",
                            Convenio = "Unimed",
                            Cpf = "67890123400",
                            DataNascimento = new DateTime(1975, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListaCuidadosEspecifios = "Insuficiência renal",
                            ListaDeAlergias = "Alergico a morango",
                            NomeCompleto = "Luiz Carlos Rodrigues",
                            StatusdeAtendimento = "Em atendimento",
                            Telefone = "11987654321"
                        },
                        new
                        {
                            Id = 12,
                            ContadorTotalAtendimentos = 0,
                            ContatoDeEmergencia = "21999999999",
                            Convenio = "Amil",
                            Cpf = "78901234500",
                            DataNascimento = new DateTime(2000, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListaCuidadosEspecifios = "Nenhuma",
                            ListaDeAlergias = "Nenhuma",
                            NomeCompleto = "Larissa Silva",
                            StatusdeAtendimento = "Aguardando",
                            Telefone = "21987654321"
                        },
                        new
                        {
                            Id = 13,
                            ContadorTotalAtendimentos = 4,
                            ContatoDeEmergencia = "11999999999",
                            Convenio = "SulAmérica",
                            Cpf = "89012345600",
                            DataNascimento = new DateTime(1989, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListaCuidadosEspecifios = "Nenhuma",
                            ListaDeAlergias = "Alergico a penicilina",
                            NomeCompleto = "Renato Souza",
                            StatusdeAtendimento = "Aguardando",
                            Telefone = "11987654321"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
