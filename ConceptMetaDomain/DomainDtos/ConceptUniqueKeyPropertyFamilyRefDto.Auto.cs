/****************************
 * ConceptUniqueKeyPropertyFamilyRefDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ConceptMeta.DomainDtos.JsonConverters;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// A record that associates a given unique key with a particular family of properties, signifying that the family of properties is relevant to that unique key
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(ConceptUniqueKeyPropertyFamilyRefDtoJsonConverter))]
    public partial class ConceptUniqueKeyPropertyFamilyRefDto
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
