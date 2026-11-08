/****************************
 * ConceptRefLiteDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// A field or relationship
    /// </summary>
    [DataContract]
    public partial class ConceptRefLiteDto
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptRef
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods.
        /// </summary>
        [DataMember]
        public int? ConceptRefId { get; set; }

        /// <summary>
        /// The ID of the Concept
        /// </summary>
        [DataMember]
        public int ConceptId { get; set; }

        [DataMember]
        public string PropertyName { get; set; }

        /// <summary>
        /// The ID of the Referenced Concept
        /// </summary>
        [DataMember]
        public int ReferencedConceptId { get; set; }

        /// <summary>
        /// The ID of the ConceptPropertyFamily
        /// </summary>
        [DataMember]
        public int? ConceptPropertyFamilyId { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptLiteDto Concept { get; set; }

        /// <summary>
        /// The Referenced <see cref="ConceptLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptLiteDto ReferencedConcept { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptPropertyFamilyLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptPropertyFamilyLiteDto PropertyFamily { get; set; }

        #endregion
    }
}
