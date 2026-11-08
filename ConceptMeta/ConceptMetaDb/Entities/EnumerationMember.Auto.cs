/****************************
 * EnumerationMember.Auto.cs
 ****************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ConceptMeta.ConceptMetaDb.Entities
{
    /// <summary>
    /// An item within a constrained vocabulary
    /// </summary>
    [DebuggerDisplay("EnumerationMember: {EnumeratedValue}")]
    public partial class EnumerationMember
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the EnumerationMember
        /// </summary>
        [Display(Name = "Enumeration Member Id")]
        public int EnumerationMemberId { get; set; }

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
        [JsonIgnore]
        public int EnumerationId { get; set; }

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

        #endregion
    }
}
