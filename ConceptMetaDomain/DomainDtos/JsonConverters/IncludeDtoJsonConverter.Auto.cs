/****************************
 * IncludeDtoJsonConverter.Auto.cs
 ****************************/
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConceptMeta.DomainDtos.JsonConverters
{
    /// <summary>
    /// Json Converter used to serialise and deserialise Include domain DTOs
    /// </summary>
    public partial class IncludeDtoJsonConverter
        : JsonConverter<IncludeDto>
    {

        #region Instance Methods
        public override IncludeDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string itemValue = reader.GetString();
            return new IncludeDto
            {
                ItemValue = itemValue
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            IncludeDto value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ItemValue);
        }

        #endregion
    }
}
