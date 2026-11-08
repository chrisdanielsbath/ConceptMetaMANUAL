/****************************
 * DataType.Auto.cs
 ****************************/
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ConceptMeta.Blueprint
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
        /// The ID of the DataType
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods, and wherever the underlying store does not require identifiers for nested objects.
        /// </summary>
        [DataMember]
        public int? DataTypeId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [DataMember]
        public int? ConceptModelId { get; set; }

        /// <summary>
        /// The ModelName value for the ConceptModel
        /// </summary>
        [DataMember]
        public string ModelName { get; set; }

        [DataMember]
        public string DataTypeName { get; set; }

        [DataMember]
        public string SqlServerDataType { get; set; }

        [DataMember]
        public string OracleDataType { get; set; }

        [DataMember]
        public string MySqlDataType { get; set; }

        [DataMember]
        public string MongoDbDataType { get; set; }

        [DataMember]
        public string DotNetDataType { get; set; }

        [DataMember]
        public string JavaDataType { get; set; }

        [DataMember]
        public string XmlDataType { get; set; }

        [DataMember]
        public string ExampleValueAsString { get; set; }

        [DataMember]
        public string JsonDataType { get; set; }

        [DataMember]
        public string JsonFormat { get; set; }

        [DataMember]
        public string OpenApiDataType { get; set; }

        [DataMember]
        public string OpenApiFormat { get; set; }

        [DataMember]
        public string ErsDataType { get; set; }

        [DataMember]
        public string BasicDataType { get; set; }

        [DataMember]
        public int? MinLength { get; set; }

        [DataMember]
        public int? MaxLength { get; set; }

        [DataMember]
        public decimal? MinValue { get; set; }

        [DataMember]
        public decimal? MaxValue { get; set; }

        [DataMember]
        public int? TotalDigits { get; set; }

        [DataMember]
        public int? DecimalPlaces { get; set; }

        [DataMember]
        public int? DatePrecision { get; set; }

        [DataMember]
        public bool? HasLength { get; set; }

        [DataMember]
        public bool? HasTotalDigits { get; set; }

        [DataMember]
        public bool? HasDecimalPlaces { get; set; }

        [DataMember]
        public bool? HasIdentity { get; set; }

        [DataMember]
        public bool? HasDatePrecision { get; set; }

        #endregion
    }
}
