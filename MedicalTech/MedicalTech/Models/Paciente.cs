using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalTech.Models
{
    [Table("Paciente")]
    public class Paciente:Pesssoa
    {
        public string? ContatoDeEmergencia { get; set; }
        public List<string>ListaDeAlergias { get; set; }
        public List<string> ListaCuidadosEspecifios { get; set; }
        public string Convenio { get; set; }
        public string? StatusdeAtendimento { get; set; }
        public List<string> TotalAtendimentos { get; set; }
        
    }
}
