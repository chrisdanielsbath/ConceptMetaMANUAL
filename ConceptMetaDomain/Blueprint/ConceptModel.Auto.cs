/****************************
 * ConceptModel.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ConceptMeta.Blueprint
{
    /// <summary>
    /// A model, made primarily of scalar concepts and object concepts
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptModel: {ModelName}")]
    public partial class ConceptModel
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptModel
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods, and wherever the underlying store does not require identifiers for nested objects.
        /// </summary>
        [DataMember]
        public int? ConceptModelId { get; set; }

        [DataMember]
        public string ModelName { get; set; }

        [DataMember]
        public int? DefaultStringLength { get; set; }

        /// <summary>
        /// The set of child <see cref="DataType" /> objects
        /// </summary>
        [DataMember]
        public List<DataType> DataTypes { get; set; }

        /// <summary>
        /// The set of child <see cref="Enumeration" /> objects
        /// </summary>
        [DataMember]
        public List<Enumeration> Enumerations { get; set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [DataMember]
        public List<Concept> Concepts { get; set; }

        #endregion
    }
}
