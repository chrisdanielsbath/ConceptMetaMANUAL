/****************************
 * EnumerationDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// A constrained vocabulary
    /// </summary>
    [DataContract]
    public partial class EnumerationDto
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the Enumeration
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods.
        /// </summary>
        [DataMember]
        public int? EnumerationId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [DataMember]
        public int ConceptModelId { get; set; }

        [DataMember]
        public string EnumerationName { get; set; }

        [DataMember]
        public string EnumerationDescription { get; set; }

        /// <summary>
        /// The ID of the DataType
        /// </summary>
        [DataMember]
        public int DataTypeId { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptModelLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptModelLiteDto ConceptModel { get; set; }

        /// <summary>
        /// The associated <see cref="DataTypeLiteDto" /> object
        /// </summary>
        [DataMember]
        public DataTypeLiteDto DataType { get; set; }

        #endregion
    }
}
