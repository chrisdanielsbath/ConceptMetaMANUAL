/****************************
 * IncludeJsonConverter.Auto.cs
 ****************************/
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConceptMeta.Blueprint.JsonConverters
{
    /// <summary>
    /// Json Converter used to serialise and deserialise Include blueprint objects
    /// </summary>
    public partial class IncludeJsonConverter
        : JsonConverter<Include>
    {

        #region Instance Methods
        public override Include Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string itemValue = reader.GetString();
            return new Include
            {
                ItemValue = itemValue
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            Include value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ItemValue);
        }

        #endregion
    }
}
