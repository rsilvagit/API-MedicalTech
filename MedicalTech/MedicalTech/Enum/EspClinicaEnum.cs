using System.Text.Json.Serialization;

namespace MedicalTech.Enumerador
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EspClinicaEnum
    {
        Clinico_Geral=0,
        Anestesista=1,
        Dermatologia=2,
        Ginecologia=3,
        Neurologia=4,
        Pediatria=5,
        Ortopedia=6
    }
}
