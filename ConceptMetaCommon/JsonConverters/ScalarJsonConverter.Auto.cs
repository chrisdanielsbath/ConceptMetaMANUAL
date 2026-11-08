using System;
using System.Reflection;
using Newtonsoft.Json;

namespace ConceptMeta.JsonConverters
{
    /// <summary>
    /// A JsonConverter that serialises / deserialises an object,
    /// using the value of a single nominated property
    /// 
    /// This may be used by annotating the class as follows:
    /// [JsonConverter(typeof(ScalarJsonConverter), "FieldName")]
    /// </summary>
    public class ScalarJsonConverter : JsonConverter
    {
        #region Private variables
        private string _scalarFieldName;
        #endregion

        #region Constructor
        public ScalarJsonConverter(string scalarFieldName)
        {
            _scalarFieldName = scalarFieldName;
        }
        #endregion

        #region Public methods
        public override bool CanConvert(Type objectType)
        {
            PropertyInfo scalarFieldProperty = objectType.GetProperty(_scalarFieldName);
            if (scalarFieldProperty != null
                && scalarFieldProperty.CanRead
                && scalarFieldProperty.CanWrite)
            {
                return true;
            }
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // get details of the named scalar field
            PropertyInfo scalarFieldProperty = objectType.GetProperty(_scalarFieldName);
            Type scalarFieldPropertyType = scalarFieldProperty.PropertyType;

            object scalarFieldValue;

            if (scalarFieldPropertyType == typeof(string))
            {
                // scalar field is of type "string" - this is the easy case!
                scalarFieldValue = (string)reader.Value;
            }
            else
            {
                // verify the scalar field is of a type that has a Parse method
                MethodInfo parseMethod = scalarFieldPropertyType.GetMethod("Parse", new Type[] { typeof(string) });

                if (parseMethod != null
                    && parseMethod.IsStatic
                    && parseMethod.ReturnType == scalarFieldPropertyType)
                {
                    // use the parse method to determine which value we should assign to the scalar field
                    scalarFieldValue = parseMethod.Invoke(null, new object[] { (string)reader.Value });
                }
                else
                {
                    throw new JsonException(string.Format(
                        "The {0} type does not have a public static Parse(string) method that returns a {0}.",
                        objectType.Name));
                }
            }

            // create an instance of the appropriate class
            ConstructorInfo constructorMethod = objectType.GetConstructor(Type.EmptyTypes);
            object result = constructorMethod.Invoke(null);

            // customise it by setting the right field to the right value
            objectType.InvokeMember(_scalarFieldName, BindingFlags.SetProperty, null, result, new object[] { scalarFieldValue });

            // return it
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // get details of the named scalar field
            PropertyInfo scalarFieldProperty = value.GetType().GetProperty(_scalarFieldName);

            // customise it by setting the right field to the right value
            object scalarFieldValue = value.GetType().InvokeMember(_scalarFieldName, BindingFlags.GetProperty, null, value, new object[] { });

            writer.WriteValue(scalarFieldValue.ToString());
        }
        #endregion
    }
}
