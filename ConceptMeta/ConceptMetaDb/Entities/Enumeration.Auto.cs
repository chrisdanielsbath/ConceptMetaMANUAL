/****************************
 * Enumeration.Auto.cs
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
    /// A constrained vocabulary
    /// </summary>
    [DebuggerDisplay("Enumeration: {EnumerationName}")]
    public partial class Enumeration
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the Enumeration
        /// </summary>
        [Display(Name = "Enumeration Id")]
        public int EnumerationId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [Required]
        [Display(Name = "Concept Model Id")]
        [JsonIgnore]
        public int ConceptModelId { get; set; }

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
                return ConceptModel?.ModelName;
            }
        }

        [Display(Name = "Enumeration Name")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EnumerationName { get; set; }

        [Display(Name = "Enumeration Description")]
        [MaxLength(500)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EnumerationDescription { get; set; }

        /// <summary>
        /// The ID of the DataType
        /// </summary>
        [Required]
        [Display(Name = "Data Type Id")]
        public int DataTypeId { get; set; }

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
                return DataType?.DataTypeName;
            }
        }

        /// <summary>
        /// The associated <see cref="ConceptModel" /> object
        /// that is referenced using the <see cref="ConceptModelId" /> property
        /// </summary>
        [JsonIgnore]
        public ConceptModel ConceptModel { get; set; }

        /// <summary>
        /// The associated <see cref="DataType" /> object
        /// that is referenced using the <see cref="DataTypeId" /> property
        /// </summary>
        [JsonIgnore]
        public DataType DataType { get; set; }

        /// <summary>
        /// The set of child <see cref="EnumerationMember" /> objects
        /// </summary>
        public virtual ICollection<EnumerationMember> EnumeratedValues { get; set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Concept> Concepts { get; set; }

        #endregion
    }
}
