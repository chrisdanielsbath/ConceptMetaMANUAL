/****************************
 * ConceptSubTypePropertyFamilyRef.Auto.cs
 ****************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ConceptMeta.ConceptMetaDb.Entities
{
    /// <summary>
    /// A record which associates a given sub type with a particular family of properties, signifying that the family is relevant to that sub type
    /// </summary>
    [DebuggerDisplay("ConceptSubTypePropertyFamilyRef: {PropertyFamilyName}")]
    public partial class ConceptSubTypePropertyFamilyRef
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptSubTypePropertyFamilyRef
        /// </summary>
        [Display(Name = "Concept Sub Type Property Family Ref Id")]
        public int ConceptSubTypePropertyFamilyRefId { get; set; }

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
        [JsonIgnore]
        public int ConceptSubTypeId { get; set; }

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

        #endregion
    }
}
