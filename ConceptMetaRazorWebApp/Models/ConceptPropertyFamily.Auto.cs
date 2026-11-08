/****************************
 * ConceptPropertyFamily.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ConceptMeta.JsonConverters;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models
{
    /// <summary>
    /// A family of properties
    /// </summary>
    [JsonConverter(typeof(ScalarJsonConverter), "PropertyFamilyName")]
    public partial class ConceptPropertyFamily
    {

        #region Static Methods

        /// <summary>
        /// Creates a new ConceptPropertyFamily
        /// based on the value of the supplied string
        /// </summary>
        /// <param name="s">A string holding the PropertyFamilyName</param>
        /// <returns>the new ConceptPropertyFamily</returns>
        public static ConceptPropertyFamily Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentException("s cannot be null or empty", "s");
            }
            return new ConceptPropertyFamily { PropertyFamilyName = s };
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptPropertyFamily
        /// </summary>
        [Display(Name = "Concept Property Family Id")]
        [JsonIgnore]
        public int? ConceptPropertyFamilyId { get; set; }

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
        [ConceptPropertyFamily_AkConceptPropertyFamilyConceptIdPropertyFamilyName]
        [ConceptPropertyFamily_FkConceptPropertyFamilyConceptId]
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
        [Display(Name = "Property Family Name")]
        [MaxLength(200)]
        [ConceptPropertyFamily_AkConceptPropertyFamilyConceptIdPropertyFamilyName]
        public string PropertyFamilyName { get; set; }

        /// <summary>
        /// Sequence number
        /// </summary>
        [Required]
        [Display(Name = "Seq No")]
        [JsonIgnore]
        public int? SeqNo { get; set; }

        /// <summary>
        /// The associated <see cref="Concept" /> object
        /// that is referenced using the <see cref="ConceptId" /> property
        /// </summary>
        [JsonIgnore]
        public Concept Concept { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptRef" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<ConceptRef> Properties { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptSubTypePropertyFamilyRef" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<ConceptSubTypePropertyFamilyRef> PropertyFamilyRefs { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptUniqueKeyPropertyFamilyRef" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<ConceptUniqueKeyPropertyFamilyRef> UniqueKeyPropertyFamilyRefs { get; set; }

        /// <summary>
        /// Returns a string value to represent the unique identifier for the ConceptPropertyFamily
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string PkString
        {
            get
            {
                return 
                    ConceptPropertyFamilyId.ToString();
            }
        }

        /// <summary>
        /// Returns a string value to represent the ConceptPropertyFamily,
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
        /// Returns a string value to represent the unique identifier for The associated <see cref="Concept" /> object
        /// that is referenced using the <see cref="ConceptId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept")]
        [NotMapped]
        [ConceptPropertyFamily_FkConceptPropertyFamilyConceptId]
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
        [ConceptPropertyFamily_FkConceptPropertyFamilyConceptId]
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
        /// Returns a string value to represent the ConceptPropertyFamily,
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
