/****************************
 * ConceptRef.Auto.cs
 ****************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ConceptMeta.ConceptMetaDb.Entities
{
    /// <summary>
    /// A field or relationship
    /// </summary>
    [DebuggerDisplay("ConceptRef: {PropertyName}")]
    public partial class ConceptRef
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptRef
        /// </summary>
        [Display(Name = "Concept Ref Id")]
        public int ConceptRefId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [NotMapped]
        [Display(Name = "Concept Model Id")]
        [JsonIgnore]
        public int? ConceptModelId
        {
            get
            {
                return Concept?.ConceptModelId;
            }
        }

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
                return Concept?.ConceptModel?.ModelName;
            }
        }

        /// <summary>
        /// The ID of the Concept
        /// </summary>
        [Required]
        [Display(Name = "Concept Id")]
        [JsonIgnore]
        public int ConceptId { get; set; }

        /// <summary>
        /// The name of the Concept
        /// </summary>
        [NotMapped]
        [Display(Name = "Concept Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string ConceptName
        {
            get
            {
                return Concept?.ConceptName;
            }
        }

        [Display(Name = "Property Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PropertyName { get; set; }

        [Display(Name = "Property Description")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PropertyDescription { get; set; }

        /// <summary>
        /// The ID of the Referenced Concept
        /// </summary>
        [Required]
        [Display(Name = "Referenced Concept Id")]
        public int ReferencedConceptId { get; set; }

        /// <summary>
        /// The ConceptName value for the Referenced Concept
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

        [Required]
        [Display(Name = "Concept Ref Type")]
        [MaxLength(200)]
        public string ConceptRefType { get; set; }

        /// <summary>
        /// The ID of the ConceptPropertyFamily
        /// </summary>
        [Display(Name = "Concept Property Family Id")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ConceptPropertyFamilyId { get; set; }

        /// <summary>
        /// The PropertyFamilyName value for the ConceptPropertyFamily
        /// </summary>
        [NotMapped]
        [Display(Name = "Property Family Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string PropertyFamilyName
        {
            get
            {
                return PropertyFamily?.PropertyFamilyName;
            }
        }

        [Display(Name = "Is Propagating")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPropagating { get; set; }

        [Display(Name = "Db Column Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DbColumnName { get; set; }

        [Display(Name = "Is Identity")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsIdentity { get; set; }

        [Display(Name = "Is Core Field")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCoreField { get; set; }

        [Display(Name = "Field Family Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FieldFamilyName { get; set; }

        [Display(Name = "Is Updatable")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUpdatable { get; set; }

        [Display(Name = "Field Label")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FieldLabel { get; set; }

        [Display(Name = "Is Scalar Field To Serialise In Persistence Model")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsScalarFieldToSerialiseInPersistenceModel { get; set; }

        [Display(Name = "Is Scalar Field To Serialise In Domain Model")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsScalarFieldToSerialiseInDomainModel { get; set; }

        [Display(Name = "Is Seq No Field")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSeqNoField { get; set; }

        [Display(Name = "Is Discriminator Field")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDiscriminatorField { get; set; }

        [Display(Name = "Is Xml Attribute")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsXmlAttribute { get; set; }

        [Display(Name = "Is Reference To Child Entity")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsReferenceToChildEntity { get; set; }

        [Display(Name = "Parent Qualifier")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ParentQualifier { get; set; }

        [Display(Name = "Child Qualifier")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ChildQualifier { get; set; }

        [Display(Name = "Min Child Occurrences")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MinChildOccurrences { get; set; }

        [Display(Name = "Max Child Occurrences")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxChildOccurrences { get; set; }

        [Display(Name = "Child Verb Phrase")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ChildVerbPhrase { get; set; }

        [Display(Name = "Parent Verb Phrase")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ParentVerbPhrase { get; set; }

        [Display(Name = "Child Property Seq")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ChildPropertySeq { get; set; }

        [Display(Name = "Child Collection Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ChildCollectionName { get; set; }

        [Display(Name = "Child Item Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ChildItemName { get; set; }

        [Display(Name = "Child Property Description")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ChildPropertyDescription { get; set; }

        [Display(Name = "Selector Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SelectorType { get; set; }

        [Display(Name = "Relationship Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RelationshipType { get; set; }

        [Display(Name = "Output Explicit Xml Collection")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? OutputExplicitXmlCollection { get; set; }

        [Display(Name = "Is Serialised Using Scalar Field In Domain Model")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSerialisedUsingScalarFieldInDomainModel { get; set; }

        [Display(Name = "Scalar Field Name In Domain Model")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ScalarFieldNameInDomainModel { get; set; }

        [Display(Name = "Example Value As String")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExampleValueAsString { get; set; }

        [Display(Name = "Relationship Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RelationshipName { get; set; }

        [Display(Name = "Db Foreign Key Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DbForeignKeyName { get; set; }

        [Display(Name = "Parent Index Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ParentIndexName { get; set; }

        [Display(Name = "Foreign Key Surrogate Key Field Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ForeignKeySurrogateKeyFieldName { get; set; }

        [Display(Name = "Child Property Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ChildPropertyName { get; set; }

        [Display(Name = "Is Nullable")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsNullable { get; set; }

        [Display(Name = "Property Seq")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? PropertySeq { get; set; }

        /// <summary>
        /// The associated <see cref="Concept" /> object
        /// that is referenced using the <see cref="ConceptId" /> property
        /// </summary>
        [JsonIgnore]
        public Concept Concept { get; set; }

        /// <summary>
        /// The Referenced <see cref="Concept" /> object
        /// that is referenced using the <see cref="ReferencedConceptId" /> property
        /// </summary>
        [JsonIgnore]
        public Concept ReferencedConcept { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptPropertyFamily" /> object
        /// that is referenced using the <see cref="ConceptPropertyFamilyId" /> property
        /// </summary>
        [JsonIgnore]
        public ConceptPropertyFamily PropertyFamily { get; set; }

        #endregion
    }
}
