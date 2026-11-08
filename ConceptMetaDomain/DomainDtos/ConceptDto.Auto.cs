/****************************
 * ConceptDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// An entity, a domain, a unique key or a sub type
    /// </summary>
    [DataContract]
    public partial class ConceptDto
    {

        #region Instance Properties

        [DataMember]
        public string ConceptName { get; set; }

        [DataMember]
        public string ConceptDescription { get; set; }

        [DataMember]
        public string ConceptType { get; set; }

        /// <summary>
        /// The DataTypeName value for the DataType
        /// </summary>
        [DataMember]
        public string DataTypeName { get; set; }

        /// <summary>
        /// The EnumerationName value for the Enumeration
        /// </summary>
        [DataMember]
        public string EnumerationName { get; set; }

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
        /// The business-facing identifier for the Referenced Concept
        /// </summary>
        [DataMember]
        public string ReferencedConceptName { get; set; }

        /// <summary>
        /// The business-facing identifier for the Referenced ConceptUniqueKey
        /// </summary>
        [DataMember]
        public string ReferencedUniqueKeyName { get; set; }

        /// <summary>
        /// The business-facing identifier for the Specialised Concept
        /// </summary>
        [DataMember]
        public string SpecialisedConceptName { get; set; }

        /// <summary>
        /// The business-facing identifier for the Specialised ConceptSubType
        /// </summary>
        [DataMember]
        public string SpecialisedSubTypeName { get; set; }

        /// <summary>
        /// The set of child <see cref="IncludeDto" /> objects
        /// </summary>
        [DataMember]
        public List<IncludeDto> Includes { get; set; }

        /// <summary>
        /// The set of child <see cref="QualifierDto" /> objects
        /// </summary>
        [DataMember]
        public List<QualifierDto> Qualifiers { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptPropertyFamilyDto" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptPropertyFamilyDto> PropertyFamilies { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptUniqueKeyDto" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptUniqueKeyDto> UniqueKeys { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptSubTypeDto" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptSubTypeDto> SubTypes { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptRefDto" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptRefDto> Properties { get; set; }

        #endregion
    }
}
