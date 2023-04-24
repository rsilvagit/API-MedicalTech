using MedicalTech.Enum;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MedicalTech.Dto
{
    public class MedicoPutDTO:PessoaDto
    {
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(35)]
        public string? InstEnsinoForm { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(maximumLength:12,MinimumLength =8)]
        public string? Crm { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public EspClinicaEnum? EspClinica { get; set; }
        public StatusSistemaEnum StatusSistema { get; set; }
        public int TotalAtendimentos { get; set; }
    }
}
