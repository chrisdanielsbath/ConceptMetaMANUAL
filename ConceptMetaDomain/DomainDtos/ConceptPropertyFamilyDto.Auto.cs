/****************************
 * ConceptPropertyFamilyDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ConceptMeta.DomainDtos.JsonConverters;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// A family of properties
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(ConceptPropertyFamilyDtoJsonConverter))]
    public partial class ConceptPropertyFamilyDto
    {

        #region Instance Properties

        [DataMember]
        public string PropertyFamilyName { get; set; }

        #endregion
    }
}
