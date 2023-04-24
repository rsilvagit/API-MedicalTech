using MedicalTech.Enum;
using Microsoft.Build.Framework;

namespace MedicalTech.Dto
{
    public class MedicoDto:PessoaDto
    {
        [Required]
        public string? InstEnsinoForm { get; set; }
        [Required]
        public string? Crm { get; set; }
        [Required]
        public EspClinicaEnum EspClinica { get; set; }
        public StatusSistemaEnum StatusSistema { get; set; }
        public int TotalAtendimentos { get; set; }

    }
}
