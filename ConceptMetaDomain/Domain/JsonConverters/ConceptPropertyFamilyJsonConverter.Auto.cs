/****************************
 * ConceptPropertyFamilyJsonConverter.Auto.cs
 ****************************/
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConceptMeta.Domain.JsonConverters
{
    /// <summary>
    /// Json Converter used to serialise and deserialise ConceptPropertyFamily domain objects
    /// </summary>
    public partial class ConceptPropertyFamilyJsonConverter
        : JsonConverter<ConceptPropertyFamily>
    {

        #region Instance Methods
        public override ConceptPropertyFamily Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string propertyFamilyName = reader.GetString();
            return new ConceptPropertyFamily
            {
                PropertyFamilyName = propertyFamilyName
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            ConceptPropertyFamily value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.PropertyFamilyName);
        }

        #endregion
    }
}
