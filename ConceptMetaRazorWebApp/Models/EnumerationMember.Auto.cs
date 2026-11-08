/****************************
 * EnumerationMember.Auto.cs
 ****************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models
{
    /// <summary>
    /// An item within a constrained vocabulary
    /// </summary>
    public partial class EnumerationMember
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the EnumerationMember
        /// </summary>
        [Display(Name = "Enumeration Member Id")]
        [JsonIgnore]
        public int? EnumerationMemberId { get; set; }

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
                return Enumeration?.ConceptModelId;
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
                return Enumeration?.ConceptModel?.ModelName;
            }
        }

        /// <summary>
        /// The ID of the DataType
        /// </summary>
        [NotMapped]
        [Display(Name = "Data Type Id")]
        [JsonIgnore]
        public int? DataTypeId
        {
            get
            {
                return Enumeration?.DataTypeId;
            }
        }

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
                return Enumeration?.DataType?.DataTypeName;
            }
        }

        /// <summary>
        /// The ID of the Enumeration
        /// </summary>
        [Required]
        [Display(Name = "Enumeration Id")]
        [EnumerationMember_AkEnumerationMemberEnumerationIdEnumeratedValue]
        [EnumerationMember_FkEnumerationMemberEnumerationId]
        [JsonIgnore]
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

        [Required]
        [Display(Name = "Enumerated Value")]
        [MaxLength(200)]
        [EnumerationMember_AkEnumerationMemberEnumerationIdEnumeratedValue]
        public string EnumeratedValue { get; set; }

        [Display(Name = "Enumerated Value Description")]
        [MaxLength(500)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EnumeratedValueDescription { get; set; }

        /// <summary>
        /// The associated <see cref="Enumeration" /> object
        /// that is referenced using the <see cref="EnumerationId" /> property
        /// </summary>
        [JsonIgnore]
        public Enumeration Enumeration { get; set; }

        /// <summary>
        /// Returns a string value to represent the unique identifier for the EnumerationMember
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string PkString
        {
            get
            {
                return 
                    EnumerationMemberId.ToString();
            }
        }

        /// <summary>
        /// Returns a string value to represent the EnumerationMember,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string ValueString
        {
            get
            {
                return EnumeratedValue;
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The associated <see cref="Enumeration" /> object
        /// that is referenced using the <see cref="EnumerationId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Enumeration")]
        [NotMapped]
        [EnumerationMember_FkEnumerationMemberEnumerationId]
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
        /// Returns a string value to represent The associated <see cref="Enumeration" /> object
        /// that is referenced using the <see cref="EnumerationId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Enumeration")]
        [NotMapped]
        [EnumerationMember_FkEnumerationMemberEnumerationId]
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

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the EnumerationMember,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return EnumeratedValue;
        }

        #endregion
    }
}
