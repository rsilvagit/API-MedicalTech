using MedicalTech.Enum;
using System.ComponentModel.DataAnnotations;

namespace MedicalTech.Dto
{
    public class PacienteDeleteDTO:PessoaDeleteDTO
    {
        [Required(ErrorMessage = "O preenchimento do campo Contato de Emergência é obrigatório")]
        public string? ContatoDeEmergencia { get; set; }
        [MaxLength]
        public List<string> ListaDeAlergias { get; set; }
        [MaxLength]
        public List <string> ListaCuidadosEspecificos { get; set; }
        [StringLength(15)]
        public string Convenio { get; set; }
        [MaxLength(15)]
        public StatusAtendimentoEnum StatusdeAtendimento { get; set; }
        [MaxLength]
        public int ContadorTotalAtendimentos { get; set; }
    }
}
