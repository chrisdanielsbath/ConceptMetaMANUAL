/****************************
 * QualifierDtoJsonConverter.Auto.cs
 ****************************/
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConceptMeta.DomainDtos.JsonConverters
{
    /// <summary>
    /// Json Converter used to serialise and deserialise Qualifier domain DTOs
    /// </summary>
    public partial class QualifierDtoJsonConverter
        : JsonConverter<QualifierDto>
    {

        #region Instance Methods
        public override QualifierDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string itemValue = reader.GetString();
            return new QualifierDto
            {
                ItemValue = itemValue
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            QualifierDto value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ItemValue);
        }

        #endregion
    }
}
