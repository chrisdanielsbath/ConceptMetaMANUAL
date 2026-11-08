/****************************
 * Concept.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ConceptMeta.ConceptMetaDb.Entities
{
    /// <summary>
    /// An entity, a domain, a unique key or a sub type
    /// </summary>
    [DebuggerDisplay("Concept: {ConceptName}")]
    public partial class Concept
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the Concept
        /// </summary>
        [Display(Name = "Concept Id")]
        public int ConceptId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [Required]
        [Display(Name = "Concept Model Id")]
        [JsonIgnore]
        public int ConceptModelId { get; set; }

        /// <summary>
        /// The ModelName value for the ConceptModel
        /// </summary>
        [NotMapped]
        [Display(Name = "Model Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string ModelName
        {
            get
            {
                return ConceptModel?.ModelName;
            }
        }

        [Required]
        [Display(Name = "Concept Name")]
        [MaxLength(200)]
        public string ConceptName { get; set; }

        [Display(Name = "Concept Description")]
        [MaxLength(500)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ConceptDescription { get; set; }

        [Required]
        [Display(Name = "Concept Type")]
        public string ConceptType { get; set; }

        /// <summary>
        /// The ID of the DataType
        /// </summary>
        [Display(Name = "Data Type Id")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? DataTypeId { get; set; }

        /// <summary>
        /// The DataTypeName value for the DataType
        /// </summary>
        [NotMapped]
        [Display(Name = "Data Type Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string DataTypeName
        {
            get
            {
                return DataType?.DataTypeName;
            }
        }

        /// <summary>
        /// The ID of the Enumeration
        /// </summary>
        [Display(Name = "Enumeration Id")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? EnumerationId { get; set; }

        /// <summary>
        /// The EnumerationName value for the Enumeration
        /// </summary>
        [NotMapped]
        [Display(Name = "Enumeration Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string EnumerationName
        {
            get
            {
                return Enumeration?.EnumerationName;
            }
        }

        /// <summary>
        /// The ID of the BasedOn Concept
        /// </summary>
        [Display(Name = "Based On Concept Id")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? BasedOnConceptId { get; set; }

        /// <summary>
        /// The ConceptName value for the BasedOn Concept
        /// </summary>
        [NotMapped]
        [Display(Name = "Based On Concept Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string BasedOnConceptName
        {
            get
            {
                return BasedOnConcept?.ConceptName;
            }
        }

        [Display(Name = "Example Value As String")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExampleValueAsString { get; set; }

        [Display(Name = "Min Length")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MinLength { get; set; }

        [Display(Name = "Max Length")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxLength { get; set; }

        [Display(Name = "Min Value")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MinValue { get; set; }

        [Display(Name = "Max Value")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MaxValue { get; set; }

        [Display(Name = "Total Digits")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalDigits { get; set; }

        [Display(Name = "Decimal Places")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? DecimalPlaces { get; set; }

        [Display(Name = "Date Precision")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? DatePrecision { get; set; }

        [Display(Name = "Db Schema Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DbSchemaName { get; set; }

        [Display(Name = "Db Table Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DbTableName { get; set; }

        [Display(Name = "Is Collection Item")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCollectionItem { get; set; }

        [Display(Name = "To String Expression")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ToStringExpression { get; set; }

        [Display(Name = "Is Creatable")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCreatable { get; set; }

        [Display(Name = "Is Updatable")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUpdatable { get; set; }

        [Display(Name = "Is Deletable")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDeletable { get; set; }

        [Display(Name = "Surrogate Key Field Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SurrogateKeyFieldName { get; set; }

        [Display(Name = "Primary Key Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PrimaryKeyName { get; set; }

        [Display(Name = "Alternate Key Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateKeyName { get; set; }

        /// <summary>
        /// The ID of the Referenced Concept
        /// </summary>
        [Display(Name = "Referenced Concept Id")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ReferencedConceptId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Referenced Concept
        /// </summary>
        [NotMapped]
        [Display(Name = "Referenced Concept Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string ReferencedConceptName
        {
            get
            {
                return ReferencedConcept?.ConceptName;
            }
        }

        /// <summary>
        /// The ID of the Referenced ConceptUniqueKey
        /// </summary>
        [Display(Name = "Referenced Concept Unique Key Id")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ReferencedConceptUniqueKeyId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Referenced ConceptUniqueKey
        /// </summary>
        [NotMapped]
        [Display(Name = "Referenced Unique Key Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string ReferencedUniqueKeyName
        {
            get
            {
                return ReferencedUniqueKey?.UniqueKeyName;
            }
        }

        /// <summary>
        /// The ID of the Specialised Concept
        /// </summary>
        [Display(Name = "Specialised Concept Id")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? SpecialisedConceptId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Specialised Concept
        /// </summary>
        [NotMapped]
        [Display(Name = "Specialised Concept Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string SpecialisedConceptName
        {
            get
            {
                return SpecialisedConcept?.ConceptName;
            }
        }

        /// <summary>
        /// The ID of the Specialised ConceptSubType
        /// </summary>
        [Display(Name = "Specialised Concept Sub Type Id")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? SpecialisedConceptSubTypeId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Specialised ConceptSubType
        /// </summary>
        [NotMapped]
        [Display(Name = "Specialised Sub Type Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string SpecialisedSubTypeName
        {
            get
            {
                return SpecialisedSubType?.SubTypeName;
            }
        }

        /// <summary>
        /// The associated <see cref="ConceptModel" /> object
        /// that is referenced using the <see cref="ConceptModelId" /> property
        /// </summary>
        [JsonIgnore]
        public ConceptModel ConceptModel { get; set; }

        /// <summary>
        /// The associated <see cref="DataType" /> object
        /// that is referenced using the <see cref="DataTypeId" /> property
        /// </summary>
        [JsonIgnore]
        public DataType DataType { get; set; }

        /// <summary>
        /// The associated <see cref="Enumeration" /> object
        /// that is referenced using the <see cref="EnumerationId" /> property
        /// </summary>
        [JsonIgnore]
        public Enumeration Enumeration { get; set; }

        /// <summary>
        /// The BasedOn <see cref="Concept" /> object
        /// that is referenced using the <see cref="BasedOnConceptId" /> property
        /// </summary>
        [JsonIgnore]
        public Concept BasedOnConcept { get; set; }

        /// <summary>
        /// The Referenced <see cref="Concept" /> object
        /// that is referenced using the <see cref="ReferencedConceptId" /> property
        /// </summary>
        [JsonIgnore]
        public Concept ReferencedConcept { get; set; }

        /// <summary>
        /// The Referenced <see cref="ConceptUniqueKey" /> object
        /// that is referenced using the <see cref="ReferencedConceptUniqueKeyId" /> property
        /// </summary>
        [JsonIgnore]
        public ConceptUniqueKey ReferencedUniqueKey { get; set; }

        /// <summary>
        /// The Specialised <see cref="Concept" /> object
        /// that is referenced using the <see cref="SpecialisedConceptId" /> property
        /// </summary>
        [JsonIgnore]
        public Concept SpecialisedConcept { get; set; }

        /// <summary>
        /// The Specialised <see cref="ConceptSubType" /> object
        /// that is referenced using the <see cref="SpecialisedConceptSubTypeId" /> property
        /// </summary>
        [JsonIgnore]
        public ConceptSubType SpecialisedSubType { get; set; }

        /// <summary>
        /// The set of child <see cref="Include" /> objects
        /// </summary>
        public virtual ICollection<Include> Includes { get; set; }

        /// <summary>
        /// The set of child <see cref="Qualifier" /> objects
        /// </summary>
        public virtual ICollection<Qualifier> Qualifiers { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptPropertyFamily" /> objects
        /// </summary>
        public virtual ICollection<ConceptPropertyFamily> PropertyFamilies { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptUniqueKey" /> objects
        /// </summary>
        public virtual ICollection<ConceptUniqueKey> UniqueKeys { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptSubType" /> objects
        /// </summary>
        public virtual ICollection<ConceptSubType> SubTypes { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptRef" /> objects
        /// </summary>
        public virtual ICollection<ConceptRef> Properties { get; set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Concept> DerivedConcepts { get; set; }

        /// <summary>
        /// The set of ReferencedBy <see cref="ConceptRef" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<ConceptRef> ReferencedByProperties { get; set; }

        /// <summary>
        /// The set of ReferencedBy <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Concept> ReferencedByConcepts { get; set; }

        /// <summary>
        /// The set of SpecialisedBy <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Concept> SpecialisedByConcepts { get; set; }

        #endregion
    }
}
