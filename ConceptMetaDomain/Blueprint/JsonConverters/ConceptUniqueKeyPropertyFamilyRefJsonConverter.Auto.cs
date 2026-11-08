/****************************
 * ConceptUniqueKeyPropertyFamilyRefJsonConverter.Auto.cs
 ****************************/
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConceptMeta.Blueprint.JsonConverters
{
    /// <summary>
    /// Json Converter used to serialise and deserialise ConceptUniqueKeyPropertyFamilyRef blueprint objects
    /// </summary>
    public partial class ConceptUniqueKeyPropertyFamilyRefJsonConverter
        : JsonConverter<ConceptUniqueKeyPropertyFamilyRef>
    {

        #region Instance Methods
        public override ConceptUniqueKeyPropertyFamilyRef Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string propertyFamilyName = reader.GetString();
            return new ConceptUniqueKeyPropertyFamilyRef
            {
                PropertyFamilyName = propertyFamilyName
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            ConceptUniqueKeyPropertyFamilyRef value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.PropertyFamilyName);
        }

        #endregion
    }
}
