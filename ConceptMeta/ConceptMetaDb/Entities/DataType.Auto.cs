/****************************
 * DataType.Auto.cs
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
    /// A data type
    /// </summary>
    [DebuggerDisplay("DataType: {DataTypeName}")]
    public partial class DataType
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the DataType
        /// </summary>
        [Display(Name = "Data Type Id")]
        public int DataTypeId { get; set; }

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

        [Required]
        [Display(Name = "Data Type Name")]
        [MaxLength(200)]
        public string DataTypeName { get; set; }

        [Display(Name = "Sql Server Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SqlServerDataType { get; set; }

        [Display(Name = "Oracle Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string OracleDataType { get; set; }

        [Display(Name = "My Sql Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MySqlDataType { get; set; }

        [Display(Name = "Mongo Db Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MongoDbDataType { get; set; }

        [Display(Name = "Dot Net Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DotNetDataType { get; set; }

        [Display(Name = "Java Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string JavaDataType { get; set; }

        [Display(Name = "Xml Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string XmlDataType { get; set; }

        [Display(Name = "Example Value As String")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExampleValueAsString { get; set; }

        [Display(Name = "Json Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string JsonDataType { get; set; }

        [Display(Name = "Json Format")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string JsonFormat { get; set; }

        [Display(Name = "Open Api Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string OpenApiDataType { get; set; }

        [Display(Name = "Open Api Format")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string OpenApiFormat { get; set; }

        [Display(Name = "Ers Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErsDataType { get; set; }

        [Display(Name = "Basic Data Type")]
        [MaxLength(200)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BasicDataType { get; set; }

        [Display(Name = "Min Length")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MinLength { get; set; }

        [Display(Name = "Max Length")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxLength { get; set; }

        [Display(Name = "Min Value")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MinValue { get; set; }

        [Display(Name = "Max Value")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MaxValue { get; set; }

        [Display(Name = "Total Digits")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? TotalDigits { get; set; }

        [Display(Name = "Decimal Places")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? DecimalPlaces { get; set; }

        [Display(Name = "Date Precision")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? DatePrecision { get; set; }

        [Display(Name = "Has Length")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasLength { get; set; }

        [Display(Name = "Has Total Digits")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasTotalDigits { get; set; }

        [Display(Name = "Has Decimal Places")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasDecimalPlaces { get; set; }

        [Display(Name = "Has Identity")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasIdentity { get; set; }

        [Display(Name = "Has Date Precision")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasDatePrecision { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptModel" /> object
        /// that is referenced using the <see cref="ConceptModelId" /> property
        /// </summary>
        [JsonIgnore]
        public ConceptModel ConceptModel { get; set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Concept> Concepts { get; set; }

        /// <summary>
        /// The set of child <see cref="Enumeration" /> objects
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Enumeration> Enumerations { get; set; }

        #endregion
    }
}
