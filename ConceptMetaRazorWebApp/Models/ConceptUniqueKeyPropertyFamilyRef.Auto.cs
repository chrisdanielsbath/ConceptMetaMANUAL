/****************************
 * ConceptUniqueKeyPropertyFamilyRef.Auto.cs
 ****************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models
{
    /// <summary>
    /// A record that associates a given unique key with a particular family of properties, signifying that the family of properties is relevant to that unique key
    /// </summary>
    public partial class ConceptUniqueKeyPropertyFamilyRef
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptUniqueKeyPropertyFamilyRef
        /// </summary>
        [Display(Name = "Concept Unique Key Property Family Ref Id")]
        [JsonIgnore]
        public int? ConceptUniqueKeyPropertyFamilyRefId { get; set; }

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
                return ConceptUniqueKey?.Concept?.ConceptModelId;
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
                return ConceptUniqueKey?.Concept?.ConceptModel?.ModelName;
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
                return ConceptUniqueKey?.ConceptId;
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
                return ConceptUniqueKey?.Concept?.ConceptName;
            }
        }

        /// <summary>
        /// The ID of the ConceptUniqueKey
        /// </summary>
        [Required]
        [Display(Name = "Concept Unique Key Id")]
        [ConceptUniqueKeyPropertyFamilyRef_AkConceptUniqueKeyPropertyFamilyRefConceptUniqueKeyIdConceptPropertyFamilyId]
        [ConceptUniqueKeyPropertyFamilyRef_FkConceptUniqueKeyPropertyFamilyRefConceptUniqueKeyId]
        [JsonIgnore]
        public int? ConceptUniqueKeyId { get; set; }

        /// <summary>
        /// The UniqueKeyName value for the ConceptUniqueKey
        /// </summary>
        [NotMapped]
        [Display(Name = "Unique Key Name")]
        [MaxLength(200)]
        [JsonIgnore]
        public string UniqueKeyName
        {
            get
            {
                return ConceptUniqueKey?.UniqueKeyName;
            }
        }

        /// <summary>
        /// The ID of the ConceptPropertyFamily
        /// </summary>
        [Required]
        [Display(Name = "Concept Property Family Id")]
        [ConceptUniqueKeyPropertyFamilyRef_AkConceptUniqueKeyPropertyFamilyRefConceptUniqueKeyIdConceptPropertyFamilyId]
        [ConceptUniqueKeyPropertyFamilyRef_FkConceptUniqueKeyPropertyFamilyRefConceptPropertyFamilyId]
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
        /// The associated <see cref="ConceptUniqueKey" /> object
        /// that is referenced using the <see cref="ConceptUniqueKeyId" /> property
        /// </summary>
        [JsonIgnore]
        public ConceptUniqueKey ConceptUniqueKey { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptPropertyFamily" /> object
        /// that is referenced using the <see cref="ConceptPropertyFamilyId" /> property
        /// </summary>
        [JsonIgnore]
        public ConceptPropertyFamily ConceptPropertyFamily { get; set; }

        /// <summary>
        /// Returns a string value to represent the unique identifier for the ConceptUniqueKeyPropertyFamilyRef
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string PkString
        {
            get
            {
                return 
                    ConceptUniqueKeyPropertyFamilyRefId.ToString();
            }
        }

        /// <summary>
        /// Returns a string value to represent the ConceptUniqueKeyPropertyFamilyRef,
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
        /// Returns a string value to represent the unique identifier for The associated <see cref="ConceptUniqueKey" /> object
        /// that is referenced using the <see cref="ConceptUniqueKeyId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept Unique Key")]
        [NotMapped]
        [ConceptUniqueKeyPropertyFamilyRef_FkConceptUniqueKeyPropertyFamilyRefConceptUniqueKeyId]
        [JsonIgnore]
        public string ConceptUniqueKeyKeyString
        {
            get
            {
                if ((ConceptUniqueKeyId == null))
                {
                    return "";
                }
                else
                {
                    return ConceptUniqueKeyId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    ConceptUniqueKeyId = null;
                }
                else
                {
                    ConceptUniqueKeyId = (value == "" ? null : int.Parse(value));
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
        [ConceptUniqueKeyPropertyFamilyRef_FkConceptUniqueKeyPropertyFamilyRefConceptPropertyFamilyId]
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
        /// Returns a string value to represent The associated <see cref="ConceptUniqueKey" /> object
        /// that is referenced using the <see cref="ConceptUniqueKeyId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept Unique Key")]
        [NotMapped]
        [ConceptUniqueKeyPropertyFamilyRef_FkConceptUniqueKeyPropertyFamilyRefConceptUniqueKeyId]
        [JsonIgnore]
        public string ConceptUniqueKeyValueString
        {
            get
            {
                if (ConceptUniqueKey == null)
                {
                    if (ConceptUniqueKeyKeyString != "")
                    {
                        return "ConceptUniqueKey " + ConceptUniqueKeyKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return ConceptUniqueKey.ToString();
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
        [ConceptUniqueKeyPropertyFamilyRef_FkConceptUniqueKeyPropertyFamilyRefConceptPropertyFamilyId]
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
        /// Returns a string value to represent the ConceptUniqueKeyPropertyFamilyRef,
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
