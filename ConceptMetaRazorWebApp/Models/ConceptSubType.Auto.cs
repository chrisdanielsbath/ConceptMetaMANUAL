/****************************
 * ConceptSubType.Auto.cs
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
    /// A specialised variety of an entity
    /// </summary>
    public partial class ConceptSubType
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptSubType
        /// </summary>
        [Display(Name = "Concept Sub Type Id")]
        [JsonIgnore]
        public int? ConceptSubTypeId { get; set; }

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
        [ConceptSubType_AkConceptSubTypeConceptIdSubTypeName]
        [ConceptSubType_FkConceptSubTypeConceptId]
        [JsonIgnore]
        public int? ConceptId { get; set; }

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

        [Required]
        [Display(Name = "Sub Type Name")]
        [MaxLength(200)]
        [ConceptSubType_AkConceptSubTypeConceptIdSubTypeName]
        public string SubTypeName { get; set; }

        /// <summary>
        /// The associated <see cref="Concept" /> object
        /// that is referenced using the <see cref="ConceptId" /> property
        /// </summary>
        [JsonIgnore]
        public Concept Concept { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptSubTypePropertyFamilyRef" /> objects
        /// </summary>
        public virtual ICollection<ConceptSubTypePropertyFamilyRef> PropertyFamilyRefs { get; set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Concept> SubTypeRefs { get; set; }

        /// <summary>
        /// Returns a string value to represent the unique identifier for the ConceptSubType
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string PkString
        {
            get
            {
                return 
                    ConceptSubTypeId.ToString();
            }
        }

        /// <summary>
        /// Returns a string value to represent the ConceptSubType,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string ValueString
        {
            get
            {
                return SubTypeName;
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The associated <see cref="Concept" /> object
        /// that is referenced using the <see cref="ConceptId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept")]
        [NotMapped]
        [ConceptSubType_FkConceptSubTypeConceptId]
        [JsonIgnore]
        public string ConceptKeyString
        {
            get
            {
                if ((ConceptId == null))
                {
                    return "";
                }
                else
                {
                    return ConceptId.ToString();
                }
            }
            set
            {
                if (value == null)
                {
                    ConceptId = null;
                }
                else
                {
                    ConceptId = (value == "" ? null : int.Parse(value));
                }
            }
        }

        /// <summary>
        /// Returns a string value to represent The associated <see cref="Concept" /> object
        /// that is referenced using the <see cref="ConceptId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept")]
        [NotMapped]
        [ConceptSubType_FkConceptSubTypeConceptId]
        [JsonIgnore]
        public string ConceptValueString
        {
            get
            {
                if (Concept == null)
                {
                    if (ConceptKeyString != "")
                    {
                        return "Concept " + ConceptKeyString;
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return Concept.ToString();
                }
            }
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the ConceptSubType,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return SubTypeName;
        }

        #endregion
    }
}
