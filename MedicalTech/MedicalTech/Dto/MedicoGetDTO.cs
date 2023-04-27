using MedicalTech.Enum;
using System.ComponentModel.DataAnnotations;

namespace MedicalTech.Dto
{
    public class MedicoGetDTO:PessoaGetDTO
    {
        [Required]
        [StringLength(100)]
        public string InstEnsinoForm { get; set; }
        [Required]
        [StringLength(20)]
        public string Crm { get; set; }
        [Required]
        
        public EspClinicaEnum EspClinica { get; set; }
        public StatusSistemaEnum StatusSistema { get; set; }
        [MaxLength]
        public int TotalAtendimentos { get; set; }


    }
}
