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
        [MaxLength(20)]
        public EspClinicaEnum EspClinica { get; set; }
        [MaxLength(10)]
        public StatusSistemaEnum StatusSistema { get; set; }
        [MaxLength]
        public int TotalAtendimentos { get; set; }

    }
}
