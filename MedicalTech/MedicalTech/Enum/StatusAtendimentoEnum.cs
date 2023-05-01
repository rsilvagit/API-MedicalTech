using System.Text.Json.Serialization;

namespace MedicalTech.Enumerador
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusAtendimentoEnum
    {
        Aguardando_Atendimento = 0,
        Em_Atendimento= 1,
        Atendido= 2,
        Nao_Atendido= 3,       
    };
}
