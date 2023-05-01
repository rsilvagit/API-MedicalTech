using MedicalTech.Enumerador;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static MedicalTech.Base.Validation;

namespace MedicalTech.Dto
{
    public class PacientePutDTO:PessoaPutDTO
    {
       
        public string ContatoDeEmergencia { get; set; }
        public List<string> ListaDeAlergias { get; set; }
        public List<string> ListaCuidadosEspecificos { get; set; }
        [StringLength(15)]
        public string Convenio { get; set; }
        [JsonConverter(typeof(StatusAtendimentoConverter))]
        public StatusAtendimentoEnum StatusdeAtendimento { get; set; }
        public int ContadorTotalAtendimentos { get; set; }
    }
}
