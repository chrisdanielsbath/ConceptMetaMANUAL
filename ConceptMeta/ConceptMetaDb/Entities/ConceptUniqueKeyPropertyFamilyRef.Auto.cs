/****************************
 * ConceptUniqueKeyPropertyFamilyRef.Auto.cs
 ****************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ConceptMeta.ConceptMetaDb.Entities
{
    /// <summary>
    /// A record that associates a given unique key with a particular family of properties, signifying that the family of properties is relevant to that unique key
    /// </summary>
    [DebuggerDisplay("ConceptUniqueKeyPropertyFamilyRef: {PropertyFamilyName}")]
    public partial class ConceptUniqueKeyPropertyFamilyRef
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptUniqueKeyPropertyFamilyRef
        /// </summary>
        [Display(Name = "Concept Unique Key Property Family Ref Id")]
        public int ConceptUniqueKeyPropertyFamilyRefId { get; set; }

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
        [JsonIgnore]
        public int ConceptUniqueKeyId { get; set; }

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
        public int ConceptPropertyFamilyId { get; set; }

        /// <summary>
        /// The business-facing identifier for the ConceptPropertyFamily
        /// </summary>
        [NotMapped]
        [Display(Name = "Property Family Name")]
        [MaxLength(200)]
        [JsonIgnore]
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
        public int SeqNo { get; set; }

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

        #endregion
    }
}
