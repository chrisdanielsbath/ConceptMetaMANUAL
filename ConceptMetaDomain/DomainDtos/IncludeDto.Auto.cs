/****************************
 * IncludeDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ConceptMeta.DomainDtos.JsonConverters;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// A Linq expression, starting from the current entity, that defines an item to be hydrated when hydrating the current entity
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(IncludeDtoJsonConverter))]
    public partial class IncludeDto
    {

        #region Instance Properties

        [DataMember]
        public string ItemValue { get; set; }

        #endregion
    }
}
