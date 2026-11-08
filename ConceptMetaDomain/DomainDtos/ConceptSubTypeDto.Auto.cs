/****************************
 * ConceptSubTypeDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// A specialised variety of an entity
    /// </summary>
    [DataContract]
    public partial class ConceptSubTypeDto
    {

        #region Instance Properties

        [DataMember]
        public string SubTypeName { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptSubTypePropertyFamilyRefDto" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptSubTypePropertyFamilyRefDto> PropertyFamilyRefs { get; set; }

        #endregion
    }
}
