/****************************
 * DataTypeLiteDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// A data type
    /// </summary>
    [DataContract]
    public partial class DataTypeLiteDto
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

        /// <summary>
        /// The associated <see cref="ConceptModelLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptModelLiteDto ConceptModel { get; set; }

        #endregion
    }
}
