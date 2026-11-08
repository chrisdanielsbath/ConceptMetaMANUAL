/****************************
 * Concept.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ConceptMeta.DomainRegistryClasses;

namespace ConceptMeta.Domain
{
    /// <summary>
    /// An entity, a domain, a unique key or a sub type
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Concept: {ConceptName}")]
    public partial class Concept
    {

        #region Constructors
        public Concept()
        {
            ConceptRegistry = new ConceptRegistry(this);
        }

        #endregion

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

        [DataMember]
        public string ConceptName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ConceptDescription { get; set; }

        [DataMember]
        public string ConceptType { get; set; }

        /// <summary>
        /// The DataTypeName value for the DataType
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string DataTypeName { get; set; }

        /// <summary>
        /// The EnumerationName value for the Enumeration
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string EnumerationName { get; set; }

        /// <summary>
        /// The ConceptName value for the BasedOn Concept
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string BasedOnConceptName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ExampleValueAsString { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? MinLength { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? MaxLength { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public decimal? MinValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public decimal? MaxValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? TotalDigits { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? DecimalPlaces { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? DatePrecision { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string DbSchemaName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string DbTableName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsCollectionItem { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ToStringExpression { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsCreatable { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsUpdatable { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? IsDeletable { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string SurrogateKeyFieldName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string PrimaryKeyName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string AlternateKeyName { get; set; }

        /// <summary>
        /// The business-facing identifier for the Referenced Concept
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ReferencedConceptName { get; set; }

        /// <summary>
        /// The business-facing identifier for the Referenced ConceptUniqueKey
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ReferencedUniqueKeyName { get; set; }

        /// <summary>
        /// The business-facing identifier for the Specialised Concept
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string SpecialisedConceptName { get; set; }

        /// <summary>
        /// The business-facing identifier for the Specialised ConceptSubType
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string SpecialisedSubTypeName { get; set; }

        /// <summary>
        /// The set of child <see cref="Include" /> objects
        /// </summary>
        [DataMember]
        public IList<Include> Includes => ConceptRegistry.Includes;

        /// <summary>
        /// The set of child <see cref="Qualifier" /> objects
        /// </summary>
        [DataMember]
        public IList<Qualifier> Qualifiers => ConceptRegistry.Qualifiers;

        /// <summary>
        /// The set of child <see cref="ConceptPropertyFamily" /> objects
        /// </summary>
        [DataMember]
        public IList<ConceptPropertyFamily> PropertyFamilies => ConceptRegistry.PropertyFamilies;

        /// <summary>
        /// The set of child <see cref="ConceptUniqueKey" /> objects
        /// </summary>
        [DataMember]
        public IList<ConceptUniqueKey> UniqueKeys => ConceptRegistry.UniqueKeys;

        /// <summary>
        /// The set of child <see cref="ConceptSubType" /> objects
        /// </summary>
        [DataMember]
        public IList<ConceptSubType> SubTypes => ConceptRegistry.SubTypes;

        /// <summary>
        /// The set of child <see cref="ConceptRef" /> objects
        /// </summary>
        [DataMember]
        public IList<ConceptRef> Properties => ConceptRegistry.Properties;

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the Concept,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ConceptName;
        }

        /// <summary>
        /// Links the Concept to the parent ConceptModel and recurses in order to link up child objects similarly
        /// </summary>
        /// <param name="conceptModel"></param>
        public void Fixup(ConceptModel conceptModel)
        {
            ConceptModel = conceptModel;
            ConceptRegistry.ConceptModelRegistry = conceptModel.ConceptModelRegistry;
            foreach (Include i in Includes)
            {
                i.Fixup(this);
            }
            foreach (Qualifier q in Qualifiers)
            {
                q.Fixup(this);
            }
            foreach (ConceptPropertyFamily c in PropertyFamilies)
            {
                c.Fixup(this);
            }
            foreach (ConceptUniqueKey c in UniqueKeys)
            {
                c.Fixup(this);
            }
            foreach (ConceptSubType c in SubTypes)
            {
                c.Fixup(this);
            }
            foreach (ConceptRef c in Properties)
            {
                c.Fixup(this);
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the Concept
        /// </summary>
        internal ConceptRegistry ConceptRegistry { get; }

        /// <summary>
        /// The associated <see cref="ConceptModel" /> object
        /// </summary>
        [JsonIgnore]
        public ConceptModel ConceptModel { get; private set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<Concept> DerivedConcepts => ConceptRegistry
            .ConceptModelRegistry
            .GetDerivedConceptsByBasedOnConceptName(ConceptName);

        /// <summary>
        /// The set of ReferencedBy <see cref="ConceptRef" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<ConceptRef> ReferencedByProperties => ConceptRegistry
            .ConceptModelRegistry
            .GetReferencedByPropertiesByReferencedConceptName(ConceptName);

        /// <summary>
        /// The set of ReferencedBy <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<Concept> ReferencedByConcepts => ConceptRegistry
            .ConceptModelRegistry
            .GetReferencedByConceptsByReferencedConceptName(ConceptName);

        /// <summary>
        /// The set of SpecialisedBy <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<Concept> SpecialisedByConcepts => ConceptRegistry
            .ConceptModelRegistry
            .GetSpecialisedByConceptsBySpecialisedConceptName(ConceptName);

        /// <summary>
        /// The associated <see cref="DataType" /> object
        /// </summary>
        [JsonIgnore]
        public DataType DataType => ConceptRegistry
            .ConceptModelRegistry
            .FindDataTypeByDataTypeName(DataTypeName);

        /// <summary>
        /// The associated <see cref="Enumeration" /> object
        /// </summary>
        [JsonIgnore]
        public Enumeration Enumeration => ConceptRegistry
            .ConceptModelRegistry
            .FindEnumerationByEnumerationName(EnumerationName);

        /// <summary>
        /// The BasedOn <see cref="Concept" /> object
        /// </summary>
        [JsonIgnore]
        public Concept BasedOnConcept => ConceptRegistry
            .ConceptModelRegistry
            .FindConceptByConceptName(BasedOnConceptName);

        /// <summary>
        /// The Referenced <see cref="Concept" /> object
        /// </summary>
        [JsonIgnore]
        public Concept ReferencedConcept => ConceptRegistry
            .ConceptModelRegistry
            .FindConceptByConceptName(ReferencedConceptName);

        /// <summary>
        /// The Referenced <see cref="ConceptUniqueKey" /> object
        /// </summary>
        [JsonIgnore]
        public ConceptUniqueKey ReferencedUniqueKey => ConceptRegistry
            .ConceptModelRegistry
            .FindConceptByConceptName(ReferencedConceptName)
            .ConceptRegistry
            .FindUniqueKeyByUniqueKeyName(ReferencedUniqueKeyName);

        /// <summary>
        /// The Specialised <see cref="Concept" /> object
        /// </summary>
        [JsonIgnore]
        public Concept SpecialisedConcept => ConceptRegistry
            .ConceptModelRegistry
            .FindConceptByConceptName(SpecialisedConceptName);

        /// <summary>
        /// The Specialised <see cref="ConceptSubType" /> object
        /// </summary>
        [JsonIgnore]
        public ConceptSubType SpecialisedSubType => ConceptRegistry
            .ConceptModelRegistry
            .FindConceptByConceptName(SpecialisedConceptName)
            .ConceptRegistry
            .FindSubTypeBySubTypeName(SpecialisedSubTypeName);

        #endregion
    }
}
