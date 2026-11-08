/****************************
 * ConceptSubTypePropertyFamilyRefDtoJsonConverter.Auto.cs
 ****************************/
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConceptMeta.DomainDtos.JsonConverters
{
    /// <summary>
    /// Json Converter used to serialise and deserialise ConceptSubTypePropertyFamilyRef domain DTOs
    /// </summary>
    public partial class ConceptSubTypePropertyFamilyRefDtoJsonConverter
        : JsonConverter<ConceptSubTypePropertyFamilyRefDto>
    {

        #region Instance Methods
        public override ConceptSubTypePropertyFamilyRefDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string propertyFamilyName = reader.GetString();
            return new ConceptSubTypePropertyFamilyRefDto
            {
                PropertyFamilyName = propertyFamilyName
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            ConceptSubTypePropertyFamilyRefDto value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.PropertyFamilyName);
        }

        #endregion
    }
}
