/****************************
 * ConceptModelDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// A model, made primarily of scalar concepts and object concepts
    /// </summary>
    [DataContract]
    public partial class ConceptModelDto
    {

        #region Instance Properties

        [DataMember]
        public string ModelName { get; set; }

        [DataMember]
        public int? DefaultStringLength { get; set; }

        /// <summary>
        /// The set of child <see cref="DataTypeDto" /> objects
        /// </summary>
        [DataMember]
        public List<DataTypeDto> DataTypes { get; set; }

        /// <summary>
        /// The set of child <see cref="EnumerationDto" /> objects
        /// </summary>
        [DataMember]
        public List<EnumerationDto> Enumerations { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptDto" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptDto> Concepts { get; set; }

        #endregion
    }
}
