/****************************
 * ConceptPropertyFamily.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Newtonsoft.Json;
using ConceptMeta.JsonConverters;

namespace ConceptMeta.ConceptMetaDb.Entities
{
    /// <summary>
    /// A family of properties
    /// </summary>
    [JsonConverter(typeof(ScalarJsonConverter), "PropertyFamilyName")]
    [DebuggerDisplay("ConceptPropertyFamily: {PropertyFamilyName}")]
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
        public int ConceptPropertyFamilyId { get; set; }

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

        [Required]
        [Display(Name = "Property Family Name")]
        [MaxLength(200)]
        public string PropertyFamilyName { get; set; }

        /// <summary>
        /// Sequence number
        /// </summary>
        [Required]
        [Display(Name = "Seq No")]
        public int SeqNo { get; set; }

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

        #endregion
    }
}
