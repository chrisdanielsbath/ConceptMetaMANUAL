/****************************
 * ConceptUniqueKeyPropertyFamilyRefDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// A record that associates a given unique key with a particular family of properties, signifying that the family of properties is relevant to that unique key
    /// </summary>
    [DataContract]
    public partial class ConceptUniqueKeyPropertyFamilyRefDto
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptUniqueKeyPropertyFamilyRef
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods.
        /// </summary>
        [DataMember]
        public int? ConceptUniqueKeyPropertyFamilyRefId { get; set; }

        /// <summary>
        /// The ID of the ConceptUniqueKey
        /// </summary>
        [DataMember]
        public int ConceptUniqueKeyId { get; set; }

        /// <summary>
        /// The ID of the ConceptPropertyFamily
        /// </summary>
        [DataMember]
        public int ConceptPropertyFamilyId { get; set; }

        /// <summary>
        /// Sequence number
        /// </summary>
        [DataMember]
        public int SeqNo { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptUniqueKeyLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptUniqueKeyLiteDto ConceptUniqueKey { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptPropertyFamilyLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptPropertyFamilyLiteDto ConceptPropertyFamily { get; set; }

        #endregion
    }
}
