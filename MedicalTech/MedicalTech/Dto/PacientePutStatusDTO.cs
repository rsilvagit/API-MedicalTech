using MedicalTech.Enumerador;
using Microsoft.Build.Framework;
using System.Text.Json.Serialization;
using static MedicalTech.Base.Validation;

namespace MedicalTech.Dto
{
    public class PacientePutStatusDTO:PessoaPutDTO
    {
        [JsonConverter(typeof(StatusAtendimentoConverter))]
        public StatusAtendimentoEnum StatusAtendimento { get; set; }

    }
}
