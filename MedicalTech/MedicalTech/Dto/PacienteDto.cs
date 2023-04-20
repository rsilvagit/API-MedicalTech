using MedicalTech.Enum;

namespace MedicalTech.Dto
{
    public class PacienteDto:PessoaDto
    {
        public string? ContatoDeEmergencia { get; set; }
        public List<string> ListaDeAlergias { get; set; }
        public List<string> ListaCuidadosEspecifios { get; set; }
        public string Convenio { get; set; }
        public StatusAtendimentoEnum StatusAtendimento { get; set; }
        public List<string> TotalAtendimentos { get; set; }
    }
}
