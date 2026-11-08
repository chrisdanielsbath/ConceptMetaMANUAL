/****************************
 * Enumeration.Auto.cs
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
    /// A constrained vocabulary
    /// </summary>
    public partial class Enumeration
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the Enumeration
        /// </summary>
        [Display(Name = "Enumeration Id")]
        [JsonIgnore]
        public int? EnumerationId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [Required]
        [Display(Name = "Concept Model Id")]
        [Enumeration_AkEnumerationConceptModelIdEnumerationName]
        [Enumeration_FkEnumerationConceptModelId]
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

        [Display(Name = "Enumeration Name")]
        [MaxLength(200)]
        [Enumeration_AkEnumerationConceptModelIdEnumerationName]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EnumerationName { get; set; }

        [Display(Name = "Enumeration Description")]
        [MaxLength(500)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EnumerationDescription { get; set; }

        /// <summary>
        /// The ID of the DataType
        /// </summary>
        [Required]
        [Display(Name = "Data Type Id")]
        [Enumeration_FkEnumerationDataTypeId]
        [JsonIgnore]
        public int? DataTypeId { get; set; }

        /// <summary>
        /// The DataTypeName value for the DataType
        /// </summary>
        [NotMapped]
        [Display(Name = "Data Type Name")]
        [MaxLength(200)]
        public string DataTypeName
        {
            get
            {
                return DataType?.DataTypeName;
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
        /// The set of child <see cref="EnumerationMember" /> objects
        /// </summary>
        public virtual ICollection<EnumerationMember> EnumeratedValues { get; set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Concept> Concepts { get; set; }

        /// <summary>
        /// Returns a string value to represent the unique identifier for the Enumeration
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string PkString
        {
            get
            {
                return 
                    EnumerationId.ToString();
            }
        }

        /// <summary>
        /// Returns a string value to represent the Enumeration,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string ValueString
        {
            get
            {
                return EnumerationName;
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The associated <see cref="ConceptModel" /> object
        /// that is referenced using the <see cref="ConceptModelId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept Model")]
        [NotMapped]
        [Enumeration_FkEnumerationConceptModelId]
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
        [Required]
        [Display(Name = "Data Type")]
        [NotMapped]
        [Enumeration_FkEnumerationDataTypeId]
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
        /// Returns a string value to represent The associated <see cref="ConceptModel" /> object
        /// that is referenced using the <see cref="ConceptModelId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept Model")]
        [NotMapped]
        [Enumeration_FkEnumerationConceptModelId]
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
        [Required]
        [Display(Name = "Data Type")]
        [NotMapped]
        [Enumeration_FkEnumerationDataTypeId]
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

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the Enumeration,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return EnumerationName;
        }

        #endregion
    }
}
