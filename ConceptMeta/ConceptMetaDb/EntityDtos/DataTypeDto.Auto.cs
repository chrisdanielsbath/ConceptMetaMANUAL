/****************************
 * DataTypeDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// A data type
    /// </summary>
    [DataContract]
    public partial class DataTypeDto
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the DataType
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods.
        /// </summary>
        [DataMember]
        public int? DataTypeId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [DataMember]
        public int ConceptModelId { get; set; }

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

        /// <summary>
        /// The associated <see cref="ConceptModelLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptModelLiteDto ConceptModel { get; set; }

        #endregion
    }
}
