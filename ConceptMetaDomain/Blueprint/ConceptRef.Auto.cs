/****************************
 * ConceptRef.Auto.cs
 ****************************/
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ConceptMeta.Blueprint
{
    /// <summary>
    /// A field or relationship
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptRef: {PropertyName}")]
    public partial class ConceptRef
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptRef
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods, and wherever the underlying store does not require identifiers for nested objects.
        /// </summary>
        [DataMember]
        public int? ConceptRefId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [DataMember]
        public int ConceptModelId { get; set; }

        /// <summary>
        /// The ModelName value for the ConceptModel
        /// </summary>
        [DataMember]
        public string ModelName { get; set; }

        /// <summary>
        /// The ID of the Concept
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [DataMember]
        public int? ConceptId { get; set; }

        /// <summary>
        /// The name of the Concept
        /// </summary>
        [DataMember]
        public string ConceptName { get; set; }

        [DataMember]
        public string PropertyName { get; set; }

        [DataMember]
        public string PropertyDescription { get; set; }

        /// <summary>
        /// The ID of the Referenced Concept
        /// </summary>
        [DataMember]
        public int ReferencedConceptId { get; set; }

        /// <summary>
        /// The ConceptName value for the Referenced Concept
        /// </summary>
        [DataMember]
        public string ReferencedConceptName { get; set; }

        [DataMember]
        public string ConceptRefType { get; set; }

        /// <summary>
        /// The ID of the ConceptPropertyFamily
        /// </summary>
        [DataMember]
        public int? ConceptPropertyFamilyId { get; set; }

        /// <summary>
        /// The PropertyFamilyName value for the ConceptPropertyFamily
        /// </summary>
        [DataMember]
        public string PropertyFamilyName { get; set; }

        [DataMember]
        public bool? IsPropagating { get; set; }

        [DataMember]
        public string DbColumnName { get; set; }

        [DataMember]
        public bool? IsIdentity { get; set; }

        [DataMember]
        public bool? IsCoreField { get; set; }

        [DataMember]
        public string FieldFamilyName { get; set; }

        [DataMember]
        public bool? IsUpdatable { get; set; }

        [DataMember]
        public string FieldLabel { get; set; }

        [DataMember]
        public bool? IsScalarFieldToSerialiseInPersistenceModel { get; set; }

        [DataMember]
        public bool? IsScalarFieldToSerialiseInDomainModel { get; set; }

        [DataMember]
        public bool? IsSeqNoField { get; set; }

        [DataMember]
        public bool? IsDiscriminatorField { get; set; }

        [DataMember]
        public bool? IsXmlAttribute { get; set; }

        [DataMember]
        public bool? IsReferenceToChildEntity { get; set; }

        [DataMember]
        public string ParentQualifier { get; set; }

        [DataMember]
        public string ChildQualifier { get; set; }

        [DataMember]
        public int? MinChildOccurrences { get; set; }

        [DataMember]
        public int? MaxChildOccurrences { get; set; }

        [DataMember]
        public string ChildVerbPhrase { get; set; }

        [DataMember]
        public string ParentVerbPhrase { get; set; }

        [DataMember]
        public int? ChildPropertySeq { get; set; }

        [DataMember]
        public string ChildCollectionName { get; set; }

        [DataMember]
        public string ChildItemName { get; set; }

        [DataMember]
        public string ChildPropertyDescription { get; set; }

        [DataMember]
        public string SelectorType { get; set; }

        [DataMember]
        public string RelationshipType { get; set; }

        [DataMember]
        public bool? OutputExplicitXmlCollection { get; set; }

        [DataMember]
        public bool? IsSerialisedUsingScalarFieldInDomainModel { get; set; }

        [DataMember]
        public string ScalarFieldNameInDomainModel { get; set; }

        [DataMember]
        public string ExampleValueAsString { get; set; }

        [DataMember]
        public string RelationshipName { get; set; }

        [DataMember]
        public string DbForeignKeyName { get; set; }

        [DataMember]
        public string ParentIndexName { get; set; }

        [DataMember]
        public string ForeignKeySurrogateKeyFieldName { get; set; }

        [DataMember]
        public string ChildPropertyName { get; set; }

        [DataMember]
        public bool? IsNullable { get; set; }

        [DataMember]
        public int? PropertySeq { get; set; }

        #endregion
    }
}
