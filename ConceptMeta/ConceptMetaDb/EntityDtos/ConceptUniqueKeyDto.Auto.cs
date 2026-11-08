/****************************
 * ConceptUniqueKeyDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// A unique key index that can be used to uniquely identify objects of a particular type
    /// </summary>
    [DataContract]
    public partial class ConceptUniqueKeyDto
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptUniqueKey
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods.
        /// </summary>
        [DataMember]
        public int? ConceptUniqueKeyId { get; set; }

        /// <summary>
        /// The ID of the Concept
        /// </summary>
        [DataMember]
        public int ConceptId { get; set; }

        [DataMember]
        public string UniqueKeyName { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptLiteDto Concept { get; set; }

        #endregion
    }
}
