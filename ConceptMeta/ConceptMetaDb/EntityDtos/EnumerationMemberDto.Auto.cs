/****************************
 * EnumerationMemberDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// An item within a constrained vocabulary
    /// </summary>
    [DataContract]
    public partial class EnumerationMemberDto
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the EnumerationMember
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods.
        /// </summary>
        [DataMember]
        public int? EnumerationMemberId { get; set; }

        /// <summary>
        /// The ID of the Enumeration
        /// </summary>
        [DataMember]
        public int EnumerationId { get; set; }

        [DataMember]
        public string EnumeratedValue { get; set; }

        [DataMember]
        public string EnumeratedValueDescription { get; set; }

        /// <summary>
        /// The associated <see cref="EnumerationLiteDto" /> object
        /// </summary>
        [DataMember]
        public EnumerationLiteDto Enumeration { get; set; }

        #endregion
    }
}
