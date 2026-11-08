/****************************
 * QualifierDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using ConceptMeta.DomainDtos.JsonConverters;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// A prefix that can be placed before the name of the current entity to specify the role it plays
    /// </summary>
    [DataContract]
    [JsonConverter(typeof(QualifierDtoJsonConverter))]
    public partial class QualifierDto
    {

        #region Instance Properties

        [DataMember]
        public string ItemValue { get; set; }

        #endregion
    }
}
