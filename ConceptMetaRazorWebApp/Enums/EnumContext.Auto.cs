/****************************
 * EnumContext.Auto.cs
 ****************************/
using ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Definitions;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums
{
    /// <summary>
    /// Context providing access to enumerations within the ConceptMeta model
    /// </summary>
    public partial class EnumContext
    {

        #region Instance Variables
        public BoolSet BoolSet = new BoolSet();
        public EnumSet<BasicDataType> BasicDataTypeSet = new EnumSet<BasicDataType>(new BasicDataTypeDefn());
        public EnumSet<ConceptRefType> ConceptRefTypeSet = new EnumSet<ConceptRefType>(new ConceptRefTypeDefn());
        public EnumSet<ConceptType> ConceptTypeSet = new EnumSet<ConceptType>(new ConceptTypeDefn());
        public EnumSet<ParentOrChildDirection> ParentOrChildDirectionSet = new EnumSet<ParentOrChildDirection>(new ParentOrChildDirectionDefn());
        public EnumSet<PropagatingFieldType> PropagatingFieldTypeSet = new EnumSet<PropagatingFieldType>(new PropagatingFieldTypeDefn());
        public EnumSet<RelationshipType> RelationshipTypeSet = new EnumSet<RelationshipType>(new RelationshipTypeDefn());
        public EnumSet<SelectorType> SelectorTypeSet = new EnumSet<SelectorType>(new SelectorTypeDefn());

        #endregion
    }
}
