using MedicalTech.Enumerador;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static MedicalTech.Base.Validation;

namespace MedicalTech.Dto
{
    public class PacientePostDTO : PessoaPostDTO
    {
        [Required(ErrorMessage ="Campo Obrigatório")]
        [StringLength(25)]
        public string ContatoDeEmergencia { get; set; }
        public List <string> ListaDeAlergias { get; set; }= new List<string>();
        public List <string> ListaCuidadosEspecificos { get; set; }=new List<string>();
        [StringLength(25)]
        public string Convenio { get; set; }
        [JsonConverter(typeof(StatusAtendimentoConverter))]
        public StatusAtendimentoEnum StatusAtendimento { get; set; }
        public int ContadorTotalAtendimentos { get; set; }
    }
}

