using MedicalTech.Base;
using MedicalTech.Enumerador;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using static MedicalTech.Base.Validation;

namespace MedicalTech.Dto
{
    public class MedicoPutDTO:PessoaPutDTO
    {
      
        [StringLength(100)]
        public string InstEnsinoForm { get; set; }
        
        [StringLength(20)]
        public string Crm { get; set; }
        [Required]
        [JsonConverter(typeof(EspClinicaConverter))]
        public EspClinicaEnum EspClinica { get; set; }
        [JsonConverter(typeof(StatusSistemaConverter))]
        public StatusSistemaEnum StatusSistema { get; set; }
     
        public int TotalAtendimentos { get; set; }

    }
}
