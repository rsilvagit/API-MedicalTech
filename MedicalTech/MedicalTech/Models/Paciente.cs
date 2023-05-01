using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalTech.Base;
using MedicalTech.Enumerador;

namespace MedicalTech.Models
{
    [Table("Paciente")]
    public class Paciente:Pesssoa
    {

        [Required]
        public string ContatoDeEmergencia { get; set; }
        [MaxLength]
        public string ListaDeAlergias { get; set; }
        [MaxLength]
        public string ListaCuidadosEspecificos { get; set; }
        [StringLength(15)]
        public string Convenio { get; set; }
      
        public StatusAtendimentoEnum StatusdeAtendimento { get; set; }
        [MaxLength]
        public int  ContadorTotalAtendimentos { get; set; }
        
    }
}
