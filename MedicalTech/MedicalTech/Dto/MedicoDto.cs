using MedicalTech.Enum;

namespace MedicalTech.Dto
{
    public class MedicoDto:PessoaDto
    {
        public string InstEnsinoForm { get; set; }
        public string? Crm { get; set; }
        public EspClinicaEnum EspClinica { get; set; }
        public StatusAtendimentoEnum StatusSistema { get; set; }
        public int TotalAtendimentos { get; set; }

    }
}
