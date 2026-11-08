/****************************
 * ConceptUniqueKey.Auto.cs
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
    /// A unique key index that can be used to uniquely identify objects of a particular type
    /// </summary>
    public partial class ConceptUniqueKey
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptUniqueKey
        /// </summary>
        [Display(Name = "Concept Unique Key Id")]
        [JsonIgnore]
        public int? ConceptUniqueKeyId { get; set; }

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
        [ConceptUniqueKey_AkConceptUniqueKeyConceptIdUniqueKeyName]
        [ConceptUniqueKey_FkConceptUniqueKeyConceptId]
        [JsonIgnore]
        public int? ConceptId { get; set; }

        /// <summary>
        /// The Name value of the Concept
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
        [Display(Name = "Unique Key Name")]
        [MaxLength(200)]
        [ConceptUniqueKey_AkConceptUniqueKeyConceptIdUniqueKeyName]
        public string UniqueKeyName { get; set; }

        /// <summary>
        /// The associated <see cref="Concept" /> object
        /// that is referenced using the <see cref="ConceptId" /> property
        /// </summary>
        [JsonIgnore]
        public Concept Concept { get; set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Concept> UniqueKeyRefs { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptUniqueKeyPropertyFamilyRef" /> objects
        /// </summary>
        public virtual ICollection<ConceptUniqueKeyPropertyFamilyRef> PropertyFamilyRefs { get; set; }

        /// <summary>
        /// Returns a string value to represent the unique identifier for the ConceptUniqueKey
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string PkString
        {
            get
            {
                return 
                    ConceptUniqueKeyId.ToString();
            }
        }

        /// <summary>
        /// Returns a string value to represent the ConceptUniqueKey,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string ValueString
        {
            get
            {
                return UniqueKeyName;
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The associated <see cref="Concept" /> object
        /// that is referenced using the <see cref="ConceptId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept")]
        [NotMapped]
        [ConceptUniqueKey_FkConceptUniqueKeyConceptId]
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
        [ConceptUniqueKey_FkConceptUniqueKeyConceptId]
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
        /// Returns a string value to represent the ConceptUniqueKey,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return UniqueKeyName;
        }

        #endregion
    }
}
