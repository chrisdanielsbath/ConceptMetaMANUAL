/****************************
 * Concept.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models
{
    /// <summary>
    /// An entity, a domain, a unique key or a sub type
    /// </summary>
    public partial class Concept
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the Concept
        /// </summary>
        [Display(Name = "Concept Id")]
        [Concept_Pk2CommonConcept]
        [Concept_Pk3ScalarConcept]
        [Concept_Pk4ObjectConcept]
        [Concept_Pk5UniqueKeyConcept]
        [Concept_Pk6SubTypeConcept]
        [JsonIgnore]
        public int? ConceptId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [Required]
        [Display(Name = "Concept Model Id")]
        [Concept_AkConceptConceptModelIdConceptName]
        [Concept_FkConceptConceptModelId]
        [JsonIgnore]
        public int? ConceptModelId { get; set; }

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
        [Concept_AkConceptConceptModelIdConceptName]
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
        [Concept_FkConceptDataTypeId]
        [JsonIgnore]
        public int? DataTypeId { get; set; }

        /// <summary>
        /// The DataTypeName value for the DataType
        /// </summary>
        [NotMapped]
        [Display(Name = "Data Type Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
        [Concept_FkConceptEnumerationId]
        [JsonIgnore]
        public int? EnumerationId { get; set; }

        /// <summary>
        /// The EnumerationName value for the Enumeration
        /// </summary>
        [NotMapped]
        [Display(Name = "Enumeration Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
        [Concept_FkConceptBasedOnConceptId]
        [JsonIgnore]
        public int? BasedOnConceptId { get; set; }

        /// <summary>
        /// The ConceptName value for the BasedOn Concept
        /// </summary>
        [NotMapped]
        [Display(Name = "Based On Concept Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
        [Concept_FkConceptReferencedConceptId]
        [JsonIgnore]
        public int? ReferencedConceptId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Referenced Concept
        /// </summary>
        [NotMapped]
        [Display(Name = "Referenced Concept Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
        [Concept_FkConceptReferencedConceptUniqueKeyId]
        [JsonIgnore]
        public int? ReferencedConceptUniqueKeyId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Referenced ConceptUniqueKey
        /// </summary>
        [NotMapped]
        [Display(Name = "Referenced Unique Key Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
        [Concept_FkConceptSpecialisedConceptId]
        [JsonIgnore]
        public int? SpecialisedConceptId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Specialised Concept
        /// </summary>
        [NotMapped]
        [Display(Name = "Specialised Concept Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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
        [Concept_FkConceptSpecialisedConceptSubTypeId]
        [JsonIgnore]
        public int? SpecialisedConceptSubTypeId { get; set; }

        /// <summary>
        /// The business-facing identifier for the Specialised ConceptSubType
        /// </summary>
        [NotMapped]
        [Display(Name = "Specialised Sub Type Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
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

        /// <summary>
        /// Returns a string value to represent the unique identifier for the Concept
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string PkString
        {
            get
            {
                return 
                    ConceptId.ToString();
            }
        }

        /// <summary>
        /// Returns a string value to represent the Concept,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string ValueString
        {
            get
            {
                return ConceptName;
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The associated <see cref="ConceptModel" /> object
        /// that is referenced using the <see cref="ConceptModelId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept Model")]
        [NotMapped]
        [Concept_FkConceptConceptModelId]
        [JsonIgnore]
        public string ConceptModelKeyString
        {
            get
            {
                if ((ConceptModelId == null))
                {
                    return "";
                }
                else
                {
                    return ConceptModelId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    ConceptModelId = null;
                }
                else
                {
                    ConceptModelId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The associated <see cref="DataType" /> object
        /// that is referenced using the <see cref="DataTypeId" /> property
        /// </summary>
        [Display(Name = "Data Type")]
        [NotMapped]
        [Concept_FkConceptDataTypeId]
        [JsonIgnore]
        public string DataTypeKeyString
        {
            get
            {
                if ((DataTypeId == null))
                {
                    return "";
                }
                else
                {
                    return DataTypeId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    DataTypeId = null;
                }
                else
                {
                    DataTypeId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The associated <see cref="Enumeration" /> object
        /// that is referenced using the <see cref="EnumerationId" /> property
        /// </summary>
        [Display(Name = "Enumeration")]
        [NotMapped]
        [Concept_FkConceptEnumerationId]
        [JsonIgnore]
        public string EnumerationKeyString
        {
            get
            {
                if ((EnumerationId == null))
                {
                    return "";
                }
                else
                {
                    return EnumerationId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    EnumerationId = null;
                }
                else
                {
                    EnumerationId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The BasedOn <see cref="Concept" /> object
        /// that is referenced using the <see cref="BasedOnConceptId" /> property
        /// </summary>
        [Display(Name = "Based On Concept")]
        [NotMapped]
        [Concept_FkConceptBasedOnConceptId]
        [JsonIgnore]
        public string BasedOnConceptKeyString
        {
            get
            {
                if ((BasedOnConceptId == null))
                {
                    return "";
                }
                else
                {
                    return BasedOnConceptId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    BasedOnConceptId = null;
                }
                else
                {
                    BasedOnConceptId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The Referenced <see cref="Concept" /> object
        /// that is referenced using the <see cref="ReferencedConceptId" /> property
        /// </summary>
        [Display(Name = "Referenced Concept")]
        [NotMapped]
        [Concept_FkConceptReferencedConceptId]
        [JsonIgnore]
        public string ReferencedConceptKeyString
        {
            get
            {
                if ((ReferencedConceptId == null))
                {
                    return "";
                }
                else
                {
                    return ReferencedConceptId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    ReferencedConceptId = null;
                }
                else
                {
                    ReferencedConceptId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The Referenced <see cref="ConceptUniqueKey" /> object
        /// that is referenced using the <see cref="ReferencedConceptUniqueKeyId" /> property
        /// </summary>
        [Display(Name = "Referenced Unique Key")]
        [NotMapped]
        [Concept_FkConceptReferencedConceptUniqueKeyId]
        [JsonIgnore]
        public string ReferencedUniqueKeyKeyString
        {
            get
            {
                if ((ReferencedConceptUniqueKeyId == null))
                {
                    return "";
                }
                else
                {
                    return ReferencedConceptUniqueKeyId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    ReferencedConceptUniqueKeyId = null;
                }
                else
                {
                    ReferencedConceptUniqueKeyId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The Specialised <see cref="Concept" /> object
        /// that is referenced using the <see cref="SpecialisedConceptId" /> property
        /// </summary>
        [Display(Name = "Specialised Concept")]
        [NotMapped]
        [Concept_FkConceptSpecialisedConceptId]
        [JsonIgnore]
        public string SpecialisedConceptKeyString
        {
            get
            {
                if ((SpecialisedConceptId == null))
                {
                    return "";
                }
                else
                {
                    return SpecialisedConceptId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    SpecialisedConceptId = null;
                }
                else
                {
                    SpecialisedConceptId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The Specialised <see cref="ConceptSubType" /> object
        /// that is referenced using the <see cref="SpecialisedConceptSubTypeId" /> property
        /// </summary>
        [Display(Name = "Specialised Sub Type")]
        [NotMapped]
        [Concept_FkConceptSpecialisedConceptSubTypeId]
        [JsonIgnore]
        public string SpecialisedSubTypeKeyString
        {
            get
            {
                if ((SpecialisedConceptSubTypeId == null))
                {
                    return "";
                }
                else
                {
                    return SpecialisedConceptSubTypeId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    SpecialisedConceptSubTypeId = null;
                }
                else
                {
                    SpecialisedConceptSubTypeId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The associated <see cref="ConceptModel" /> object
        /// that is referenced using the <see cref="ConceptModelId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept Model")]
        [NotMapped]
        [Concept_FkConceptConceptModelId]
        [JsonIgnore]
        public string ConceptModelValueString
        {
            get
            {
                if (ConceptModel == null)
                {
                    if (ConceptModelKeyString != "")
                    {
                        return "ConceptModel " + ConceptModelKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return ConceptModel.ToString();
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The associated <see cref="DataType" /> object
        /// that is referenced using the <see cref="DataTypeId" /> property
        /// </summary>
        [Display(Name = "Data Type")]
        [NotMapped]
        [Concept_FkConceptDataTypeId]
        [JsonIgnore]
        public string DataTypeValueString
        {
            get
            {
                if (DataType == null)
                {
                    if (DataTypeKeyString != "")
                    {
                        return "DataType " + DataTypeKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return DataType.ToString();
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The associated <see cref="Enumeration" /> object
        /// that is referenced using the <see cref="EnumerationId" /> property
        /// </summary>
        [Display(Name = "Enumeration")]
        [NotMapped]
        [Concept_FkConceptEnumerationId]
        [JsonIgnore]
        public string EnumerationValueString
        {
            get
            {
                if (Enumeration == null)
                {
                    if (EnumerationKeyString != "")
                    {
                        return "Enumeration " + EnumerationKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return Enumeration.ToString();
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The BasedOn <see cref="Concept" /> object
        /// that is referenced using the <see cref="BasedOnConceptId" /> property
        /// </summary>
        [Display(Name = "Based On Concept")]
        [NotMapped]
        [Concept_FkConceptBasedOnConceptId]
        [JsonIgnore]
        public string BasedOnConceptValueString
        {
            get
            {
                if (BasedOnConcept == null)
                {
                    if (BasedOnConceptKeyString != "")
                    {
                        return "Concept " + BasedOnConceptKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return BasedOnConcept.ToString();
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The Referenced <see cref="Concept" /> object
        /// that is referenced using the <see cref="ReferencedConceptId" /> property
        /// </summary>
        [Display(Name = "Referenced Concept")]
        [NotMapped]
        [Concept_FkConceptReferencedConceptId]
        [JsonIgnore]
        public string ReferencedConceptValueString
        {
            get
            {
                if (ReferencedConcept == null)
                {
                    if (ReferencedConceptKeyString != "")
                    {
                        return "Concept " + ReferencedConceptKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return ReferencedConcept.ToString();
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The Referenced <see cref="ConceptUniqueKey" /> object
        /// that is referenced using the <see cref="ReferencedConceptUniqueKeyId" /> property
        /// </summary>
        [Display(Name = "Referenced Unique Key")]
        [NotMapped]
        [Concept_FkConceptReferencedConceptUniqueKeyId]
        [JsonIgnore]
        public string ReferencedUniqueKeyValueString
        {
            get
            {
                if (ReferencedUniqueKey == null)
                {
                    if (ReferencedUniqueKeyKeyString != "")
                    {
                        return "ConceptUniqueKey " + ReferencedUniqueKeyKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return ReferencedUniqueKey.ToString();
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The Specialised <see cref="Concept" /> object
        /// that is referenced using the <see cref="SpecialisedConceptId" /> property
        /// </summary>
        [Display(Name = "Specialised Concept")]
        [NotMapped]
        [Concept_FkConceptSpecialisedConceptId]
        [JsonIgnore]
        public string SpecialisedConceptValueString
        {
            get
            {
                if (SpecialisedConcept == null)
                {
                    if (SpecialisedConceptKeyString != "")
                    {
                        return "Concept " + SpecialisedConceptKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return SpecialisedConcept.ToString();
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The Specialised <see cref="ConceptSubType" /> object
        /// that is referenced using the <see cref="SpecialisedConceptSubTypeId" /> property
        /// </summary>
        [Display(Name = "Specialised Sub Type")]
        [NotMapped]
        [Concept_FkConceptSpecialisedConceptSubTypeId]
        [JsonIgnore]
        public string SpecialisedSubTypeValueString
        {
            get
            {
                if (SpecialisedSubType == null)
                {
                    if (SpecialisedSubTypeKeyString != "")
                    {
                        return "ConceptSubType " + SpecialisedSubTypeKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return SpecialisedSubType.ToString();
                }
            }
        }

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

        #endregion
    }
}
