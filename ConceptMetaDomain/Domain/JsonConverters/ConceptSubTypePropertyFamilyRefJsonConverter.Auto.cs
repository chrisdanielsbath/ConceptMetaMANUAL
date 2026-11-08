/****************************
 * ConceptSubTypePropertyFamilyRefJsonConverter.Auto.cs
 ****************************/
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConceptMeta.Domain.JsonConverters
{
    /// <summary>
    /// Json Converter used to serialise and deserialise ConceptSubTypePropertyFamilyRef domain objects
    /// </summary>
    public partial class ConceptSubTypePropertyFamilyRefJsonConverter
        : JsonConverter<ConceptSubTypePropertyFamilyRef>
    {

        #region Instance Methods
        public override ConceptSubTypePropertyFamilyRef Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string propertyFamilyName = reader.GetString();
            return new ConceptSubTypePropertyFamilyRef
            {
                PropertyFamilyName = propertyFamilyName
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            ConceptSubTypePropertyFamilyRef value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.PropertyFamilyName);
        }

        #endregion
    }
}
