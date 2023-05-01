using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MedicalTech.Models
{
    [Table("Atendimento")]
    public class Atendimento
    {
        [Key]
        [Column("Id_Atendimento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
        public Medico Medico { get; set; } = new Medico();

        [ForeignKey("PacienteModel")]
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; } = new Paciente();

        [AllowNull]
        public string DescricaoAtendimento { get; set; }


    }
}
