/****************************
 * Concept.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ConceptMeta.Blueprint
{
    /// <summary>
    /// An entity, a domain, a unique key or a sub type
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Concept: {ConceptName}")]
    public partial class Concept
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the Concept
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods, and wherever the underlying store does not require identifiers for nested objects.
        /// </summary>
        [DataMember]
        public int? ConceptId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [DataMember]
        public int? ConceptModelId { get; set; }

        /// <summary>
        /// The ModelName value for the ConceptModel
        /// </summary>
        [DataMember]
        public string ModelName { get; set; }

        [DataMember]
        public string ConceptName { get; set; }

        [DataMember]
        public string ConceptDescription { get; set; }

        [DataMember]
        public string ConceptType { get; set; }

        /// <summary>
        /// The ID of the DataType
        /// </summary>
        [DataMember]
        public int? DataTypeId { get; set; }

        /// <summary>
        /// The DataTypeName value for the DataType
        /// </summary>
        [DataMember]
        public string DataTypeName { get; set; }

        /// <summary>
        /// The ID of the Enumeration
        /// </summary>
        [DataMember]
        public int? EnumerationId { get; set; }

        /// <summary>
        /// The EnumerationName value for the Enumeration
        /// </summary>
        [DataMember]
        public string EnumerationName { get; set; }

        /// <summary>
        /// The ID of the BasedOn Concept
        /// </summary>
        [DataMember]
        public int? BasedOnConceptId { get; set; }

        /// <summary>
        /// The ConceptName value for the BasedOn Concept
        /// </summary>
        [DataMember]
        public string BasedOnConceptName { get; set; }

        [DataMember]
        public string ExampleValueAsString { get; set; }

        [DataMember]
        public int? MinLength { get; set; }

        [DataMember]
        public int? MaxLength { get; set; }

        [DataMember]
        public decimal? MinValue { get; set; }

        [DataMember]
        public decimal? MaxValue { get; set; }

        [DataMember]
        public int? TotalDigits { get; set; }

        [DataMember]
        public int? DecimalPlaces { get; set; }

        [DataMember]
        public int? DatePrecision { get; set; }

        [DataMember]
        public string DbSchemaName { get; set; }

        [DataMember]
        public string DbTableName { get; set; }

        [DataMember]
        public bool? IsCollectionItem { get; set; }

        [DataMember]
        public string ToStringExpression { get; set; }

        [DataMember]
        public bool? IsCreatable { get; set; }

        [DataMember]
        public bool? IsUpdatable { get; set; }

        [DataMember]
        public bool? IsDeletable { get; set; }

        [DataMember]
        public string SurrogateKeyFieldName { get; set; }

        [DataMember]
        public string PrimaryKeyName { get; set; }

        [DataMember]
        public string AlternateKeyName { get; set; }

        /// <summary>
        /// The ID of the Referenced Concept
        /// </summary>
        [DataMember]
        public int? ReferencedConceptId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Referenced Concept
        /// </summary>
        [DataMember]
        public string ReferencedConceptName { get; set; }

        /// <summary>
        /// The ID of the Referenced ConceptUniqueKey
        /// </summary>
        [DataMember]
        public int? ReferencedConceptUniqueKeyId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Referenced ConceptUniqueKey
        /// </summary>
        [DataMember]
        public string ReferencedUniqueKeyName { get; set; }

        /// <summary>
        /// The ID of the Specialised Concept
        /// </summary>
        [DataMember]
        public int? SpecialisedConceptId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Specialised Concept
        /// </summary>
        [DataMember]
        public string SpecialisedConceptName { get; set; }

        /// <summary>
        /// The ID of the Specialised ConceptSubType
        /// </summary>
        [DataMember]
        public int? SpecialisedConceptSubTypeId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Specialised ConceptSubType
        /// </summary>
        [DataMember]
        public string SpecialisedSubTypeName { get; set; }

        /// <summary>
        /// The set of child <see cref="Include" /> objects
        /// </summary>
        [DataMember]
        public List<Include> Includes { get; set; }

        /// <summary>
        /// The set of child <see cref="Qualifier" /> objects
        /// </summary>
        [DataMember]
        public List<Qualifier> Qualifiers { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptPropertyFamily" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptPropertyFamily> PropertyFamilies { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptUniqueKey" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptUniqueKey> UniqueKeys { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptSubType" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptSubType> SubTypes { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptRef" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptRef> Properties { get; set; }

        #endregion
    }
}
