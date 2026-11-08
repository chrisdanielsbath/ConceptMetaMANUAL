/****************************
 * RelationshipTypeDefn.Auto.cs
 ****************************/
using System.Collections.Generic;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Definitions
{
    /// <summary>
    /// Definition providing information about the <see cref="RelationshipType" /> enumeration
    /// </summary>
    public partial class RelationshipTypeDefn
        : EnumProviderBase<RelationshipType>
    {

        #region Constructors
        public RelationshipTypeDefn()
            : base ()
        {
        }

        #endregion

        #region Instance Methods
        protected override void BuildDictionary()
        {
            Dictionary = new Dictionary<RelationshipType, string>
            {
                { RelationshipType.Reference, "The primary entity contains a reference to the secondary entity" },
                { RelationshipType.ParentChild, "Multiple instances of the secondary entity are nested within the primary entity" },
                { RelationshipType.NestedObject, "Nesting is used to fully describe the single instance of the secondary entity which is referenced by the primary entity" },
                { RelationshipType.DescriptiveReference, "Nesting is used to partially describe the single instance of the secondary entity which is referenced by the primary entity.  The nested item is a \"reference\" which holds more than just an identifier - it also contains some additional information about the referenced object, with the aim of reducing the need for the secondary entity to be fetched separately." },
                { RelationshipType.Subtype, "The secondary entity extends the primary entity, providing additional information that is relevant to a particular of that entity." },
                { RelationshipType.UniqueChild, "A single instance of the secondary entity is nested within the primary entity" },
                { RelationshipType.PassThrough, "The relationship forms part of the path between two entities, but it is not exposed within hierarchical renderings: it is \"collapsed\" or \"passed-through\") ." }
            };
        }

        #endregion
    }
}
