using System.Text.Json.Serialization;

namespace MedicalTech.Enumerador
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum StatusSistemaEnum
    {
        Inativo=0,
        Ativo=1
    }
}
