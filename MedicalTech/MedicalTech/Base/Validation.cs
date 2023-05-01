
using MedicalTech.Enumerador;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MedicalTech.Base
{
    public partial class Validation
    {
        public sealed class EspClinicaConverter : JsonConverter<EspClinicaEnum>
        {
            public override EspClinicaEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<EspClinicaEnum>(value, out var result))
                    throw new JsonException($"Por favor, informe um valor válido para a Especialização Clinica: {string.Join(",", Enum.GetNames(typeof(EspClinicaEnum)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, EspClinicaEnum value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }
        public sealed class StatusAtendimentoConverter : JsonConverter<StatusAtendimentoEnum>
        {
            public override StatusAtendimentoEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<StatusAtendimentoEnum>(value, out var result))
                    throw new JsonException($"Por favor, informe um valor válido para o Status de Atendimento: {string.Join(",", Enum.GetNames(typeof(StatusAtendimentoEnum)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, StatusAtendimentoEnum value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }
        public sealed class StatusSistemaConverter : JsonConverter<StatusSistemaEnum>
        {
            public override StatusSistemaEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<StatusSistemaEnum>(value, out var result))
                    throw new JsonException($"Por favor, informe um valor válido para o Status do Sistema: {string.Join(",", Enum.GetNames(typeof(StatusSistemaEnum)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, StatusSistemaEnum value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }
    }
}
