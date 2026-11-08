/****************************
 * ConceptLiteDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// An entity, a domain, a unique key or a sub type
    /// </summary>
    [DataContract]
    public partial class ConceptLiteDto
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the Concept
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods.
        /// </summary>
        [DataMember]
        public int? ConceptId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [DataMember]
        public int ConceptModelId { get; set; }

        [DataMember]
        public string ConceptName { get; set; }

        /// <summary>
        /// The ID of the DataType
        /// </summary>
        [DataMember]
        public int? DataTypeId { get; set; }

        /// <summary>
        /// The ID of the Enumeration
        /// </summary>
        [DataMember]
        public int? EnumerationId { get; set; }

        /// <summary>
        /// The ID of the BasedOn Concept
        /// </summary>
        [DataMember]
        public int? BasedOnConceptId { get; set; }

        /// <summary>
        /// The ID of the Referenced Concept
        /// </summary>
        [DataMember]
        public int? ReferencedConceptId { get; set; }

        /// <summary>
        /// The ID of the Referenced ConceptUniqueKey
        /// </summary>
        [DataMember]
        public int? ReferencedConceptUniqueKeyId { get; set; }

        /// <summary>
        /// The ID of the Specialised Concept
        /// </summary>
        [DataMember]
        public int? SpecialisedConceptId { get; set; }

        /// <summary>
        /// The ID of the Specialised ConceptSubType
        /// </summary>
        [DataMember]
        public int? SpecialisedConceptSubTypeId { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptModelLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptModelLiteDto ConceptModel { get; set; }

        /// <summary>
        /// The associated <see cref="DataTypeLiteDto" /> object
        /// </summary>
        [DataMember]
        public DataTypeLiteDto DataType { get; set; }

        /// <summary>
        /// The associated <see cref="EnumerationLiteDto" /> object
        /// </summary>
        [DataMember]
        public EnumerationLiteDto Enumeration { get; set; }

        /// <summary>
        /// The BasedOn <see cref="ConceptLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptLiteDto BasedOnConcept { get; set; }

        /// <summary>
        /// The Referenced <see cref="ConceptLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptLiteDto ReferencedConcept { get; set; }

        /// <summary>
        /// The Referenced <see cref="ConceptUniqueKeyLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptUniqueKeyLiteDto ReferencedUniqueKey { get; set; }

        /// <summary>
        /// The Specialised <see cref="ConceptLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptLiteDto SpecialisedConcept { get; set; }

        /// <summary>
        /// The Specialised <see cref="ConceptSubTypeLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptSubTypeLiteDto SpecialisedSubType { get; set; }

        #endregion
    }
}
