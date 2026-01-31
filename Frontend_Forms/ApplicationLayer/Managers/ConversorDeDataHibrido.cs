using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

public class ConversorDeDataHibrido : JsonConverter
{
    // O formato "estranho" que você recebe
    private const string FormatoEntrada = "MM/dd/yyyy HH:mm:ss zzz";

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?);
    }

    // LÊ O JSON (Do formato com barras para o objeto C#)
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.Value == null) return null;

        var texto = reader.Value.ToString();

        // Tenta fazer o parse do formato específico
        if (DateTimeOffset.TryParseExact(texto, FormatoEntrada, CultureInfo.InvariantCulture, DateTimeStyles.None, out var data))
        {
            return data;
        }

        // Se falhar, tenta o padrão do sistema (fallback)
        return DateTimeOffset.Parse(texto);
    }

    // ESCREVE O JSON (Do objeto C# para o formato com Z para o Go)
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var data = (DateTimeOffset)value;

        // AQUI É O PULO DO GATO:
        // Converte para UTC e força o formato ISO com Z no final
        string dataFormatada = data.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");

        writer.WriteValue(dataFormatada);
    }
}