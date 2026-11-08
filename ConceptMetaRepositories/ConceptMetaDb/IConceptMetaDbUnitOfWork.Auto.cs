/****************************
 * IConceptMetaDbUnitOfWork.Auto.cs
 ****************************/
using ConceptMeta.Common;
using ConceptMeta.ConceptMetaDb.RepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Unit Of Work interface for the ConceptMeta model
    /// </summary>
    public partial interface IConceptMetaDbUnitOfWork
        : ITransactionalUnitOfWork
    {

        #region Instance Properties
        IConceptRepository Concepts { get; }
        IConceptModelRepository ConceptModels { get; }
        IConceptPropertyFamilyRepository ConceptPropertyFamilies { get; }
        IConceptRefRepository ConceptRefs { get; }
        IConceptSubTypeRepository ConceptSubTypes { get; }
        IConceptSubTypePropertyFamilyRefRepository ConceptSubTypePropertyFamilyRefs { get; }
        IConceptUniqueKeyRepository ConceptUniqueKeys { get; }
        IConceptUniqueKeyPropertyFamilyRefRepository ConceptUniqueKeyPropertyFamilyRefs { get; }
        IDataTypeRepository DataTypes { get; }
        IEnumerationRepository Enumerations { get; }
        IEnumerationMemberRepository EnumerationMembers { get; }
        IIncludeRepository Includes { get; }
        IQualifierRepository Qualifiers { get; }
        IConceptModelAggregateRepository ConceptModelAggregates { get; }

        #endregion
    }
}
