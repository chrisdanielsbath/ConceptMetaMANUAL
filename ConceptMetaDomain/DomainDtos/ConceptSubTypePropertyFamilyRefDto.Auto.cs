/****************************
 * ConceptSubTypePropertyFamilyRefDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ConceptMeta.DomainDtos.JsonConverters;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// A record which associates a given sub type with a particular family of properties, signifying that the family is relevant to that sub type
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(ConceptSubTypePropertyFamilyRefDtoJsonConverter))]
    public partial class ConceptSubTypePropertyFamilyRefDto
    {

        #region Instance Properties

        /// <summary>
        /// The business-facing identifier for the ConceptPropertyFamily
        /// </summary>
        [DataMember]
        public string PropertyFamilyName { get; set; }

        #endregion
    }
}
