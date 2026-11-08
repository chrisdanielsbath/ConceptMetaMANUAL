/****************************
 * ConceptSubTypePropertyFamilyRefDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// A record which associates a given sub type with a particular family of properties, signifying that the family is relevant to that sub type
    /// </summary>
    [DataContract]
    public partial class ConceptSubTypePropertyFamilyRefDto
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptSubTypePropertyFamilyRef
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods.
        /// </summary>
        [DataMember]
        public int? ConceptSubTypePropertyFamilyRefId { get; set; }

        /// <summary>
        /// The ID of the ConceptSubType
        /// </summary>
        [DataMember]
        public int ConceptSubTypeId { get; set; }

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
        /// The associated <see cref="ConceptSubTypeLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptSubTypeLiteDto ConceptSubType { get; set; }

        /// <summary>
        /// The associated <see cref="ConceptPropertyFamilyLiteDto" /> object
        /// </summary>
        [DataMember]
        public ConceptPropertyFamilyLiteDto ConceptPropertyFamily { get; set; }

        #endregion
    }
}
