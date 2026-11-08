/****************************
 * EnumerationMemberDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// An item within a constrained vocabulary
    /// </summary>
    [DataContract]
    public partial class EnumerationMemberDto
    {

        #region Instance Properties

        [DataMember]
        public string EnumeratedValue { get; set; }

        [DataMember]
        public string EnumeratedValueDescription { get; set; }

        #endregion
    }
}
