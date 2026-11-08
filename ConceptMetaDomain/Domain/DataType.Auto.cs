/****************************
 * DataType.Auto.cs
 ****************************/
using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ConceptMeta.DomainRegistryClasses;

namespace ConceptMeta.Domain
{
    /// <summary>
    /// A data type
    /// </summary>
    [DataContract]
    [DebuggerDisplay("DataType: {DataTypeName}")]
    public partial class DataType
    {

        #region Instance Properties

        /// <summary>
        /// The ModelName value for the ConceptModel
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [JsonIgnore]
        [DataMember]
        public string ModelName { get; set; }

        [DataMember]
        public string DataTypeName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string SqlServerDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string OracleDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string MySqlDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string MongoDbDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string DotNetDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string JavaDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string XmlDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ExampleValueAsString { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string JsonDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string JsonFormat { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string OpenApiDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string OpenApiFormat { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ErsDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string BasicDataType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? MinLength { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? MaxLength { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public decimal? MinValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public decimal? MaxValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? TotalDigits { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? DecimalPlaces { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? DatePrecision { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? HasLength { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? HasTotalDigits { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? HasDecimalPlaces { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? HasIdentity { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public bool? HasDatePrecision { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the DataType,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DataTypeName;
        }

        /// <summary>
        /// Links the DataType to the parent ConceptModel and recurses in order to link up child objects similarly
        /// </summary>
        /// <param name="conceptModel"></param>
        public void Fixup(ConceptModel conceptModel)
        {
            ConceptModel = conceptModel;
            ConceptModelRegistry = conceptModel.ConceptModelRegistry;
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the ConceptModel
        /// </summary>
        internal ConceptModelRegistry ConceptModelRegistry { get; private set; }

        /// <summary>
        /// The associated <see cref="ConceptModel" /> object
        /// </summary>
        [JsonIgnore]
        public ConceptModel ConceptModel { get; private set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<Concept> Concepts => ConceptModelRegistry
            .GetConceptsByDataTypeName(DataTypeName);

        /// <summary>
        /// The set of child <see cref="Enumeration" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<Enumeration> Enumerations => ConceptModelRegistry
            .GetEnumerationsByDataTypeName(DataTypeName);

        #endregion
    }
}
