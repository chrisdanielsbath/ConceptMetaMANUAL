/****************************
 * ConceptUniqueKeyPropertyFamilyRefDtoJsonConverter.Auto.cs
 ****************************/
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConceptMeta.DomainDtos.JsonConverters
{
    /// <summary>
    /// Json Converter used to serialise and deserialise ConceptUniqueKeyPropertyFamilyRef domain DTOs
    /// </summary>
    public partial class ConceptUniqueKeyPropertyFamilyRefDtoJsonConverter
        : JsonConverter<ConceptUniqueKeyPropertyFamilyRefDto>
    {

        #region Instance Methods
        public override ConceptUniqueKeyPropertyFamilyRefDto Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string propertyFamilyName = reader.GetString();
            return new ConceptUniqueKeyPropertyFamilyRefDto
            {
                PropertyFamilyName = propertyFamilyName
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            ConceptUniqueKeyPropertyFamilyRefDto value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.PropertyFamilyName);
        }

        #endregion
    }
}
