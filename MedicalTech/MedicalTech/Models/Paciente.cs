using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalTech.Models
{
    [Table("Paciente")]
    public class Paciente:Pesssoa
    {
        public string? ContatoDeEmergencia { get; set; }
        public string ListaDeAlergias { get; set; }
        public string ListaCuidadosEspecifios { get; set; }
        public string Convenio { get; set; }
        public string? StatusdeAtendimento { get; set; }
        public int  ContadorTotalAtendimentos { get; set; }
        
    }
}
