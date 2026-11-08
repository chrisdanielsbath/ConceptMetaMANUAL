/****************************
 * ConceptModel.Auto.cs
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
    /// A model, made primarily of scalar concepts and object concepts
    /// </summary>
    public partial class ConceptModel
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [Display(Name = "Concept Model Id")]
        [JsonIgnore]
        public int? ConceptModelId { get; set; }

        [Display(Name = "Model Name")]
        [MaxLength(200)]
        [ConceptModel_AkConceptModelModelName]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ModelName { get; set; }

        [Display(Name = "Default String Length")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? DefaultStringLength { get; set; }

        /// <summary>
        /// The set of child <see cref="DataType" /> objects
        /// </summary>
        public virtual ICollection<DataType> DataTypes { get; set; }

        /// <summary>
        /// The set of child <see cref="Enumeration" /> objects
        /// </summary>
        public virtual ICollection<Enumeration> Enumerations { get; set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        public virtual ICollection<Concept> Concepts { get; set; }

        /// <summary>
        /// Returns a string value to represent the unique identifier for the ConceptModel
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string PkString
        {
            get
            {
                return 
                    ConceptModelId.ToString();
            }
        }

        /// <summary>
        /// Returns a string value to represent the ConceptModel,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string ValueString
        {
            get
            {
                return ModelName;
            }
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the ConceptModel,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ModelName;
        }

        #endregion
    }
}
