using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalTech.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enfermeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstEnsFormacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cofen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstEnsinoForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspClinica = table.Column<int>(type: "int", nullable: false),
                    StatusSistema = table.Column<int>(type: "int", nullable: false),
                    TotalAtendimentos = table.Column<int>(type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContatoDeEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListaDeAlergias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListaCuidadosEspecifios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Convenio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusdeAtendimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContadorTotalAtendimentos = table.Column<int>(type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Enfermeiro",
                columns: new[] { "Id", "Cofen", "Cpf", "DataNascimento", "InstEnsFormacao", "NomeCompleto", "Telefone" },
                values: new object[,]
                {
                    { 3, "9871256", "0096388765", new DateTime(1986, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "PUC/PR", "Thomaz Antunes", "4578945678" },
                    { 4, "9873456", "0096385612", new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "UniRitter", "Tania Lozartana", "457898965" }
                });

            migrationBuilder.InsertData(
                table: "Medico",
                columns: new[] { "Id", "Cpf", "Crm", "DataNascimento", "EspClinica", "InstEnsinoForm", "NomeCompleto", "StatusSistema", "Telefone", "TotalAtendimentos" },
                values: new object[,]
                {
                    { 1, "07363796220", "133122244", new DateTime(1990, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Unisinos", "Maria de Fatima", 1, "6126469720", 10 },
                    { 2, "00963896220", "8975622244", new DateTime(1980, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "URGS/RS", "Carlos Fontes", 0, "6126460098", 34 }
                });

            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "Id", "ContadorTotalAtendimentos", "ContatoDeEmergencia", "Convenio", "Cpf", "DataNascimento", "ListaCuidadosEspecifios", "ListaDeAlergias", "NomeCompleto", "StatusdeAtendimento", "Telefone" },
                values: new object[,]
                {
                    { 5, 15, "67908765413", "UNIMED", "00098712", new DateTime(1960, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deficiente Visual", "Alergico a penicilina", "Clovis Pinheiro", "Aguardando", "4578987654" },
                    { 6, 5, "11999999999", "Bradesco Saúde", "12345678900", new DateTime(1985, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diabetes", "Nenhuma", "José da Silva", "Aguardando", "11987654321" },
                    { 7, 10, "21999999999", "Amil", "98765432100", new DateTime(1990, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hipertensão", "Alergica a camarão", "Maria Oliveira", "Em atendimento", "21987654321" },
                    { 8, 2, "31999999999", "Unimed", "23456789000", new DateTime(1978, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asma", "Alergico a amendoim", "Pedro Santos", "Aguardando", "31987654321" },
                    { 9, 7, "21999999999", "SulAmérica", "34567890100", new DateTime(1982, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ansiedade", "Nenhuma", "Ana Paula Fernandes", "Em atendimento", "21987654321" },
                    { 10, 1, "11999999999", "Bradesco Saúde", "45678901200", new DateTime(1995, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nenhuma", "Alergico a poeira", "Fernando Souza", "Aguardando", "11987654321" },
                    { 11, 3, "11999999999", "Unimed", "67890123400", new DateTime(1975, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Insuficiência renal", "Alergico a morango", "Luiz Carlos Rodrigues", "Em atendimento", "11987654321" },
                    { 12, 0, "21999999999", "Amil", "78901234500", new DateTime(2000, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nenhuma", "Nenhuma", "Larissa Silva", "Aguardando", "21987654321" },
                    { 13, 4, "11999999999", "SulAmérica", "89012345600", new DateTime(1989, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nenhuma", "Alergico a penicilina", "Renato Souza", "Aguardando", "11987654321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medico_Cpf",
                table: "Medico",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfermeiro");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
