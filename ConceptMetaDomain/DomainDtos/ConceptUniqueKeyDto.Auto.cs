/****************************
 * ConceptUniqueKeyDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ConceptMeta.DomainDtos
{
    /// <summary>
    /// A unique key index that can be used to uniquely identify objects of a particular type
    /// </summary>
    [DataContract]
    public partial class ConceptUniqueKeyDto
    {

        #region Instance Properties

        [DataMember]
        public string UniqueKeyName { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptUniqueKeyPropertyFamilyRefDto" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptUniqueKeyPropertyFamilyRefDto> PropertyFamilyRefs { get; set; }

        #endregion
    }
}
