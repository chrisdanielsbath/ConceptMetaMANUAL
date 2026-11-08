/****************************
 * ConceptModel.Auto.cs
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
    /// A model, made primarily of scalar concepts and object concepts
    /// </summary>
    [DebuggerDisplay("ConceptModel: {ModelName}")]
    public partial class ConceptModel
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [Display(Name = "Concept Model Id")]
        public int ConceptModelId { get; set; }

        [Display(Name = "Model Name")]
        [MaxLength(200)]
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

        #endregion
    }
}
