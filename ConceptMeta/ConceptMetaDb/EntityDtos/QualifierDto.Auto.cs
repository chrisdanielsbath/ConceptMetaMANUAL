/****************************
 * QualifierDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// A prefix that can be placed before the name of the current entity to specify the role it plays
    /// </summary>
    [DataContract]
    public partial class QualifierDto
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the Qualifier
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods.
        /// </summary>
        [DataMember]
        public int? QualifierId { get; set; }

        /// <summary>
        /// The ID of the Concept
        /// </summary>
        [DataMember]
        public int ConceptId { get; set; }

        [DataMember]
        public string ItemValue { get; set; }

        /// <summary>
        /// Sequence number
        /// </summary>
        [DataMember]
        public int SeqNo { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptLiteDto Concept { get; set; }

        #endregion
    }
}
