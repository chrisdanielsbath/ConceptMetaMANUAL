/****************************
 * Qualifier.Auto.cs
 ****************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ConceptMeta.JsonConverters;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models.Validators;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models
{
    /// <summary>
    /// A prefix that can be placed before the name of the current entity to specify the role it plays
    /// </summary>
    [JsonConverter(typeof(ScalarJsonConverter), "ItemValue")]
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
        [JsonIgnore]
        public int? QualifierId { get; set; }

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
        [Qualifier_AkQualifierConceptIdItemValue]
        [Qualifier_FkQualifierConceptId]
        [JsonIgnore]
        public int? ConceptId { get; set; }

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
        [Qualifier_AkQualifierConceptIdItemValue]
        public string ItemValue { get; set; }

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
        /// Returns a string value to represent the unique identifier for the Qualifier
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string PkString
        {
            get
            {
                return 
                    QualifierId.ToString();
            }
        }

        /// <summary>
        /// Returns a string value to represent the Qualifier,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string ValueString
        {
            get
            {
                return ItemValue;
            }
        }

        /// <summary>
        /// Returns a string value to represent the unique identifier for The associated <see cref="Concept" /> object
        /// that is referenced using the <see cref="ConceptId" /> property
        /// </summary>
        [Required]
        [Display(Name = "Concept")]
        [NotMapped]
        [Qualifier_FkQualifierConceptId]
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
        [Qualifier_FkQualifierConceptId]
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
        /// Returns a string value to represent the Qualifier,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ItemValue;
        }

        #endregion
    }
}
