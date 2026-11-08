/****************************
 * ConceptSubTypePropertyFamilyRef.Auto.cs
 ****************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models
{
    /// <summary>
    /// A record which associates a given sub type with a particular family of properties, signifying that the family is relevant to that sub type
    /// </summary>
    public partial class ConceptSubTypePropertyFamilyRef
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptSubTypePropertyFamilyRef
        /// </summary>
        [Display(Name = "Concept Sub Type Property Family Ref Id")]
        [JsonIgnore]
        public int? ConceptSubTypePropertyFamilyRefId { get; set; }

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
                return ConceptSubType?.Concept?.ConceptModelId;
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
                return ConceptSubType?.Concept?.ConceptModel?.ModelName;
            }
        }

        /// <summary>
        /// The ID of the Concept
        /// </summary>
        [NotMapped]
        [Display(Name = "Concept Id")]
        [JsonIgnore]
        public int? ConceptId
        {
            get
            {
                return ConceptSubType?.ConceptId;
            }
        }

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
                return ConceptSubType?.Concept?.ConceptName;
            }
        }

        /// <summary>
        /// The ID of the ConceptSubType
        /// </summary>
        [Required]
        [Display(Name = "Concept Sub Type Id")]
        [ConceptSubTypePropertyFamilyRef_AkConceptSubTypePropertyFamilyRefConceptSubTypeIdConceptPropertyFamilyId]
        [ConceptSubTypePropertyFamilyRef_FkConceptSubTypePropertyFamilyRefConceptSubTypeId]
        [JsonIgnore]
        public int? ConceptSubTypeId { get; set; }

        /// <summary>
        /// The SubTypeName value for the ConceptSubType
        /// </summary>
        [NotMapped]
        [Display(Name = "Sub Type Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string SubTypeName
        {
            get
            {
                return ConceptSubType?.SubTypeName;
            }
        }

        /// <summary>
        /// The ID of the ConceptPropertyFamily
        /// </summary>
        [Required]
        [Display(Name = "Concept Property Family Id")]
        [ConceptSubTypePropertyFamilyRef_AkConceptSubTypePropertyFamilyRefConceptSubTypeIdConceptPropertyFamilyId]
        [ConceptSubTypePropertyFamilyRef_FkConceptSubTypePropertyFamilyRefConceptPropertyFamilyId]
        [JsonIgnore]
        public int? ConceptPropertyFamilyId { get; set; }

        /// <summary>
        /// The business-facing identifier for the ConceptPropertyFamily
        /// </summary>
        [NotMapped]
        [Display(Name = "Property Family Name")]
        [MaxLength(200)]
        public string PropertyFamilyName
        {
            get
            {
                return ConceptPropertyFamily?.PropertyFamilyName;
            }
        }

        /// <summary>
        /// Sequence number
        /// </summary>
        [Required]
        [Display(Name = "Seq No")]
        [JsonIgnore]
        public int? SeqNo { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptSubType" /> object
        /// that is referenced using the <see cref="ConceptSubTypeId" /> property
        /// </summary>
        [JsonIgnore]
        public ConceptSubType ConceptSubType { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptPropertyFamily" /> object
        /// that is referenced using the <see cref="ConceptPropertyFamilyId" /> property
        /// </summary>
        [JsonIgnore]
        public ConceptPropertyFamily ConceptPropertyFamily { get; set; }

        /// <summary>
        /// Returns a string value to represent the unique identifier for the ConceptSubTypePropertyFamilyRef
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string PkString
        {
            get
            {
                return 
                    ConceptSubTypePropertyFamilyRefId.ToString();
            }
        }

        /// <summary>
        /// Returns a string value to represent the ConceptSubTypePropertyFamilyRef,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string ValueString
        {
            get
            {
                return PropertyFamilyName;
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The associated <see cref="ConceptSubType" /> object
        /// that is referenced using the <see cref="ConceptSubTypeId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept Sub Type")]
        [NotMapped]
        [ConceptSubTypePropertyFamilyRef_FkConceptSubTypePropertyFamilyRefConceptSubTypeId]
        [JsonIgnore]
        public string ConceptSubTypeKeyString
        {
            get
            {
                if ((ConceptSubTypeId == null))
                {
                    return "";
                }
                else
                {
                    return ConceptSubTypeId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    ConceptSubTypeId = null;
                }
                else
                {
                    ConceptSubTypeId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The associated <see cref="ConceptPropertyFamily" /> object
        /// that is referenced using the <see cref="ConceptPropertyFamilyId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept Property Family")]
        [NotMapped]
        [ConceptSubTypePropertyFamilyRef_FkConceptSubTypePropertyFamilyRefConceptPropertyFamilyId]
        [JsonIgnore]
        public string ConceptPropertyFamilyKeyString
        {
            get
            {
                if ((ConceptPropertyFamilyId == null))
                {
                    return "";
                }
                else
                {
                    return ConceptPropertyFamilyId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    ConceptPropertyFamilyId = null;
                }
                else
                {
                    ConceptPropertyFamilyId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The associated <see cref="ConceptSubType" /> object
        /// that is referenced using the <see cref="ConceptSubTypeId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept Sub Type")]
        [NotMapped]
        [ConceptSubTypePropertyFamilyRef_FkConceptSubTypePropertyFamilyRefConceptSubTypeId]
        [JsonIgnore]
        public string ConceptSubTypeValueString
        {
            get
            {
                if (ConceptSubType == null)
                {
                    if (ConceptSubTypeKeyString != "")
                    {
                        return "ConceptSubType " + ConceptSubTypeKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return ConceptSubType.ToString();
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The associated <see cref="ConceptPropertyFamily" /> object
        /// that is referenced using the <see cref="ConceptPropertyFamilyId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept Property Family")]
        [NotMapped]
        [ConceptSubTypePropertyFamilyRef_FkConceptSubTypePropertyFamilyRefConceptPropertyFamilyId]
        [JsonIgnore]
        public string ConceptPropertyFamilyValueString
        {
            get
            {
                if (ConceptPropertyFamily == null)
                {
                    if (ConceptPropertyFamilyKeyString != "")
                    {
                        return "ConceptPropertyFamily " + ConceptPropertyFamilyKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return ConceptPropertyFamily.ToString();
                }
            }
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the ConceptSubTypePropertyFamilyRef,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return PropertyFamilyName;
        }

        #endregion
    }
}
