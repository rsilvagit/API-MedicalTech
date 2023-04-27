using MedicalTech.Enum;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace MedicalTech.Dto
{
    public class MedicoPostDTO:PessoaPostDTO
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
        
        public int TotalAtendimentos { get; set; }

    }
}
