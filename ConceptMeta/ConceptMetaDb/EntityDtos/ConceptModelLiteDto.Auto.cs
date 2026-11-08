/****************************
 * ConceptModelLiteDto.Auto.cs
 ****************************/
using System;
using System.Runtime.Serialization;

namespace ConceptMeta.ConceptMetaDb.EntityDtos
{
    /// <summary>
    /// A model, made primarily of scalar concepts and object concepts
    /// </summary>
    [DataContract]
    public partial class ConceptModelLiteDto
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptModel
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods.
        /// </summary>
        [DataMember]
        public int? ConceptModelId { get; set; }

        [DataMember]
        public string ModelName { get; set; }

        #endregion
    }
}
