/****************************
 * QualifierJsonConverter.Auto.cs
 ****************************/
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConceptMeta.Blueprint.JsonConverters
{
    /// <summary>
    /// Json Converter used to serialise and deserialise Qualifier blueprint objects
    /// </summary>
    public partial class QualifierJsonConverter
        : JsonConverter<Qualifier>
    {

        #region Instance Methods
        public override Qualifier Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string itemValue = reader.GetString();
            return new Qualifier
            {
                ItemValue = itemValue
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            Qualifier value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ItemValue);
        }

        #endregion
    }
}
