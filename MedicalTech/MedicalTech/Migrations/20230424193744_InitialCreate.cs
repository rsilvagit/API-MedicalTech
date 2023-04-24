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
                    ContatoDeEmergencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListaDeAlergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListaCuidadosEspecificos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Convenio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusdeAtendimento = table.Column<int>(type: "int", nullable: false),
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
                    { 3, "9871256", "573.053.080-30", new DateTime(1986, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "PUC/PR", "Thomaz Antunes", "4578945678" },
                    { 4, "9873456", "024.306.570-15", new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "UniRitter", "Tania Lozartana", "457898965" }
                });

            migrationBuilder.InsertData(
                table: "Medico",
                columns: new[] { "Id", "Cpf", "Crm", "DataNascimento", "EspClinica", "InstEnsinoForm", "NomeCompleto", "StatusSistema", "Telefone", "TotalAtendimentos" },
                values: new object[,]
                {
                    { 1, "207.138.120-36", "4887-RS", new DateTime(1990, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Unisinos", "Maria de Fatima", 1, "6126469720", 10 },
                    { 2, "918.293.130-53", "9117-RS", new DateTime(1980, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "URGS/RS", "Carlos Fontes", 0, "6126460098", 34 }
                });

            migrationBuilder.InsertData(
                table: "Paciente",
                columns: new[] { "Id", "ContadorTotalAtendimentos", "ContatoDeEmergencia", "Convenio", "Cpf", "DataNascimento", "ListaCuidadosEspecificos", "ListaDeAlergias", "NomeCompleto", "StatusdeAtendimento", "Telefone" },
                values: new object[,]
                {
                    { 5, 15, "67908765413", "UNIMED", "364.835.440-06", new DateTime(1960, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deficiente Visual", "Alergico a penicilina", "Clovis Pinheiro", 1, "4578987654" },
                    { 6, 5, "11999999999", "Bradesco Saúde", "768.168.230-95", new DateTime(1985, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diabetes", "Nenhuma", "José da Silva", 0, "11987654321" },
                    { 7, 10, "21999999999", "Amil", "015.128.240-46", new DateTime(1990, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hipertensão", "Alergica a camarão", "Maria Oliveira", 1, "21987654321" },
                    { 8, 2, "31999999999", "Unimed", "022.185.900-42", new DateTime(1978, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asma", "Alergico a amendoim", "Pedro Santos", 3, "31987654321" },
                    { 9, 7, "21999999999", "SulAmérica", "511.755.110-99", new DateTime(1982, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ansiedade", "Nenhuma", "Ana Paula Fernandes", 1, "21987654321" },
                    { 10, 1, "11999999999", "Bradesco Saúde", "966.931.580-80", new DateTime(1995, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nenhuma", "Alergico a poeira", "Fernando Souza", 1, "11987654321" },
                    { 11, 3, "11999999999", "Unimed", "002.958.820-00", new DateTime(1975, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Insuficiência renal|Cadeirante", "Alergico a morango|Alergico Lactose", "Luiz Carlos Rodrigues", 0, "11987654321" },
                    { 12, 0, "21999999999", "Amil", "631.192.340-87", new DateTime(2000, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nenhuma", "Nenhuma", "Larissa Silva", 2, "21987654321" },
                    { 13, 4, "11999999999", "SulAmérica", "629.783.790-22", new DateTime(1989, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nenhuma", "Alergico a penicilina", "Renato Souza", 2, "51995783456" },
                    { 14, 2, "11999999999", "Unimed", "492.470.580-23", new DateTime(1995, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuidados com pressão alta", "Não tem", "Ana Silva", 0, "11987651234" }
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
