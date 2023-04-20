using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalTech.Base;
using MedicalTech.Enum;

namespace MedicalTech.Models
{
    [Table("Paciente")]
    public class Paciente:Pesssoa
    {
        public string? ContatoDeEmergencia { get; set; }
        [MaxLength]
        public string? ListaDeAlergias { get; set; }
        [MaxLength]
        public string? ListaCuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public StatusAtendimentoEnum StatusdeAtendimento { get; set; }
        public int  ContadorTotalAtendimentos { get; set; }
        
    }
}
