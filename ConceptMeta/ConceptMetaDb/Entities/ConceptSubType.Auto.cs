/****************************
 * ConceptSubType.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ConceptMeta.ConceptMetaDb.Entities
{
    /// <summary>
    /// A specialised variety of an entity
    /// </summary>
    [DebuggerDisplay("ConceptSubType: {SubTypeName}")]
    public partial class ConceptSubType
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptSubType
        /// </summary>
        [Display(Name = "Concept Sub Type Id")]
        public int ConceptSubTypeId { get; set; }

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
        [Display(Name = "Sub Type Name")]
        [MaxLength(200)]
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

        #endregion
    }
}
