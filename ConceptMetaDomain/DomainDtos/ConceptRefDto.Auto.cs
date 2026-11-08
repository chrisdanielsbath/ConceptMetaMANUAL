/****************************
 * ConceptRefDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// A field or relationship
    /// </summary>
    [DataContract]
    public partial class ConceptRefDto
    {

        #region Instance Properties

        [DataMember]
        public string PropertyName { get; set; }

        [DataMember]
        public string PropertyDescription { get; set; }

        /// <summary>
        /// The ConceptName value for the Referenced Concept
        /// </summary>
        [DataMember]
        public string ReferencedConceptName { get; set; }

        [DataMember]
        public string ConceptRefType { get; set; }

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
