/****************************
 * EnumerationDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// A constrained vocabulary
    /// </summary>
    [DataContract]
    public partial class EnumerationDto
    {

        #region Instance Properties

        [DataMember]
        public string EnumerationName { get; set; }

        [DataMember]
        public string EnumerationDescription { get; set; }

        /// <summary>
        /// The DataTypeName value for the DataType
        /// </summary>
        [DataMember]
        public string DataTypeName { get; set; }

        /// <summary>
        /// The set of child <see cref="EnumerationMemberDto" /> objects
        /// </summary>
        [DataMember]
        public List<EnumerationMemberDto> EnumeratedValues { get; set; }

        #endregion
    }
}
