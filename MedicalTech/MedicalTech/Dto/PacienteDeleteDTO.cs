using MedicalTech.Enumerador;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static MedicalTech.Base.Validation;

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
        public string Convenio { get; set; }
        [JsonConverter(typeof(StatusAtendimentoConverter))]
        public StatusAtendimentoEnum StatusdeAtendimento { get; set; }
        [MaxLength]
        public int ContadorTotalAtendimentos { get; set; }
    }
}
