/****************************
 * ConceptRef.Auto.cs
 ****************************/
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ConceptMeta.DomainRegistryClasses;

namespace ConceptMeta.Domain
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
        /// The ModelName value for the ConceptModel
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [JsonIgnore]
        [DataMember]
        public string ModelName { get; set; }

        /// <summary>
        /// The name of the Concept
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [JsonIgnore]
        [DataMember]
        public string ConceptName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string PropertyName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string PropertyFamilyName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsPropagating { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string DbColumnName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsIdentity { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsCoreField { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string FieldFamilyName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsUpdatable { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string FieldLabel { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsScalarFieldToSerialiseInPersistenceModel { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsScalarFieldToSerialiseInDomainModel { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsSeqNoField { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsDiscriminatorField { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsXmlAttribute { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsReferenceToChildEntity { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ParentQualifier { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ChildQualifier { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? MinChildOccurrences { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? MaxChildOccurrences { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ChildVerbPhrase { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ParentVerbPhrase { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? ChildPropertySeq { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ChildCollectionName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ChildItemName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ChildPropertyDescription { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string SelectorType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string RelationshipType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? OutputExplicitXmlCollection { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsSerialisedUsingScalarFieldInDomainModel { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ScalarFieldNameInDomainModel { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ExampleValueAsString { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string RelationshipName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string DbForeignKeyName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ParentIndexName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ForeignKeySurrogateKeyFieldName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ChildPropertyName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsNullable { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? PropertySeq { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the ConceptRef,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return PropertyName;
        }

        /// <summary>
        /// Links the ConceptRef to the parent Concept and recurses in order to link up child objects similarly
        /// </summary>
        /// <param name="concept"></param>
        public void Fixup(Concept concept)
        {
            Concept = concept;
            ConceptRegistry = concept.ConceptRegistry;
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the Concept
        /// </summary>
        internal ConceptRegistry ConceptRegistry { get; private set; }

        /// <summary>
        /// The associated <see cref="Concept" /> object
        /// </summary>
        [JsonIgnore]
        public Concept Concept { get; private set; }

        /// <summary>
        /// The Referenced <see cref="Concept" /> object
        /// </summary>
        [JsonIgnore]
        public Concept ReferencedConcept => ConceptRegistry
            .ConceptModelRegistry
            .FindConceptByConceptName(ReferencedConceptName);

        /// <summary>
        /// The associated <see cref="ConceptPropertyFamily" /> object
        /// </summary>
        [JsonIgnore]
        public ConceptPropertyFamily PropertyFamily => ConceptRegistry
            .FindPropertyFamilyByPropertyFamilyName(PropertyFamilyName);

        #endregion
    }
}
