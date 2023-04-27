using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalTech.Base;
using MedicalTech.Enum;

namespace MedicalTech.Models
{
    [Table("Paciente")]
    public class Paciente:Pesssoa
    {

        [Required(ErrorMessage = "O preenchimento do campo Contato de Emergência é obrigatório")]
        public string? ContatoDeEmergencia { get; set; }
        [MaxLength]
        public string? ListaDeAlergias { get; set; }
        [MaxLength]
        public string? ListaCuidadosEspecificos { get; set; }
        [StringLength(15)]
        public string Convenio { get; set; }
        [MaxLength(15)]
        public StatusAtendimentoEnum StatusdeAtendimento { get; set; }
        [MaxLength]
        public int  ContadorTotalAtendimentos { get; set; }
        
    }
}
