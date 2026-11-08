/****************************
 * Qualifier.Auto.cs
 ****************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Newtonsoft.Json;
using ConceptMeta.JsonConverters;

namespace ConceptMeta.ConceptMetaDb.Entities
{
    /// <summary>
    /// A prefix that can be placed before the name of the current entity to specify the role it plays
    /// </summary>
    [JsonConverter(typeof(ScalarJsonConverter), "ItemValue")]
    [DebuggerDisplay("Qualifier: {ItemValue}")]
    public partial class Qualifier
    {

        #region Static Methods

        /// <summary>
        /// Creates a new Qualifier
        /// based on the value of the supplied string
        /// </summary>
        /// <param name="s">A string holding the ItemValue</param>
        /// <returns>the new Qualifier</returns>
        public static Qualifier Parse(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentException("s cannot be null or empty", "s");
            }
            return new Qualifier { ItemValue = s };
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The ID of the Qualifier
        /// </summary>
        [Display(Name = "Qualifier Id")]
        public int QualifierId { get; set; }

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
        /// The ConceptName value for the Concept
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
        [Display(Name = "Item Value")]
        [MaxLength(200)]
        public string ItemValue { get; set; }

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

        #endregion
    }
}
