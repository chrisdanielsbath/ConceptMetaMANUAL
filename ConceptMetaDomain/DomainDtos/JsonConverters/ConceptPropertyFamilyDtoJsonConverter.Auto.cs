/****************************
 * ConceptPropertyFamilyDtoJsonConverter.Auto.cs
 ****************************/
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConceptMeta.DomainDtos.JsonConverters
{
    /// <summary>
    /// Json Converter used to serialise and deserialise ConceptPropertyFamily domain DTOs
    /// </summary>
    public partial class ConceptPropertyFamilyDtoJsonConverter
        : JsonConverter<ConceptPropertyFamilyDto>
    {

        #region Instance Methods
        public override ConceptPropertyFamilyDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string propertyFamilyName = reader.GetString();
            return new ConceptPropertyFamilyDto
            {
                PropertyFamilyName = propertyFamilyName
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            ConceptPropertyFamilyDto value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.PropertyFamilyName);
        }

        #endregion
    }
}
