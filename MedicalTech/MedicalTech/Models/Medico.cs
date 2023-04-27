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
        [StringLength(100)]
       public string? InstEnsinoForm { get; set; }
        [Required]
        [StringLength(20)]
       public string Crm { get; set; }
        [Required]
        [MaxLength(20)]
       public EspClinicaEnum EspClinica { get; set; }
        [MaxLength(10)]
       public StatusSistemaEnum StatusSistema { get; set; }
        [MaxLength]
       public int TotalAtendimentos { get; set; }

    }
}
