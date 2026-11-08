/****************************
 * IConceptMetaDbBlueprintUnitOfWork.Auto.cs
 ****************************/
using ConceptMeta.Common;
using ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Blueprint Unit Of Work interface for the ConceptMeta model
    /// </summary>
    public partial interface IConceptMetaDbBlueprintUnitOfWork
        : IBlueprintUnitOfWork
    {

        #region Instance Properties
        IConceptBlueprintRepository Concepts { get; }
        IConceptModelBlueprintRepository ConceptModels { get; }
        IConceptPropertyFamilyBlueprintRepository ConceptPropertyFamilies { get; }
        IConceptRefBlueprintRepository ConceptRefs { get; }
        IConceptSubTypeBlueprintRepository ConceptSubTypes { get; }
        IConceptSubTypePropertyFamilyRefBlueprintRepository ConceptSubTypePropertyFamilyRefs { get; }
        IConceptUniqueKeyBlueprintRepository ConceptUniqueKeys { get; }
        IConceptUniqueKeyPropertyFamilyRefBlueprintRepository ConceptUniqueKeyPropertyFamilyRefs { get; }
        IDataTypeBlueprintRepository DataTypes { get; }
        IEnumerationBlueprintRepository Enumerations { get; }
        IEnumerationMemberBlueprintRepository EnumerationMembers { get; }
        IIncludeBlueprintRepository Includes { get; }
        IQualifierBlueprintRepository Qualifiers { get; }
        IConceptModelBlueprintAggregateRepository ConceptModelAggregates { get; }

        #endregion
    }
}
