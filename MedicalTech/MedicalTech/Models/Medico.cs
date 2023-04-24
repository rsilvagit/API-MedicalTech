using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalTech.Base;
using MedicalTech.Enum;

namespace MedicalTech.Models
{
    [Table("Medico")]
    public class Medico:Pesssoa
    {
        [Required]
        public string InstEnsinoForm { get; set; }
        [Required]
       public string? Crm { get; set; }
        [Required]
        public EspClinicaEnum EspClinica { get; set; }
       public StatusSistemaEnum StatusSistema { get; set; }
       public int TotalAtendimentos { get; set; }

    }
}
